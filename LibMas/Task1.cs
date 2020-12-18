using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LibMas
{
    public class Task1
    {
        /// <summary>
        /// Генерирует числа распределенные в диапазоне от 0 до 20.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public  int[] Rand(int n)
        {
            Random Rnd = new Random();
            int[] mas = new int[n];

            for (int t = 0; t < mas.Length; t++)
            {
                mas[t] = Rnd.Next(0, 20);
            }

            return mas;

        }

        /// <summary>
        /// Очищает одномерный массив случайными значениями
        /// </summary>
        /// <param name="mas">очищаемый одномерный массив</param>
        public  void ClearMass(ref int[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = 0;
            }
        }
        /// <summary>
        /// Сохранение одномерного массива в файл
        /// </summary>
        /// <param name="mas">сохраняемый одномерный массив</param>
        /// <param name="path">путь к файлу</param>
        public  void SaveArray(int[] mas, string path)
        {
            //Создание потока для работы с файлом, на запись
            using (StreamWriter saveFile = new StreamWriter(path))
            {
               
                saveFile.WriteLine(mas.Length); //Запись кол-во столбцов
                for (int i = 0; i < mas.Length; i++) //Запись элемнтов массива
                {
                    saveFile.WriteLine(mas[i]);
                }
            }
        }

        /// <summary>
        /// Открытие одномерного масиива из файла
        /// </summary>
        /// <param name="mas">открываемый одномерный массив</param>
        /// <param name="path">путь к файлу</param>
        public  void OpenArray(ref int[] mas, string path)
        {
            
            using (StreamReader readFile = new StreamReader(path))//Создание потока для работы с файлом, на чтение
            {
               
                int columns = Convert.ToInt32(readFile.ReadLine()); //Чтение кол-во столбцов из файла  
                for (int i = 0; i < columns; i++)//Чтение элемнтов из файла
                {
                    mas[i] = Convert.ToInt32(readFile.ReadLine());
                }
            }
        }


    }
}

