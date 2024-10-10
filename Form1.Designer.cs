namespace SplitImageFiles
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnSplitTiff;
        private System.Windows.Forms.Button btnSplitPdf;
        private System.Windows.Forms.Button btnConvertFolder;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnSplitTiff = new System.Windows.Forms.Button();
            this.btnSplitPdf = new System.Windows.Forms.Button();
            this.btnConvertFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSplitTiff
            // 
            this.btnSplitTiff.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnSplitTiff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSplitTiff.ForeColor = System.Drawing.Color.White;
            this.btnSplitTiff.Location = new System.Drawing.Point(12, 12);
            this.btnSplitTiff.Name = "btnSplitTiff";
            this.btnSplitTiff.Size = new System.Drawing.Size(170, 40);
            this.btnSplitTiff.TabIndex = 0;
            this.btnSplitTiff.Text = "Split TIFF Files";
            this.btnSplitTiff.UseVisualStyleBackColor = false;
            this.btnSplitTiff.Click += new System.EventHandler(this.btnSplitTiff_Click);
            // 
            // btnSplitPdf
            // 
            this.btnSplitPdf.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnSplitPdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSplitPdf.ForeColor = System.Drawing.Color.White;
            this.btnSplitPdf.Location = new System.Drawing.Point(249, 12);
            this.btnSplitPdf.Name = "btnSplitPdf";
            this.btnSplitPdf.Size = new System.Drawing.Size(171, 40);
            this.btnSplitPdf.TabIndex = 1;
            this.btnSplitPdf.Text = "Split PDF Files";
            this.btnSplitPdf.UseVisualStyleBackColor = false;
            this.btnSplitPdf.Click += new System.EventHandler(this.btnSplitPdf_Click);
            // 
            // btnConvertFolder
            // 
            this.btnConvertFolder.BackColor = System.Drawing.Color.DarkCyan;
            this.btnConvertFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvertFolder.ForeColor = System.Drawing.Color.White;
            this.btnConvertFolder.Location = new System.Drawing.Point(123, 143);
            this.btnConvertFolder.Name = "btnConvertFolder";
            this.btnConvertFolder.Size = new System.Drawing.Size(178, 68);
            this.btnConvertFolder.TabIndex = 2;
            this.btnConvertFolder.Text = "Convert Folder";
            this.btnConvertFolder.UseVisualStyleBackColor = false;
            this.btnConvertFolder.Click += new System.EventHandler(this.btnConvertFolder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(387, 279);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "lnfo";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(428, 304);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConvertFolder);
            this.Controls.Add(this.btnSplitPdf);
            this.Controls.Add(this.btnSplitTiff);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "File Splitter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
    }
}
