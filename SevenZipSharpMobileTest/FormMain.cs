using System;
using System.IO;
using System.Windows.Forms;

namespace SevenZipSharpMobileTest
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void menuItem1_Click(object sender, System.EventArgs e)
        {          
            var fileName = Path.GetDirectoryName(
            System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) +
            "\\gpl.7z";
            tb_Log.Text += "File name is \"" + fileName + "\"" + Environment.NewLine;
            using (var extr = new SevenZip.SevenZipExtractor(fileName))
            {
                tb_Log.Text += "The archive was successfully identified. Ready to extract" + Environment.NewLine;
                extr.ExtractArchive(Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase));
                tb_Log.Text += "Extracted successfully!" + Environment.NewLine;
            }
            tb_Log.Text += "Performing an internal benchmark..." + Environment.NewLine;
            var features = SevenZip.SevenZipExtractor.CurrentLibraryFeatures;
            tb_Log.Text += "Finished. The score is " + ((uint)features).ToString("X6") + Environment.NewLine;
        }
    }
}