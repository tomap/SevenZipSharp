namespace SevenZipTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;

    using SevenZip;

    using NUnit.Framework;

    [TestFixture]
    public class SevenZipCompressorTests : TestBase
    {
        /// <summary>
        /// TestCaseSource for CompressDifferentFormatsTest
        /// </summary>
        public static List<CompressionMethod> CompressionMethods
        {
            get
            {
                var result = new List<CompressionMethod>();
                foreach(CompressionMethod format in Enum.GetValues(typeof(CompressionMethod)))
                {
                    result.Add(format);
                }

                return result;
            }
        }

        [Test]
        public void CompressFileTest()
        {
            var compressor = new SevenZipCompressor
            {
                ArchiveFormat = OutArchiveFormat.SevenZip,
                DirectoryStructure = false
            };

            compressor.CompressFiles(TemporaryFile, @"Testdata\7z_LZMA2.7z");
            Assert.IsTrue(File.Exists(TemporaryFile));

            using (var extractor = new SevenZipExtractor(TemporaryFile))
            {
                extractor.ExtractArchive(OutputDirectory);
            }

            Assert.IsTrue(File.Exists(Path.Combine(OutputDirectory, "7z_LZMA2.7z")));
        }

        [Test]
        public void CompressDirectoryTest()
        {
            var compressor = new SevenZipCompressor
            {
                ArchiveFormat = OutArchiveFormat.SevenZip,
                DirectoryStructure = false
            };

            compressor.CompressDirectory("TestData", TemporaryFile);
            Assert.IsTrue(File.Exists(TemporaryFile));

            using (var extractor = new SevenZipExtractor(TemporaryFile))
            {
                extractor.ExtractArchive(OutputDirectory);
            }

            File.Delete(TemporaryFile);

            Assert.AreEqual(Directory.GetFiles("TestData").Select(Path.GetFileName).ToArray(), Directory.GetFiles(OutputDirectory).Select(Path.GetFileName).ToArray());
        }

        [Test]
        public void CompressWithAppendModeTest()
        {
            var compressor = new SevenZipCompressor
            {
                ArchiveFormat = OutArchiveFormat.SevenZip,
                DirectoryStructure = false
            };

            compressor.CompressFiles(TemporaryFile, @"Testdata\7z_LZMA2.7z");
            Assert.IsTrue(File.Exists(TemporaryFile));

            using (var extractor = new SevenZipExtractor(TemporaryFile))
            {
                Assert.AreEqual(1, extractor.FilesCount);
            }

            compressor.CompressionMode = CompressionMode.Append;

            compressor.CompressFiles(TemporaryFile, @"TestData\zip.zip");

            using (var extractor = new SevenZipExtractor(TemporaryFile))
            {
                Assert.AreEqual(2, extractor.FilesCount);
            }
        }

        [Test]
        public void CompressWithModifyModeRenameTest()
        {
            var compressor = new SevenZipCompressor
            {
                ArchiveFormat = OutArchiveFormat.SevenZip,
                DirectoryStructure = false
            };

            compressor.CompressFiles(TemporaryFile, @"Testdata\7z_LZMA2.7z");
            Assert.IsTrue(File.Exists(TemporaryFile));

            compressor.ModifyArchive(TemporaryFile, new Dictionary<int, string> { { 0, "renamed.7z" }});

            using (var extractor = new SevenZipExtractor(TemporaryFile))
            {
                Assert.AreEqual(1, extractor.FilesCount);
                extractor.ExtractArchive(OutputDirectory);
            }

            Assert.IsTrue(File.Exists(Path.Combine(OutputDirectory, "renamed.7z")));
            Assert.IsFalse(File.Exists(Path.Combine(OutputDirectory, "7z_LZMA2.7z")));
        }

        [Test]
        public void CompressWithModifyModeDeleteTest()
        {
            var compressor = new SevenZipCompressor
            {
                ArchiveFormat = OutArchiveFormat.SevenZip,
                DirectoryStructure = false
            };

            compressor.CompressFiles(TemporaryFile, @"Testdata\7z_LZMA2.7z");
            Assert.IsTrue(File.Exists(TemporaryFile));

            compressor.ModifyArchive(TemporaryFile, new Dictionary<int, string> { { 0, null } });

            using (var extractor = new SevenZipExtractor(TemporaryFile))
            {
                Assert.AreEqual(0, extractor.FilesCount);
                extractor.ExtractArchive(OutputDirectory);
            }

            Assert.IsFalse(File.Exists(Path.Combine(OutputDirectory, "7z_LZMA2.7z")));
        }

        [Test]
        public void MultiVolumeCompressionTest()
        {
            var compressor = new SevenZipCompressor
            {
                ArchiveFormat = OutArchiveFormat.SevenZip,
                DirectoryStructure = false,
                VolumeSize = 100
            };

            compressor.CompressFiles(TemporaryFile, @"Testdata\7z_LZMA2.7z");

            Assert.AreEqual(3, Directory.GetFiles(OutputDirectory).Length);
            Assert.IsTrue(File.Exists($"{TemporaryFile}.003"));
        }

        [Test]
        public void CompressToStreamTest()
        {
            var compressor = new SevenZipCompressor {DirectoryStructure = false};

            using (var stream = File.Create(TemporaryFile))
            {
                compressor.CompressFiles(stream, @"TestData\zip.zip");
            }
            
            Assert.IsTrue(File.Exists(TemporaryFile));

            using (var extractor = new SevenZipExtractor(TemporaryFile))
            {
                Assert.AreEqual(1, extractor.FilesCount);
                Assert.AreEqual("zip.zip", extractor.ArchiveFileNames[0]);
            }
        }

        [Test]
        public void CompressFromStreamTest()
        {
            using (var input = File.OpenRead(@"TestData\zip.zip"))
            {
                using (var output = File.Create(TemporaryFile))
                {
                    var compressor = new SevenZipCompressor
                    {
                        DirectoryStructure = false
                    };

                    compressor.CompressStream(input, output);
                }
                    
            }

            Assert.IsTrue(File.Exists(TemporaryFile));

            using (var extractor = new SevenZipExtractor(TemporaryFile))
            {
                Assert.AreEqual(1, extractor.FilesCount);
                Assert.AreEqual(new FileInfo(@"TestData\zip.zip").Length, extractor.ArchiveFileData[0].Size);
            }
        }

        [Test]
        public void CompressFileDictionaryTest()
        {
            var compressor = new SevenZipCompressor { DirectoryStructure = false };

            var fileDict = new Dictionary<string, string>
            {
                {"zip.zip", @"TestData\zip.zip"}
            };

            compressor.CompressFileDictionary(fileDict, TemporaryFile);

            Assert.IsTrue(File.Exists(TemporaryFile));

            using (var extractor = new SevenZipExtractor(TemporaryFile))
            {
                Assert.AreEqual(1, extractor.FilesCount);
                Assert.AreEqual("zip.zip", extractor.ArchiveFileNames[0]);
            }
        }

        public void ThreadedCompressionTest()
        {
            Assert.Ignore("Not translated yet.");

            var t1 = new Thread(() =>
            {
                var tmp = new SevenZipCompressor();
                tmp.FileCompressionStarted += (s, e) =>
                    Console.WriteLine(String.Format("[{0}%] {1}", e.PercentDone, e.FileName));
                tmp.CompressDirectory(@"D:\Temp\t1", @"D:\Temp\arch1.7z");
            });
            var t2 = new Thread(() =>
            {
                var tmp = new SevenZipCompressor();
                tmp.FileCompressionStarted += (s, e) =>
                    Console.WriteLine(String.Format("[{0}%] {1}", e.PercentDone, e.FileName));
                tmp.CompressDirectory(@"D:\Temp\t2", @"D:\Temp\arch2.7z");
            });

            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
        }

        [Test, TestCaseSource(nameof(CompressionMethods))]
        public void CompressDifferentFormatsTest(CompressionMethod method)
        {
            var compressor = new SevenZipCompressor
            {
                ArchiveFormat = OutArchiveFormat.SevenZip,
                CompressionMethod = method
            };

            compressor.CompressFiles(TemporaryFile, @"TestData\zip.zip");

            Assert.IsTrue(File.Exists(TemporaryFile));
        }
    }
}
