using System.ComponentModel;
using System.Media;

namespace CheckScreenColor
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 画面を確認する間隔（ミリ秒）
        /// </summary>
        private const int PollIntervalMs = 100;

        /// <summary>
        /// 検出が続いている間、何ティックおきにビープするか
        /// </summary>
        private const int BeepIntervalTicks = 10;

        /// <summary>
        /// 対象色と判定する G チャンネルの下限
        /// </summary>
        private const int MinTargetChannel = 200;

        /// <summary>
        /// 対象色と判定する R / B チャンネルの上限
        /// </summary>
        private const int MaxOtherChannel = 30;

        /// <summary>
        /// 検出が続いている間だけ加算するティック数。途切れたら 0 に戻す
        /// </summary>
        private int detectedTicks;

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// bmp に緑っぽい色が含まれるか？
        /// </summary>
        public static bool IsGreenish(Bitmap bmp)
        {
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixelColor = bmp.GetPixel(x, y);

                    // 緑っぽいかどうかは適当
                    if (pixelColor.G > MinTargetChannel
                        && pixelColor.R < MaxOtherChannel
                        && pixelColor.B < MaxOtherChannel)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Shown += MainForm_Shown;

            pollTimer.Start();
        }

        private void PollTimer_Tick(object? sender, EventArgs e)
        {
            // 監視枠の内側だけをキャプチャする。
            // PointToScreen は枠線の内側を原点として返すので、
            // 大きさにも枠線を含まない ClientSize を使う。
            Size captureSize = targetPanel.ClientSize;
            if (captureSize.Width <= 0 || captureSize.Height <= 0)
            {
                return;
            }

            using Bitmap bmp = new(captureSize.Width, captureSize.Height);
            using Graphics g = Graphics.FromImage(bmp);

            try
            {
                g.CopyFromScreen(targetPanel.PointToScreen(Point.Empty), Point.Empty, captureSize);
            }
            catch (Win32Exception)
            {
                // ロック画面や UAC のセキュアデスクトップ表示中は画面を取得できない。
                // このティックは黙って見送る。
                return;
            }

            if (IsGreenish(bmp))
            {
                // 検出が続く間はカウンタを増やし続け、BeepIntervalTicks おきにだけ鳴らす
                if (detectedTicks % BeepIntervalTicks == 0)
                {
                    SystemSounds.Beep.Play();
                }
                detectedTicks++;
            }
            else
            {
                detectedTicks = 0;
            }
        }

        /// <summary>
        /// Designder の表示が High DPI でおかしくなるので
        /// targetPanel を中心に再配置
        /// </summary>
        private void MainForm_Shown(object? sender, EventArgs e)
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
