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
                    MessageBox.Show("����� ����� �� ����� ����� ������������� ��� ������� ��������!", "������",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("�������� ���� ������!", "������",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string path = @"D:\������� ��������\������� 9\lab9.1(console)\lab9.1(console)\TextFile1.dat";
            string[] read = null;
            try
            {
                read = new StreamReader(path).ReadToEnd().Split(new char[] { '!', '?', ';', '.', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            }
            catch
            {
                MessageBox.Show("��������� ������� ����", "������",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // ���������� ����� � ���������� ��� �� ������ ����� � ������� ������������
            bool flag = false;
            string summ = "";
            foreach (var line in read) //������ �� ���� �������
            {
                foreach (var word in line.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)) //������ �� ���� ������
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
                MessageBox.Show("����� ���� � ������ ���", "��������������",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            textBox2.Text = summ + Environment.NewLine;
        }
    }
}