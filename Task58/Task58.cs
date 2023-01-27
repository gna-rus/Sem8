/*Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18*/

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

void PrintMatrix(int[,] matr) // метод вывода на экран матрицы
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

int[,] Multy2Matrix(int[,] matr1, int[,] matr2) // метод перемножения двух матриц
    {
        int[,] resultMatrix = new int[matr1.GetLength(0),  matr2.GetLength(1)]; // создается результирующая матрица

        for (int i = 0; i < matr1.GetLength(0); i++) // три цикла для перемножения и присвоения результата умножения в результрующую матрицу
        {
            for (int j = 0; j < matr2.GetLength(1); j++)
            {
                for (int k = 0; k < matr2.GetLength(0); k++)
                {
                    resultMatrix[i, j] += matr1[i, k] * matr2[k, j];
                }                
            }            
        }
        return resultMatrix;
    }


int row = 3, colm = 3; // размерность для матриц
int[,] matrix1 = new int[row+1, colm]; // обьявляются прямоугольные матрицы и их размерность
int[,] matrix2 = new int[row, colm+1];
int[,] multyMatrix = new int[row+1, colm+1]; // результирующая матрица
matrix1 = FillMatrix(matrix1); // заполнение массивов случайными числами и возвращенеие результатов
matrix2 = FillMatrix(matrix2); 
PrintMatrix(matrix1); // вывод матрицы на экран
Console.WriteLine();
PrintMatrix(matrix2);
Console.WriteLine();
multyMatrix = Multy2Matrix(matrix1,matrix2); // присвоение результатов перемножения двух матриц
PrintMatrix(multyMatrix);