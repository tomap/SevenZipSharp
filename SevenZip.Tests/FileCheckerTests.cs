namespace SevenZip.Tests
{
    using System.Collections.Generic;
    using System.IO;

    using SevenZip;

    using NUnit.Framework;

    /// <summary>
    /// Test data to use for CheckFileSignatureTest.
    /// </summary>
    public struct FileCheckerTestData
    {
        public FileCheckerTestData(string testDataFilePath, InArchiveFormat expectedFormat)
        {
            TestDataFilePath = testDataFilePath;
            ExpectedFormat = expectedFormat;
        }

        /// <summary>
        /// Format this test expects to find.
        /// </summary>
        public InArchiveFormat ExpectedFormat { get; }

        /// <summary>
        /// Path to archive file to test against.
        /// </summary>
        public string TestDataFilePath { get; }
        
        public override string ToString()
        {
            // Used to get useful test results.
            return ExpectedFormat.ToString();
        }
    }

    [TestFixture]
    public class FileCheckerTests
    {
        /// <summary>
        /// Test data for CheckFileSignature test.
        /// </summary>
        public static List<FileCheckerTestData> TestData = new List<FileCheckerTestData>
        {
            new FileCheckerTestData(@"TestData\arj.arj", InArchiveFormat.Arj),
            new FileCheckerTestData(@"TestData\bzip2.bz2", InArchiveFormat.BZip2),
            new FileCheckerTestData(@"TestData\", InArchiveFormat.Cab),
            new FileCheckerTestData(@"TestData\", InArchiveFormat.Chm),
            new FileCheckerTestData(@"TestData\", InArchiveFormat.Compound),
            new FileCheckerTestData(@"TestData\", InArchiveFormat.Cpio),
            new FileCheckerTestData(@"TestData\", InArchiveFormat.Deb),
            new FileCheckerTestData(@"TestData\", InArchiveFormat.Dmg),
            new FileCheckerTestData(@"TestData\", InArchiveFormat.Elf),
            new FileCheckerTestData(@"TestData\", InArchiveFormat.Flv),
            new FileCheckerTestData(@"TestData\gzip.gz", InArchiveFormat.GZip),
            new FileCheckerTestData(@"TestData\", InArchiveFormat.Hfs),
            new FileCheckerTestData(@"TestData\", InArchiveFormat.Iso),
            new FileCheckerTestData(@"TestData\", InArchiveFormat.Lzh),
            new FileCheckerTestData(@"TestData\", InArchiveFormat.Lzma),
            new FileCheckerTestData(@"TestData\", InArchiveFormat.Lzw),
            new FileCheckerTestData(@"TestData\", InArchiveFormat.Msi),
            new FileCheckerTestData(@"TestData\", InArchiveFormat.Mslz),
            new FileCheckerTestData(@"TestData\", InArchiveFormat.Mub),
            new FileCheckerTestData(@"TestData\", InArchiveFormat.Nsis),
            new FileCheckerTestData(@"TestData\", InArchiveFormat.PE),
            new FileCheckerTestData(@"TestData\rar5.rar", InArchiveFormat.Rar),
            new FileCheckerTestData(@"TestData\rar4.rar", InArchiveFormat.Rar4),
            new FileCheckerTestData(@"TestData\", InArchiveFormat.Rpm),
            new FileCheckerTestData(@"TestData\7z_LZMA2.7z", InArchiveFormat.SevenZip),
            new FileCheckerTestData(@"TestData\", InArchiveFormat.Split),
            new FileCheckerTestData(@"TestData\", InArchiveFormat.Swf),
            new FileCheckerTestData(@"TestData\tar.tar", InArchiveFormat.Tar),
            new FileCheckerTestData(@"TestData\", InArchiveFormat.Udf),
            new FileCheckerTestData(@"TestData\", InArchiveFormat.Vhd),
            new FileCheckerTestData(@"TestData\wim.wim", InArchiveFormat.Wim),
            new FileCheckerTestData(@"TestData\xz.xz", InArchiveFormat.XZ),
            new FileCheckerTestData(@"TestData\", InArchiveFormat.Xar),
            new FileCheckerTestData(@"TestData\zip.zip", InArchiveFormat.Zip)
        };

        [SetUp]
        public void SetUp()
        {
            // Ensures we're in the correct working directory (for test data files).
            Directory.SetCurrentDirectory(TestContext.CurrentContext.TestDirectory);
        }
        
        [TestCaseSource(nameof(TestData))]
        public void CheckFileSignatureTest(FileCheckerTestData data)
        {
            if (!File.Exists(data.TestDataFilePath))
            {
                Assert.Ignore("No test data found for this format.");
            }
            else
            {
                int ignored;
                bool ignored2;
                Assert.AreEqual(data.ExpectedFormat, FileChecker.CheckSignature(data.TestDataFilePath, out ignored, out ignored2));
            }
        }
    }
}
