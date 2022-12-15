namespace lab9._1_graph_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num = 0;
            try
            {
                num = Convert.ToInt32(textBox1.Text);
                if (num <= 0)
                {
                    MessageBox.Show("Длина слова не может иметь отрицательное или нулевое значение!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Неверный ввод данных!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string path = @"D:\Учебная практика\Задание 9\lab9.1(console)\lab9.1(console)\TextFile1.dat";
            string[] read = null;
            try
            {
                read = new StreamReader(path).ReadToEnd().Split(new char[] { '!', '?', ';', '.', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            }
            catch
            {
                MessageBox.Show("Неудалось считать файл", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Считывание файла и разделение его на массив строк с помощью разделителей
            bool flag = false;
            string summ = "";
            foreach (var line in read) //проход по всем строкам
            {
                foreach (var word in line.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)) //проход по всем словам
                {
                    if (word.Length == num)
                    {
                        summ = summ + " " + word + Environment.NewLine;
                        flag = true;
                    }

                }
            }
            if (!flag)
            {
                MessageBox.Show("Таких слов в тексте нет", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            textBox2.Text = summ + Environment.NewLine;
        }
    }
}