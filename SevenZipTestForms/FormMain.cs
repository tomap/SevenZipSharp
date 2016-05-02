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
using System.Windows.Forms;
using SevenZip;
using System.IO;
using System.Threading;

namespace SevenZipTestForms
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            cb_Format.Items.AddRange(Enum.GetNames(typeof(OutArchiveFormat)));
            cb_Method.Items.AddRange(Enum.GetNames(typeof(CompressionMethod)));
            cb_Format.SelectedIndex = (int)OutArchiveFormat.SevenZip;
            cb_Method.SelectedIndex = (int)CompressionMethod.Default;
            tb_CompressDirectory.Text = @"D:\Temp\!Пусто";
            tb_CompressOutput.Text = @"D:\Temp\arch.7z";
            tb_ExtractDirectory.Text = @"D:\Temp\!Пусто";
            tb_ExtractArchive.Text = @"D:\Temp\7z465_extra.7z";
            trb_Level.Maximum = Enum.GetNames(typeof(CompressionLevel)).Length - 1;
            trb_Level.Value = (int)CompressionLevel.Normal;
            trb_Level_Scroll(this, EventArgs.Empty);
        }        

        private void b_Compress_Click(object sender, EventArgs e)
        {
            SevenZipCompressor.SetLibraryPath(@"C:\Program Files\7-Zip\7z.dll");
            SevenZipCompressor cmp = new SevenZipCompressor();
            cmp.Compressing += new EventHandler<ProgressEventArgs>(cmp_Compressing);
            cmp.FileCompressionStarted += new EventHandler<FileNameEventArgs>(cmp_FileCompressionStarted);
            cmp.CompressionFinished += new EventHandler<EventArgs>(cmp_CompressionFinished);
            cmp.ArchiveFormat = (OutArchiveFormat)Enum.Parse(typeof(OutArchiveFormat), cb_Format.Text);
            cmp.CompressionLevel = (CompressionLevel)trb_Level.Value;
            cmp.CompressionMethod = (CompressionMethod)cb_Method.SelectedIndex;
            cmp.VolumeSize = chb_Volumes.Checked ? (int)nup_VolumeSize.Value : 0;
            string directory = tb_CompressDirectory.Text;
            string archFileName = tb_CompressOutput.Text;
            bool sfxMode = chb_Sfx.Checked;
            if (!sfxMode)
            {
                cmp.BeginCompressDirectory(directory, archFileName);
            }
            else
            {
                // Build SevenZipSharp with SFX
                /*SevenZipSfx sfx = new SevenZipSfx();
                using (MemoryStream ms = new MemoryStream())
                {
                    cmp.CompressDirectory(directory, ms);
                    sfx.MakeSfx(ms, archFileName.Substring(0, archFileName.LastIndexOf('.')) + ".exe");
                }*/
            }           
        }

        void cmp_Compressing(object sender, ProgressEventArgs e)
        {
            pb_CompressProgress.Increment(e.PercentDelta);
        }

        void cmp_FileCompressionStarted(object sender, FileNameEventArgs e)
        {
            l_CompressProgress.Text = String.Format("Compressing \"{0}\"", e.FileName);
        }

        void cmp_CompressionFinished(object sender, EventArgs e)
        {
            l_CompressProgress.Text = "Finished";
            pb_CompressWork.Style = ProgressBarStyle.Blocks;
            pb_CompressProgress.Value = 0;
        }

        private void b_Browse_Click(object sender, EventArgs e)
        {
            if (fbd_Directory.ShowDialog() == DialogResult.OK)
            {
                tb_CompressDirectory.Text = fbd_Directory.SelectedPath;
            }
        }

        private void trb_Level_Scroll(object sender, EventArgs e)
        {
            l_CompressionLevel.Text = String.Format("Compression level: {0}", (CompressionLevel)trb_Level.Value);
        }

        private void b_BrowseOut_Click(object sender, EventArgs e)
        {
            if (sfd_Archive.ShowDialog() == DialogResult.OK)
            {
                tb_CompressOutput.Text = sfd_Archive.FileName;
            }
        }

        void extr_ExtractionFinished(object sender, EventArgs e)
        {
            pb_ExtractWork.Style = ProgressBarStyle.Blocks;
            pb_ExtractProgress.Value = 0;
            pb_ExtractWork.Value = 0;
            l_ExtractProgress.Text = "Finished";
            (sender as SevenZipExtractor).Dispose();
        }

        void extr_FileExists(object sender, FileOverwriteEventArgs e)
        {
            tb_Messages.Text += String.Format("Warning: \"{0}\" already exists; overwritten\r\n", e.FileName);
        }

        void extr_FileExtractionStarted(object sender, FileInfoEventArgs e)
        {
            l_ExtractProgress.Text = String.Format("Extracting \"{0}\"", e.FileInfo.FileName);
            l_ExtractProgress.Refresh();
            pb_ExtractWork.Increment(1);
            pb_ExtractWork.Refresh();
        }

        void extr_Extracting(object sender, ProgressEventArgs e)
        {
            pb_ExtractProgress.Increment(e.PercentDelta);
            pb_ExtractProgress.Refresh();
        }

        private void b_Extract_Click(object sender, EventArgs e)
        {
            SevenZipExtractor.SetLibraryPath(@"C:\Program Files\7-Zip\7z.dll");
            string fileName = tb_ExtractArchive.Text;
            string directory = tb_ExtractDirectory.Text;
            var extr = new SevenZipExtractor(fileName);
            pb_ExtractWork.Maximum = (int)extr.FilesCount;
            extr.Extracting += new EventHandler<ProgressEventArgs>(extr_Extracting);
            extr.FileExtractionStarted += new EventHandler<FileInfoEventArgs>(extr_FileExtractionStarted);
            extr.FileExists += new EventHandler<FileOverwriteEventArgs>(extr_FileExists);
            extr.ExtractionFinished += new EventHandler<EventArgs>(extr_ExtractionFinished);
            extr.BeginExtractArchive(directory);            
        }

        private void b_ExtractBrowseDirectory_Click(object sender, EventArgs e)
        {
            if (fbd_Directory.ShowDialog() == DialogResult.OK)
            {
                tb_ExtractDirectory.Text = fbd_Directory.SelectedPath;
            }
        }

        private void b_ExtractBrowseArchive_Click(object sender, EventArgs e)
        {
            if (ofd_Archive.ShowDialog() == DialogResult.OK)
            {
                tb_ExtractArchive.Text = ofd_Archive.FileName;
                using (SevenZipExtractor extr = new SevenZipExtractor(ofd_Archive.FileName))
                {
                    var lines = new string[extr.ArchiveFileNames.Count];
                    extr.ArchiveFileNames.CopyTo(lines, 0);
                    tb_Messages.Lines = lines;
                }
            }
        }
    }
}
