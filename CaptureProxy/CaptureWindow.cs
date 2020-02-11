using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureProxy
{
    public partial class CaptureWindow : Form
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int x;
            public int y;
        }
        [StructLayout(LayoutKind.Sequential)]
        struct CURSORINFO
        {
            public Int32 cbSize;
            public Int32 flags;
            public IntPtr hCursor;
            public POINT ptScreenPos;
        }

        public delegate bool EnumWindowsDelegate(IntPtr hWnd, IntPtr lparam);

        [DllImport("user32.dll")]
        private static extern int GetClientRect(IntPtr hwnd, out RECT lpRect);

        [DllImport("user32.dll")]
        private static extern bool ClientToScreen(IntPtr hwnd, out POINT lpPoint);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public extern static bool EnumWindows(EnumWindowsDelegate lpEnumFunc, IntPtr lparam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll")]
        static extern bool GetCursorInfo(out CURSORINFO pci);

        private Setting _data { get; set; }

        private EnumWindowsDelegate _enumWindowsDelegate;

        private static Dictionary<string, IntPtr> _windowList;

        private DateTime _fpsBaseTime;
        private int _fpsDrawCount;
        private float _fps;
        private readonly TimeSpan _fpsInterval = TimeSpan.FromMilliseconds(1000);
        private Stream _soundStream;
        private SoundPlayer _soundPlayer;

        private static bool EnumWindowCallBack(IntPtr hWnd, IntPtr lparam)
        {
            //ウィンドウのタイトルの長さを取得する
            int textLen = GetWindowTextLength(hWnd);
            if (0 < textLen)
            {
                //ウィンドウのタイトルを取得する
                StringBuilder tsb = new StringBuilder(textLen + 1);
                GetWindowText(hWnd, tsb, tsb.Capacity);
                _windowList[tsb.ToString()] = hWnd;
            }

            //すべてのウィンドウを列挙する
            return true;
        }

        public CaptureWindow()
        {
            InitializeComponent();
            _windowList = new Dictionary<string, IntPtr>();
            _enumWindowsDelegate = new EnumWindowsDelegate(EnumWindowCallBack);
            _fpsBaseTime = DateTime.Now;
            _fpsDrawCount = 0;
            _soundStream = Properties.Resources.Camera_Phone03_1;
            _soundPlayer = new SoundPlayer(_soundStream);
        }

        private void CaptureWindow_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke((MethodInvoker)(() =>
            {
                timer1.Start();
            }));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_data != null)
            {
                Invalidate();
            }
        }

        public void SetSettingData(Setting setting)
        {
            _data = setting;
            ClientSize = new Size(_data.Width, _data.Height);
        }

        public void UpdateOffsetX(int offsetX)
        {
            if (_data == null) { return; }
            _data.OffsetX = offsetX;
        }
        public void UpdateOffsetY(int offsetY)
        {
            if (_data == null) { return; }
            _data.OffsetY = offsetY;
        }
        public void UpdateWidth(int width)
        {
            if (_data == null) { return; }
            _data.Width = width;
            ClientSize = new Size(_data.Width, _data.Height);
        }
        public void UpdateHeight(int height)
        {
            if (_data == null) { return; }
            _data.Height = height;
            ClientSize = new Size(_data.Width, _data.Height);
        }

        public void UpdateInterval(int interval)
        {
            if (_data == null) { return; }
            _data.Interval = interval;
            timer1.Interval = _data.Interval;
        }

        public void UpdateDrawCursor(bool drawCursor)
        {
            if (_data == null) { return; }
            _data.DrawCursor = drawCursor;
        }

        public void UpdateShowFPS(bool showFps)
        {
            if (_data == null) { return; }
            _data.ShowFPS = showFps;
        }

        private void CaptureWindow_Paint(object sender, PaintEventArgs e)
        {
            if (_data != null)
            {
                Invoke((MethodInvoker)(() =>
                {
                    e.Graphics.FillRectangle(Brushes.Black, 0, 0, _data.Width, _data.Height);
                    _windowList.Clear();
                    EnumWindows(EnumWindowCallBack, IntPtr.Zero);
                    IntPtr hWnd = IntPtr.Zero;
                    foreach (string key in _windowList.Keys)
                    {
                        if (key.Contains(_data.Title))
                        {
                            hWnd = _windowList[key];
                        }
                    }
                    if (hWnd != IntPtr.Zero)
                    {
                        RECT rect = new RECT();
                        if (GetClientRect(hWnd, out rect) == 0) return;
                        Size size = new Size(_data.Width, _data.Height);
                        POINT point = new POINT { x = rect.left, y = rect.top };
                        ClientToScreen(hWnd, out point);
                        e.Graphics.SmoothingMode = SmoothingMode.None;
                        e.Graphics.CopyFromScreen(point.x + _data.OffsetX, point.y + _data.OffsetY, 0, 0, size);

                        if (_data.DrawCursor)
                        {
                            CURSORINFO pci;
                            pci.cbSize = Marshal.SizeOf(typeof(CURSORINFO));
                            GetCursorInfo(out pci);

                            if (pci.hCursor != IntPtr.Zero)
                            {
                                Cursor cur = new Cursor(pci.hCursor);
                                Point p = new Point(Cursor.Position.X - (point.x + _data.OffsetX) - cur.HotSpot.X, Cursor.Position.Y - (point.y + _data.OffsetY) - cur.HotSpot.Y);
                                cur.Draw(e.Graphics, new Rectangle(p, cur.Size));
                            }
                        }
                        if (_data.ShowFPS)
                        {
                            _fpsDrawCount++;
                            DateTime now = DateTime.Now;
                            TimeSpan span = now - _fpsBaseTime;
                            if (span >= TimeSpan.FromMilliseconds(1000))
                            {
                                _fps = (float)_fpsDrawCount * 1000 / (float)span.TotalMilliseconds;
                                _fpsBaseTime = now;
                                _fpsDrawCount = 0;
                            }
                            GraphicsPath gp = new GraphicsPath();
                            FontFamily ff = new FontFamily("Arial");
                            gp.AddString(_fps.ToString("F2"), ff, 1, 28, new Point(0, 0), StringFormat.GenericDefault);
                            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                            e.Graphics.FillPath(Brushes.Lime, gp);
                            e.Graphics.DrawPath(Pens.Black, gp);
                            ff.Dispose();
                            gp.Dispose();
                        }
                    }
                }));
            }
        }

        private void GetScreenShot()
        {
            _soundPlayer.Play();
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(bmp, ClientRectangle);
            
            if (!Directory.Exists("capture"))
            {
                Directory.CreateDirectory("capture");
            }

            string fileName = _data.Title;
            if (fileName == null || fileName.Length == 0)
            {
                fileName = "Caputure";
            }

            string timeStamp = DateTime.Now.ToString("yyyy-MM-dd_HH_mm_ss_FF");
            char[] invalidChars = Path.GetInvalidFileNameChars();
            fileName = string.Concat(fileName.Select(c => invalidChars.Contains(c) ? '_' : c));

            bmp.Save("capture\\" + fileName + "_" + timeStamp + ".png", ImageFormat.Png);
            bmp.Dispose();
        }

        private void CaptureWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                GetScreenShot();
            }
        }

        public Dictionary<string, IntPtr> GetWindowList()
        {
            _windowList.Clear();
            EnumWindows(EnumWindowCallBack, IntPtr.Zero);
            return _windowList;
        }
    }
}
