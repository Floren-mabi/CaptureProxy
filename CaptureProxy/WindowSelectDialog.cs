using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureProxy
{
    public partial class WindowSelectDialog : Form
    {
        Dictionary<string, IntPtr> _windowList;
        public string SelectedItem { get; set; }

        public WindowSelectDialog()
        {
            InitializeComponent();
        }

        public WindowSelectDialog(Dictionary<string, IntPtr> windowList)
        {
            InitializeComponent();
            _windowList = windowList;
        }

        private void WindowSelectDialog_Load(object sender, EventArgs e)
        {
            foreach(string windowName in _windowList.Keys)
            {
                listBox1.Items.Add(windowName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }
            SelectedItem = (string) listBox1.SelectedItem;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectedItem = null;
        }
    }
}
