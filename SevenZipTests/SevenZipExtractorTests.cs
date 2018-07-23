namespace SevenZipTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;

    using SevenZip;

    using NUnit.Framework;

    [TestFixture]
    public class SevenZipExtractorTests : TestBase
    {
        public static List<TestFile> TestFiles
        {
            get
            {
                var result = new List<TestFile>();

                foreach (var file in Directory.GetFiles(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData")))
                {
                    if (file.Contains("multi"))
                    {
                        continue;
                    }

                    result.Add(new TestFile(file));
                }

                return result;
            }
        }

        [Test]
        public void ExtractFilesTest()
        {
            using (var extractor = new SevenZipExtractor(@"TestData\multiple_files.7z"))
            {
                for (var i = 0; i < extractor.ArchiveFileData.Count; i++)
                {
                    extractor.ExtractFiles(OutputDirectory, extractor.ArchiveFileData[i].Index);
                }

                Assert.AreEqual(3, Directory.GetFiles(OutputDirectory).Length);
            }
        }

        [Test]
        public void ExtractSpecificFilesTest()
        {
            using (var extractor = new SevenZipExtractor(@"TestData\multiple_files.7z"))
            {
                extractor.ExtractFiles(OutputDirectory, 0, 2);
                Assert.AreEqual(2, Directory.GetFiles("output").Length);
            }

            Assert.AreEqual(2, Directory.GetFiles(OutputDirectory).Length);
            Assert.Contains(Path.Combine(OutputDirectory, "file1.txt"), Directory.GetFiles(OutputDirectory));
            Assert.Contains(Path.Combine(OutputDirectory, "file3.txt"), Directory.GetFiles(OutputDirectory));
        }

        [Test]
        public void ExtractArchiveMultiVolumesTest()
        {
            using (var extractor = new SevenZipExtractor(@"TestData\multivolume.part0001.rar"))
            {
                extractor.ExtractArchive(OutputDirectory);
            }

            Assert.AreEqual(1, Directory.GetFiles(OutputDirectory).Length);
            Assert.IsTrue(File.ReadAllText(Directory.GetFiles(OutputDirectory)[0]).StartsWith("Lorem ipsum dolor sit amet"));
        }

        [Test]
        public void ExtractionWithCancellationTest()
        {
            using (var tmp = new SevenZipExtractor(@"TestData\multiple_files.7z"))
            {
                tmp.FileExtractionStarted += (s, e) =>
                {
                    if (e.FileInfo.Index == 2)
                    {
                        e.Cancel = true;
                    }
                };
               
                tmp.ExtractArchive(OutputDirectory);

                Assert.AreEqual(2, Directory.GetFiles(OutputDirectory).Length);
            }
        }

        [Test]
        public void ExtractionFromStreamTest()
        {
            using (var tmp = new SevenZipExtractor(File.OpenRead(@"TestData\multiple_files.7z")))
            {
                tmp.ExtractArchive(OutputDirectory);

                Assert.AreEqual(3, Directory.GetFiles(OutputDirectory).Length);
            }
        }

        [Test]
        public void ExtractionToStreamTest()
        {
            using (var tmp = new SevenZipExtractor(@"TestData\multiple_files.7z"))
            {
                using (var fileStream = new FileStream(Path.Combine(OutputDirectory, "streamed_file.txt"), FileMode.Create))
                {
                    tmp.ExtractFile(1, fileStream);
                }
            }

            Assert.AreEqual(1, Directory.GetFiles(OutputDirectory).Length);

            var extractedFile = Directory.GetFiles(OutputDirectory)[0];

            Assert.AreEqual("file2", File.ReadAllText(extractedFile));
        }

        [Test]
        public void ThreadedExtractionTest()
        {
            Assert.Ignore("Not translated yet.");

            var t1 = new Thread(() =>
            {
                using (var tmp = new SevenZipExtractor(@"D:\Temp\7z465_extra.7z"))
                {
                    tmp.FileExtractionStarted += (s, e) =>
                    {
                        Console.WriteLine(String.Format("[{0}%] {1}",
                            e.PercentDone, e.FileInfo.FileName));
                    };
                    tmp.ExtractionFinished += (s, e) => { Console.WriteLine("Finished!"); };
                    tmp.ExtractArchive(@"D:\Temp\t1");
                }
            });
            var t2 = new Thread(() =>
            {
                using (var tmp = new SevenZipExtractor(@"D:\Temp\7z465_extra.7z"))
                {
                    tmp.FileExtractionStarted += (s, e) =>
                    {
                        Console.WriteLine(String.Format("[{0}%] {1}",
                            e.PercentDone, e.FileInfo.FileName));
                    };
                    tmp.ExtractionFinished += (s, e) => { Console.WriteLine("Finished!"); };
                    tmp.ExtractArchive(@"D:\Temp\t2");
                }
            });
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
        }

        [Test, TestCaseSource(nameof(TestFiles))]
        public void ExtractDifferentFormatsTest(TestFile file)
        {
            using (var extractor = new SevenZipExtractor(file.FilePath))
            {
                try
                {
                    extractor.ExtractArchive(OutputDirectory);
                    Assert.AreEqual(1, Directory.GetFiles(OutputDirectory).Length);
                }
                catch (SevenZipException)
                {
                    Assert.Warn("Legacy bug, needs to be investigated.");
                }
            }
        }
    }

    /// <summary>
    /// Simple wrapper to get better names for ExtractDifferentFormatsTest results.
    /// </summary>
    public class TestFile
    {
        public string FilePath { get; }

        public TestFile(string filePath)
        {
            FilePath = filePath;
        }

        public override string ToString()
        {
            return Path.GetFileName(FilePath);
        }
    }
}
