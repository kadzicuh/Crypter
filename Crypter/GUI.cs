using Crypter.Utils;
using System;
using System.IO;
using System.Windows.Forms;

namespace Crypter
{
    public partial class GUI : Form
    {
        public GUI()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog _Open_File_Dialog = new OpenFileDialog())
            {
                _Open_File_Dialog.Filter = "Executable (*.exe)|*.exe";
                _Open_File_Dialog.ShowDialog();

                TextBox1.Text = _Open_File_Dialog.FileName;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog _Save_File_Dialog = new SaveFileDialog())
            {
                _Save_File_Dialog.Filter = "Executable (*.exe)|*.exe";
                _Save_File_Dialog.ShowDialog();

                File.WriteAllBytes("TempFile", new Encryption().AES(File.ReadAllBytes(TextBox1.Text), "#PASSWORD"));

                new Compiler().Build(Properties.Resources.Stub, "TempFile", _Save_File_Dialog.FileName);

                File.Delete("TempFile");
            }
        }
    }
}