using System;

namespace SevenZipTests
{
    using System.IO;

    using SevenZip;

    using NUnit.Framework;

    [TestFixture]
    public class SevenZipExtractorTests
    {
        private const string OutputDirectory = "output";

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
        public void ExtractFilesTest()
        {
            using (var tmp = new SevenZipExtractor(@"TestData\multiple_files.7z"))
            {
                for (var i = 0; i < tmp.ArchiveFileData.Count; i++)
                {
                    tmp.ExtractFiles(OutputDirectory, tmp.ArchiveFileData[i].Index);
                }

                Assert.AreEqual(3, Directory.GetFiles(OutputDirectory).Length);
            }
        }

        [Test]
        public void ExtractSpecificFilesTest()
        {
            using (var tmp = new SevenZipExtractor(@"TestData\multiple_files.7z"))
            {
                tmp.ExtractFiles(OutputDirectory, 0, 2);
                Assert.AreEqual(2, Directory.GetFiles("output").Length);
            }

            Assert.AreEqual(2, Directory.GetFiles(OutputDirectory).Length);
            Assert.Contains(Path.Combine(OutputDirectory, "file1.txt"), Directory.GetFiles(OutputDirectory));
            Assert.Contains(Path.Combine(OutputDirectory, "file3.txt"), Directory.GetFiles(OutputDirectory));
        }

        [Test]
        public void ExtractArchiveMultiVolumesTest()
        {
            using (var tmp = new SevenZipExtractor(@"TestData\multivolume.part0001.rar"))
            {                
                tmp.ExtractArchive(OutputDirectory);
            }

            Assert.AreEqual(1, Directory.GetFiles(OutputDirectory).Length);
            Assert.IsTrue(File.ReadAllText(Directory.GetFiles(OutputDirectory)[0]).StartsWith("Lorem ipsum dolor sit amet"));
        }
    }
}
