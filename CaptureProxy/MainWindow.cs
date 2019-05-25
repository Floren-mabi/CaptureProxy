using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.ListViewItem;

namespace CaptureProxy
{
    public partial class MainWindow : Form
    {
        internal CaptureWindow SubWindow { get; set; }

        private string SettingsFileName { get; set; } = "CaptureProxySettings.xml";
        public Settings Settings { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            SubWindow = new CaptureWindow();
            listView.GetType().InvokeMember(
                "DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null,
                listView,
                new object[] { true });
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            SubWindow.Top = this.Top;
            SubWindow.Left = this.Right;
            SubWindow.Show();
            LoadSettings();
        }

        private void LoadSettings()
        {
            if (!File.Exists(SettingsFileName))
            {
                Settings = null;
                SaveSettings();
            }
            XmlSerializer se = new XmlSerializer(typeof(Settings));
            using (StreamReader sr = new StreamReader(SettingsFileName, Encoding.UTF8))
            {
                Settings = (Settings)se.Deserialize(sr);
            }
            if (Settings.Datas == null)
            {
                Settings.Datas = new List<Setting>();
            }
            listView.Items.Clear();
            RenderListView();
        }

        private void SaveSettings()
        {
            if (Settings == null)
            {
                Settings = new Settings();
            }
            if (Settings.Datas == null)
            {
                Settings.Datas = new List<Setting>();
            }
            XmlSerializer se = new XmlSerializer(typeof(Settings));
            using (StreamWriter sw = new StreamWriter(SettingsFileName, false, Encoding.UTF8))
            {
                se.Serialize(sw, Settings);
            }
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.SelectedIndices.Count > 0)
            {
                int idx = listView.SelectedIndices[0];
                Setting item = Settings.Datas[idx];
                SubWindow.SetSettingData(item);

                textName.Text = item.Name;
                textTitle.Text = item.Title;
                numericOffsetX.Value = item.OffsetX;
                numericOffsetY.Value = item.OffsetY;
                numericWidth.Value = item.Width;
                numericHeight.Value = item.Height;
                checkDrawCursor.Checked = item.DrawCursor;
                numericInterval.Value = item.Interval;
                checkShowFPS.Checked = item.ShowFPS;
            }
        }

        private void Save()
        {
            if (textName.Text.Length > 0 && textTitle.Text.Length > 0)
            {
                int idx = Settings.Datas.FindIndex((o) => { return o.Name.Equals(textName.Text); });
                Setting item;
                if (idx > -1)
                {
                    item = Settings.Datas[idx];
                    item.Name = textName.Text;
                    item.Title = textTitle.Text;
                    item.OffsetX = (int)numericOffsetX.Value;
                    item.OffsetY = (int)numericOffsetY.Value;
                    item.Width = (int)numericWidth.Value;
                    item.Height = (int)numericHeight.Value;
                    item.DrawCursor = checkDrawCursor.Checked;
                    item.Interval = (int)numericInterval.Value;
                    item.ShowFPS = checkShowFPS.Checked;
                }
                else
                {
                    item = new Setting();
                    item.Name = textName.Text;
                    item.Title = textTitle.Text;
                    item.OffsetX = (int)numericOffsetX.Value;
                    item.OffsetY = (int)numericOffsetY.Value;
                    item.Width = (int)numericWidth.Value;
                    item.Height = (int)numericHeight.Value;
                    item.DrawCursor = checkDrawCursor.Checked;
                    item.Interval = (int)numericInterval.Value;
                    item.ShowFPS = checkShowFPS.Checked;
                    Settings.Datas.Add(item);
                }
                SaveSettings();
                RenderListView();
                SubWindow.SetSettingData(item);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void RenderListView()
        {
            if (Settings == null || Settings.Datas == null) return;
            listView.Items.Clear();
            Settings.Datas.ForEach((o) => {
                ListViewItem item = new ListViewItem(o.Name);
                item.SubItems.Add(o.Title);
                item.SubItems.Add(o.OffsetX.ToString());
                item.SubItems.Add(o.OffsetY.ToString());
                item.SubItems.Add(o.Width.ToString());
                item.SubItems.Add(o.Height.ToString());
                item.SubItems.Add(o.DrawCursor.ToString());
                item.SubItems.Add(o.Interval.ToString());
                item.SubItems.Add(o.ShowFPS.ToString());
                listView.Items.Add(item);
            });
        }

        private void listView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (listView.SelectedIndices.Count > 0)
                {
                    if (Settings == null || Settings.Datas == null) return;
                    int idx = listView.SelectedIndices[0];
                    Settings.Datas.RemoveAt(idx);
                    SaveSettings();
                    RenderListView();
                    if (listView.Items.Count - 1 >= idx)
                    {
                        listView.Items[idx].Selected = true;
                    }
                }
            }
        }

        private void numericOffsetX_ValueChanged(object sender, EventArgs e)
        {
            SubWindow.UpdateOffsetX((int) numericOffsetX.Value);
        }

        private void numericOffsetY_ValueChanged(object sender, EventArgs e)
        {
            SubWindow.UpdateOffsetY((int)numericOffsetY.Value);
        }

        private void numericWidth_ValueChanged(object sender, EventArgs e)
        {
            SubWindow.UpdateWidth((int)numericWidth.Value);
        }

        private void numericHeight_ValueChanged(object sender, EventArgs e)
        {
            SubWindow.UpdateHeight((int)numericHeight.Value);
        }

        private void numericInterval_ValueChanged(object sender, EventArgs e)
        {
            SubWindow.UpdateInterval((int)numericInterval.Value);
        }

        private void checkDrawCursor_CheckedChanged(object sender, EventArgs e)
        {
            SubWindow.UpdateDrawCursor(checkDrawCursor.Checked);
        }

        private void checkShowFPS_CheckedChanged(object sender, EventArgs e)
        {
            SubWindow.UpdateShowFPS(checkShowFPS.Checked);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WindowSelectDialog wsd = new WindowSelectDialog(SubWindow.GetWindowList());

            DialogResult result = wsd.ShowDialog();

            if (result == DialogResult.OK)
            {
                textTitle.Text = wsd.SelectedItem;
            }

            wsd.Dispose();
        }
    }
}
