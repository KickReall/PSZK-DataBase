namespace Ver1._0
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            listBox1_SelectedIndexChanged(null, EventArgs.Empty);
            getList();
        }

        public void getList()
        {
            List<string> list;
            try
            {
                list = Directory.GetFiles(@"System\NewTabs\").ToList();
            }
            catch(Exception e)
            {
                MessageBox.Show("Такого пути не существует. Обратитесь в поддержку.");
                return;
            }

            listBox1.Items.Clear();

            foreach(string item in list)
            {
                listBox1.Items.Add(Path.GetFileNameWithoutExtension(item));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!File.Exists(@"System\NewTabs\" + DateTime.Now.Year + " - ЖурналПЗСК.txt"))
            { 
                File.Create(@"System\NewTabs\" + DateTime.Now.Year + " - ЖурналПЗСК.txt").Close();
                File.Create(@"System\NewOptionTabs\" + DateTime.Now.Year + " - ЖурналПЗСК.txt").Close();
                getList();
            }
            else
            {
                MessageBox.Show("В этом году уже создан журнал: " + DateTime.Now.Year + " - ЖурналПЗСК.");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить эту таблицу ?","Предупреждение!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                File.Delete(@"System\NewTabs\" + listBox1.Text + ".txt");
                File.Delete(@"System\NewOptionTabs\" + listBox1.Text + ".txt");
                getList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new MainWindow(listBox1.Text).Show();
            Hide();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex != -1)
            {
                button2.Enabled = true;
                button3.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (listBox1.IndexFromPoint(e.Location) == -1)
            {
                listBox1.SelectedIndex = -1;
                listBox1_SelectedIndexChanged(null, EventArgs.Empty);
            }
        }
    }
}