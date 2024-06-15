using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Ionic.Zlib;

namespace SplitImageFiles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "TIFF files (*.tiff)|*.tiff|PDF files (*.pdf)|*.pdf";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in openFileDialog1.FileNames)
                {
                    if (Path.GetExtension(file).ToLower() == ".tiff")
                    {
                        SplitTiff(file);
                    }
                    else if (Path.GetExtension(file).ToLower() == ".pdf")
                    {
                        SplitPdf(file);
                    }
                }
            }
        }

        private void SplitTiff(string filePath)
        {
            using (Image image = Image.FromFile(filePath))
            {
                int width = image.Width;
                int height = image.Height;
                int rows = height / 100; // adjust the number of rows as needed
                int cols = width / 100; // adjust the number of columns as needed

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        Rectangle rect = new Rectangle(col * width / cols, row * height / rows, width / cols, height / rows);
                        Image newImage = image.Clone(new Rectangle(rect.X, rect.Y, rect.Width, rect.Height), image.PixelFormat);
                        newImage.Save($"C:\\Split\\{Path.GetFileNameWithoutExtension(filePath)}_{row}_{col}.{Path.GetExtension(filePath)}");
                    }
                }
            }
        }

        private void SplitPdf(string filePath)
        {
            iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document();
            iTextSharp.text.pdf.PdfReader pdfReader = new iTextSharp.text.pdf.PdfReader(filePath);
            int totalPages = pdfReader.NumberOfPages;

            for (int page = 1; page <= totalPages; page++)
            {
                iTextSharp.text.pdf.PdfImportedPage pageObj = pdfReader.GetImportedPage(page);
                iTextSharp.text.Document document = new iTextSharp.text.Document(pageObj.GetWidth(), pageObj.GetHeight());
                PdfContentByte pdfContentByte = pdfReader.GetPageContent(page);

                using (MemoryStream ms = new MemoryStream())
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, ms);
                    document.Open();

                    document.Add(pageObj);

                    document.Close();
                    ms.Position = 0;

                    byte[] bytes = ms.ToArray();
                    using (MemoryStream ms2 = new MemoryStream(bytes))
                    {
                        using (Image image = Image.FromStream(ms2))
                        {
                            int width = image.Width;
                            int height = image.Height;
                            int rows = height / 100; // adjust the number of rows as needed
                            int cols = width / 100; // adjust the number of columns as needed

                            for (int row = 0; row < rows; row++)
                            {
                                for (int col = 0; col < cols; col++)
                                {
                                    Rectangle rect = new Rectangle(col * width / cols, row * height / rows, width / cols, height / rows);
                                    Image newImage = image.Clone(new Rectangle(rect.X, rect.Y, rect.Width, rect.Height), image.PixelFormat);
                                    newImage.Save($"C:\\Split\\{Path.GetFileNameWithoutExtension(filePath)}_{page}_{row}_{col}.{Path.GetExtension(filePath)}");
                                }
                            }
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog1.ShowNewFolderButton = true;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string folderPath = folderBrowserDialog1.SelectedPath;

                foreach (string file in Directory.GetFiles(folderPath))
                {
                    if (Path.GetExtension(file).ToLower() == ".tiff")
                    {
                        SplitTiff(file);
                    }
                    else if (Path.GetExtension(file).ToLower() == ".pdf")
                    {
                        SplitPdf(file);
                    }
                }
            }
        }
    }
}