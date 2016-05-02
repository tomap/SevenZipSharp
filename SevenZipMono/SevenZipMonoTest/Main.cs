using System;
using SevenZip;

namespace SevenZipMonoTest
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var features = SevenZipExtractor.CurrentLibraryFeatures;
            Console.WriteLine(((uint)features).ToString("X6"));
		}
	}
}