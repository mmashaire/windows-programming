using System;

namespace MatrixOperations {
  class Program {
    private static Random random = new Random();

    private static int[, ] GenerateRandomMatrix(int rows, int columns) {
      int[, ] matrix = new int[rows, columns];
      for (int i = 0; i < rows; i++) {
        for (int j = 0; j < columns; j++) {
          matrix[i, j] = random.Next(1, 10); // Generates random values between 1 and 9
        }
      }
      return matrix;
    }

    // Method to print a matrix
    private static void PrintMatrix(int[, ] matrix) {
      int rows = matrix.GetLength(0);
      int columns = matrix.GetLength(1);

      for (int i = 0; i < rows; i++) {
        for (int j = 0; j < columns; j++) {
          Console.Write(matrix[i, j] + "\t"); // Print each element of the matrix followed by a tab
        }
        Console.WriteLine(); // Move to the next line after printing a row
      }
    }

    // Method to add two matrices
    private static int[, ] AddMatrices(int[, ] matrix1, int[, ] matrix2) {
      int rows1 = matrix1.GetLength(0);
      int columns1 = matrix1.GetLength(1);

      int[, ] result = new int[rows1, columns1];

      for (int i = 0; i < rows1; i++) {
        for (int j = 0; j < columns1; j++) {
          result[i, j] = matrix1[i, j] + matrix2[i, j]; // Add corresponding elements
        }
      }

      return result; // Return the resulting matrix after addition
    }

    // Method to subtract two matrices
    private static int[, ] SubtractMatrices(int[, ] matrix1, int[, ] matrix2) {
      int rows1 = matrix1.GetLength(0);
      int columns1 = matrix1.GetLength(1);

      int[, ] result = new int[rows1, columns1];

      for (int i = 0; i < rows1; i++) {
        for (int j = 0; j < columns1; j++) {
          result[i, j] = matrix1[i, j] - matrix2[i, j]; // Subtract corresponding elements
        }
      }

      return result; // Return the resulting matrix after subtraction
    }

    // Method to multiply two matrices
    private static int[, ] MultiplyMatrices(int[, ] matrix1, int[, ] matrix2) {
      int rows1 = matrix1.GetLength(0);
      int columns1 = matrix1.GetLength(1);
      int rows2 = matrix2.GetLength(0);
      int columns2 = matrix2.GetLength(1);

      // Check if matrices can be multiplied
      if (columns1 != rows2) {
        Console.WriteLine("Matrix dimensions are not compatible for multiplication.");
        return null; // Return null to indicate an error
      }

      int[, ] result = new int[rows1, columns2];

      for (int i = 0; i < rows1; i++) {
        for (int j = 0; j < columns2; j++) {
          result[i, j] = 0;
          for (int k = 0; k < columns1; k++) {
            result[i, j] += matrix1[i, k] * matrix2[k, j];
          }
        }
      }

      return result; // Return the resulting matrix after multiplication
    }

    static void Main(string[] args) {
      // Generate random dimensions for matrices
      int rows1 = random.Next(1, 6); // Random number of rows between 1 and 5
      int columns1 = random.Next(1, 6); // Random number of columns between 1 and 5
      int rows2 = random.Next(1, 6); // Random number of rows between 1 and 5
      int columns2 = random.Next(1, 6); // Random number of columns between 1 and 5

      // Generate random matrices with the determined dimensions
      int[, ] matrix1 = GenerateRandomMatrix(rows1, columns1);
      int[, ] matrix2 = GenerateRandomMatrix(rows1, columns1);

      Console.WriteLine("Matrix 1:");
      PrintMatrix(matrix1);

      Console.WriteLine("Matrix 2:");
      PrintMatrix(matrix2);

      // Calculate and print results
      int[, ] sum = AddMatrices(matrix1, matrix2);
      int[, ] subtraction = SubtractMatrices(matrix1, matrix2);
      matrix2 = new int[columns1, rows1];
      matrix2 = GenerateRandomMatrix(columns1, rows1);
      int[, ] multiplication = MultiplyMatrices(matrix1, matrix2);

      if (sum != null) {
        Console.WriteLine("Sum:");
        PrintMatrix(sum);
      }

      if (subtraction != null) {
        Console.WriteLine("Subtraction:");
        PrintMatrix(subtraction);
      }

      if (multiplication != null) {
        Console.WriteLine("Multiplication:");
        PrintMatrix(multiplication);
      }
    }
  }
}