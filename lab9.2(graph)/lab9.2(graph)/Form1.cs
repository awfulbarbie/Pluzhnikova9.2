namespace lab9._2_graph_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += button1_Click;
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = 0;
            try
            {

                if (numericUpDown1.Value <= 0)
                {
                    MessageBox.Show("Длина строки не может иметь отрицательное или нулевое значение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
            }
            catch
            {
                MessageBox.Show("Неверный ввод данных", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            n = (int)numericUpDown1.Value;

            string path1 = @"D:\Учебная практика\Задание 9\1.txt";
            string path2 = @"D:\Учебная практика\Задание 9\2.txt";
            StreamReader reader = new StreamReader(path1);
            string[] text = null;
            string text2 = " ";
            try
            {
                text = new StreamReader(path1).ReadToEnd().Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            }
            catch
            {
                MessageBox.Show("Не удалось считать файл", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            bool flag = false;
            foreach (var lines in text)
            {
                if (lines.Length > n)
                {
                    text2 += lines;
                    flag = true;
                }
            }
            reader.Close();

            using (FileStream file = new FileStream(path2, FileMode.Open))
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    if (flag)
                    {
                        writer.WriteLine(text2);
                    }
                    else
                    {
                        writer.WriteLine("Отсутствуют строки заданной длины");
                    }

                }
            }


            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;     // получаем выбранный файл
            string fileText = System.IO.File.ReadAllText(filename);  // читаем файл в строку
            textBox1.Text = fileText;
            MessageBox.Show("Файл открыт");
        }
    }
}