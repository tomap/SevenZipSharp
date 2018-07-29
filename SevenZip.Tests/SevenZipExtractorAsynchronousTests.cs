namespace SevenZip.Tests
{
    using System.IO;
    using System.Threading;

    using NUnit.Framework;

    [TestFixture]
    public class SevenZipExtractorAsynchronousTests : TestBase
    {
        [Test]
        public void AsynchronousExtractArchiveEventsTest()
        {
            var extractingEventInvoked = false;
            var extractionFinishedEventInvoked = false;

            using (var extractor = new SevenZipExtractor(@"TestData\multiple_files.7z"))
            {
                extractor.EventSynchronization = EventSynchronizationStrategy.AlwaysSynchronous;

                extractor.Extracting += (o, e) => extractingEventInvoked = true;
                extractor.ExtractionFinished += (o, e) => extractionFinishedEventInvoked = true;

                extractor.BeginExtractArchive(OutputDirectory);

                var timeToWait = 250;
                while (!extractionFinishedEventInvoked)
                {
                    if (timeToWait <= 0)
                    {
                        break;
                    }

                    Thread.Sleep(25);
                    timeToWait -= 25;
                }
            }

            Assert.IsTrue(extractingEventInvoked);
            Assert.IsTrue(extractionFinishedEventInvoked);
        }

        [Test]
        public void AsynchronousExtractFileEventsTest()
        {
            var extractingEventInvoked = false;
            var extractionFinishedEventInvoked = false;
            var fileExtractionStartedInvoked = false;
            var fileExtractionFinishedInvoked = false;

            var fileStream = File.Create(TemporaryFile);

            using (var extractor = new SevenZipExtractor(@"TestData\multiple_files.7z"))
            {
                extractor.EventSynchronization = EventSynchronizationStrategy.AlwaysSynchronous;

                extractor.FileExtractionStarted += (o, e) => fileExtractionStartedInvoked = true;
                extractor.FileExtractionFinished += (o, e) => fileExtractionFinishedInvoked = true;
                extractor.Extracting += (o, e) => extractingEventInvoked = true;
                extractor.ExtractionFinished += (o, e) => extractionFinishedEventInvoked = true;

                extractor.BeginExtractFile(0, fileStream);

                var timeToWait = 250;
                while (!extractionFinishedEventInvoked)
                {
                    if (timeToWait <= 0)
                    {
                        break;
                    }

                    Thread.Sleep(25);
                    timeToWait -= 25;
                }

                fileStream.Dispose();
            }

            Assert.IsTrue(extractingEventInvoked);
            Assert.IsTrue(extractionFinishedEventInvoked);
            Assert.IsTrue(fileExtractionStartedInvoked);
            Assert.IsTrue(fileExtractionFinishedInvoked);

            Assert.AreEqual("file1", File.ReadAllText(TemporaryFile));
        }

        [Test]
        public void AsynchronousExtractFilesEventsTest()
        {
            var extractingEventInvoked = false;
            var extractionFinishedEventInvoked = false;
            var fileExtractionStartedInvoked = false;
            var fileExtractionFinishedInvoked = false;

            using (var extractor = new SevenZipExtractor(@"TestData\multiple_files.7z"))
            {
                extractor.EventSynchronization = EventSynchronizationStrategy.AlwaysSynchronous;

                extractor.FileExtractionStarted += (o, e) => fileExtractionStartedInvoked = true;
                extractor.FileExtractionFinished += (o, e) => fileExtractionFinishedInvoked = true;
                extractor.Extracting += (o, e) => extractingEventInvoked = true;
                extractor.ExtractionFinished += (o, e) => extractionFinishedEventInvoked = true;

                extractor.BeginExtractFiles(OutputDirectory, new [] { 0, 2 });

                var timeToWait = 250;
                while (!extractionFinishedEventInvoked)
                {
                    if (timeToWait <= 0)
                    {
                        break;
                    }

                    Thread.Sleep(25);
                    timeToWait -= 25;
                }
            }

            Assert.IsTrue(extractingEventInvoked);
            Assert.IsTrue(extractionFinishedEventInvoked);
            Assert.IsTrue(fileExtractionStartedInvoked);
            Assert.IsTrue(fileExtractionFinishedInvoked);

            Assert.AreEqual(2, Directory.GetFiles(OutputDirectory).Length);
        }
    }
}
