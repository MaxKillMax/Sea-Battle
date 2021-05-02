using System;
namespace SeaBattle
{
    class Program
    {
        // Приветствие
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте!");
            Console.WriteLine("Надо ввести значения ширины и высоты карты");
            Console.WriteLine("Желательно вводить значения не меньше 6");
            CreateMapRandom();
        }

        // Настройки генерации
        static void CreateMapRandom()
        {
            Console.Write("Ширина: ");
            string a = Console.ReadLine();
            Console.Write("Высота: ");
            string b = Console.ReadLine();
            DigitsOnly(a, b);
        }

        // Метод распознавания чисел
        static void DigitsOnly(string a, string b)
        {
            bool Stop = false;
            foreach (char c in a)
            {
                if (c < '0' || c > '9')
                {
                    Console.WriteLine("Ширина записана неверно");
                    Stop = true;
                }
            }

            foreach (char c in b)
            {
                if (c < '0' || c > '9')
                {
                    Console.WriteLine("Высота записана неверно");
                    Stop = true;
                }
            }

            if (!Stop)  Output(Convert.ToInt32(a), Convert.ToInt32(b));
            else CreateMapRandom();
        }

        // Метод генерации и вывода карты в консоль
        static void Output(int a, int b)
        {
            // Расширенный режим показа информации
            Console.WriteLine("Включить расширенный показ информации?");
            Console.WriteLine("Чтобы включить, введите '1'");
            bool MoreInfo = false;
            if (Console.ReadLine() == "1") MoreInfo = true;

            // Генерация карты
            Map map = new Map(a, b, MoreInfo);

            // Вывод информации о карте
            int Rows = map.Grid.GetUpperBound(0) + 1;
            int Columns = map.Grid.Length / Rows;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (map.Grid[i, j] == true) Console.Write("X");
                    else Console.Write("O");
                }
                Console.WriteLine();
            }
        }
    }
}
