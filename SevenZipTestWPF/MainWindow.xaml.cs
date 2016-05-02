using System;
using System.IO;
using System.Windows;
using CP.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using SevenZip;
using System.Threading;

namespace SevenZipTestWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void b_Folder_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new ShellFolderBrowser();
            dialog.BrowseFlags |= BrowseFlags.NewDialogStyle;
            dialog.Title = "Select the output folder where to extract files";
            if (dialog.ShowDialog())
            {
                tb_ExtractFolder.Text = dialog.FolderPath;
            }
        }

        private void b_Archive_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog();
            dialog.Title = "Select the archive file";
            if (dialog.ShowDialog() == CommonFileDialogResult.OK)
            {
                tb_ExtractArchive.Text = dialog.FileName;
                tb_Messages.Text = "";
                using (var extr = new SevenZipExtractor(dialog.FileName))
                {
                    pb_Extract2.Maximum = extr.ArchiveFileData.Count;
                    tb_Messages.BeginChange();
                    foreach (var item in extr.ArchiveFileData)
                    {
                        tb_Messages.Text += string.Format("{0} [{1}]" + Environment.NewLine, item.FileName, item.Size);
                    }
                    tb_Messages.EndChange();
                    tb_Messages.ScrollToEnd();
                }
            }
        }

        private void b_Extract_Click(object sender, RoutedEventArgs e)
        {
            SevenZipExtractor.SetLibraryPath(@"C:\Program Files\7-Zip\7z.dll");
            tb_Messages.Text = "Started" + Environment.NewLine;
            string fileName = tb_ExtractArchive.Text;
            string directory = tb_ExtractFolder.Text;
            var extractor = new SevenZipExtractor(fileName);
            extractor.Extracting += new EventHandler<ProgressEventArgs>(extr_Extracting);
            extractor.FileExtractionStarted += new EventHandler<FileInfoEventArgs>(extr_FileExtractionStarted);
            extractor.FileExists += new EventHandler<FileOverwriteEventArgs>(extr_FileExists);
            extractor.ExtractionFinished += new EventHandler<EventArgs>(extr_ExtractionFinished);
            extractor.BeginExtractArchive(directory);
        }


        void extr_ExtractionFinished(object sender, EventArgs e)
        {
            pb_Extract1.Value = 0;
            pb_Extract2.Value = 0;
            tb_Messages.Text += "Finished!" + Environment.NewLine;
            (sender as SevenZipExtractor).Dispose();
        }

        void extr_FileExists(object sender, FileOverwriteEventArgs e)
        {
            tb_Messages.Text += String.Format(
                    "Warning: \"{0}\" already exists; overwritten" + Environment.NewLine,
                    e.FileName);
        }

        void extr_FileExtractionStarted(object sender, FileInfoEventArgs e)
        {
            tb_Messages.Text += String.Format("Extracting \"{0}\"" + Environment.NewLine, e.FileInfo.FileName);
            tb_Messages.ScrollToEnd();
            pb_Extract2.Value += 1;
        }

        void extr_Extracting(object sender, ProgressEventArgs e)
        {
            pb_Extract1.Value += e.PercentDelta;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cb_Format.ItemsSource = Enum.GetNames(typeof(OutArchiveFormat));            
            cb_Format.SelectedIndex = (int)OutArchiveFormat.SevenZip;
        }

        private void b_Compress_Click(object sender, RoutedEventArgs e)
        {
            SevenZipCompressor.SetLibraryPath(@"C:\Program Files\7-Zip\7z.dll");
            SevenZipCompressor cmp = new SevenZipCompressor();
            cmp.Compressing += new EventHandler<ProgressEventArgs>(cmp_Compressing);
            cmp.FileCompressionStarted += new EventHandler<FileNameEventArgs>(cmp_FileCompressionStarted);
            cmp.CompressionFinished += new EventHandler<EventArgs>(cmp_CompressionFinished);
            cmp.ArchiveFormat = (OutArchiveFormat)Enum.Parse(typeof(OutArchiveFormat), cb_Format.Text);
            cmp.CompressionLevel = (CompressionLevel)slider_Level.Value;
            string directory = tb_CompressFolder.Text;
            string archFileName = tb_CompressArchive.Text;
            cmp.BeginCompressDirectory(directory, archFileName);  
        }

        void cmp_Compressing(object sender, ProgressEventArgs e)
        {
            pb_Compress.Value += (e.PercentDelta);
        }

        void cmp_FileCompressionStarted(object sender, FileNameEventArgs e)
        {
            l_CompressStatus.Content = String.Format("Compressing \"{0}\"", e.FileName);
        }

        void cmp_CompressionFinished(object sender, EventArgs e)
        {
            l_CompressStatus.Content = "Finished";
            pb_Compress.Value = 0;
        }

        private void b_CompressFolder_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new ShellFolderBrowser();
            dialog.BrowseFlags |= BrowseFlags.NewDialogStyle;
            dialog.Title = "Select the folder to compress";
            if (dialog.ShowDialog())
            {
                tb_CompressFolder.Text = dialog.FolderPath;
            }
        }

        private void b_CompressArchive_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonSaveFileDialog();
            dialog.Title = "Select where to save the archive";
            if (dialog.ShowDialog() == CommonFileDialogResult.OK)
            {
                tb_CompressArchive.Text = dialog.FileName;
            }
        }


    }
}
