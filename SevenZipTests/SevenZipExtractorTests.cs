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
        }

        [Test]
        public void ExtractFilesTest()
        {
            Directory.CreateDirectory(OutputDirectory);

            using (var tmp = new SevenZipExtractor(@"TestData\7z_LZMA2.7z"))
            {
                for (var i = 0; i < tmp.ArchiveFileData.Count; i++)
                {
                    tmp.ExtractFiles(@"output\", tmp.ArchiveFileData[i].Index);
                }

                Assert.AreEqual(1, Directory.GetFiles("output").Length);

                // To extract more than 1 file at a time or when you definitely know which files to extract,
                // use something like
                //tmp.ExtractFiles(@"d:\Temp\Result", 1, 3, 5);
            }

            Directory.Delete(OutputDirectory, true);
        }

        [Test]
        public void ExtractArchiveMultiVolumesTest()
        {
            Assert.Ignore("No test written.");
            //SevenZipExtractor.SetLibraryPath(@"d:\Work\Misc\7zip\9.04\CPP\7zip\Bundles\Format7zF\7z.dll");
            /*using (var tmp = new SevenZipExtractor(@"d:\Temp\The_Name_of_the_Wind.part1.rar"))
            {                
                tmp.ExtractArchive(@"d:\Temp\!Пусто");
            }
            //*/
        }
    }
}
