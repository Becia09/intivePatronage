using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs1
{
    public class Patronage
    {
        public static bool directory = false;
        public static string path = @"..\..\deepDive\";        //. - folder bin/debug; .. - folder wyżej
        public static int quantityDirectory;// = folderNames.Count;
        //public static List<Guid> folderNames = new List<Guid>();
        public static Guid[] folderNames;// = new Guid[10];

        public static int getNumberFromUser(int number, int rangeBottom, int rangeTop)
        {
            bool flag = false;

            do
            {
                Console.WriteLine("Podaj liczbę w zakresie " + rangeBottom + " - " + rangeTop);
                flag = Int32.TryParse(Console.ReadLine(), out number);
                //Console.WriteLine(number);
                if (flag == false)
                {
                    Console.WriteLine("Wartość niepoprawna, spróbuj jeszcze raz");
                }
                else if (number < rangeBottom || number > rangeTop)
                {
                    flag = false;
                    Console.WriteLine("Podana liczba jest mniejsza od " + rangeBottom + " lub większa od " + rangeTop + ", spróbuj jeszcze raz");
                }
            }
            while (flag == false);

            //Console.WriteLine(number);
            return number;
        }

        public static void drownItDown()
        {
            Console.WriteLine("3. DrownItDown:");
            Console.WriteLine("Tworzenie pliku na wybranym poziomie");

            if (directory == false)
            {
                Console.WriteLine("Może najpierw stworzyć foldery na pliki ? Użyj funkcji 2. DeepDive z menu głównego, aby stworzyć foldery na pliki tworzone przez funkcję DrownItDown");
                ConsoleKey response;
                do
                {
                    Console.Write("Czy chcesz teraz wybrać funkcję DeepDive [y/n] ");
                    response = Console.ReadKey(false).Key;   // true is intercept key (dont show), false is show
                    if (response != ConsoleKey.Enter)
                        Console.WriteLine();

                } while (response != ConsoleKey.Y && response != ConsoleKey.N);
                Console.WriteLine(response);
                if (response == ConsoleKey.Y)
                {
                    deepDive();
                }
            }
            else
            {
                int fileLevel = 0;
                fileLevel = getNumberFromUser(fileLevel, 1, 5);
                string fileName = "plik";

                string filePath = path;

                for (int i = 0; i < fileLevel; i++)
                {
                    filePath = filePath + folderNames[i] + "\\";
                }
                filePath = System.IO.Path.Combine(filePath, fileName);
                Console.WriteLine("Ścieżka do pliku: " + filePath);
                if (!System.IO.File.Exists(filePath + fileName))
                {
                    using (System.IO.FileStream fs = System.IO.File.Create(filePath + fileName))
                    {
                        for (byte i = 0; i < 100; i++)
                        {
                            fs.WriteByte(i);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("File \"{0}\" already exists.", fileName);
                    return;
                }
            }
        }

        public static void deepDive()
        {
            directory = true;
            Console.WriteLine("2. DeepDive");
            Console.WriteLine("Ile folderów chcesz utworzyć:");

            //int quantityDirectory = 0;

            quantityDirectory = getNumberFromUser(quantityDirectory, 1, 5);

            //string path = @"..\..\";        //. - folder bin/debug; .. - folder wyżej
            folderNames = new Guid[quantityDirectory];
            Console.WriteLine(quantityDirectory);

            string deepPath = path;

            for (int i = 0; i < quantityDirectory; i++)
            {
                //folderNames.Add(Guid.NewGuid());
                folderNames[i] = Guid.NewGuid();//Guid.NewGuid().ToString();
                Console.WriteLine(folderNames[i]);
                System.IO.Directory.CreateDirectory(deepPath + folderNames[i]);
                deepPath = deepPath + folderNames[i] + "\\";
                Console.WriteLine("Ścieżka do ostatniego folderu: " + deepPath);
                Console.WriteLine("Ścieżka do pierwszego folderu: " + path);
            }
        }
        
        public static void fizzBuzz()
        {
            Console.WriteLine("1. FizzBuzz");
            Console.WriteLine("Czy liczba jest podzielna przez 2 - Fizz, przez 3 - Buzz czy przez 2 i 3 - FizzBuzz:");

            int numberFizzBuzz = 0;
            numberFizzBuzz = getNumberFromUser(numberFizzBuzz, 0, 1000);

            //int number = Console.ReadLine() ;
            //Console.WriteLine("Podaj numer w zakresie 0 - 1000");
            //int number = 0;
            //bool flag = false;

            /*do
            {
                Console.WriteLine("Podaj liczbę w zakresie 0 - 1000");
                flag = Int32.TryParse(Console.ReadLine(), out number);
                //Console.WriteLine(number);
                if (flag == false)
                {
                    Console.WriteLine("Wartość niepoprawna, spróbuj jeszcze raz");
                }
                else if (number < 0 || number > 1000)
                {
                    flag = false;
                    Console.WriteLine("Podana liczba jest mniejsza od 0 lub większa od 1000, spróbuj jeszcze raz");
                }
            }
            while (flag == false);*/

            //Console.WriteLine(numberFizzBuzz);
            if ((numberFizzBuzz % 2 == 0) && (numberFizzBuzz % 3 == 0))
            {
                Console.WriteLine("FizzBuzz");
            }
            else if (numberFizzBuzz % 2 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if (numberFizzBuzz % 3 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else
            {
                Console.WriteLine("Ani Fizz ani Buzz :D");
            }

            //Console.WriteLine("Może jeszcze raz ?");                      ????
        }

        public static void Main()
        {
            /*ConsoleKey response;
            do
            {
                Console.Write("Are you sure you want to choose this as your login key? [y/n] ");
                response = Console.ReadKey(false).Key;   // true is intercept key (dont show), false is show
                if (response != ConsoleKey.Enter)
                    Console.WriteLine();

            } while (response != ConsoleKey.Y && response != ConsoleKey.N);
            Console.WriteLine(response);*/

            //Guid g;
            // Create and display the value of two GUIDs.
            //g = Guid.NewGuid();
            //Console.WriteLine(g);
            //Console.WriteLine(Guid.NewGuid());

            char choice = ' ';

            for (;;)
            {
                Console.Clear();
                Console.WriteLine("Co mogę dla ciebie zrobić ;) ?");
                Console.WriteLine("1. FizzBuzz");
                Console.WriteLine("2. DeepDive");
                Console.WriteLine("3. DrownItDown");
                Console.WriteLine("4. Exit");

                //choice = Console.ReadLine();    //wybor
                choice = Console.ReadKey(true).KeyChar;

                Console.WriteLine(choice);

                switch (choice)
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine("Wybierasz 1. FizzBuzz:");
                        fizzBuzz();
                        break;

                    case '2':
                        Console.Clear();
                        Console.WriteLine("Wybierasz 2. DeepDive:");
                        deepDive();
                        break;

                    case '3':
                        Console.Clear();
                        Console.WriteLine("Wybierasz 3. DrownItDown:");
                        break;

                    case '4':
                        Console.Clear();
                        Console.WriteLine("Wybierasz 4. Exit");
                        if (directory)
                        //if (Directory.Exists(path))
                        {
                            Console.WriteLine(Directory.Exists(path));
                            Directory.Delete(path + folderNames[0], true);
                        }
                        System.Environment.Exit(1);
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("To niepoprawna wartość, nie wiem co mam zrobić ?");
                        break;
                }
                Console.ReadKey();
                //Console.Clear();
            }
        }
    }
}
