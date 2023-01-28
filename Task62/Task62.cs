/*Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07*/

Console.Clear();

int InputNumber(string Logo) // метод ввод числа
{
    int num;
    while (true)
    {
        Console.WriteLine(Logo);
        if (int.TryParse(Console.ReadLine(), out num))
            break;
        Console.WriteLine("Ошибка ввода");
    }
    return num;
}

void PrintMatrix(int[,] matr) // метод вывода на экран матрицы
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            Console.Write(String.Format("{0,4}", matr[i, j])); // вывод на экран результата генерации           
        }
        Console.WriteLine();
    }
}

int[,] FillMatrixSize(int[,] matr) //заполнение матрицы по спирали
{
    int lenMatr = matr.GetLength(0) * matr.GetLength(1);
    int row = 0; // заполняет матрицу начиная с позиции 0,0
    int col = 0;
    int dx = 1;
    int dy = 0;
    int dirChanges = 0;
    int vis = matr.GetLength(1);

    for (int i = 1; i < lenMatr + 1; i++) // цикл заполнения
    {
        matr[row, col] = i;
        if (--vis == 0)
        {
            vis = matr.GetLength(1) * (dirChanges % 2) + matr.GetLength(0) * ((dirChanges + 1) % 2) - (dirChanges / 2 - 1) - 2; // формуза заполнения матрицы
            int temp = dx;
            dx = -dy;
            dy = temp;
            dirChanges++;
        }

        col += dx;
        row += dy;
    }
    return matr;
}

int colm = InputNumber("Введите количество столбцов"); // ввод размерностей матрицы
int row = InputNumber("Введите количество строк");

int[,] matrix = new int[row, colm];
int count = 0;
matrix = FillMatrixSize(matrix); // заполняем матрицу по спирали
PrintMatrix(matrix);