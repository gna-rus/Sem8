/*Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)*/

Console.Clear();

int[,,] Fill3DMatrix(int[,,] matr) // метод заполнения  3D матрицы случайными и не повторяющимися числами
{
    int[] mark = new int[150];

    int rndNum = 0;
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            for (int k = 0; k < matr.GetLength(2); k++)
            {
                rndNum = KeepOfNums(mark); // проверка на уникальность числа и генерация нового числа
                mark = SaveOfNums(rndNum, mark); // заполнение массива уникальных чисел                
                matr[i, j, k] = rndNum;
            }

        }
    }  

    return matr;
}
int KeepOfNums(int[] arr)
{
    int rndNum = 0;
    Random rnd = new Random();

    while (true) // цикл, который не прирвется пока не сгенерирует уникальное число
    {
        bool markForNum = true;
        rndNum = rnd.Next(10, 100); // генерируем число для проверки его на уникальность
        for (int i = 0; i < arr.Length; i++) // проверяющий цикл, находится ли число в массиве уникальных чисел
        {
            if (rndNum == arr[i])
            {
                markForNum = false;
            }
        }
        if (markForNum == true) break;
    }

    return rndNum; // возвращается уникальное число
}

int[] SaveOfNums(int num, int[] arr) // массив заполнения уникальных чисел (0 принимается за null так как 0 не входит в диапазон генерации)
{
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] == 0)
        {
            arr[i] = num;
            break;
        }
    }
    return arr;
}


void Print3DMatrix(int[,,] matr) // метод вывода на экран 3D матрицу в виде N слайсов (разрезов)
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            for (int k = 0; k < matr.GetLength(2); k++)
            {
                Console.Write($"{matr[i, j, k]} "); // вывод на экран результата генерации
            }
            Console.WriteLine();
        }
        Console.WriteLine();

    }
}
int[,,] array3D = new int[4, 4, 4];

array3D = Fill3DMatrix(array3D);
Print3DMatrix(array3D);