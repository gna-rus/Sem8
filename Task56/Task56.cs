/*Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:

1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7

Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка*/

Console.Clear();

int[,] FillMatrix(int[,] matr) // метод заполнения  матрицы случайно сгенерированными числами
{
    Random rnd = new Random();
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            matr[i, j] = rnd.Next(0, 11); // присвоение элементу матрицы значения от 0 до 10            
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

int FinadMinImMatrix(int[,] matr)
{
    int[] arr = new int[4];
    int MinLine = 0, countForNumberLine = 0; // обьявляются переменная для минимальной суммы и счетчика номеров строк
    for (int i = 0; i < matr.GetLength(1); i++) // поиск первого минимума, чтобы его сравнивать уже с другими строками
    {
        MinLine += matr[0, i];
    }
    
    for (int i = 1; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            arr[j] = matr[i, j]; // заполняется массив состоящий из элементов строки матрицы
        }
        int mark = SumInLine(arr); // вычисление суммы элементов строки
        if (mark < MinLine)
        {
            MinLine = mark;
            countForNumberLine = i;
        }
    }
    return countForNumberLine + 1;
}

int SumInLine(int[] arr) // расчет суммы элементов строки
{
    int sum = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        sum += arr[i];
    }
    return sum;
}

int[,] matrix = new int[4, 4]; // обьявляется матрица и ее размерность
matrix = FillMatrix(matrix); // заполнение массива случайными числами и возвращенеие результата
PrintMatrix(matrix); // вывод сгенерированной матрицы на экран
Console.WriteLine();
Console.WriteLine($"Строка с наименьшей суммой элементов: {FinadMinImMatrix(matrix)}"); //вывод
