import java.util.Scanner;
import java.util.Random;

public class zad4 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.println("Введите длину массива:");
        int n = scanner.nextInt();

        System.out.println("Введите значение x:");
        int x = scanner.nextInt();
        System.out.println("Введите значение y:");
        int y = scanner.nextInt();

        int[] arr = new int[n];
        Random random = new Random();

        System.out.print("Сгенерированный массив: ");
        int sum = 0;
        for (int i = 0; i < n; i++) {
            arr[i] = random.nextInt(2*y+1) - y;
            sum += arr[i];
            System.out.print(arr[i] + " ");
        }

        double average = (double)sum / n;

        System.out.println("\nСумма элементов массива: " + sum);
        System.out.println("Среднее арифметическое элементов массива: " + average);
    }
}