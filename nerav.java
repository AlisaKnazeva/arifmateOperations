import java.util.Scanner;

public class nerav {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Введите значение переменной a: ");
        int a = scanner.nextInt();

        System.out.print("Введите значение переменной b: ");
        int b = scanner.nextInt();

        if ((a > 2 && a < 11) || (b >= 6 && b < 14)) {
            System.out.println("Верно");
        } else {
            System.out.println("Неверно");
        }

        scanner.close();
    }
}