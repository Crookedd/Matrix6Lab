using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix6Lab
{
    class MatrixCalculator
    {
        public void Start()
        {
            Console.WriteLine("Размерность Квадратной Матрицы: ");
            int Size = int.Parse(Console.ReadLine());
            MatrixInf MatrixA = new MatrixInf(Size);
            MatrixInf MatrixB = new MatrixInf(Size);
            Console.WriteLine("Заполнение матрицы:");
            MatrixA.Generate();
            MatrixB.Generate();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("\n1. Генерация Матриц\n2Вычисление 2х матриц\n3. Найти Определитель матрицы А\n4. Обратная матрица А\n5. Транспортирование матрицы А\n6. Сумма элементов диагонали Матрицы А\n7.Диагональный вид матрицы А\n8. Вывести матрицу\n9.Выход");
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
                        DetermMatrix(MatrixA); 
                        break;
                    case "4":
                        InversMatrix(MatrixA);
                        break;
                    case "5":
                        TransposeMatrix(MatrixA);
                        break;
                    case "6":
                        CalculateTrace(MatrixA);
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

        private void DetermMatrix(MatrixInf A)
        {
            Console.WriteLine($"Determinant of MatrixA: {A.Determ(A)}");
        }

        private void InversMatrix(MatrixInf A)
        {
            var inverseA = A.Inverse(A);
            Console.WriteLine($"Инверсия Матрицы:\n{inverseA}");
        }
        private void TransposeMatrix(MatrixInf A)
        {
            MatrixInf transposedMatrix = A.MatrixTransposition(A);
            Console.WriteLine("Транспонированная матрица:");
            Console.WriteLine(transposedMatrix);
        }

        private void CalculateTrace(MatrixInf A)
        {
            double trace = A.MatrixTrace(A);
            Console.WriteLine($"След матрицы: {trace}\n");
        }

        private void ConvertToDiagonal(MatrixInf A)
        {
            Action<MatrixInf> convertDelegate = delegate (MatrixInf matrix) {
                for (int Column = 0; Column < matrix.SizeN; Column++)
                {
                    for (int Row = 0; Row < matrix.SizeN; Row++)
                    {
                        if (Column != Row)
                            matrix[Column, Row] = 0;
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
