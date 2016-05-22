using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubiks_Matrix
{
    class Rubiks_Matrix
    {
        static void Main(string[] args)
        {
            int[,] matrix = GetMatrix();
            int numberOfCommands = int.Parse(Console.ReadLine());
            int[,] rotatedMatrix = CopyMatrix(matrix);
            rotatedMatrix = GetRotatedMatrix(rotatedMatrix, numberOfCommands);
            //PrintMatrix(matrix);
            //PrintMatrix(rotatedMatrix);

            SwapRotatedMatrixBackToOriginal(rotatedMatrix, matrix);
            //PrintMatrix(matrix);
            //PrintMatrix(rotatedMatrix);
        }

        static void SwapRotatedMatrixBackToOriginal(int[,] rotatedMatrix, int[,] targetMatrix)
        {
            int rows = targetMatrix.GetLength(0);
            int cols = targetMatrix.GetLength(1);
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (rotatedMatrix[row, col] == targetMatrix[row, col])
                        Console.WriteLine("No swap required");
                    else
                    {
                        bool foundSwapElement = false;
                        for (int swapRow = row; swapRow < rows; swapRow++)
                        {
                            for (int swapCol = 0; swapCol < cols; swapCol++)
                            {
                                if (rotatedMatrix[swapRow, swapCol] == targetMatrix[row, col] &&
                                    rotatedMatrix[swapRow, swapCol] != rotatedMatrix[row, col])
                                {
                                    Console.WriteLine($"Swap ({row}, {col}) with ({swapRow}, {swapCol})");
                                    rotatedMatrix[swapRow, swapCol] = rotatedMatrix[row, col];
                                    rotatedMatrix[row, col] = targetMatrix[row, col];
                                    foundSwapElement = true;
                                    break;
                                }
                            }
                            if (foundSwapElement) break;
                        }
                    }
                }
            }
        }

        static int[,] GetRotatedMatrix(int[,] matrix, int numberOfCommands)
        {
            for (int command = 0; command < numberOfCommands; command++)
            {
                string[] input = Console.ReadLine().Split(' ').ToArray();
                int rowColToRotate = int.Parse(input[0]);
                string rotationDirection = input[1];
                int numberOfRotations = int.Parse(input[2]);
                bool rowRotation = rotationDirection == "left"
                                || rotationDirection == "right";
                bool colRotation = rotationDirection == "up"
                                || rotationDirection == "down";
                if (rowRotation)
                    numberOfRotations %= matrix.GetLength(1);   // cols
                else if (colRotation)
                    numberOfRotations %= matrix.GetLength(0);   // rows
                for (int rotation = 0; rotation < numberOfRotations; rotation++)
                {
                    if (colRotation)
                        matrix = RotateMatrixCol(matrix, rowColToRotate, rotationDirection);
                    else if (rowRotation)
                        matrix = RotateMatrixRow(matrix, rowColToRotate, rotationDirection);
                }
            }
            return matrix;
        }

        static int[,] RotateMatrixRow(int[,] matrix, int row, string direction)
        {
            int[] rotatedRow = new int[matrix.GetLength(1)];    // cols
            for (int col = 0; col < matrix.GetLength(1); col++) // cols
                rotatedRow[col] = matrix[row, col];
            if (direction == "left")
                rotatedRow = rotatedRow.Skip(1).Take(rotatedRow.Length - 1)
                            .Concat(rotatedRow.Take(1))
                            .ToArray();
            else if (direction == "right")
                rotatedRow = rotatedRow.Skip(rotatedRow.Length - 1).Take(1)
                            .Concat(rotatedRow.Take(rotatedRow.Length - 1))
                            .ToArray();
            for (int col = 0; col < matrix.GetLength(1); col++) // cols
                matrix[row, col] = rotatedRow[col];
            return matrix;
        }

        static int[,] RotateMatrixCol(int[,] matrix, int col, string direction)
        {
            int[] rotatedCol = new int[matrix.GetLength(0)];    // rows
            for (int row = 0; row < matrix.GetLength(0); row++) // rows
                rotatedCol[row] = matrix[row, col];
            if (direction == "down")
                rotatedCol = rotatedCol.Skip(rotatedCol.Length - 1).Take(1)
                            .Concat(rotatedCol.Take(rotatedCol.Length - 1))
                            .ToArray();
            else if (direction == "up")
                rotatedCol = rotatedCol.Skip(1).Take(rotatedCol.Length - 1)
                            .Concat(rotatedCol.Take(1))
                            .ToArray();
            for (int row = 0; row < matrix.GetLength(0); row++) // rows
                matrix[row, col] = rotatedCol[row];
            return matrix;
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)     // rows
            {
                for (int col = 0; col < matrix.GetLength(1); col++) // cols
                    Console.Write("{0} ", matrix[row, col]);
                Console.WriteLine();
            }
        }

        static int[,] CopyMatrix(int[,] matrix)
        {
            int[,] matrixCopy = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int row = 0; row < matrix.GetLength(0); row++)     // rows
            {
                for (int col = 0; col < matrix.GetLength(1); col++) // cols
                    matrixCopy[row, col] = matrix[row, col];
            }
            return matrixCopy;
        }

        static int[,] GetMatrix()
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            int[,] matrix = new int[rows, cols];
            int number = 1;
            for (int row = 0; row < rows; row++)    // 1,2,3...
            {
                for (int col = 0; col < cols; col++)
                    matrix[row, col] = number++;
            }
            return matrix;
        }
    }
}