namespace SevenZip.Tests
{
    using System.IO;

    using NUnit.Framework;

    public abstract class TestBase
    {
        protected const string OutputDirectory = "output";
        protected readonly string TemporaryFile = Path.Combine(OutputDirectory, "tmp.7z");

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
    }
}
