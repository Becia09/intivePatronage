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
        //public static bool directory = false;
        public static string path = @"..\..\deepDive\";        // lub "..\\..\\deepDive\\";         //. - folder bin/debug; .. - folder wyżej
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

        public static bool closedQuestion(string questions)
        {
            ConsoleKey response;
            do
            {
                Console.Write(questions + "[y/n] ");
                response = Console.ReadKey(false).Key;   // true is intercept key (dont show), false is show
                if (response != ConsoleKey.Enter)
                    Console.WriteLine();

            } while (response != ConsoleKey.Y && response != ConsoleKey.N);
            Console.WriteLine("Odpowiedź: " + response);

            if (response == ConsoleKey.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool deleteDirectory(string path, Guid folderNames)
        {
            if (Directory.Exists(path + folderNames))
            {
                Console.WriteLine("Czy folder istnieje: " + Directory.Exists(path + folderNames));
                //Directory.Delete(path + folderNames[0], true);
                try
                {
                    Directory.Delete(path + folderNames, true);
                    Console.WriteLine("Folder skasowany");
                    return true;
                }
                catch (IOException)
                {
                    Console.WriteLine("Nie udało się skasować folderu: " + folderNames + ", na ścieżce: " + path + ", być może inny program (np. explorator windows) go używa");
                    string deleteDirectoryAgain = "Czy spróbować ponownie skasować folder folderNames";
                    if (closedQuestion(deleteDirectoryAgain))
                    {
                        deleteDirectory(path, folderNames);
                    }
                    return false;
                }
            }
            else  //jeśli tablica z nazwami jest zainicjalizowana, a folderu nie ma
            {
                Console.WriteLine("Folder nie istniał");
                return true;
            }
        }

        public static void drownItDown()
        {
            Console.WriteLine("3. DrownItDown:");
            Console.WriteLine("Tworzenie pliku na wybranym poziomie");

            if (null == folderNames)
            {
                Console.WriteLine("Może najpierw stworzyć foldery na pliki ? Użyj funkcji 2. DeepDive z menu głównego, aby stworzyć foldery na pliki tworzone przez funkcję DrownItDown");

                string questionDeepDive = "Czy chcesz teraz wybrać funkcję DeepDive";
                
                if (true == closedQuestion(questionDeepDive))
                {
                    deepDive();
                }
                
                /*ConsoleKey response;
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
                }*/
            }
            else
            {
                int fileLevel = 0;
                fileLevel = getNumberFromUser(fileLevel, 1, quantityDirectory);
                string fileName = "plik.txt";

                string filePath = path;

                for (int i = 0; i < fileLevel; i++)
                {
                    filePath = filePath + folderNames[i] + "\\";
                }
                filePath = System.IO.Path.Combine(filePath, fileName);
                Console.WriteLine("Ścieżka do pliku: " + filePath);

                bool fileCreate = false;
                if (false == File.Exists(filePath))
                {
                    fileCreate = true;
                }
                else
                {
                    string questionOverwriting = "Plik już istnieje - czy nadpisać ?";
                    if (true == closedQuestion(questionOverwriting))
                    {
                        fileCreate = true;
                        Console.WriteLine("Plik już istniał - nadpisanie:");
                    }
                }

                if (true == fileCreate)
                {
                    //StreamWriter f = File.CreateText(filePath);
                    //f.Close();
                    try
                    {
                        StreamWriter f = File.CreateText(filePath);
                        f.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Nie udało się utworzyć pliku");
                    }
                }

                /*else
                {
                    FileStream("text" + nr + ".txt", FileMode.CreateNew);
                }*/
                /*if (!System.IO.File.Exists(filePath))
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
                }*/
                Console.WriteLine("Plik został utworzony. Naciśnij enter aby powrócić do menu");
            }
        }

        public static void deepDive()
        {
            //directory = true;
            if (folderNames != null)
            {
                Console.WriteLine("Struktura folderów została już utworzona przez funkcję DeepDive:");
                string questionDirectory = "Czy chcesz stworzyć nową strukturę folderów ?";
                if (true == closedQuestion(questionDirectory))
                {
                    deleteDirectory(path, folderNames[0]);
                    folderNames = null;
                }
                else
                {
                    return;
                }
            }
            Console.WriteLine("Ile folderów chcesz utworzyć:");

            //int quantityDirectory = 0;

            quantityDirectory = getNumberFromUser(quantityDirectory, 1, 5);

            //string path = @"..\..\";        //. - folder bin/debug; .. - folder wyżej
            folderNames = new Guid[quantityDirectory];
            Console.WriteLine(quantityDirectory);

            string deepPath = path;

            for (int i = 0; i < quantityDirectory; i++)         //iteracyjnie
            {
                //folderNames.Add(Guid.NewGuid());
                folderNames[i] = Guid.NewGuid();//Guid.NewGuid().ToString();
                //Console.WriteLine(folderNames[i]);
                System.IO.Directory.CreateDirectory(deepPath + folderNames[i]);
                deepPath = deepPath + folderNames[i] + "\\";
                //Console.WriteLine("Ścieżka do ostatniego folderu: " + deepPath);
                //Console.WriteLine("Ścieżka do pierwszego folderu: " + path);
            }

            /*string deepPathRecursion = path;
            int j = 0;
            string createDirectory(int quantityDirectory, string deepPathRec)
            {
                if (quantityDirectory == 1)
                {
                    folderNames[j] = Guid.NewGuid();
                    System.IO.Directory.CreateDirectory(deepPathRecursion + folderNames[j]);
                    return deepPathRecursion + folderNames[j] + "\\";
                }
                j++;
                return createDirectory(quantityDirectory - 1, deepPathRec);
            }
            Console.WriteLine("Ścieżka po createDirectory: " + deepPathRecursion);
            deepPathRecursion = createDirectory(quantityDirectory, deepPathRecursion);
            Console.WriteLine("Ścieżka2 po createDirectory: " + deepPathRecursion);*/

            Console.WriteLine("Struktura folderów została stworzona. Naciśnij enter aby powrócić do menu");
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
            Console.WriteLine("Naciśnij enter aby powrócić do menu");
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
                        drownItDown();
                        break;

                    case '4':
                        Console.Clear();
                        Console.WriteLine("Wybierasz 4. Exit");
                        
                        if (folderNames != null)        //czy tablica jest zainicjalizowana
                        {
                            deleteDirectory(path, folderNames[0]);
                            //Console.WriteLine("Folder: " + path + folderNames[0]);
                            //if (directory)
                            /*if (Directory.Exists(path + folderNames[0]))
                            {
                                Console.WriteLine("Czy folder istnieje: " + Directory.Exists(path + folderNames[0]));
                                //Directory.Delete(path + folderNames[0], true);
                                try
                                {
                                    Directory.Delete(path + folderNames[0], true);
                                }
                                catch (IOException)
                                {
                                    Console.WriteLine("Nie udało się skasować folderu: " + folderNames[0] + ", na ścieżce: " + path);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Czy folder istnieje: " + Directory.Exists(path + folderNames[0]));
                            }*/
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
/*zrobić:
 v kasowanie folderów przy ponownym użyciu deepdiv (w oparciu np. o flagę directory albo if (folderNames != null))
 v przerobić na funkcję opcję y/n
 v pytać czy nadpisać plik
 * przerobić for w funkcji tworzącej foldery na rekurencję
 * dopisać wyjątki
 */

/*Pytania do zadania:
 * czy zrobić obiektowo (na klasach niestatycznych ?
 * czy zrobić np. żeby po funkcji fizzbuzz wyświetlało się pytanie czy uruchomić tą funkcję ponownie ?
*/
