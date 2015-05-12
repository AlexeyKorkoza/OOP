using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 1)
            {
                char[] str = textBox1.Text.ToCharArray();
                textBox1.Text = "";
                for (int i = 0; i < str.Length - 1; i++)
                {
                    textBox1.Text += str[i];
                }
            }
            else
                textBox1.Text = "";
        }

        private void buttonCassetes_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "(*.json;*.csv;*.xml;*.txt)|*.json;*.csv;*.xml;*.txt";
            if (open.FileName == "")
            {
                string FileName = open.FileName;
                if (open.ShowDialog() == DialogResult.OK)
                {
                    using (var sr = new StreamReader(open.FileName))
                    {
                        var str = sr.ReadToEnd();
                        listBox1.Items.Add(str.ToString());
                    }
                }
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            string pattern = @"[0-9]";
            Match isMatch = Regex.Match(textBox1.Text, pattern, RegexOptions.IgnoreCase);
            if (!isMatch.Success || Convert.ToInt32(textBox1.Text) <= 0)
            {
                MessageBox.Show("Некорректный ввод");
                textBox1.BackColor = Color.Yellow;
                return;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            listBox1.Text = string.Empty;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += (sender as Button).Text;
        }        
    }
}
