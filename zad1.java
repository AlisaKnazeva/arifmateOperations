import java.util.Scanner;
import java.util.Random;

public class zad1 {
    public static void main(String[] args) {
        Scanner inputScanner = new Scanner(System.in);

        System.out.print("Введите длину массива: ");
        int n = inputScanner.nextInt();

        System.out.print("Введите пороговое значение x: ");
        int x = inputScanner.nextInt();

        if (n <= 0 || x < 0) {
            System.out.println("Пожалуйста, введите корректные значения.");
        } else {
            int[] array = new int[n];
            Random rand = new Random();

            System.out.print("Сгенерированный массив: ");
            for (int i = 0; i < n; i++) {
                array[i] = rand.nextInt(100); // Генерация случайного числа от 0 до 99
                System.out.print(array[i] + " ");
            }

            System.out.println("\nИндексы элементов, значения которых превосходят порог " + x + ":");
            for (int i = 0; i < n; i++) {
                if (array[i] > x) {
                    System.out.println("Индекс " + i + ", Значение " + array[i]);
                }
            }
        }

        inputScanner.close();
    }
}