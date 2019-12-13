using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DICTIONARYHASH
{
    public partial class fromAddnewword : Form
    {
        public fromAddnewword()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTuMoi.Text == "" || txtPhienAm.Text == "" || txtNghia.Text == "" || cboLoaiTu.SelectedIndex < 0)
                MessageBox.Show("Bạn chưa nhập đầy đủ thông tin!","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else
            {


                Dictionary td = new Dictionary();
                td.ReadFromData();
                if (td.themtu(txtTuMoi.Text.ToLower(), (string)cboLoaiTu.SelectedItem, txtPhienAm.Text, txtNghia.Text) == true)
                {
                    td.xoadata();
                    td.WriteToData();
                    MessageBox.Show("Bạn đã thêm thành công!","Thêm từ",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Close();
                }
                else MessageBox.Show("Từ bạn thêm đã có trong hệ thống!","Thêm từ", MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Bạn có chắc muốn hủy không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                txtNghia.Text = "";
                txtTuMoi.Text = "";
                txtPhienAm.Text = "";
                cboLoaiTu.Text = "";
                txtTuMoi.Focus();
            }
        }
    }
}
