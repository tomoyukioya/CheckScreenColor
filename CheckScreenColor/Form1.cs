using System.Runtime.InteropServices;

namespace CheckScreenColor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// bmpに緑っぽい色が含まれるか？
        /// </summary>
        public static bool IsGreenish(Bitmap bmp)
        {
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixelColor = bmp.GetPixel(x, y);

                    // 緑っぽいかどうかは適当
                    if (pixelColor.G > 200 && pixelColor.R < 30 && pixelColor.B < 30)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private int count = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Shown += Form1_Shown;

            // タイマーを作成
            System.Windows.Forms.Timer timer = new()
            {
                Interval = 100 // 100ミリ秒ごとにチェック
            };

            timer.Tick += (sender, e) =>
            {
                // キャプチャ取得
                MemoryStream ms = new();
                using Bitmap bmp = new(targetPanel.Width, targetPanel.Height);
                using Graphics g = Graphics.FromImage(bmp);

                g.CopyFromScreen(targetPanel.PointToScreen(new Point(0, 0)), new Point(0, 0), bmp.Size);

                if (IsGreenish(bmp))
                {
                    if (count++ % 10 == 0)
                    {
                        count = 0;
                        Console.Beep();
                    }
                }
                else
                    count = 0;
            };
            timer.Start();
        }

        /// <summary>
        /// Designderの表示がHigh DPIでおかしくなるので
        /// targetPanelを中心に再配置
        /// </summary>
        private void Form1_Shown(object? sender, EventArgs e)
        {
            // Calculate the center of capturePanel
            int centerX = capturePanel.Width / 2;
            int centerY = capturePanel.Height / 2;

            // Calculate the location of targetPanel so that it is centered in capturePanel
            int targetX = centerX - targetPanel.Width / 2;
            int targetY = centerY - targetPanel.Height / 2;

            // Set the location of targetPanel
            targetPanel.Location = new Point(targetX, targetY);
        }
    }
}
