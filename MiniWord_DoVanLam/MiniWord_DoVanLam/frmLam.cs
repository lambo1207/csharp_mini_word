using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace MiniWord_DoVanLam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ReadFont();
            AlignLeft.BackColor = Color.Cyan;
        }

        Boolean btnBold_Boo = false;
        Boolean btnItalic_Boo = false;
        Boolean btnUnderline_Boo = false;
        float Size = 10;
        String font = "Times New Roman";

        Boolean Left_Boo = true;
        Boolean Center_Boo = false;
        Boolean Right_Boo = false;

        String fileName = "";
        float zoom = 1;

        private void ReadFont()
        {
            foreach (FontFamily item in FontFamily.Families)
            {
                cbb_Font.Items.Add(item.Name);
            }

            for (int i = 8; i < 40; i++)
            {
                cbb_SelectSize.Items.Add(i);
            }

            cbb_Font.SelectedIndex = 0;
            cbb_SelectSize.SelectedIndex = 2;

        }

        private void btnSave_Tool_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.ShowDialog(this);
            text.SaveFile(save.FileName);
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.ShowDialog();
            text.SelectionBackColor = color.Color;
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            if (btnBold.BackColor == Color.White)
            {
                btnBold_Boo = true;
                btnBold.BackColor = Color.Cyan;
                fontStyle();
            }
            else
            {
                btnBold_Boo = false;
                btnBold.BackColor = Color.White;
                fontStyle();
            }
        }

        private void cbbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            font = cbb_Font.Text;
            text.SelectionFont = new Font(font, Size);
        }

        private void cbb_SelectSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            Size = float.Parse(cbb_SelectSize.Text);
            text.SelectionFont = new Font(font, Size);
        }

        private void btnU_Click(object sender, EventArgs e)
        {
            if (btnUnderline.BackColor == Color.White)
            {
                btnUnderline_Boo = true;
                btnUnderline.BackColor = Color.Cyan;
                fontStyle();
            }
            else
            {
                btnUnderline.BackColor = Color.White;
                btnUnderline_Boo = false;
                fontStyle();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có muốn thoát không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (fileName == "" && text.TextLength > 0)
            {
                if (dialog == DialogResult.Yes)
                {
                    LuuFile();
                }
            }
            Application.Exit();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnI_Click(object sender, EventArgs e)
        {
            if (btnItalic.BackColor == Color.White)
            {
                btnItalic_Boo = true;
                btnItalic.BackColor = Color.Cyan;
                fontStyle();
            }
            else
            {
                btnItalic.BackColor = Color.White;
                btnItalic_Boo = false;
                fontStyle();
            }
        }

        private void fontStyle()
        {
            if (btnBold_Boo && !btnItalic_Boo && !btnUnderline_Boo)
            {
                text.SelectionFont = new Font(font, Size, FontStyle.Bold);
            }
            else if (!btnBold_Boo && btnItalic_Boo && !btnUnderline_Boo)
            {
                text.SelectionFont = new Font(font, Size, FontStyle.Italic);
            }
            else if (!btnBold_Boo && !btnItalic_Boo && btnUnderline_Boo)
            {
                text.SelectionFont = new Font(font, Size, FontStyle.Underline);
            }
            else if (btnBold_Boo && btnItalic_Boo && !btnUnderline_Boo)
            {
                text.SelectionFont = new Font(font, Size, FontStyle.Italic | FontStyle.Bold);
            }
            else if (btnBold_Boo && !btnItalic_Boo && btnUnderline_Boo)
            {
                text.SelectionFont = new Font(font, Size, FontStyle.Underline | FontStyle.Bold);
            }
            else if (!btnBold_Boo && btnItalic_Boo && btnUnderline_Boo)
            {
                text.SelectionFont = new Font(font, Size, FontStyle.Italic | FontStyle.Underline);
            }
            else if (btnBold_Boo && btnItalic_Boo && btnUnderline_Boo)
            {
                text.SelectionFont = new Font(font, Size, FontStyle.Italic | FontStyle.Bold | FontStyle.Underline);
            }
            else
            {
                text.SelectionFont = new Font(font, Size, FontStyle.Regular);
            }
        }

        private void homeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ToolStrip toolStrip = new ToolStrip();
            toolStrip.Items.Add(new ToolStripButton("fds"));
            toolStrip.Items.Add(new ToolStripButton("fs"));
            toolStrip.Items.Add(new ToolStripButton("ff"));
            toolStrip.Visible = true;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileName != "")
            {
                text.SaveFile(fileName);
            }
            else
            {
                LuuFile();
            }
        }

        private void highlightColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.ShowDialog();
            text.SelectionBackColor = color.Color;
        }

        private void fontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.ShowDialog();
            text.ForeColor = color.Color;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LuuFile();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoFile();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có muốn thoát không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(fileName == "" && text.TextLength > 0)
            {
                if (dialog == DialogResult.Yes)
                {
                    LuuFile();
                }
            }
            text.Visible = false;
        }

        private void btnSave_Tool_Click_1(object sender, EventArgs e)
        {
            if (fileName != "")
            {
                text.SaveFile(fileName);
            }
            else
            {
                LuuFile();
            }
        }

        int dem = 0;

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            text.Visible = true;
            fileName = "";
            FileName.Text = "";
            text.Text = String.Empty;
            text.SelectionFont = new Font(font, Size);
            text.SelectionAlignment = HorizontalAlignment.Left;
            text.ForeColor = Color.Black;
            /*text.ScrollBars = RichTextBoxScrollBars.Vertical;*/
        }

        private void newLayoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*RichTextBox rtb = new RichTextBox();
            rtb.Name = "text";
            rtb.Visible = true;
            fileName = "";
            FileName.Text = "";
            rtb.Text = String.Empty;
            rtb.SelectionFont = new Font(font, Size);
            rtb.SelectionAlignment = HorizontalAlignment.Left;
            rtb.ForeColor = Color.Black;
            rtb.Size = new Size(984, 640);
            rtb.Top = 990;
            rtb.Left = 0;*/

            
        }

        private void LuuFile()
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Save File (*.rtf)|*.rtf";
            save.ShowDialog(this);
            fileName = save.FileName;
            FileName.Text = fileName;
            if (save.FileName != "")
            {
                text.SaveFile(save.FileName);
            }
        }

        private void MoFile()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();
            fileName = open.FileName;
            FileName.Text = fileName;
            if (open.FileName != "")
            {
                text.Visible = true;
                text.LoadFile(open.FileName);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            if (color.ShowDialog() == DialogResult.OK)
            {
                colorText.BackColor = color.Color;
                text.SelectionColor = color.Color;
            }
        }

        private void Undo_Click(object sender, EventArgs e)
        {
            text.Undo();
        }

        private void Redo_Click(object sender, EventArgs e)
        {
            text.Redo();
        }

        private void AlignLeft_Click(object sender, EventArgs e)
        {
            text.SelectionAlignment = HorizontalAlignment.Left;
            if (Left_Boo)
            {
                Left_Boo = false;
                AlignLeft.BackColor = Color.White;
            }
            else
            {
                AlignLeft.BackColor = Color.Cyan;
                AlignCenter.BackColor = Color.White;
                AlignRight.BackColor = Color.White;
                Left_Boo = true;
                Center_Boo= false;
                Right_Boo= false;
            }
        }

        private void AlignCenter_Click(object sender, EventArgs e)
        {
            text.SelectionAlignment = HorizontalAlignment.Center;
            if (Center_Boo)
            {
                Center_Boo = false;
                AlignCenter.BackColor = Color.White;
            }
            else
            {
                AlignLeft.BackColor = Color.White;
                AlignCenter.BackColor = Color.Cyan;
                AlignRight.BackColor = Color.White;
                Center_Boo = true;
                Left_Boo = false;
                Right_Boo = false;
            }
        }

        private void AlignRight_Click(object sender, EventArgs e)
        {
            text.SelectionAlignment = HorizontalAlignment.Right;
            if (Right_Boo)
            {
                Right_Boo = false;
                AlignRight.BackColor = Color.White;
            }
            else
            {
                AlignLeft.BackColor = Color.White;
                AlignCenter.BackColor = Color.White;
                AlignRight.BackColor = Color.Cyan;
                Right_Boo = true;
                Center_Boo = false;
                Left_Boo= false;
            }
        }

        private void ZoomIn_Click(object sender, EventArgs e)
        {
            if (zoom <= 1)
            {
                zoom = 1;
            }
            else
            {
                zoom -= 2;
                text.ZoomFactor = zoom;
            }
        }

        private void ZoomOut_Click(object sender, EventArgs e)
        {
            if (zoom >= 50)
            {
                zoom = 50;
            }
            else
            {
                zoom += 2;
                text.ZoomFactor = zoom;
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (text.SelectionLength > 0)
                text.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (text.SelectionLength > 0)
                text.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
                text.Paste();
        }

        private void insertIMGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog img = new OpenFileDialog();
            img.Filter = "Image|*.bmp;*.jpg;*.gif;*.png;*.tif";
            img.ShowDialog();
            string file = img.FileName;
            if (file != "")
            {
                Clipboard.SetImage(Image.FromFile(file));
                text.Paste();
            }
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Find nextToFind = new Find(text, this);
            nextToFind.Show();
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Find nextToFind = new Find(text, this);
            nextToFind.Show();
        }

        int pos = 0;
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (listView1.FocusedItem == null) return;
                pos = listView1.SelectedIndices[0];
                Clipboard.SetImage(imageList1.Images[pos]);
                text.Paste();
            }
            catch (Exception)
            {
                return;
            }
        }

        private void iconToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\ASUS\Downloads\tessticon");
            /*ResourceManager rm = new ResourceManager("rmc", Assembly.GetExecutingAssembly());*/

            foreach (FileInfo file in dir.GetFiles())
            {
                try
                {
                    imageList1.Images.Add(Image.FromFile(file.FullName));
                }
                catch
                {
                    Console.WriteLine("fall");
                }
            }
            listView1.View = View.LargeIcon;
            imageList1.ImageSize = new Size(32, 32);
            listView1.LargeImageList = imageList1;

            for (int j = 0; j < imageList1.Images.Count; j++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = j;
                listView1.Items.Add(item);
            }

            listView1.Visible = true;
        }

        private void text_Click(object sender, EventArgs e)
        {
            if (listView1.Visible = true)
            {
                listView1.Visible = false;
            }
        }
    }
}
