using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace RichText_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        bool color = false;
        int count = 0;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //richTextBox1.Text = textBox1.Text + "\r\n" + richTextBox1.Text;
            if (color)
            {
                richTextBox1.SelectionColor = Color.GreenYellow;
                color = !color;
            }
            else
            {
                richTextBox1.SelectionColor = Color.Salmon;
                color = !color;

            }
            string str = textBox1.Text;
            char[] newStr = new char[str.Length];
            byte b, b0, b1;
            for (int i = 0; i < str.Length; i++)                
            {
                if (i > 0) b0 = (byte)str[i-1];
                if (i < str.Length - 1) b1 = (byte)str[i+1];
                
                b = (byte)str[i];
                if (b == 10 || b == 13)
                {
                    newStr[i] = ' ';
                }
                else
                {
                    newStr[i] = str[i];
                }
            }

            str = new string(newStr);

            int len = textBox1.Text.Length;
           // richTextBox1.SelectedText = Environment.NewLine + textBox1.Text + count.ToString();
            richTextBox1.SelectedText = textBox1.Text + count.ToString() + "\r\n";
            count++;
           // WriteTextToRichTextBox();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Font font = new Font("Tahoma", 8, FontStyle.Regular);
            richTextBox1.SelectionFont = font;

        }

        private void WriteTextToRichTextBox()
        {
            // Clear all text from the RichTextBox;
            richTextBox1.Clear();
            // Set the font for the opening text to a larger Arial font;
            richTextBox1.SelectionFont = new Font("Arial", 16);
            // Assign the introduction text to the RichTextBox control.
            richTextBox1.SelectedText = "The following is a list of bulleted items:" + "\n";
            richTextBox1.AppendText("Appedned Text 1");
            // Set the Font for the first item to a smaller size Arial font.
            richTextBox1.SelectionFont = new Font("Arial", 12);
            // Specify that the following items are to be added to a bulleted list.
            richTextBox1.SelectionBullet = true;
            // Set the color of the item text.
            richTextBox1.SelectionColor = Color.Red;
            // Assign the text to the bulleted item.
            richTextBox1.SelectedText = "Apples" + "\n";
            richTextBox1.AppendText("Appedned Text 2");

            // Apply same font since font settings do not carry to next line.
            richTextBox1.SelectionFont = new Font("Arial", 12);
            richTextBox1.SelectionColor = Color.Orange;
            richTextBox1.SelectedText = "Oranges" + "\n";
            richTextBox1.SelectionFont = new Font("Arial", 12);
            richTextBox1.SelectionColor = Color.Purple;
            richTextBox1.SelectedText = "Grapes" + "\n";
            // End the bulleted list.
            richTextBox1.SelectionBullet = false;
            // Specify the font size and string for text displayed below bulleted list.
            richTextBox1.SelectionFont = new Font("Arial", 16);
            richTextBox1.SelectedText = "Bulleted Text Complete!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = textBox1.Text;
            #region --File open testing
            ////string fileName;

            ////fileName = Application.StartupPath + "\\a\\b\\c";
            ////if (!Directory.Exists(fileName)) Directory.CreateDirectory(fileName);
            ////fileName += "\\file2.txt";
            ////using (StreamWriter sw = new StreamWriter(fileName, true))
            ////{
            ////    sw.WriteLine("Hello at " + DateTime.Now.ToString() + "\r\n");
            ////}
            #endregion
        }
    }
}
