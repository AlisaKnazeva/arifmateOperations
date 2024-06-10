import javax.swing.JOptionPane;
import java.util.Random;

public class zad6 {
    public static void main(String[] args) {
        int n = 0;
        int x = 0;
        int y = 0;

        boolean correctInput = false;
        while (!correctInput) {
            try {
                n = Integer.parseInt(JOptionPane.showInputDialog("Введите размерность матрицы n:"));
                x = Integer.parseInt(JOptionPane.showInputDialog("Введите значение x:"));
                y = Integer.parseInt(JOptionPane.showInputDialog("Введите значение y:"));

                correctInput = true;
            } catch (NumberFormatException e) {
                JOptionPane.showMessageDialog(null, "Пожалуйста, введите целые числа.");
            }
        }

        int[][] matrix1 = generateMatrix(n, x);
        int[][] matrix2 = generateMatrix(n, y);
        int[][] productMatrix = multiplyMatrices(matrix1, matrix2);

        StringBuilder dialogMessage = new StringBuilder("Первая матрица:\n");
        dialogMessage.append(matrixToString(matrix1));

        dialogMessage.append("\n\nВторая матрица:\n");
        dialogMessage.append(matrixToString(matrix2));

        dialogMessage.append("\n\nРезультат умножения матриц:\n");
        dialogMessage.append(matrixToString(productMatrix));

        JOptionPane.showMessageDialog(null, dialogMessage.toString());
    }

    public static int[][] generateMatrix(int n, int range) {
        int[][] matrix = new int[n][n];
        Random random = new Random();
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                matrix[i][j] = random.nextInt(2 * range + 1) - range;
            }
        }
        return matrix;
    }

    public static int[][] multiplyMatrices(int[][] matrix1, int[][] matrix2) {
        int n = matrix1.length;
        int[][] result = new int[n][n];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                for (int k = 0; k < n; k++) {
                    result[i][j] += matrix1[i][k] * matrix2[k][j];
                }
            }
        }
        return result;
    }

    public static String matrixToString(int[][] matrix) {
        StringBuilder sb = new StringBuilder();
        for (int[] row : matrix) {
            for (int num : row) {
                sb.append(num).append(" ");
            }
            sb.append("\n");
        }
        return sb.toString();
    }
}