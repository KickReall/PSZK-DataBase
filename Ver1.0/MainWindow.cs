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
    }
}
