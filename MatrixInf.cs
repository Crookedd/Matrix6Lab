using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix6Lab
{
    class MatrixInf
    {
        private int Size;
        private double[,] arry;

        public MatrixInf() { }
        public int SizeN
        {
            get { return Size; }
            set { if (value < 0) Size = value; }

        }
        public MatrixInf(int Size)
        {
            this.Size = Size;
            arry = new double[this.Size, this.Size];
        }
        public double this[int ColumnCount, int RowCount]
        {
            get
            {
                return arry[ColumnCount, RowCount];
            }
            set
            {
                arry[ColumnCount, RowCount] = value;
            }
        }

        public void Generate()
        {
            arry = new double[Size, Size];
            var RandomNumber = new Random((int)Stopwatch.GetTimestamp());
            for (int IndexColumn = 0; IndexColumn < Size; ++IndexColumn)
            {
                for (int IndexRow = 0; IndexRow < Size; ++IndexRow)
                {
                    arry[IndexColumn, IndexRow] = RandomNumber.Next(10, 100);
                }
            }
        }
        public MatrixInf DeepCopy()
        {
            MatrixInf clone = (MatrixInf)this.MemberwiseClone();
            return clone;
        }

        public int CompareTo(MatrixInf other)
        {
            if (other is null)
                return 1;

            if (Size != other.Size)
                return Size.CompareTo(other.Size);

            for (int IndexColumn = 0; IndexColumn < Size; ++IndexColumn)
            {
                for (int IndexRow = 0; IndexRow < Size; ++IndexRow)
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
                for (int ColumnCounter = 0; ColumnCounter < Size; ColumnCounter++)
                {
                    for (int RowCounter = 0; RowCounter < Size; RowCounter++)
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
            var Result = new MatrixInf(A.SizeN);
            for (int IndexColumn = 0; IndexColumn < Result.SizeN; ++IndexColumn)
            {
                for (int IndexRow = 0; IndexRow < Result.SizeN; ++IndexRow)
                {
                    Result[IndexColumn, IndexRow] = A[IndexColumn, IndexRow] + B[IndexColumn, IndexRow];
                }
            }
            return Result;
        }
        //Вычитание
        public static MatrixInf operator -(MatrixInf A, MatrixInf B)
        {
            var Result = new MatrixInf(A.SizeN);
            for (int IndexColumn = 0; IndexColumn < Result.SizeN; ++IndexColumn)
            {
                for (int IndexRow = 0; IndexRow < Result.SizeN; ++IndexRow)
                {
                    Result[IndexColumn, IndexRow] = A[IndexColumn, IndexRow] - B[IndexColumn, IndexRow];
                }
            }
            return Result;
        }
        //Умножение 
        public static MatrixInf operator *(MatrixInf A, MatrixInf B)
        {
            var Result = new MatrixInf(A.SizeN);
            for (int IndexColumn = 0; IndexColumn < Result.SizeN; ++IndexColumn)
            {
                for (int K = 0; K < A.SizeN; ++K)
                {
                    for (int IndexRow = 0; IndexRow < Result.SizeN; ++IndexRow)
                    {
                        Result[IndexColumn, K] += A[IndexRow, K] * B[IndexColumn, IndexRow];
                    }
                }
            }
            return Result;
        }
        //Деление
        public static MatrixInf operator /(MatrixInf A, MatrixInf B)
        {
            var Result = new MatrixInf(A.SizeN);
            for (int IndexColumn = 0; IndexColumn < Result.Size; ++IndexColumn)
            {
                for (int IndexRow = 0; IndexRow < Result.SizeN; ++IndexRow)
                {
                    try
                    {
                        Result[IndexColumn, IndexRow] = A[IndexColumn, IndexRow] / B[IndexColumn, IndexRow];
                    }
                    catch
                    {
                        Result[IndexColumn, IndexRow] = 0;
                    }
                }
            }
            return Result;
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
                    if (A[IndexColumn, IndexRow] == B[IndexColumn, IndexRow])
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
                    if (A[IndexColumn, IndexRow] != B[IndexColumn, IndexRow])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static MatrixInf operator >(MatrixInf A, MatrixInf B)
        {
            var Result = new MatrixInf(A.SizeN);
            for (int IndexColumn = 0; IndexColumn < Result.SizeN; ++IndexColumn)
            {
                for (int IndexRow = 0; IndexRow < Result.SizeN; ++IndexRow)
                {
                    if (A[IndexColumn, IndexRow] > B[IndexColumn, IndexRow])
                    {
                        Result[IndexColumn, IndexRow] = 1;
                    }
                    else
                    {
                        Result[IndexColumn, IndexRow] = 0;
                    }
                }
            }
            return Result;
        }
        public static MatrixInf operator <(MatrixInf A, MatrixInf B)
        {
            var Result = new MatrixInf(A.SizeN);
            for (int IndexColumn = 0; IndexColumn < Result.SizeN; ++IndexColumn)
            {
                for (int IndexRow = 0; IndexRow < Result.SizeN; ++IndexRow)
                {
                    if (A[IndexColumn, IndexRow] < B[IndexColumn, IndexRow])
                    {
                        Result[IndexColumn, IndexRow] = 1;
                    }
                    else
                    {
                        Result[IndexColumn, IndexRow] = 0;
                    }
                }
            }
            return Result;
        }

        public static MatrixInf operator >=(MatrixInf A, MatrixInf B)
        {
            var Result = new MatrixInf(A.SizeN);
            for (int IndexColumn = 0; IndexColumn < Result.SizeN; ++IndexColumn)
            {
                for (int IndexRow = 0; IndexRow < Result.SizeN; ++IndexRow)
                {
                    if (A[IndexColumn, IndexRow] >= B[IndexColumn, IndexRow])
                    {
                        Result[IndexColumn, IndexRow] = 1;
                    }
                    else
                    {
                        Result[IndexColumn, IndexRow] = 0;
                    }
                }
            }
            return Result;

        }
        public static MatrixInf operator <=(MatrixInf A, MatrixInf B)
        {
            var Result = new MatrixInf(A.SizeN);
            for (int IndexColumn = 0; IndexColumn < Result.SizeN; ++IndexColumn)
            {
                for (int IndexRow = 0; IndexRow < Result.SizeN; ++IndexRow)
                {
                    if (A[IndexColumn, IndexRow] <= B[IndexColumn, IndexRow])
                    {
                        Result[IndexColumn, IndexRow] = 1;
                    }
                    else
                    {
                        Result[IndexColumn, IndexRow] = 0;
                    }
                }
            }
            return Result;
        }
        //Поиск Минора и по нему находим определитель. 
        public static MatrixInf Minor(MatrixInf A, int Column, int Row)
        {
            MatrixInf buf = new MatrixInf(A.SizeN - 1);
            for (int IndexColumn = 0; IndexColumn < A.SizeN; ++IndexColumn)
            {
                for (int IndexRow = 0; IndexRow < A.SizeN; ++IndexRow)
                {
                    if ((IndexRow != Row) || (IndexColumn != Column))
                    {
                        if (IndexColumn > Column && IndexRow < Row) buf[IndexColumn - 1, IndexRow] = A[IndexColumn, IndexRow];
                        if (IndexColumn < Column && IndexRow > Row) buf[IndexColumn, IndexRow - 1] = A[IndexColumn, IndexRow];
                        if (IndexColumn > Column && IndexRow > Row) buf[IndexColumn - 1, IndexRow - 1] = A[IndexColumn, IndexRow];
                        if (IndexColumn < Column && IndexRow < Row) buf[IndexColumn, IndexRow] = A[IndexColumn, IndexRow];
                    }
                }
            }
            return buf;
        }
        public double Determ(MatrixInf A)
        {
            double det = 0;
            int Rank = A.SizeN;
            if (Rank == 1) det = A[0, 0];
            if (Rank == 2) det = A[0, 0] * A[1, 1] - A[0, 1] * A[1, 0];
            if (Rank > 2)
            {
                for (int Index = 0; Index < A.SizeN; ++Index)
                {
                    det += Math.Pow(-1, 0 + Index) * A[0, Index] * Determ(Minor(A, 0, Index));
                }
            }
            return det;
        }

        private MatrixInf SubMatrix(int Row, int Column)
        {
            var subMatrix = new MatrixInf(Size - 1);

            int subRow = 0;
            for (int IndexRow = 0; IndexRow < Size; ++IndexRow)
            {
                if (IndexRow == Row)
                    continue;
                int subColumn = 0;
                for (int IndexColumn = 0; IndexColumn < Size; ++IndexColumn)
                {
                    if (IndexColumn == Column)
                        continue;

                    subMatrix[subColumn, subColumn] = arry[IndexColumn, IndexColumn];
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
            var Result = new MatrixInf(A.SizeN);

            int sign = 1;
            for (int IndexColumn = 0; IndexColumn < Result.SizeN; IndexColumn++)
            {
                for (int IndexRow = 0; IndexRow < Result.SizeN; IndexRow++)
                {
                    var subMatrix = SubMatrix(IndexColumn, IndexRow);
                    Result[IndexRow, IndexColumn] = sign * subMatrix.Determ(A) / determinant;
                    sign = -sign;
                }
            }

            return Result;
        }
        //Транспортация 
        public MatrixInf MatrixTransposition(MatrixInf A)
        {
            var Result = new MatrixInf(A.SizeN);
            for (int IndexColumn = 0; IndexColumn < A.Size; IndexColumn++)
            {
                for (int IndexRow = 0; IndexRow < A.Size; IndexRow++)
                {
                    Result[IndexColumn, IndexRow] = A[IndexRow, IndexColumn];
                }
            }
            return Result;
        }
        public double MatrixTrace(MatrixInf A)
        {
            double Result = 0;
            for (int IndexColumn = 0; IndexColumn < A.SizeN; ++IndexColumn)
            {
                for (int IndexRow = 0; IndexRow < A.SizeN; ++IndexRow)
                {
                    if (IndexColumn == IndexRow)
                    {
                        Result += A[IndexColumn, IndexRow];
                    }
                }
            }
            return Result;
        }
        // Метод для приведения матрицы к диагональному виду с использованием делегата
        public void ConvertToDiagonal(Action<MatrixInf> convertDelegate)
        {
            convertDelegate(this);
        }
        private void ConvertToDiagonal()
        {
            Action<MatrixInf> convertDelegate = delegate (MatrixInf A) {
                for (int i = 0; i < A.Size; i++)
                {
                    for (int j = 0; j < A.Size; j++)
                    {
                        if (i != j)
                            A[i, j] = 0;
                    }
                }
            };
        }
        //Вывод Матрицы
        public override string ToString()
        {
            string Result = $"Размеры: {Size} x {Size}\n";
            Result += "\n-------- Матрица ---------------\n";
            for (int IndexColumn = 0; IndexColumn < Size; ++IndexColumn)
            {
                for (int IndexRow = 0; IndexRow < Size; ++IndexRow)
                {
                    Result += arry[IndexColumn, IndexRow].ToString() + "\t";
                }
                Result += "\n";
            }
            return Result;

        }
    }
}
