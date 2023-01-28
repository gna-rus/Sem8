/*Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07*/

Console.Clear();

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

int[,] FillMatrixSize(int[,] matr, int row, int colm, int count)
{
    
        matr[row, colm] = count;
        count++;

        if ((colm < matr.GetLength(0) - 2) & (matr[row, colm+1] == 0))
        {
            FillMatrixSize(matr, row, colm + 1, count);
        }

        else if ((row < matr.GetLength(1) - 2) & (matr[row+1, colm] == 0))
        {
            FillMatrixSize(matr, row + 1, colm, count);
        }
        else if ((colm > 1) & (matr[row, colm-1] == 0))
        {
            FillMatrixSize(matr, row, colm - 1, count);
        }
        else if ((row > 1) & (matr[row-1, colm] == 0))
        {
            FillMatrixSize(matr, row-1, colm, count);
        }        

    return matr;
}

int[,] matrix = new int[8, 8];
int count = 0;
matrix = FillMatrixSize(matrix, 0, 0, count);
PrintMatrix(matrix);