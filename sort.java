import java.util.Arrays;
import java.util.Scanner;

public class sort {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Введите элементы массива через пробел: ");
        String input = scanner.nextLine();
        String[] elements = input.split(" ");
        int[] array = new int[elements.length];
        for (int i = 0; i < elements.length; i++) {
            array[i] = Integer.parseInt(elements[i]);
        }

        System.out.print("Введите крайнее число: ");
        int maxValue = scanner.nextInt();

        // Сортировка массива по убыванию
        Arrays.sort(array);
        int[] sortedArray = new int[array.length];
        for (int i = 0; i < array.length; i++) {
            sortedArray[i] = array[array.length - 1 - i];
        }

        // Вывод отсортированного массива, исключая значения больше maxValue
        System.out.print("Отсортированный массив без значений больше " + maxValue + ": ");
        for (int num : sortedArray) {
            if (num <= maxValue) {
                System.out.print(num + " ");
            }
        }

        scanner.close();
    }
}