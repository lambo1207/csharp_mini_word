using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MiniWord_DoVanLam
{
    public partial class Find : Form
    {
        private RichTextBox txtText = new RichTextBox();
        private Form1 form1 = new Form1();
        public Find(RichTextBox text, Form1 form1)
        {
            InitializeComponent();
            txtText = text;
            this.form1 = form1;
        }

        String txtFind = "";
        String txtReplace = "";

        private void Find_Load(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            txtFind = textFind.Text;
            if (txtFind.Equals(""))
            {
                MessageBox.Show("Bạn chưa nhập từ tìm kiếm!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                FindBTN(txtText, txtFind);
            }
        }

        private int FindBTN(RichTextBox textBox, string text)
        {
            RichTextBoxFinds options = new RichTextBoxFinds();
            int index = new int();
            /*index = textBox.Find(text, 0, textBox.SelectionStart, options);*/
            index = textBox.Find(text, textBox.SelectionStart + textBox.SelectionLength, options);
            if (index >= 0)
            {
                textBox.SelectionStart = index;
                textBox.SelectionLength = text.Length;
                form1.Focus();
            }
            else
            {
                MessageBox.Show("Không tìm thấy từ cần tìm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return index;
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            int i = FindBTN(txtText, textFind.Text);
            if (textFind.Text == "")
                MessageBox.Show("Bạn chưa nhập từ cần tìm!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (textReplace.Text == "")
                MessageBox.Show("Bạn chưa nhập từ thay thế!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (txtText.SelectedText != "")
                txtText.SelectedText = textReplace.Text;
        }

        private void btnReplaceAll_Click(object sender, EventArgs e)
        {
            int i = FindBTN(txtText, textFind.Text);
            if (textFind.Text == "")
                MessageBox.Show("Bạn chưa nhập từ cần tìm!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (textReplace.Text == "")
                MessageBox.Show("Bạn chưa nhập từ thay thế!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (i != 0) { 
                txtText.Text = txtText.Text.Replace(textFind.Text, textReplace.Text);
                form1.Focus();
            }
        }
    }
}
