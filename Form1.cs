using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace SplitImageFiles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSplitTiff_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Filter = "TIFF files (*.tiff)|*.tiff",
                Multiselect = true,
                RestoreDirectory = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in openFileDialog1.FileNames)
                {
                    try
                    {
                        SplitTiff(file);
                        MessageBox.Show($"Successfully split {file} into TIFF images.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error processing file {file}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSplitPdf_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                Multiselect = true,
                RestoreDirectory = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in openFileDialog1.FileNames)
                {
                    try
                    {
                        SplitPdf(file);
                        MessageBox.Show($"Successfully split {file} into PDF files.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error processing file {file}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnConvertFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = folderBrowserDialog.SelectedPath;

                    try
                    {
                        // Process all TIFF files
                        string[] tiffFiles = Directory.GetFiles(selectedPath, "*.tiff", SearchOption.AllDirectories);
                        foreach (string file in tiffFiles)
                        {
                            SplitTiff(file);
                        }

                        // Process all PDF files
                        string[] pdfFiles = Directory.GetFiles(selectedPath, "*.pdf", SearchOption.AllDirectories);
                        foreach (string file in pdfFiles)
                        {
                            SplitPdf(file);
                        }

                        MessageBox.Show($"Successfully processed TIFF and PDF files from {selectedPath}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error processing files in folder: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void SplitTiff(string filePath)
        {
            using (System.Drawing.Image image = System.Drawing.Image.FromFile(filePath))
            {
                var frameCount = image.GetFrameCount(FrameDimension.Page);
                for (int i = 0; i < frameCount; i++)
                {
                    image.SelectActiveFrame(FrameDimension.Page, i);
                    using (System.Drawing.Image page = new Bitmap(image))
                    {
                        string directory = "C:\\Split";  // Ensure directory exists
                        Directory.CreateDirectory(directory);
                        page.Save(Path.Combine(directory, $"{Path.GetFileNameWithoutExtension(filePath)}_page_{i + 1}.tiff"), ImageFormat.Tiff);
                    }
                }
            }
        }

        private void SplitPdf(string filePath)
        {
            try
            {
                using (PdfDocument inputDocument = PdfReader.Open(filePath, PdfDocumentOpenMode.Import))
                {
                    if (inputDocument.PageCount == 0)
                    {
                        MessageBox.Show("The PDF file does not contain any pages.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int totalPages = inputDocument.PageCount;
                    string directory = "C:\\Split";  // Ensure directory exists
                    Directory.CreateDirectory(directory);

                    for (int pageIdx = 0; pageIdx < totalPages; pageIdx++)
                    {
                        using (PdfDocument outputDocument = new PdfDocument())
                        {
                            outputDocument.AddPage(inputDocument.Pages[pageIdx]);
                            string newFilePath = Path.Combine(directory, $"{Path.GetFileNameWithoutExtension(filePath)}_page_{pageIdx + 1}.pdf");
                            outputDocument.Save(newFilePath);
                        }
                    }

                    MessageBox.Show($"Successfully split {totalPages} pages from {filePath}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Support and feedback: support@iuliani.com");
        }
    }
}
