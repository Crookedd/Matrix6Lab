using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Matrix6Lab
{
   public  class MatrixInf
    {
        public int SizeN;
        public double[,] arry = new double[10,10];
        public MatrixInf DeepCopy()
        {
            MatrixInf clone = (MatrixInf)this.MemberwiseClone();
            return clone;
        }

        public int CompareTo(MatrixInf other)
        {
            if (other is null)
                return 1;

            if (SizeN != other.SizeN)
                return SizeN.CompareTo(other.SizeN);

            for (int IndexColumn = 0; IndexColumn < SizeN; ++IndexColumn)
            {
                for (int IndexRow = 0; IndexRow < SizeN; ++IndexRow)
                {
                    int compare = arry[IndexColumn, IndexRow].CompareTo(other.arry[IndexColumn, IndexRow]);
                    if (compare != 0)
                        return compare;
                }
            }
            return 0;
        }
        public override bool Equals(object obj)
        {
            if (obj is null || !(obj is MatrixInf))
            {
                return false;
            }
            return this == (MatrixInf)obj;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 20;
                for (int ColumnCounter = 0; ColumnCounter < SizeN; ColumnCounter++)
                {
                    for (int RowCounter = 0; RowCounter < SizeN; RowCounter++)
                    {
                        hashCode = hashCode * 23 + arry[ColumnCounter, RowCounter].GetHashCode();
                    }
                }
                return hashCode;
            }
        }
        //Сложение
        public static MatrixInf operator +(MatrixInf A, MatrixInf B)
        {
            for (int IndexColumn = 0; IndexColumn < A.SizeN; ++IndexColumn)
            {
                for (int IndexRow = 0; IndexRow < A.SizeN; ++IndexRow)
                {
                    A.arry[IndexColumn, IndexRow] = A.arry[IndexColumn, IndexRow] + B.arry[IndexColumn, IndexRow];
                }
            }
            return A;
        }
        //Вычитание
        public static MatrixInf operator -(MatrixInf A, MatrixInf B)
        {
            for (int IndexColumn = 0; IndexColumn < A.SizeN; ++IndexColumn)
            {
                for (int IndexRow = 0; IndexRow < A.SizeN; ++IndexRow)
                {
                    A.arry[IndexColumn, IndexRow] = A.arry[IndexColumn, IndexRow] - B.arry[IndexColumn, IndexRow];
                }
            }
            return A;
        }
        //Умножение 
        public static MatrixInf operator *(MatrixInf A, MatrixInf B)
        {
            for (int IndexColumn = 0; IndexColumn < A.SizeN; ++IndexColumn)
            {
                for (int K = 0; K < A.SizeN; ++K)
                {
                    for (int IndexRow = 0; IndexRow < A.SizeN; ++IndexRow)
                    {
                        A.arry[IndexColumn, K] += A.arry[IndexRow, K] * B.arry[IndexColumn, IndexRow];
                    }
                }
            }
            return A;
        }
        //Деление
        public static MatrixInf operator /(MatrixInf A, MatrixInf B)
        {
            for (int IndexColumn = 0; IndexColumn < A.SizeN; ++IndexColumn)
            {
                for (int IndexRow = 0; IndexRow < A.SizeN; ++IndexRow)
                {
                    try
                    {
                        A.arry[IndexColumn, IndexRow] = A.arry[IndexColumn, IndexRow] / B.arry[IndexColumn, IndexRow];
                    }
                    catch
                    {
                        A.arry[IndexColumn, IndexRow] = 0;
                    }
                }
            }
            return A;
        }
        //Операторы сравнения
        public static bool operator ==(MatrixInf A, MatrixInf B)
        {
            if (A.SizeN != B.SizeN)
            {
                return true;
            }
            for (int IndexColumn = 0; IndexColumn < A.SizeN; ++IndexColumn)
            {
                for (int IndexRow = 0; IndexRow < A.SizeN; ++IndexRow)
                {
                    if (A.arry[IndexColumn, IndexRow] == B.arry[IndexColumn, IndexRow])
                    {
                        return true;
                    }
                }

            }
            return false;
        }
        public static bool operator !=(MatrixInf A, MatrixInf B)
        {
            if (A.SizeN != B.SizeN)
            {
                return true;
            }
            for (int IndexColumn = 0; IndexColumn < A.SizeN; ++IndexColumn)
            {
                for (int IndexRow = 0; IndexRow < A.SizeN; ++IndexRow)
                {
                    if (A.arry[IndexColumn, IndexRow] != B.arry[IndexColumn, IndexRow])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static MatrixInf operator >(MatrixInf A, MatrixInf B)
        {
            for (int IndexColumn = 0; IndexColumn < A.SizeN; ++IndexColumn)
            {
                for (int IndexRow = 0; IndexRow < A.SizeN; ++IndexRow)
                {   
                    if (A.arry[IndexColumn, IndexRow] > B.arry[IndexColumn, IndexRow])
                    {
                        A.arry[IndexColumn, IndexRow] = 1;
                    }
                    else
                    {
                        A.arry[IndexColumn, IndexRow] = 0;
                    }
                }
            }
            return A;
        }
        public static MatrixInf operator <(MatrixInf A, MatrixInf B)
        {
            for (int IndexColumn = 0; IndexColumn < A.SizeN; ++IndexColumn)
            {
                for (int IndexRow = 0; IndexRow < A.SizeN; ++IndexRow)
                {
                    if (A.arry[IndexColumn, IndexRow] < B.arry[IndexColumn, IndexRow])
                    {
                        A.arry[IndexColumn, IndexRow] = 1;
                    }
                    else
                    {
                        A.arry[IndexColumn, IndexRow] = 0;
                    }
                }
            }
            return A;
        }

        public static MatrixInf operator >=(MatrixInf A, MatrixInf B)
        {
            for (int IndexColumn = 0; IndexColumn < A.SizeN; ++IndexColumn)
            {
                for (int IndexRow = 0; IndexRow < A.SizeN; ++IndexRow)
                {
                    if (A.arry[IndexColumn, IndexRow] >= B.arry[IndexColumn, IndexRow])
                    {
                        A.arry[IndexColumn, IndexRow] = 1;
                    }
                    else
                    {
                        A.arry[IndexColumn, IndexRow] = 0;
                    }
                }
            }
            return A;

        }
        public static MatrixInf operator <=(MatrixInf A, MatrixInf B)
        {
            for (int IndexColumn = 0; IndexColumn < A.SizeN; ++IndexColumn)
            {
                for (int IndexRow = 0; IndexRow < A.SizeN; ++IndexRow)
                {
                    if (A.arry[IndexColumn, IndexRow] <= B.arry[IndexColumn, IndexRow])
                    {
                        A.arry[IndexColumn, IndexRow] = 1;
                    }
                    else
                    {
                        A.arry[IndexColumn, IndexRow] = 0;
                    }
                }
            }
            return A;
        }
        //Поиск Минора и по нему находим определитель. 
        public static MatrixInf Minor(MatrixInf A, int Column, int Row)
        {
            MatrixInf buf = new MatrixInf();
            for (int IndexColumn = 0; IndexColumn < A.SizeN; ++IndexColumn)
            {
                for (int IndexRow = 0; IndexRow < A.SizeN; ++IndexRow)
                {
                    if ((IndexRow != Row) || (IndexColumn != Column))
                    {
                        if (IndexColumn > Column && IndexRow < Row) buf.arry[IndexColumn - 1, IndexRow] = A.arry[IndexColumn, IndexRow];
                        if (IndexColumn < Column && IndexRow > Row) buf.arry[IndexColumn, IndexRow - 1] = A.arry[IndexColumn, IndexRow];
                        if (IndexColumn > Column && IndexRow > Row) buf.arry[IndexColumn - 1, IndexRow - 1] = A.arry[IndexColumn, IndexRow];
                        if (IndexColumn < Column && IndexRow < Row) buf.arry[IndexColumn, IndexRow] = A.arry[IndexColumn, IndexRow];
                    }
                }
            }
            return buf;
        }
        public double Determ(MatrixInf A)
        {
            double det = 0;
            int Rank = A.SizeN;
            if (Rank == 1) det = A.arry[0, 0];
            if (Rank == 2) det = A.arry[0, 0] * A.arry[1, 1] - A.arry[0, 1] * A.arry[1, 0];
            if (Rank > 2)
            {
                for (int Index = 0; Index < A.SizeN; ++Index)
                {
                    det += Math.Pow(-1, 0 + Index) * A.arry[0, Index] * Determ(Minor(A, 0, Index));
                }
            }
            return det;
        }

        private MatrixInf SubMatrix(int Row, int Column)
        {
            MatrixInf subMatrix = new MatrixInf();

            int subRow = 0;
            for (int IndexRow = 0; IndexRow < SizeN; ++IndexRow)
            {
                if (IndexRow == Row)
                    continue;
                int subColumn = 0;
                for (int IndexColumn = 0; IndexColumn < SizeN; ++IndexColumn)
                {
                    if (IndexColumn == Column)
                        continue;

                    subMatrix.arry[subColumn, subColumn] = arry[IndexColumn, IndexColumn];
                    ++subColumn;
                }
                ++subRow;
            }
            return subMatrix;
        }

        public MatrixInf Inverse(MatrixInf A)
        {
            var determinant = Determ(A);
            if (determinant == 0)
            {
                throw new InvalidOperationException("Матрица не может инверст.");
            }
            MatrixInf Result = new MatrixInf();

            int sign = 1;
            for (int IndexColumn = 0; IndexColumn < A.SizeN; IndexColumn++)
            {
                for (int IndexRow = 0; IndexRow < A.SizeN; IndexRow++)
                {
                    MatrixInf subMatrix = SubMatrix(IndexColumn, IndexRow);
                    Result.arry[IndexRow, IndexColumn] = sign * subMatrix.Determ(A) / determinant;
                    sign = -sign;
                }
            }

            return Result;

        }

        //Метод для приведения матрицы к диагональному виду с использованием делегата
        public void ConvertToDiagonal(Action<MatrixInf> convertDelegate)
        {
            convertDelegate(this);
        }
        //Вывод Матрицы
        public override string ToString()
        {
            string Result = $"Размеры: {SizeN} x {SizeN}\n";
            Result += "\n-------- Матрица ---------------\n";
            for (int IndexColumn = 0; IndexColumn < SizeN; ++IndexColumn)
            {
                for (int IndexRow = 0; IndexRow < SizeN; ++IndexRow)
                {
                    Result += arry[IndexColumn, IndexRow].ToString() + "\t";
                }
                Result += "\n";
            }
            return Result;

        }
    }
}
