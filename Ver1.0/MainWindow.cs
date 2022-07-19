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

            dataGridView1.DataSource = DataTable(mainTables);
        
        }

        public DataTable DataTable (List<string> list)
        {
            string[] mainColumnsName = 
            {"Дата изготовления", 
             "Наименование изделия", 
             "Код изделия", 
             "Цех", 
             "Класс бетона",
             "Марка бетона",
             "№ состава",
             "a",
             "b",
             "c",
             "Допустимая отпускная прочность"
            };

            string[] optionColumnsName =
            {
                "Дата",
                "Вес",
                "Прочность",
                "Средняя прочность",
                "%"
            };

            List<string[]> columnsName = new List<string[]>();

            DataTable dt = new DataTable();

            if(list.GetHashCode() == mainTables.GetHashCode())
            {
               foreach(string s in mainColumnsName)
                {
                    dt.Columns.Add(s);
                }
            }
            else
            {
                foreach (string s in optionColumnsName)
                {
                    dt.Columns.Add(s);
                }
            }
            return dt;
        }
    }
}
