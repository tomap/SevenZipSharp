namespace SevenZipTests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using SevenZip;

    using NUnit.Framework;

    [TestFixture]
    public class SevenZipCompressorTests
    {
        private const string OutputDirectory = "output";
        private readonly string _temporaryFile = Path.Combine(OutputDirectory, "tmp.7z");

        [SetUp]
        public void SetUp()
        {
            // Ensures we're in the correct working directory (for test data files).
            Directory.SetCurrentDirectory(TestContext.CurrentContext.TestDirectory);
            Directory.CreateDirectory(OutputDirectory);
        }

        [TearDown]
        public void TearDown()
        {
            Directory.Delete(OutputDirectory, true);
        }

        [Test]
        public void CompressFileTest()
        {
            var compressor = new SevenZipCompressor
            {
                ArchiveFormat = OutArchiveFormat.SevenZip,
                DirectoryStructure = false
            };

            compressor.CompressFiles(_temporaryFile, @"Testdata\7z_LZMA2.7z");
            Assert.IsTrue(File.Exists(_temporaryFile));

            using (var extractor = new SevenZipExtractor(_temporaryFile))
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

            compressor.CompressDirectory("TestData", _temporaryFile);
            Assert.IsTrue(File.Exists(_temporaryFile));

            using (var extractor = new SevenZipExtractor(_temporaryFile))
            {
                extractor.ExtractArchive(OutputDirectory);
            }

            File.Delete(_temporaryFile);

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

            compressor.CompressFiles(_temporaryFile, @"Testdata\7z_LZMA2.7z");
            Assert.IsTrue(File.Exists(_temporaryFile));

            using (var extractor = new SevenZipExtractor(_temporaryFile))
            {
                Assert.AreEqual(1, extractor.FilesCount);
            }

            compressor.CompressionMode = CompressionMode.Append;

            compressor.CompressFiles(_temporaryFile, @"TestData\zip.zip");

            using (var extractor = new SevenZipExtractor(_temporaryFile))
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

            compressor.CompressFiles(_temporaryFile, @"Testdata\7z_LZMA2.7z");
            Assert.IsTrue(File.Exists(_temporaryFile));

            compressor.ModifyArchive(_temporaryFile, new Dictionary<int, string> { { 0, "renamed.7z" }});

            using (var extractor = new SevenZipExtractor(_temporaryFile))
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

            compressor.CompressFiles(_temporaryFile, @"Testdata\7z_LZMA2.7z");
            Assert.IsTrue(File.Exists(_temporaryFile));

            compressor.ModifyArchive(_temporaryFile, new Dictionary<int, string> { { 0, null } });

            using (var extractor = new SevenZipExtractor(_temporaryFile))
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

            compressor.CompressFiles(_temporaryFile, @"Testdata\7z_LZMA2.7z");

            Assert.AreEqual(3, Directory.GetFiles(OutputDirectory).Length);
            Assert.IsTrue(File.Exists($"{_temporaryFile}.003"));
        }
    }
}
