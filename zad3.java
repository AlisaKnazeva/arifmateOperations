import javax.swing.JOptionPane;
import java.util.Random;

public class zad3 {
    public static void main(String[] args) {
        int n = 0;
        try {
            n = Integer.parseInt(JOptionPane.showInputDialog("Введите длину массива:"));
            if (n <= 0) {
                JOptionPane.showMessageDialog(null, "Пожалуйста, введите положительное число для длины массива.");
                return;
            }

            int[] originalArray = new int[n];
            Random rand = new Random();
            StringBuilder originalArrayOutput = new StringBuilder("Исходный массив: ");

            for (int i = 0; i < n; i++) {
                originalArray[i] = rand.nextInt(100);
                originalArrayOutput.append(originalArray[i]).append(" ");
            }

            int[] reversedArray = new int[n];
            StringBuilder reversedArrayOutput = new StringBuilder("\nМассив с обратным порядком элементов: ");

            for (int i = 0; i < n; i++) {
                reversedArray[i] = originalArray[n - 1 - i];
                reversedArrayOutput.append(reversedArray[i]).append(" ");
            }

            JOptionPane.showMessageDialog(null, originalArrayOutput.toString() + reversedArrayOutput.toString());

        } catch (NumberFormatException e) {
            JOptionPane.showMessageDialog(null, "Пожалуйста, введите корректное число для длины массива.");
        }
    }
}