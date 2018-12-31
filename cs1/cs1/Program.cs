using System;
using System.IO;

namespace cs1
{
    public class Patronage
    {
        public static string path = @"..\..\deepDive\";
        public static int quantityDirectory;
        public static Guid[] folderNames;

        public static int getNumberFromUser(int number, int rangeBottom, int rangeTop)
        {
            bool flag = false;

            do
            {
                Console.WriteLine("Podaj liczbę w zakresie " + rangeBottom + " - " + rangeTop);
                flag = Int32.TryParse(Console.ReadLine(), out number);
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

            return number;
        }

        public static bool closedQuestion(string questions)
        {
            ConsoleKey response;
            do
            {
                Console.Write(questions + "[y/n] ");
                response = Console.ReadKey(false).Key;
                if (response != ConsoleKey.Enter)
                {
                    Console.WriteLine();
                }
            } while (response != ConsoleKey.Y && response != ConsoleKey.N);

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
                try
                {
                    Directory.Delete(path + folderNames, true);
                    //Console.WriteLine("Folder skasowany");
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
            else
            {
                Console.WriteLine("Folder nie istniał");
                return true;
            }
        }

        public static void drownItDown()
        {
            Console.WriteLine("3. DrownItDown:");
            Console.WriteLine("Tworzenie pliku na wybranym poziomie\n");

            if (null == folderNames)
            {
                Console.WriteLine("Może najpierw stworzyć foldery na pliki ? Użyj funkcji 2. DeepDive z menu głównego, aby stworzyć foldery na pliki tworzone przez funkcję DrownItDown");

                string questionDeepDive = "Czy chcesz teraz wybrać funkcję DeepDive";
                
                if (true == closedQuestion(questionDeepDive))
                {
                    deepDive();
                }
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

                Console.WriteLine("\nPlik został utworzony. Naciśnij enter aby powrócić do menu");
            }
        }

        public static void deepDive()
        {
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
            Console.WriteLine("\nIle folderów chcesz utworzyć:");

            quantityDirectory = getNumberFromUser(quantityDirectory, 1, 5);

            folderNames = new Guid[quantityDirectory];

            string deepPath = path;

            for (int i = 0; i < quantityDirectory; i++)
            {
                folderNames[i] = Guid.NewGuid();
                System.IO.Directory.CreateDirectory(deepPath + folderNames[i]);
                deepPath = deepPath + folderNames[i] + "\\";
            }

            Console.WriteLine("\nStruktura folderów została stworzona. Naciśnij enter aby powrócić do menu");
        }
        
        public static void fizzBuzz()
        {
            Console.WriteLine("1. FizzBuzz");
            Console.WriteLine("Czy liczba jest podzielna przez 2 - Fizz, przez 3 - Buzz czy przez 2 i 3 - FizzBuzz:");

            int numberFizzBuzz = 0;
            numberFizzBuzz = getNumberFromUser(numberFizzBuzz, 0, 1000);

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
            Console.WriteLine("\nNaciśnij enter aby powrócić do menu");
        }

        public static void Main()
        {
            char choice = ' ';

            for (;;)
            {
                Console.Clear();
                Console.WriteLine("Co mogę dla ciebie zrobić ;) ?");
                Console.WriteLine("1. FizzBuzz");
                Console.WriteLine("2. DeepDive");
                Console.WriteLine("3. DrownItDown");
                Console.WriteLine("4. Exit");

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
                        
                        if (folderNames != null)
                        {
                            deleteDirectory(path, folderNames[0]);
                        }

                        System.Environment.Exit(1);
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("To niepoprawna wartość, nie wiem co mam zrobić ?");
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}
