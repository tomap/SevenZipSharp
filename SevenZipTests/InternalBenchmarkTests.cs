namespace SevenZipTests
{
    using System;

    using NUnit.Framework;

    using SevenZip;

    [TestFixture]
    public class InternalBenchmarkTests
    {
        [Test]
        public void CurrentLibraryFeaturesTest()
        {
            Assert.Ignore("Not sure CurrentLibraryFeatures actually work as intended.");

            var features = SevenZip.SevenZipExtractor.CurrentLibraryFeatures;
            Console.WriteLine(features);
            Assert.AreEqual(LibraryFeature.ExtractAll, features);
            Assert.AreEqual(LibraryFeature.CompressAll, features);
        }
    }
}
