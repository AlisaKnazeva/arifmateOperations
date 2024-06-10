import java.util.Scanner;

public class Password {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int password = 0;
        boolean isValid = false;

        while (!isValid) {
            try {
                System.out.print("Введите пароль (целое число): ");
                password = scanner.nextInt();
                isValid = true;
            } catch (Exception e) {
                System.out.println("Пароль должен быть целым числом. Попробуйте снова.");
                scanner.next(); // Очистка буфера ввода
            }
        }

        System.out.println("Пароль принят: " + password);
    }
}