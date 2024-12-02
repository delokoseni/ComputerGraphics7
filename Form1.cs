using System;
using System.Drawing;
using System.Windows.Forms;

namespace ComputerGraphics7
{
    public partial class Form1 : Form
    {
        private Bitmap originalImage; // Исходное изображение
        private Bitmap currentImage;  // Текущее изображение

        public Form1()
        {
            InitializeComponent();
            buttonNearestNeighbor.Click += new EventHandler(buttonNearestNeighbor_Click);
            buttonBicubicSmoothing.Click += new EventHandler(buttonBicubicSmoothing_Click);
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    originalImage = new Bitmap(openFileDialog.FileName);
                    currentImage = new Bitmap(originalImage);
                    pictureBox.Image = currentImage;
                }
            }
        }

        private void buttonNearestNeighbor_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox.Text, out double scale))
            {
                currentImage = ScaleBitmapNearestNeighbor(originalImage, scale);
                pictureBox.Image = currentImage;
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректный коэффициент масштаба.");
            }
        }

        private void buttonBicubicSmoothing_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox.Text, out double scale))
            {
                currentImage = ScaleBitmapBicubicSmoothing(originalImage, scale);
                pictureBox.Image = currentImage;
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректный коэффициент масштаба.");
            }
        }

        private Bitmap ScaleBitmapNearestNeighbor(Bitmap bitmap, double scale)
        {
            int newWidth = (int)(bitmap.Width * scale);
            int newHeight = (int)(bitmap.Height * scale);
            Bitmap scaledBitmap = new Bitmap(newWidth, newHeight);

            for (int x1 = 0; x1 < newWidth; x1++)
            {
                for (int y1 = 0; y1 < newHeight; y1++)
                {
                    int x = (int)(x1 / scale);
                    int y = (int)(y1 / scale);
                    scaledBitmap.SetPixel(x1, y1, bitmap.GetPixel(x, y));
                }
            }

            return scaledBitmap;
        }

        private Bitmap ScaleBitmapBicubicSmoothing(Bitmap bitmap, double scale)
        {
            int newWidth = (int)(bitmap.Width * scale);
            int newHeight = (int)(bitmap.Height * scale);
            Bitmap scaledBitmap = new Bitmap(newWidth, newHeight);

            for (int x1 = 0; x1 < newWidth; x1++)
            {
                for (int y1 = 0; y1 < newHeight; y1++)
                {
                    double x = (double)x1 / scale;
                    double y = (double)y1 / scale;

                    int x0 = (int)x;
                    int y0 = (int)y;

                    // Получаем значения пикселей из оригинального изображения
                    Color Q11 = bitmap.GetPixel(x0, y0);
                    Color Q12 = bitmap.GetPixel(Math.Min(x0 + 1, bitmap.Width - 1), y0);
                    Color Q21 = bitmap.GetPixel(x0, Math.Min(y0 + 1, bitmap.Height - 1));
                    Color Q22 = bitmap.GetPixel(Math.Min(x0 + 1, bitmap.Width - 1), Math.Min(y0 + 1, bitmap.Height - 1));

                    double xDist = x - x0;
                    double yDist = y - y0;

                    // Интерполяция по горизонтали
                    int r1 = (int)(Q11.R * (1 - xDist) + Q12.R * xDist);
                    int g1 = (int)(Q11.G * (1 - xDist) + Q12.G * xDist);
                    int b1 = (int)(Q11.B * (1 - xDist) + Q12.B * xDist);

                    int r2 = (int)(Q21.R * (1 - xDist) + Q22.R * xDist);
                    int g2 = (int)(Q21.G * (1 - xDist) + Q22.G * xDist);
                    int b2 = (int)(Q21.B * (1 - xDist) + Q22.B * xDist);

                    // Вертикальная интерполяция
                    int rFinal = (int)(r1 * (1 - yDist) + r2 * yDist);
                    int gFinal = (int)(g1 * (1 - yDist) + g2 * yDist);
                    int bFinal = (int)(b1 * (1 - yDist) + b2 * yDist);

                    // Устанавливаем пиксель
                    scaledBitmap.SetPixel(x1, y1, Color.FromArgb(Clamp(rFinal), Clamp(gFinal), Clamp(bFinal)));
                }
            }

            return scaledBitmap;
        }

        private int Clamp(int value)
        {
            return Math.Max(0, Math.Min(255, value));
        }
    }
}
