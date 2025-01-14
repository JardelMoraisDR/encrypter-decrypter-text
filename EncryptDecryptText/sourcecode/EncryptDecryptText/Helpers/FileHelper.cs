using System;
using System.IO;
using System.Windows.Forms;

namespace EncryptDecryptText.Helpers
{

    public static class FileHelper
    {
        public class FileResult
        {
            public string FileContent { get; set; }
            public string FileName { get; set; }
        }

        public static void SaveTextToFile(string content)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt";
            saveFileDialog.Title = "Save as Text File";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = saveFileDialog.FileName;
                    File.WriteAllText(filePath, content);
                    MessageBox.Show("Text saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Error saving file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static FileResult OpenTextFile()
        {
            FileResult fileResult = new FileResult();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";
            openFileDialog.Title = "Select text file";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileSelected = openFileDialog.FileName;

                try
                {
                    string fileContent = File.ReadAllText(fileSelected);
                    fileResult.FileContent = fileContent;
                    fileResult.FileName = fileSelected;
                }
                catch (IOException ex)
                {
                    fileResult.FileContent = "No file selected";
                    fileResult.FileName = "";
                    MessageBox.Show("Error reading file: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return fileResult;
        }
    }

}