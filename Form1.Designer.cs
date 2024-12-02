namespace ComputerGraphics7
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox = new PictureBox();
            buttonDownload = new Button();
            helpProvider1 = new HelpProvider();
            textBox = new TextBox();
            buttonNearestNeighbor = new Button();
            buttonBicubicSmoothing = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(370, 12);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(500, 500);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // buttonDownload
            // 
            buttonDownload.Location = new Point(12, 12);
            buttonDownload.Name = "buttonDownload";
            buttonDownload.Size = new Size(213, 29);
            buttonDownload.TabIndex = 1;
            buttonDownload.Text = "Загрузить изображение";
            buttonDownload.UseVisualStyleBackColor = true;
            buttonDownload.Click += buttonDownload_Click;
            // 
            // textBox
            // 
            textBox.Location = new Point(12, 47);
            textBox.Name = "textBox";
            textBox.Size = new Size(213, 27);
            textBox.TabIndex = 2;
            // 
            // buttonNearestNeighbor
            // 
            buttonNearestNeighbor.Location = new Point(12, 80);
            buttonNearestNeighbor.Name = "buttonNearestNeighbor";
            buttonNearestNeighbor.Size = new Size(213, 29);
            buttonNearestNeighbor.TabIndex = 3;
            buttonNearestNeighbor.Text = "Ближайший сосед";
            buttonNearestNeighbor.UseVisualStyleBackColor = true;
            buttonNearestNeighbor.Click += buttonNearestNeighbor_Click;
            // 
            // buttonBicubicSmoothing
            // 
            buttonBicubicSmoothing.Location = new Point(12, 115);
            buttonBicubicSmoothing.Name = "buttonBicubicSmoothing";
            buttonBicubicSmoothing.Size = new Size(213, 29);
            buttonBicubicSmoothing.TabIndex = 4;
            buttonBicubicSmoothing.Text = "Бикубическое сглаживание";
            buttonBicubicSmoothing.UseVisualStyleBackColor = true;
            buttonBicubicSmoothing.Click += buttonBicubicSmoothing_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 553);
            Controls.Add(buttonBicubicSmoothing);
            Controls.Add(buttonNearestNeighbor);
            Controls.Add(textBox);
            Controls.Add(buttonDownload);
            Controls.Add(pictureBox);
            ForeColor = SystemColors.ControlText;
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox;
        private Button buttonDownload;
        private HelpProvider helpProvider1;
        private TextBox textBox;
        private Button buttonNearestNeighbor;
        private Button buttonBicubicSmoothing;
    }
}
