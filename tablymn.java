import java.util.Scanner;

public class tablymn {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Введите число, для которого хотите вывести таблицу умножения: ");
        int number = scanner.nextInt();

        System.out.println("Таблица умножения для числа " + number + ":");

        int i = 1;
        while (i <= 10) {
            System.out.println(number + " * " + i + " = " + (number * i));
            i++;
        }

        scanner.close();
    }
}