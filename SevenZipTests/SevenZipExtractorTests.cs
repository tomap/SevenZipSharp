namespace SevenZipTests
{
    using SevenZip;

    using NUnit.Framework;

    [TestFixture]
    public class SevenZipExtractorTests
    {
        [Test]
        public void ExtractFilesTest()
        {
            using (var tmp = new SevenZipExtractor(@"d:\Temp\7z465_extra.7z"))
            {
                for (int i = 0; i < tmp.ArchiveFileData.Count; i++)
                {
                    tmp.ExtractFiles(@"d:\Temp\Result\", tmp.ArchiveFileData[i].Index);
                }
                
                // To extract more than 1 file at a time or when you definitely know which files to extract,
                // use something like
                //tmp.ExtractFiles(@"d:\Temp\Result", 1, 3, 5);
            }
        }

        [Test]
        public void ExtractArchiveMultiVolumesTest()
        {
            //SevenZipExtractor.SetLibraryPath(@"d:\Work\Misc\7zip\9.04\CPP\7zip\Bundles\Format7zF\7z.dll");
            /*using (var tmp = new SevenZipExtractor(@"d:\Temp\The_Name_of_the_Wind.part1.rar"))
            {                
                tmp.ExtractArchive(@"d:\Temp\!Пусто");
            }
            //*/
        }
    }
}
