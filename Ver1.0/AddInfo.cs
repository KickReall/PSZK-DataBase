using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ver1._0
{
    public partial class AddInfo : Form
    {
        MainWindow mainWindows;

        public AddInfo(MainWindow form)
        {
            InitializeComponent();
            mainWindows = form;
            groupBox5.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "";
            string s2 = "";
            string s3 = "";

            if (!checkBox1.Checked && !checkBox2.Checked)
            {
                foreach (Control a in groupBox2.Controls)
                {
                    if (!a.Name.Contains("label"))
                    {
                        s += a.Text + ";";
                    }
                }
            }
            else
            {
                if (checkBox1.Checked && !checkBox2.Checked || checkBox2.Checked && !checkBox1.Checked)
                {
                    foreach (Control a in groupBox2.Controls)
                    {
                        if (!a.Name.Contains("label"))
                        {
                            s += a.Text + ";";
                        }
                    }
                    foreach (Control a in groupBox3.Controls)
                    {
                        if (!a.Name.Contains("label"))
                        {
                            s2 += a.Text + ";";
                        }
                    }
                }
                else
                {
                    foreach (Control a in groupBox2.Controls)
                    {
                        if (!a.Name.Contains("label"))
                        {
                            s += a.Text + ";";
                        }
                    }
                    foreach (Control a in groupBox3.Controls)
                    {
                        if (!a.Name.Contains("label"))
                        {
                            s2 += a.Text + ";";
                        }
                    }
                    foreach (Control a in groupBox5.Controls)
                    {
                        if (!a.Name.Contains("label"))
                        {
                            s3 += a.Text + ";";
                        }
                    }

                    
                }
            }

            s.TrimEnd(';');
            s2.TrimEnd(';');
            s3.TrimEnd(';');
            mainWindows.setInfo(s, s2, s3);

            Hide();
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!checkBox1.Checked && !checkBox2.Checked)
            {
                groupBox5.Enabled = false;
            }
            else if (checkBox1.Checked && !checkBox2.Checked || checkBox2.Checked && !checkBox1.Checked)
            {
                groupBox5.Enabled = false;
            }
            else
            {
                groupBox5.Enabled = true;
            }
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!checkBox1.Checked && !checkBox2.Checked)
            {
                groupBox5.Enabled = false;
            }
            else if (checkBox1.Checked && !checkBox2.Checked || checkBox2.Checked && !checkBox1.Checked)
            {
                groupBox5.Enabled = false;
            }
            else
            {
                groupBox5.Enabled = true;
            }
        }
    }
}
