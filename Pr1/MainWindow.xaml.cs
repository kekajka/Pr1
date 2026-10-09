
using System.Windows;
using Microsoft.Win32;
using System.Data;
using LibMas;

namespace Pr1
{
    public partial class MainWindow : Window
    {
        private int[] mas;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Заполнить_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(diapazon.Text, out int randMax))
            {
                MessageBox.Show("Диапазон должен быть целым числом");
                return;
            }

            if (!int.TryParse(columnCount.Text, out int count) || count <= 0)
            {
                MessageBox.Show("Количество ячеек должно быть положительным числом");
                return;
            }

            Massiv.InitMas(out mas, count, randMax);
            dataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
        }

        private void Рассчитать_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.ItemsSource == null)
            {
                MessageBox.Show("Массив пуст");
                return;
            }

            DataView view = (DataView)dataGrid.ItemsSource;
            DataTable table = view.Table;
            List<int> list = new List<int>();

            for (int i = 0; i < table.Columns.Count; i++)
            {
                if (table.Rows[0][i] != DBNull.Value)
                {
                    if (int.TryParse(table.Rows[0][i].ToString(), out int number))
                    {
                        list.Add(number);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка");
                        return;
                    }
                }
            }

            mas = list.ToArray();
            int sum = Calculation.CalculateSum(mas);
            rez.Text = Convert.ToString(sum);
        }

        private void MenuSave_Click(object sender, RoutedEventArgs e)
        {
            if (mas == null)
            {
                return;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*)|*.*|Текстовые файлы | *.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";

            if (save.ShowDialog() == true)
            {
                Massiv.SaveMas(mas, save.FileName);
            }
        }

        private void MenuOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Все файлы (*.*)|*.*|Текстовые файлы | *.txt";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";

            if (open.ShowDialog() == true)
            {
                Massiv.LoadMas(out mas, open.FileName);
                columnCount.Text = Convert.ToString(mas.Length);
                dataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
            }
        }

        private void MenuClear_Click(object sender, RoutedEventArgs e)
        {
            mas = null;
            dataGrid.ItemsSource = null;
            rez.Clear();
        }

        private void MenuAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа №1 Вариант 14 Выполнил Клюев");
        }

        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
           this.Close();
        }
    }
}
