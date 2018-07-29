namespace SevenZip.Tests
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    using NUnit.Framework;

    using SevenZip;

    [TestFixture]
    public class MiscellaneousTests : TestBase
    {
        [Test]
        public void CurrentLibraryFeaturesTest()
        {
            var features = SevenZipBase.CurrentLibraryFeatures;

            Assert.IsTrue(features.HasFlag(LibraryFeature.ExtractAll));
            Assert.IsTrue(features.HasFlag(LibraryFeature.CompressAll));
            Assert.IsTrue(features.HasFlag(LibraryFeature.Modify));
        }

        [Test]
        public void SerializationTest()
        {
            var ex = new ArgumentException("blahblah");
            var bf = new BinaryFormatter();

            using (var ms = new MemoryStream())
            {
                using (var fileStream = File.Create(TemporaryFile))
                {
                    bf.Serialize(ms, ex);
                    SevenZipCompressor cmpr = new SevenZipCompressor();
                    cmpr.CompressStream(ms, fileStream);
                }
            }
        }

        [Test]
        public void CreateSfxArchiveTest()
        {
            Assert.Ignore("Legacy bug, needs investigation.");

            var sfxFile = Path.Combine(OutputDirectory, "sfx.exe");

            var sfx = new SevenZipSfx();
            var compressor = new SevenZipCompressor();

            using (var ms = new MemoryStream())
            {
                compressor.CompressFiles(ms, @"TestData\zip.zip");
                sfx.MakeSfx(ms, sfxFile);
            }

            Assert.IsTrue(File.Exists(sfxFile));

            using (var extractor = new SevenZipExtractor(sfxFile))
            {
                Assert.AreEqual(1, extractor.FilesCount);
                Assert.AreEqual("zip.zip", extractor.ArchiveFileNames[0]);
            }

            Assert.DoesNotThrow(() =>
            {
                var process = Process.Start(sfxFile);
                process?.Kill();
            });
        }

        [Test]
        public void LzmaEncodeDecodeTest()
        {
            using (var output = new FileStream(TemporaryFile, FileMode.Create))
            {
                var encoder = new LzmaEncodeStream(output);
                using (var inputSample = new FileStream(@"TestData\zip.zip", FileMode.Open))
                {
                    int bufSize = 24576, count;
                    var buf = new byte[bufSize];

                    while ((count = inputSample.Read(buf, 0, bufSize)) > 0)
                    {
                        encoder.Write(buf, 0, count);
                    }
                }

                encoder.Close();
            }

            var newZip = Path.Combine(OutputDirectory, "new.zip");

            using (var input = new FileStream(TemporaryFile, FileMode.Open))
            {
                var decoder = new LzmaDecodeStream(input);
                using (var output = new FileStream(newZip, FileMode.Create))
                {
                    int bufSize = 24576, count;
                    var buf = new byte[bufSize];

                    while ((count = decoder.Read(buf, 0, bufSize)) > 0)
                    {
                        output.Write(buf, 0, count);
                    }
                }
            }

            Assert.IsTrue(File.Exists(newZip));

            using (var extractor = new SevenZipExtractor(newZip))
            {
                Assert.AreEqual(1, extractor.FilesCount);
                Assert.AreEqual("zip.txt", extractor.ArchiveFileNames[0]);
            }
        }
    }
}
