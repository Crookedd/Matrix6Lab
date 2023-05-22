﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix6Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Размерность Квадратной Матрицы: ");
            int Size = int.Parse(Console.ReadLine());
            MatrixInf MatrixA = new MatrixInf(Size);
            MatrixInf MatrixB = new MatrixInf(Size);
            // MatrixInf MatrixC;
            MatrixA.Generate();
            MatrixB.Generate();
            Console.WriteLine(MatrixA.ToString());
            Console.WriteLine(MatrixB.ToString());

            Console.WriteLine("\nВыберите какую операцию хотите совершить над Матрицей(ами): ");
            Console.WriteLine("1. Сложение\n2. Вычитание\n3. Умножение\n4. Деление\n5. Проверить на равность\n6. Сравнение >\n7. Сравнение <\n8. Сравнение >=\n" +
                "6=9. Сравнение <=\n10. Найти Определитель\n11. Обратная матрица\n");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine($"MatrixA + MatrixB \n{MatrixA + MatrixB}");
                    break;
                case "2":
                    Console.WriteLine($"MatrixA - MatrixB \n{MatrixA - MatrixB}");
                    break;
                case "3":
                    Console.WriteLine($"MatrixA * MatrixB \n{MatrixA * MatrixB}");
                    break;
                case "4":
                    Console.WriteLine($"MatrixA / MatrixB \n{MatrixA / MatrixB}");
                    break;
                case "5":
                    Console.WriteLine($"MatrixA == MatrixB: {MatrixA == MatrixB}");
                    break;
                case "6":
                    Console.WriteLine($"MatrixA > MatrixB: {MatrixA > MatrixB}");
                    break;
                case "7":
                    Console.WriteLine($"MatrixA < MatrixB: {MatrixA < MatrixB}");
                    break;
                case "8":
                    Console.WriteLine($"MatrixA >= MatrixB: {MatrixA >= MatrixB}");
                    break;
                case "9":
                    Console.WriteLine($"MatrixA <= MatrixB: {MatrixA <= MatrixB}");
                    break;
                case "10":
                    Console.WriteLine($"Determinant of MatrixA: {MatrixA.Determ(MatrixA)}");
                    break;
                case "11":
                    var inverseA = MatrixA.Inverse(MatrixA);
                    Console.WriteLine($"Инверсия Матрицы:\n{inverseA}");
                    break;
                default:
                    Console.WriteLine("Нету такого выбора!");
                    break;
            }
            Console.ReadKey();
        }
    }
}
