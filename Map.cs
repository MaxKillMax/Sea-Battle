using System;
namespace SeaBattle
{
    class Map
    {
        // Чтобы добавить новый корабль(c новой длиной), надо изменить строчки: 31, 71, 108.
        // Чтобы добавить новый корабль(с уже существующей длиной), надо изменить строчки: 31.

        // Сетка карты
        public bool[,] Grid;
        // Массив кораблей. int означает длину
        private int[] Ships;

        // Переменные для создания корабля
        bool AngleY;
        int _width;
        int _height;
        // Переменные памяти местоположения кораблей
        (int, int) A;
        (int, int) B;
        (int, int) C;
        (int, int) D;
        // Вспомогательные переменные
        Random random;
        bool Continue = false;

        public Map(int width, int height, bool MoreInfo)
        {
            // Подготовка к созданию сетки с кораблями
            Grid = new bool[width, height];
            Ships = new int[10] { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };
            random = new Random();

            // Цикл расстановки всех кораблей
            for (int i = 0; i < Ships.Length; i++)
            {
                // 1-ая стадия цикла: Выбор пустого места на сетке.
                do
                {
                    _height = random.Next(height);
                    _width = random.Next(width);
                    if (!Grid[_width, _height]) Continue = true;
                } while (!Continue);
                A = (_width, _height);
                Continue = false;

                if (random.Next(2) == 1) AngleY = true;
                else AngleY = false;

                // 2-ая стадия цикла: Проверка мест
                if (Ships[i] >= 2)
                {
                    // Проверяет взависимости от длины корабля, свободны ли занимаемые клетки

                    // Проверка по вертикали
                    if (AngleY)
                    {
                        if (_height + 1 < height && !Grid[_width, _height + 1])
                        {
                            B = (_width, _height + 1);
                            if (Ships[i] >= 3)
                            {
                                if (_height + 2 < height && !Grid[_width, _height + 2])
                                {
                                    C = (_width, _height + 2);
                                    if (Ships[i] >= 4)
                                    {
                                        if (_height + 3 < height && !Grid[_width, _height + 3])
                                        {
                                            D = (_width, _height + 3);
                                        }
                                        else
                                        {
                                            i--;
                                            Continue = true;
                                        }
                                    }
                                }
                                else
                                {
                                    i--;
                                    Continue = true;
                                }
                            }
                        }
                        else
                        {
                            i--;
                            Continue = true;
                        }
                    }
                    // Проверка по горизонтали
                    if (!AngleY)
                    {
                        if (_width + 1 < width && !Grid[_width + 1, _height])
                        {
                            B = (_width + 1, _height);
                            if (Ships[i] >= 3)
                            {
                                if (_width + 2 < width && !Grid[_width + 2, _height])
                                {
                                    C = (_width + 2, _height);
                                    if (Ships[i] >= 4)
                                    {
                                        if (_width + 3 < width && !Grid[_width + 3, _height])
                                        {
                                            D = (_width + 3, _height);
                                        }
                                        else
                                        {
                                            i--;
                                            Continue = true;
                                        }
                                    }
                                }
                                else
                                {
                                    i--;
                                    Continue = true;
                                }
                            }
                        }
                        else
                        {
                            i--;
                            Continue = true;
                        }
                    }
                }

                // 3-яя стадия цикла: Расстановка кораблей, если предыдущие стадии прошли без ошибок.
                if (!Continue)
                {
                    Grid[A.Item1, A.Item2] = true;
                    if (Ships[i] >= 2) Grid[B.Item1, B.Item2] = true;
                    if (Ships[i] >= 3) Grid[C.Item1, C.Item2] = true;
                    if (Ships[i] >= 4) Grid[D.Item1, D.Item2] = true;
                }
                Continue = false;
            }

            // Расширенный режим показа информации
            if (MoreInfo)
            {
                foreach (var item in Grid)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
