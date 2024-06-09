import java.util.Arrays;
import java.util.Random;

public class MaxElement {
    public static void main(String[] args) {
        Random random = new Random();
        int size = 10; // Размер массива
        int[] array = new int[size];

        // Заполнение массива случайными числами
        for (int i = 0; i < size; i++) {
            array[i] = random.nextInt(100); // Генерация случайного числа от 0 до 99
        }

        // Вывод исходного массива
        System.out.println("Исходный массив: " + Arrays.toString(array));

        // Поиск максимального элемента в массиве
        int maxElement = array[0];
        for (int i = 1; i < size; i++) {
            if (array[i] > maxElement) {
                maxElement = array[i];
            }
        }

        // Вывод максимального элемента
        System.out.println("Максимальный элемент в массиве: " + maxElement);
    }
}