import java.util.Scanner;

public class zad7 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Введите радиус окружности: ");
        double radius = getValidDouble(scanner);

        System.out.print("Введите '1' для расчета площади или '2' для расчета длины: ");
        int choice = getValidChoice(scanner);

        if (choice == 1) {
            double area = calculateCircleArea(radius);
            System.out.println("Площадь окружности: " + area);
        } else if (choice == 2) {
            double circumference = calculateCircleCircumference(radius);
            System.out.println("Длина окружности: " + circumference);
        } else {
            System.out.println("Ошибка: Введите только '1' или '2'.");
        }
    }

    public static double getValidDouble(Scanner scanner) {
        while (true) {
            try {
                return Double.parseDouble(scanner.nextLine());
            } catch (NumberFormatException e) {
                System.out.print("Ошибка: Введите корректное число: ");
            }
        }
    }

    public static int getValidChoice(Scanner scanner) {
        while (true) {
            try {
                int choice = Integer.parseInt(scanner.nextLine());
                if (choice == 1 || choice == 2) {
                    return choice;
                } else {
                    System.out.print("Ошибка: Введите только '1' или '2': ");
                }
            } catch (NumberFormatException e) {
                System.out.print("Ошибка: Введите только '1' или '2': ");
            }
        }
    }

    public static double calculateCircleArea(double radius) {
        return Math.PI * radius * radius;
    }

    public static double calculateCircleCircumference(double radius) {
        return 2 * Math.PI * radius;
    }
}