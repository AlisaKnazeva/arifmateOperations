import javax.swing.JOptionPane;
import java.util.Random;

public class zad2 {
    public static void main(String[] args) {
        int n = Integer.parseInt(JOptionPane.showInputDialog("Введите количество строк:"));
        int m = Integer.parseInt(JOptionPane.showInputDialog("Введите количество столбцов:"));

        if (n <= 0 || m <= 0) {
            JOptionPane.showMessageDialog(null, "Пожалуйста, введите корректные значения для размерности матрицы.");
        } else {
            int[][] matrix = new int[n][m];
            Random rand = new Random();

            int min = Integer.MAX_VALUE;
            int max = Integer.MIN_VALUE;

            StringBuilder matrixOutput = new StringBuilder("Сгенерированная матрица:\n");

            for (int i = 0; i < n; i++) {
                for (int j = 0; j < m; j++) {
                    matrix[i][j] = rand.nextInt(100);
                    matrixOutput.append(matrix[i][j]).append(" ");

                    if (matrix[i][j] < min) {
                        min = matrix[i][j];
                    }
                    if (matrix[i][j] > max) {
                        max = matrix[i][j];
                    }
                }
                matrixOutput.append("\n");
            }

            matrixOutput.append("\nМинимальное значение: ").append(min);
            matrixOutput.append("\nМаксимальное значение: ").append(max);

            StringBuilder rowSumsOutput = new StringBuilder("\nСуммы элементов для каждой строки:\n");
            for (int i = 0; i < n; i++) {
                int sum = 0;
                for (int j = 0; j < m; j++) {
                    sum += matrix[i][j];
                }
                rowSumsOutput.append("Строка ").append(i+1).append(": ").append(sum).append("\n");
            }

            StringBuilder colSumsOutput = new StringBuilder("\nСуммы элементов для каждого столбца:\n");
            for (int j = 0; j < m; j++) {
                int sum = 0;
                for (int i = 0; i < n; i++) {
                    sum += matrix[i][j];
                }
                colSumsOutput.append("Столбец ").append(j+1).append(": ").append(sum).append("\n");
            }

            JOptionPane.showMessageDialog(null, matrixOutput.toString() + rowSumsOutput.toString() + colSumsOutput.toString());
        }
    }
}