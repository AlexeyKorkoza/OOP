using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Cassetes;
using Forms.Properties;
using log4net;
using log4net.Config;

namespace Forms
{
    public partial class Form1 : Form
    {
        OpenFileDialog _open;
        private readonly Bankomat _bankomat = new Bankomat();
        List<Cassetes.Cassetes> _list  = new List<Cassetes.Cassetes>();
        public static readonly ILog Log = LogManager.GetLogger(typeof(Form1));     
        public Form1()
        {
            InitializeComponent();
            XmlConfigurator.Configure();
            Log.Info("Start Program");
        }
        public void DisplayMoney()
        {
            try
            {
                foreach (var t in _list.Where(t => t.Count != 0))
                {
                    richTextBox1.Text += t.Nominal + "\n";
                }
                if (richTextBox1.Text.Length != 0) return;
                MessageBox.Show(@"Error");
                Log.Fatal("field - empty");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                Log.Fatal(exception.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length > 0)
                {
                    var str = textBox1.Text.ToCharArray();
                    textBox1.Text = "";
                    for (var i = 0; i < str.Length - 1; i++)
                    {
                        textBox1.Text += str[i];
                    }
                }
                else
                    textBox1.Text = "";
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                Log.Fatal(exception.Message);
            }
        }

        private void buttonCassetes_Click(object sender, EventArgs e)
        {
            try
            {
                var loading = new Formatfiles();
                _open = new OpenFileDialog
                {
                    Filter = Resources.Form1_buttonCassetes_Click____json___csv___xml___txt____json___csv___xml___txt
                };
                if (_open.FileName == "")
                {
                    if (_open.ShowDialog() != DialogResult.OK) return;
                    _list = loading.Loading(_open.FileName);
                    _bankomat.InputCassettes(_list);
                    Log.Info("Input Cassetes");
                }
                DisplayMoney();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                Log.Fatal(exception.Message);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Log.Info("Exit");
            Application.Exit();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (_open.FileName == string.Empty || _list.Count==0)
                {
                    MessageBox.Show(@"Кассеты не вставлены");
                }
                string pattern = @"[0-9]";
                Match isMatch = Regex.Match(textBox1.Text, pattern, RegexOptions.IgnoreCase);
                if (!isMatch.Success || Convert.ToInt32(textBox1.Text) <= 0)
                {
                    textBox1.BackColor = Color.Yellow;
                    textBox1.Text = string.Empty;
                }
                var money = _bankomat.Withdraw(Convert.ToInt32(textBox1.Text), _open.FileName);
                Log.Info("Sum:"+Convert.ToInt32(textBox1.Text));
                for (var i = 0; i < money.Count; i++)
                {
                    if (money[i] != 0)
                        richTextBox1.Text += money[i] + " " + _list[i].Nominal + "\n";
                }
                textBox1.Text = string.Empty;
            }
            catch (Exception exception)
            {
                Log.Fatal(exception.Message);
                MessageBox.Show(exception.Message);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;
            textBox1.BackColor = Color.White;
        }

        public void button10_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null) textBox1.Text += button.Text;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox1.BackColor = Color.White;
        }

      private void buttonDelete_Click(object sender, EventArgs e)
        {
            _bankomat.DeleteCassetes();
            _open.FileName = string.Empty;
            MessageBox.Show(@"Кассеты удалены");
            Log.Info("Delete Cassetes");
          richTextBox1.Text = string.Empty;
        }
    }
}
