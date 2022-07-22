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
    public partial class MainWindow : Form
    {
        List<string> mainTables = new List<string>();
        List<string> optionTables = new List<string>();
       
        public MainWindow(string name)
        {
            InitializeComponent();
            Start(name);
        }

        public void Start(string name)
        {
            Text = name;
            mainTables = File.ReadAllLines(Path.Combine(@"System\NewTabs", Text + ".txt")).ToList();
            optionTables = File.ReadAllLines(Path.Combine(@"System\NewOptionTabs", Text + ".txt")).ToList();

            updateMainTables();

        }

        public void updateMainTables()
        {
            dataGridView1.Rows.Clear();
            foreach (string s in mainTables)
            {
                dataGridView1.Rows.Add(s.Split(";"));
            }
        }

        private void MainWindow_SizeChanged(object sender, EventArgs e)
        {
            foreach (DataGridView dgv in Controls.OfType<DataGridView>())
            {
                if (dgv.GetHashCode() == dataGridView1.GetHashCode())
                {
                    dgv.Width = (Width / 2)-45;
                    dgv.Location = new Point(12, 36);
                }
                else
                {
                    dgv.Width = Width / 2;
                    dgv.Location = new Point((Width / 2)-25, 36);
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddInfo ai = new AddInfo(this);
            ai.ShowDialog();
        }
        
        public void setInfo(string s, string s2, string s3)
        {
            mainTables.Add(s);
            optionTables.Add(s2);
            optionTables.Add(s3);
            updateMainTables();
        }


    }
}
