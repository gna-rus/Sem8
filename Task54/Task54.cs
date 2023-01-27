/*Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2*/


Console.Clear();

int[,] FillMatrix(int[,] matr) // метод заполнения и вывода на экран матрицы со случайно сгенерированными числами
{
    Random rnd = new Random();
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            matr[i, j] = rnd.Next(0, 11);// присвоение элементу матрицы значения от 0 до 10            
        }
        Console.WriteLine();
    }
    return matr;
}

int[,] SortMatrix(int[,] matr) // метод сортировки матрицы по строкам
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        int max = matr[i, 0];
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            for (int n = 0; n <  matr.GetLength(1) - j - 1; n++) // реализация пузырковой сортировки
            {
                if (matr[i, n] < matr[i, n + 1])
                {
                    max = matr[i, n + 1];
                    matr[i, n + 1] = matr[i, n];
                    matr[i, n] = max;
                }
            }
        }        
    }
    return matr;
}

void PrintMatrix(int[,] matr) // метод заполнения и вывода на экран матрицы
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            Console.Write($"{matr[i, j]} "); // вывод на экран результата генерации
        }
        Console.WriteLine();
    }
}

int[,] matrix = new int[4, 4];
matrix = FillMatrix(matrix); // заполнение массива случайными числами и возвращенеие результата
PrintMatrix(matrix); // вывод сгенерированной матрицы на экран
Console.WriteLine();
matrix = SortMatrix(matrix);
PrintMatrix(matrix); // вывод отсортированной матрицы