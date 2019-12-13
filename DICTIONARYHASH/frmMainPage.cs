using SpeechLib;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DICTIONARYHASH
{
    public partial class frmTrangChu : Form
    {
        public frmTrangChu()
        {
            InitializeComponent();
        }

        private void btnSpeech_Click(object sender, EventArgs e)
        {
            SpVoice voice = new SpVoice();
            voice.Speak(txtNhap.Text, SpeechVoiceSpeakFlags.SVSFDefault);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            fromAddnewword Them = new fromAddnewword();
            Them.Show();
        }

        private void putAllWordsInListBox(Dictionary td)
        {
            string[] s = null;
            for (int i = 0; i < 26; ++i)
            {
                td[i].inkey(ref s);
                if (s != null)
                {
                    foreach (string e in s)
                        lstDSTu.Items.Add(e);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Bạn có chắc muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Dictionary td = new Dictionary();
                td.delete((string)lstDSTu.SelectedItem);
                td.ReadFromData();
                lstDSTu.Items.Remove(lstDSTu.SelectedItem);
                lstDSNghia.Items.Clear();
                td.xoadata();
                td.WriteToData();
                putAllWordsInListBox(td);
                MessageBox.Show("Bạn đã xóa thành công!");
                txtNhap.Text = "";
            }
        }
        string tam = "";
        private void txtNhap_TextChanged(object sender, EventArgs e)
        {
            lstDSTu.Items.Clear();
            Dictionary td = new Dictionary();
            td.ReadFromData();

            tam = txtNhap.Text;
            tam = tam.ToLower();
            if (tam != "")
            {
                string[] mangchuatu = new string[50];
                td.HienThiTuLienQuan(tam, ref mangchuatu);
                int dem = 0;
                foreach (string item in mangchuatu)
                {
                    if (item != null)
                    {
                        lstDSTu.Items.Add(item);
                        dem++;
                    }
                    else break;
                }
                if (dem == 0)
                {
                    MessageBox.Show("Từ bạn cần tìm không có trong hệ thống!");
                    txtNhap.Text = "";
                }
            }
            else
            {
                putAllWordsInListBox(td);
            }
        }

        private void lstDSTu_MouseUp(object sender, MouseEventArgs e)
        {
            this.lstDSTu.SelectedIndex = this.lstDSTu.IndexFromPoint(e.X, e.Y);
            if (this.lstDSTu.SelectedIndex == ListBox.NoMatches)
                return;

            //click chuột phải bất menu
            if (e.Button == MouseButtons.Right)
            {
                this.ContextMenu.Show(this.lstDSTu, new Point(e.X, e.Y));
            }
            //click chuột trái chọn item
            else
            {
                string s = (string)lstDSTu.SelectedItem;
                txtNhap.Text = s;
                Dictionary td = new Dictionary();
                td.ReadFromData();
                lstDSNghia.Items.Clear();
                lstDSNghia.Items.Add(td.writedata(s.ToString()));
            }
        }

        private void ContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int id = this.ContextMenu.Items.IndexOf(e.ClickedItem);
            switch (id)
            {
                case 0:
                    //Đầu tiên là edit
                    break;
                case 1:
                    // Xóa từ
                    Dictionary td = new Dictionary();
                    td.delete((string)lstDSTu.SelectedItem);
                    td.ReadFromData();
                    lstDSTu.Items.Remove(lstDSTu.SelectedItem);
                    lstDSNghia.Items.Clear();

                    td.xoadata();
                    td.WriteToData();
                    putAllWordsInListBox(td);
                    MessageBox.Show("Bạn đã xóa thành công!");
                    break;
            }
        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            Dictionary td = new Dictionary();
            td.ReadFromData();
            putAllWordsInListBox(td);
        }
    }
}
