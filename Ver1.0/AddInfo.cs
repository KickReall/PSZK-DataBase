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

        Dictionary<string, string> paths = new Dictionary<string, string>()
        {
            {"comboBox1",@"System/ConstTabs/objectsName.txt"},
            {"comboBox2",@"System/ConstTabs/objectsID.txt"},
            {"comboBox3",@"System/ConstTabs/factory.txt"},
            {"comboBox4",@"System/ConstTabs/concreteClass.txt"},
            {"comboBox5",@"System/ConstTabs/concreteGrade.txt"},
            {"comboBox6",@"System/ConstTabs/compositionNumber.txt"},
            {"comboBox7",@"System/ConstTabs/permissibleStrength.txt"},
            {"result",@"System/ConstTabs/compliteObjects.txt"}
        };
        Dictionary<string, int> links = new Dictionary<string, int>()
        {
            {"comboBox1",0},
            {"comboBox2",1},
            {"comboBox3",2},
            {"comboBox4",3},
            {"comboBox5",4},
            {"comboBox6",5},
            {"textBox2",6},
            {"textBox3",7},
            {"textBox4",8},
            {"comboBox7",9},
            
        };

        public AddInfo(MainWindow form)
        {
            InitializeComponent();
            mainWindows = form;
            groupBox3.Enabled = false;
            groupBox5.Enabled = false;
            setLists();
        }
        
        public void setLists()
        {
            foreach (Control cb in groupBox2.Controls)
            {
                if (cb.Name.Contains("comboBox"))
                {
                    switch (cb.Name)
                    {
                        case "comboBox2":
                            break;

                        default:
                            foreach (string str in File.ReadAllLines(paths[cb.Name]).ToList())
                            {
                                if (str != "" && str != null)
                                {
                                    ((ComboBox)cb).Items.Add(str);
                                }
                            }
                            break;
                            
                    }
                }
            }
        }

        public void setCompliteObjectsParameters() 
        {
            foreach(string str in File.ReadAllLines(paths["result"]).ToList())
            {
                if (str != "" && str != null)
                {
                    if ((str.Split(";"))[1] == comboBox2.Text)
                    {
                        foreach (Control c in groupBox2.Controls)
                        {
                            if (!c.Name.Contains("label"))
                            {
                                switch (c.Name)
                                {
                                    case "comboBox1":
                                        break;
                                    case "comboBox2":
                                        break;
                                    case "textBox1":
                                        break;
                                    default:
                                        c.Text = (str.Split(";"))[links[c.Name]];
                                        break;
                                }
                            }

                        }
                    }
                }
            }
        }

        public void setObjectsID()
        {
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(
                File.ReadAllLines(paths["comboBox2"]).ToList().ElementAt
                (
                File.ReadAllLines(paths["comboBox1"]).ToList().IndexOf(comboBox1.Text)
                )
                .Split(";")
                );
        }

        public void saveInf()
        {
            bool check = false;
            string result = "";
            foreach(Control c in groupBox2.Controls) 
            {
                if (!c.Name.Contains("label") && c.Name != "textBox1")
                {
                    result += c.Text + ";";
                }
                if (!c.Name.Contains("textBox") && !c.Name.Contains("label"))
                {
                    switch (c.Name)
                    {
                        case "comboBox1":
                            if (checkSave(c.Name, c.Text))
                            {
                                using (StreamWriter write = new StreamWriter(paths[c.Name], true))
                                {
                                    write.WriteLine(c.Text);
                                }
                                check = true;
                            }
                            break;
                        case "comboBox2":
                            if (!check)
                            {
                                if (checkSave(c.Name, c.Text, "id"))
                                {
                                    string[] strings = File.ReadAllLines(paths[c.Name]).ToArray();
                                    strings[File.ReadAllLines(paths["comboBox1"]).ToList().IndexOf(comboBox1.Text)] += ";" + c.Text;
                                    File.WriteAllLines(paths[c.Name], strings);

                                }
                            }
                            else
                            {
                                using (StreamWriter write = new StreamWriter(paths[c.Name], true))
                                {
                                    write.WriteLine(c.Text);
                                }
                                check = false;
                            }
                            break;
                        default:
                            if (checkSave(c.Name, c.Text))
                            {
                                using (StreamWriter write = new StreamWriter(paths[c.Name], true))
                                {
                                    write.WriteLine(c.Text);
                                }
                            }
                            break;

                    }
                }
            }
            result = result.TrimEnd(';');
            if (checkSave("result", result))
            {
                using (StreamWriter write = new StreamWriter(paths["result"], true))
                {
                    write.WriteLine(result);
                }
            }

        }

        public bool checkSave(string name, string text)
        {
            foreach (string str in File.ReadAllLines(paths[name]).ToList())
            {
                if (text == str)
                {
                    return false;
                }
            }
            return true;
        }
        public bool checkSave(string name, string text, string type)
        {
            foreach (string str in File.ReadAllLines(paths[name]).ToList())
            {
                if (str.Contains(text))
                {
                    return false;
                }
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "";
            string s2 = "";
            string s3 = "";

            foreach(Control grp in Controls)
            {
                switch (grp.Name)
                {
                    case "groupBox2":
                        foreach(Control c in grp.Controls)
                        {
                            if (!c.Name.Contains("label"))
                            {
                                if (c.Text == "" || c.Text == null)
                                {
                                    MessageBox.Show("Вы не ввели данные.");
                                    return;
                                }

                                s += c.Text + ";";
                            }
                        }
                        break;
                    case "groupBox3":
                        if (groupBox3.Enabled || (groupBox3.Enabled && groupBox5.Enabled))
                        {
                            foreach (Control c in grp.Controls)
                            {
                                if (!c.Name.Contains("label"))
                                {
                                    s2 += c.Text + ";";
                                }
                            }
                        }
                        break;
                    case "groupBox5":
                        if (groupBox3.Enabled && groupBox5.Enabled)
                        {
                            foreach (Control c in grp.Controls)
                            {
                                if (!c.Name.Contains("label"))
                                {
                                    s3 += c.Text + ";";
                                }
                            }
                        }
                        break;
                }
            }

            saveInf();
            mainWindows.setInfo(s, s2, s3);
            Hide();
        }

        private void checkBoxes(object sender, EventArgs e)
        {
            if (!checkBox1.Checked && !checkBox2.Checked)
            {
                groupBox3.Enabled = false;
                groupBox5.Enabled = false;
            }
            else if (checkBox1.Checked && !checkBox2.Checked || checkBox2.Checked && !checkBox1.Checked)
            {
                groupBox3.Enabled = true;
                groupBox5.Enabled = false;
            }
            else
            {
                groupBox3.Enabled = true;
                groupBox5.Enabled = true;
            }
        }

        private void comboBoxes(object sender, EventArgs e)
        {
            switch (((ComboBox)sender).Name) 
            {
                case "comboBox4":
                    comboBox5.SelectedIndex = comboBox4.SelectedIndex;
                    comboBox7.SelectedIndex = comboBox4.SelectedIndex;
                    break;
                case "comboBox5":
                    comboBox4.SelectedIndex = comboBox5.SelectedIndex;
                    comboBox7.SelectedIndex = comboBox5.SelectedIndex;
                    break;
                case "comboBox7":
                    comboBox4.SelectedIndex = comboBox7.SelectedIndex;
                    comboBox5.SelectedIndex = comboBox7.SelectedIndex;
                    break;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Control cb in groupBox2.Controls)
            {
                if (!cb.Name.Contains("label"))
                {
                    if (cb.Name != "textBox1" && cb.Name != "comboBox2" && cb.Name != "comboBox1")
                    {
                        cb.Text = "";
                    }
                }
            }
            setCompliteObjectsParameters();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Control cb in groupBox2.Controls)
            {
                if (!cb.Name.Contains("label"))
                {
                    if (cb.Name != "textBox1" && cb.Name != "comboBox1" && cb.Name != "comboBox2")
                    {
                        cb.Text = "";
                    }
                }
            }
            setObjectsID();
        }
    }
}
