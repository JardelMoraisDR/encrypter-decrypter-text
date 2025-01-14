using EncryptDecryptText.Helpers;
using Helpers;
using System;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EncryptDecryptText
{
    public partial class frmDecrypt : Form
    {
        public frmDecrypt()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            frmEncrypt form = new frmEncrypt();
            form.Show();
            this.Hide();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text;
            string key = txtKey.Text;

            if (string.IsNullOrEmpty(input)){
                txtInput.Text = "";
                txtResult.Text = "";
                return;
            }

            if (string.IsNullOrEmpty(key)){
                MessageBox.Show("Filling in the 'KEY' field is mandatory, try again.", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string decryptedText = CryptoHelper.Decrypt(input, key);
            if (string.IsNullOrEmpty(decryptedText)){
                MessageBox.Show("An error occurred while processing, please check the 'KEY' entered.", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtResult.Text = decryptedText;
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            txtKey.Text = "";
            txtInput.Text = "";
            txtResult.Text = "";
            lbFileSelected.Text = "No file selected";
        }

        private void pbxCopyPlainText_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text;
            if (string.IsNullOrEmpty(input)){
                return;
            }

            Clipboard.SetText(input);
            MessageBox.Show("Copied!");
        }

        private void pbxEncryptedText_Click(object sender, EventArgs e)
        {
            string input = txtResult.Text;
            if (string.IsNullOrEmpty(input)){
                return;
            }

            Clipboard.SetText(input);
            MessageBox.Show("Copied!");
        }

        private void pbxRandom_Click(object sender, EventArgs e)
        {
            int minLength = 10;
            int maxLength = 18;

            string randomPassword = PasswordGenerator.GenerateRandomPassword(minLength, maxLength);
            txtKey.Text = randomPassword;
        }

        private void btnUploadFile_Click(object sender, EventArgs e)
        {
            FileHelper.FileResult fileResult = FileHelper.OpenTextFile();

            txtInput.Text = fileResult.FileContent;
            lbFileSelected.Text = fileResult.FileName;

            txtResult.Text = "";
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            string input = txtResult.Text;
            if (string.IsNullOrEmpty(input))
            {
                return;
            }

            FileHelper.SaveTextToFile(input);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            string aboutText = "Util7 - Encrypt & Decrypt Texts\n\n" +
                   "Version: 1.0.0 - 2025\n" +
                   "Home: https://util7.net/\n" +
                   "Send an email with your question, suggestion, or compliment. \n" +
                   "Contact us: support@util7.net";

            MessageBox.Show(aboutText, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
