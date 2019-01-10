using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreApi
{
    public class FizzBuzz
    {
        private int rangeBottom = 0;    //dać później do pliku config.json
        private int rangeTop = 1000;

        public int WalidateNumber(string num)
        {
            bool flag = false;
            int number = 0;

            flag = Int32.TryParse(num, out number);
            if (false == flag)
            {
                return -1;
                //Console.WriteLine("Wartość niepoprawna, spróbuj jeszcze raz");
            }
            else if (number < rangeBottom || number > rangeTop)
            {
                return -2;
                //Console.WriteLine("Podana liczba jest mniejsza od " + rangeBottom + " lub większa od " + rangeTop + ", spróbuj jeszcze raz");
            }

            return number;
        }

        public string FizzOrBuzz(string number)
        {
            int numberFizzBuzz = 0;
            numberFizzBuzz = WalidateNumber(number);

            if (-1 == numberFizzBuzz)
            {
                return "Wartość niepoprawna, spróbuj jeszcze raz";
            }
            if (-2 == numberFizzBuzz)
            {
                return "Podana liczba jest mniejsza od " + rangeBottom + " lub większa od " + rangeTop + ", spróbuj jeszcze raz";
            }

        if ((numberFizzBuzz % 2 == 0) && (numberFizzBuzz % 3 == 0))
        {
            return "FizzBuzz";
        }

        if (numberFizzBuzz % 2 == 0)
        {
            return "Fizz";
        }

        if (numberFizzBuzz % 3 == 0)
        {
            return "Buzz";
            //Console.WriteLine("Buzz");
        }
            
            return "";
        }


    }
}
