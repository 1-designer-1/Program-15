using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib_11;
using LibMas;

namespace Практическая_работа___2._0
{
    public partial class Form1 : Form
    {
        int[] randomMass; //декларируем массив
        Task1 Arry = new Task1();//декларируем и инцализируем экземпляр класса (LibMas)
        Class1 Add = new Class1();//декларируем и инцализируем экземпляр класса (Lib_11)
        public Form1()
        {
            InitializeComponent();
            dataGridView1.RowCount = 1; // задает фиксирование значение строки 
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Серегин Денис \n" +
               "Практическая работа № 2 \n" +
               "Ввести n целых чисел(>0 или <0). Найти разницу чисел. Результат вывести на экран. \n" +
               "Разработать библиотеку, содержащую базовые модули (функции) программы для работы с любым массивом: сохранить, открыть, заполнить, очистить и т.д. \n" +
               "Разработать библиотеку, содержащую вычислительные модули (функции) программы для решения задачи по варианту задания\n");
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();// закрыть программу
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int number = Convert.ToInt32(textBox1.Text);//получаем от пользователя значение с котогрым будет работать программа
                randomMass = new int[number];//одномерный массив
                randomMass = Arry.Rand(number);//вызываем функцию для генерирования случайных значений массива 
                dataGridView1.ColumnCount = number;// кол-во столбцов 
                                                   //заполнение таблицы случайными числами 
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    dataGridView1[i, 0].Value = randomMass[i];// заполнение каждого элемента таблицы соответсвуюшим номером массива
                }
                //произведенние значений массива 
                textBox3.Text = Add.Razn(randomMass).ToString() + " ";
            }
            catch
            {
                MessageBox.Show("Введите коректные значения","Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e) //очистка таблицы
        {
            textBox1.Clear();
            Arry.ClearMass(ref randomMass);
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1[i, 0].Value = randomMass[i];
                //dataGridView1[i, 0].Value = " "; очистка пустым символом 
            }


        }

        private void button2_Click(object sender, EventArgs e) //сохранить
        {
            //Создание объекта диалогового окна для сохранения
            using (SaveFileDialog save = new SaveFileDialog
            {
                //Установка стандартных свойств
                DefaultExt = ".txt",
                Filter = "Все файлы (*.*) | *.* |Текстовые файлы | *.txt",
                FilterIndex = 2,
                Title = "Сохранение таблицы"
            })
            {
                //Если пользователь нажал ОК
                if (save.ShowDialog() == DialogResult.OK)
                {
                    //Сохранить массив
                    Arry.SaveArray(randomMass, save.FileName);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e) //открыть 
        {
            //Создание объекта диалогового окна для открытия
            using (OpenFileDialog open = new OpenFileDialog
            {
                //Установка стандартных свойств
                DefaultExt = ".txt",
                Filter = "Все файлы (*.*) | *.* |Текстовые файлы | *.txt",
                FilterIndex = 2,
                Title = "Открытие таблицы"
            })
            {
                //Если пользователь нажал ОК
                if (open.ShowDialog() == DialogResult.OK)
                {
                    //Открыть массив
                    int[] arry = randomMass;
                    Arry.OpenArray(ref arry, open.FileName);
                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        dataGridView1[i, 0].Value = arry[i];

                    }

                }
            }

        }
    }
}
