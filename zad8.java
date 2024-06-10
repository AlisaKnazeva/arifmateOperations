import java.util.Random;
import java.util.Scanner;

public class zad8 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Random random = new Random();

        System.out.println("Добро пожаловать в игру \"Угадай число\"!");
        System.out.print("Введите минимальное значение диапазона: ");
        int min = scanner.nextInt();
        System.out.print("Введите максимальное значение диапазона: ");
        int max = scanner.nextInt();

        int numberToGuess = random.nextInt(max - min + 1) + min;
        int guessedNumber = 0;
        boolean guessed = false;

        System.out.println("Программа загадала число в диапазоне от " + min + " до " + max);

        while (!guessed) {
            System.out.print("Угадайте число или введите \"Сдаюсь!\": ");

            if (scanner.hasNextInt()) {
                guessedNumber = scanner.nextInt();

                if (guessedNumber == numberToGuess) {
                    System.out.println("Поздравляем, вы угадали число!");
                    guessed = true;
                } else if (guessedNumber < numberToGuess) {
                    System.out.println("Загаданное число больше");
                } else {
                    System.out.println("Загаданное число меньше");
                }
            } else {
                String input = scanner.next();
                if (input.equalsIgnoreCase("Сдаюсь!")) {
                    System.out.println("Правильный ответ: " + numberToGuess);
                    break;
                } else {
                    System.out.println("Введите корректное значение или \"Сдаюсь!\"");
                }
            }
        }

        scanner.close();
    }
}