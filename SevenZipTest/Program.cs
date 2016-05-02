/*  This file is part of SevenZipSharp.

    SevenZipSharp is free software: you can redistribute it and/or modify
    it under the terms of the GNU Lesser General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    SevenZipSharp is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public License
    along with SevenZipSharp.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;
using SevenZip;
using System.Diagnostics;

namespace SevenZipTest
{
    class Program
    {
        static void Main(string[] args)
        {          
            Console.WriteLine("SevenZipSharp test application.");
            //Console.ReadKey();

            /*
             You may specify the custom path to 7-zip dll at SevenZipLibraryManager.LibraryFileName 
                or call SevenZipExtractor.SetLibraryPath(@"c:\Program Files\7-Zip\7z.dll");
                or call SevenZipCompressor.SetLibraryPath(@"c:\Program Files\7-Zip\7z.dll");
             You may check if your library fits your goals with
                (SevenZipExtractor/Compressor.CurrentLibraryFeatures & LibraryFeature.<name>) != 0
             Internal benchmark:
                var features = SevenZip.SevenZipExtractor.CurrentLibraryFeatures;
                Console.WriteLine(((uint)features).ToString("X6"));
            */

            #region Temporary test
            var features = SevenZip.SevenZipExtractor.CurrentLibraryFeatures;
            Console.WriteLine(((uint)features).ToString("X6"));
            #endregion

            #region Extraction test - ExtractFiles
            /*using (var tmp = new SevenZipExtractor(@"d:\Temp\7z465_extra.7z"))
            {
                for (int i = 0; i < tmp.ArchiveFileData.Count; i++)
                {
                    tmp.ExtractFiles(@"d:\Temp\Result\", tmp.ArchiveFileData[i].Index);
                }
                // To extract more than 1 file at a time or when you definitely know which files to extract,
                // use something like
                //tmp.ExtractFiles(@"d:\Temp\Result", 1, 3, 5);
            }
            //*/
            #endregion

            #region Extraction test - multivolumes
            //SevenZipExtractor.SetLibraryPath(@"d:\Work\Misc\7zip\9.04\CPP\7zip\Bundles\Format7zF\7z.dll");
            /*using (var tmp = new SevenZipExtractor(@"d:\Temp\The_Name_of_the_Wind.part1.rar"))
            {                
                tmp.ExtractArchive(@"d:\Temp\!Пусто");
            }
            //*/
            #endregion

            #region Compression tests - very simple
            /*var tmp = new SevenZipCompressor();
            //tmp.ScanOnlyWritable = true;
            //tmp.CompressFiles(@"d:\Temp\arch.7z", @"d:\Temp\log.txt");
            //tmp.CompressDirectory(@"c:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\1033", @"D:\Temp\arch.7z");
            tmp.CompressDirectory(@"d:\Temp\!Пусто", @"d:\Temp\test.7z");
            //*/
            #endregion
            
            #region Compression test - features Append mode
            /*var tmp = new SevenZipCompressor();
            tmp.CompressionMode = CompressionMode.Append;            
            tmp.CompressDirectory(@"D:\Temp\!Пусто", @"D:\Temp\arch.7z");
            tmp = null;
            //*/
            #endregion

            #region Compression test - features Modify mode
            /*var tmp = new SevenZipCompressor();
            tmp.ModifyArchive(@"d:\Temp\7z465_extra.7z", new Dictionary<int, string>() { { 0, "xxx.bat" } });
            //Delete
            //tmp.ModifyArchive(@"d:\Temp\7z465_extra.7z", new Dictionary<int, string>() { { 19, null }, { 1, null } });
            //*/
            #endregion

            #region Compression test - multivolumes
            /*var tmp = new SevenZipCompressor();
            tmp.VolumeSize = 10000;            
            tmp.CompressDirectory(@"D:\Temp\!Пусто", @"D:\Temp\arch.7z");            
            //*/
            #endregion
            
            #region Extraction test. Shows cancel feature.
            /*using (var tmp = new SevenZipExtractor(@"D:\Temp\test.7z"))
            {
                tmp.FileExtractionStarted += (s, e) =>
                {
                    /*if (e.FileInfo.Index == 10)
                    {
                        e.Cancel = true;
                        Console.WriteLine("Cancelled");
                    }
                    else
                    {//*//*
                        
                       Console.WriteLine(String.Format("[{0}%] {1}",
                           e.PercentDone, e.FileInfo.FileName));
                   //}
               };
               tmp.FileExists += (o, e) =>
               {
                   Console.WriteLine("Warning: file \"" + e.FileName + "\" already exists.");
                   //e.Overwrite = false;
               };
               tmp.ExtractionFinished += (s, e) => { Console.WriteLine("Finished!"); };
               tmp.ExtractArchive(@"D:\Temp\!Пусто");
            }
            //*/
            #endregion

            #region Compression test - shows lots of features 
            /*var tmp = new SevenZipCompressor();
            tmp.ArchiveFormat = OutArchiveFormat.SevenZip;
            tmp.CompressionLevel = CompressionLevel.High;
            tmp.CompressionMethod = CompressionMethod.Ppmd;
            tmp.FileCompressionStarted += (s, e) =>
            {
                /*if (e.PercentDone > 50)
                {
                    e.Cancel = true;
                }
                else
                {
                //*//*
                    Console.WriteLine(String.Format("[{0}%] {1}",
                        e.PercentDone, e.FileName));
                //*//*}
            };
            /*
            tmp.FilesFound += (se, ea) => 
            { 
                Console.WriteLine("Number of files: " + ea.Value.ToString()); 
            };
            //*/
            /*
            tmp.CompressFiles(
                @"d:\Temp\test.bz2", @"c:\log.txt", @"d:\Temp\08022009.jpg");*/
            //tmp.CompressDirectory(@"d:\Temp\!Пусто", @"d:\Temp\arch.7z");
            #endregion

            #region Multi-threaded extraction test
            /*var t1 = new Thread(() =>
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
             //*/
            #endregion

            #region Multi-threaded compression test
            /*var t1 = new Thread(() =>
            {
                var tmp = new SevenZipCompressor();
                tmp.FileCompressionStarted += (s, e) =>
                    Console.WriteLine(String.Format("[{0}%] {1}", e.PercentDone, e.FileName));
                tmp.CompressDirectory(@"D:\Temp\t1", @"D:\Temp\arch1.7z");
            });
            var t2 = new Thread(() =>
            {
                var tmp = new SevenZipCompressor();
                tmp.FileCompressionStarted += (s, e) =>
                    Console.WriteLine(String.Format("[{0}%] {1}", e.PercentDone, e.FileName));
                tmp.CompressDirectory(@"D:\Temp\t2", @"D:\Temp\arch2.7z");
            });           
            t1.Start();
            t2.Start();           
            t1.Join();
            t2.Join();
            //*/
            #endregion

            #region Streaming extraction test
            /*using (var tmp = new SevenZipExtractor(
                File.OpenRead(@"D:\Temp\7z465_extra.7z")))
            {
                tmp.FileExtractionStarted += (s, e) =>
                {
                    Console.WriteLine(String.Format("[{0}%] {1}",
                        e.PercentDone, e.FileInfo.FileName));
                };
                tmp.ExtractionFinished += (s, e) => { Console.WriteLine("Finished!"); };
                tmp.ExtractArchive(@"D:\Temp\!Пусто");
            }//*/
            #endregion

            #region Streaming compression test
            /*var tmp = new SevenZipCompressor();
            tmp.FileCompressionStarted += (s, e) =>
            {
                Console.WriteLine(String.Format("[{0}%] {1}",
                    e.PercentDone, e.FileName));
            };
            tmp.CompressDirectory(@"D:\Temp\1",
                File.Create(@"D:\Temp\arch.bz2"));
            //*/
            #endregion

            #region CompressStream (managed) test
            /*SevenZipCompressor.CompressStream(File.OpenRead(@"D:\Temp\test.txt"), 
                File.Create(@"D:\Temp\test.lzma"), null, (o, e) =>
            {
                if (e.PercentDelta > 0)
                {
                    Console.Clear();
                    Console.WriteLine(e.PercentDone.ToString() + "%");
                }
            });
            //*/
            #endregion

            #region ExtractFile(Stream) test
            /*using (var tmp = new SevenZipExtractor(@"D:\Temp\7z465_extra.7z"))
            {
                tmp.FileExtractionStarted += (s, e) =>
                {
                    Console.WriteLine(String.Format("[{0}%] {1}",
                        e.PercentDone, e.FileInfo.FileName));
                };
                tmp.FileExists += (o, e) =>
                {
                    Console.WriteLine("Warning: file \"" + e.FileName + "\" already exists.");
                    //e.Overwrite = false;
                };
                tmp.ExtractionFinished += n(s, e) => { Console.WriteLine("Finished!"); };
                tmp.ExtractFile(2, File.Create(@"D:\Temp\!Пусто\test.txt"));
            }//*/
            #endregion

            #region ExtractFile(Disk) test
            /*using (var tmp = new SevenZipExtractor(@"D:\Temp\7z465_extra.7z"))
            {
                tmp.FileExtractionStarted += (s, e) =>
                {
                    Console.WriteLine(String.Format("[{0}%] {1}",
                        e.PercentDone, e.FileInfo.FileName));
                };
                tmp.FileExists += (o, e) =>
                {
                    Console.WriteLine("Warning: file \"" + e.FileName + "\" already exists.");
                    //e.Overwrite = false;
                };
                tmp.ExtractionFinished += (s, e) => { Console.WriteLine("Finished!"); };
                tmp.ExtractFile(4, @"D:\Temp\!Пусто");
            }
            //*/
            #endregion            

            #region CompressFiles Zip test
            /*var tmp = new SevenZipCompressor();
            tmp.ArchiveFormat = OutArchiveFormat.Zip;
            tmp.CompressFiles(@"d:\Temp\arch.zip", @"d:\Temp\gpl.txt", @"d:\Temp\ru_office.txt");
            //*/
            #endregion

            #region CompressStream (external) test
            /*var tmp = new SevenZipCompressor();
            tmp.CompressStream(
                File.OpenRead(@"D:\Temp\08022009.jpg"),
                File.Create(@"D:\Temp\arch.7z"));
            //*/
            #endregion

            #region CompressFileDictionary test
            /*var tmp = new SevenZipCompressor();
            Dictionary<string, string> fileDict = new Dictionary<string, string>();
            fileDict.Add("test.ini", @"d:\Temp\temp.ini");
            tmp.FileCompressionStarted += (o, e) =>
            {               
                Console.WriteLine(String.Format("[{0}%] {1}",
                        e.PercentDone, e.FileName));
            };
            tmp.CompressFileDictionary(fileDict, @"d:\Temp\arch.7z");
            //*/
            #endregion

            #region Toughness test - throws no exceptions and no leaks
            /*
            Console.ReadKey();
            string exeAssembly = Assembly.GetAssembly(typeof(SevenZipExtractor)).FullName;
            AppDomain dom = AppDomain.CreateDomain("Extract");
            for (int i = 0; i < 1000; i++)
            {
                using (SevenZipExtractor tmp = 
                    (SevenZipExtractor)dom.CreateInstance(
                    exeAssembly, typeof(SevenZipExtractor).FullName,
                    false, BindingFlags.CreateInstance, null, 
                    new object[] {@"D:\Temp\7z465_extra.7z"}, 
                    System.Globalization.CultureInfo.CurrentCulture, null, null).Unwrap())
                {                    
                    tmp.ExtractArchive(@"D:\Temp\!Пусто");
                }
                Console.Clear();
                Console.WriteLine(i);
            }
            AppDomain.Unload(dom);           
            //No errors, no leaks*/
            #endregion

            #region Serialization demo
            /*ArgumentException ex = new ArgumentException("blahblah");
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, ex);
                SevenZipCompressor cmpr = new SevenZipCompressor();
                cmpr.CompressStream(ms, File.Create(@"d:\Temp\test.7z"));
            }
            //*/
            #endregion

            #region Compress with custom parameters demo
            /*var tmp = new SevenZipCompressor();            
            tmp.ArchiveFormat = OutArchiveFormat.Zip;
            tmp.CompressionMethod = CompressionMethod.Deflate;
            tmp.CompressionLevel = CompressionLevel.Ultra;
            //Number of fast bytes
            tmp.CustomParameters.Add("fb", "256");
            //Number of deflate passes
            tmp.CustomParameters.Add("pass", "4");
            //Multi-threading on
            tmp.CustomParameters.Add("mt", "on");
            tmp.ZipEncryptionMethod = ZipEncryptionMethod.AES256;
            tmp.Compressing += (s, e) =>
            {
                Console.Clear();
                Console.WriteLine(String.Format("{0}%", e.PercentDone));
            };
            tmp.CompressDirectory(@"d:\Temp\!Пусто", @"d:\Temp\arch.zip", "test");
            //*/

            /*SevenZipCompressor tmp = new SevenZipCompressor();
            tmp.CompressionMethod = CompressionMethod.Ppmd;
            tmp.CompressionLevel = CompressionLevel.Ultra;
            tmp.EncryptHeadersSevenZip = true;
            tmp.ScanOnlyWritable = true;
            tmp.CompressDirectory(@"d:\Temp\!Пусто", @"d:\Temp\arch.7z", "test");  
            //*/
            #endregion

            #region Sfx demo
            /*var sfx = new SevenZipSfx();
            SevenZipCompressor tmp = new SevenZipCompressor();
            using (MemoryStream ms = new MemoryStream())
            {
                tmp.CompressDirectory(@"d:\Temp\!Пусто", ms);               
                sfx.MakeSfx(ms, @"d:\Temp\test.exe");
            }
            //*/
            #endregion

            #region Lzma Encode/Decode Stream test
            /*using (var output = new FileStream(@"d:\Temp\arch.lzma", FileMode.Create))
            {
                var encoder = new LzmaEncodeStream(output);
                using (var inputSample = new FileStream(@"d:\Temp\tolstoi_lev_voina_i_mir_kniga_1.rtf", FileMode.Open))
                {
                    int bufSize = 24576, count;
                    byte[] buf = new byte[bufSize];
                    while ((count = inputSample.Read(buf, 0, bufSize)) > 0)
                    {
                        encoder.Write(buf, 0, count);
                    }
                }
                encoder.Close();
            }//*/
            /*using (var input = new FileStream(@"d:\Temp\arch.lzma", FileMode.Open))
            {
                var decoder = new LzmaDecodeStream(input);
                using (var output = new FileStream(@"d:\Temp\res.rtf", FileMode.Create))
                {
                    int bufSize = 24576, count;
                    byte[] buf = new byte[bufSize];
                    while ((count = decoder.Read(buf, 0, bufSize)) > 0)
                    {
                        output.Write(buf, 0, count);
                    }
                }
            }//*/
            #endregion

            Console.WriteLine("Press any key to finish.");
            Console.ReadKey();
        }
    }    
}
