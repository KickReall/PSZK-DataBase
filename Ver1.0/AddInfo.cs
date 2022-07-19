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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> listA = new List<string>();
            List<string> listB = new List<string>();

            foreach (Control a in groupBox2.Controls)
            {
                if (!a.Name.Contains("label"))
                {
                    listA.Add(a.Text);
                }
            }
            mainWindows.setInfo(listA);
        }
    }
}
