using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Matrix6Lab
{
    public static class MatrixExtensions 
    {
        //Транспортация 
         public static MatrixInf MatrixTransposition(this MatrixInf A)
         {
             for (int IndexColumn = 0; IndexColumn < A.SizeN; IndexColumn++)
             {
                 for (int IndexRow = 0; IndexRow < A.SizeN; IndexRow++)
                 {
                     A.arry[IndexColumn, IndexRow] = A.arry[IndexRow, IndexColumn];
                 }
             }
             return A;
         }
        public static double MatrixTrace(this MatrixInf matrix)
        {
            double Result = 0;
            for (int IndexColumn = 0; IndexColumn < matrix.SizeN; ++IndexColumn)
            {
                for (int IndexRow = 0; IndexRow < matrix.SizeN; ++IndexRow)
                {
                    if (IndexColumn == IndexRow)
                    {
                        Result += matrix.arry[IndexColumn, IndexRow];
                    }
                }
            }
            return Result;
        }
    }

    class MatrixCalculator
    {
        public void Start()
        {
            Console.WriteLine("Размерность Квадратной Матрицы: ");
            MatrixInf MatrixA = new MatrixInf();
            MatrixA.SizeN = Convert.ToInt32(Console.ReadLine());
            MatrixInf MatrixB = new MatrixInf();
            MatrixB.SizeN = Convert.ToInt32(Console.ReadLine());
            var RandomNumber = new Random((int)Stopwatch.GetTimestamp());
            for (int IndexColumn = 0; IndexColumn < MatrixA.SizeN; ++IndexColumn)
            {
               for (int IndexRow = 0; IndexRow < MatrixA.SizeN; ++IndexRow)
               {
                  MatrixA.arry[IndexColumn, IndexRow] = RandomNumber.Next(10, 100);
                  MatrixB.arry[IndexColumn, IndexRow] = RandomNumber.Next(10, 100);
               }
            }
            Console.WriteLine("Заполненые матрицы:");
            Console.WriteLine(MatrixA.ToString());
            Console.WriteLine(MatrixB.ToString());

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("\n1. Генерация Матриц\n2. Вычисление 2х матриц\n3. Найти Определитель матрицы А\n4. Обратная матрица А\n5. Транспортирование матрицы А\n6. Сумма элементов диагонали Матрицы А\n7.Диагональный вид матрицы А\n8. Вывести матрицу\n9.Выход");
                Console.WriteLine("\nВыберите действие:");
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        FillMatrix(MatrixA,MatrixB);
                        break;
                    case "2":
                         CalculationsMenu(MatrixA,MatrixB);
                        break;
                    case "3":
                        Console.WriteLine($"Determinant of MatrixA: {MatrixA.Determ(MatrixA)}");
                        break;
                    case "4":
                        MatrixInf inverseA = MatrixA.Inverse(MatrixA);
                        Console.WriteLine($"Инверсия Матрицы:\n{inverseA}");
                        break;
                    case "5":
                        var transposedMatrix = MatrixA.MatrixTransposition();
                        Console.WriteLine("Транспонированная матрица:");
                        Console.WriteLine(transposedMatrix);
                        break;
                    case "6":
                        double trace = MatrixA.MatrixTrace();
                        Console.WriteLine($"След матрицы: {trace}\n");
                        break;
                    case "7":
                        ConvertToDiagonal(MatrixA);
                        break;
                    case "8":
                        PrintMatrix(MatrixA);
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте снова.\n");
                        break;
                }
            }
        }
        private void FillMatrix(MatrixInf A, MatrixInf B)
        {
            Console.WriteLine("Заполненые матрицы:");
            Console.WriteLine(A.ToString());
            Console.WriteLine(B.ToString());
        }
        private void CalculationsMenu(MatrixInf A, MatrixInf B)
        {
            Console.WriteLine("Выберите действие\n1. Сложение\n2. Вычитание\n3. Умножение\n4. Деление\n5. Проверить на равность\n6. Сравнение >\n7. Сравнение <\n8. Сравнение >=\n9. Сравнение <=");
            string choice = Console.ReadLine();
            switch(choice)
            {
                case "1":
                    Console.WriteLine($"MatrixA + MatrixB \n{A + B}");
                    break;
                case "2":
                    Console.WriteLine($"MatrixA - MatrixB \n{A - B}");
                    break;
                case "3":
                    Console.WriteLine($"MatrixA * MatrixB \n{A * B}");
                    break;
                case "4":
                    Console.WriteLine($"MatrixA / MatrixB \n{A / B}");
                    break;
                case "5":
                    Console.WriteLine($"MatrixA == MatrixB: {A == B}");
                    break;
                case "6":
                    Console.WriteLine($"MatrixA > MatrixB: {A > B}");
                    break;
                case "7":
                    Console.WriteLine($"MatrixA < MatrixB: {A < B}");
                    break;
                case "8":
                    Console.WriteLine($"MatrixA >= MatrixB: {A >= B}");
                    break;
                case "9":
                    Console.WriteLine($"MatrixA <= MatrixB: {A <= B}");
                    break;
                default:
                    Console.WriteLine("Нету такого выбора!");
                    break;
            }
        }

        private void ConvertToDiagonal(MatrixInf A)
        {
            Action<MatrixInf> convertDelegate = delegate (MatrixInf matrix) {
                for (int Column = 0; Column < matrix.SizeN; Column++)
                {
                    for (int Row = 0; Row < matrix.SizeN; Row++)
                    {
                        if (Column != Row)
                            matrix.arry[Column, Row] = 0;
                    }
                }
            };

            A.ConvertToDiagonal(convertDelegate);
            Console.WriteLine("Матрица приведена к диагональному виду.\n");
        }

        private void PrintMatrix(MatrixInf A)
        {
            Console.WriteLine("Матрица:");
            Console.WriteLine(A);
        }

    }

}
