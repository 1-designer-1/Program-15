using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_11
{
    public class Class1
    {
        /// <summary>
        /// Выводит разницу целых случайных чисел.
        /// </summary>
        /// <param name="mas"></param>
        /// <returns></returns>
        public int Razn(int[] mas)
        {

            int razn = mas[0];// заполнили первый элемент
            for (int i = 1; i < mas.Length; i++) // расчет производится со второго элемента  
            {
                razn -= mas[i];
            }
            return razn;

        }

    }
}
