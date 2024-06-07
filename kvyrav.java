import java.util.Scanner;

public class kvyrav {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.println("Введите коэффициенты квадратного уравнения ax^2 + bx + c = 0:");
        System.out.print("Введите значение переменной a: ");
        double a = scanner.nextDouble();

        System.out.print("Введите значение переменной b: ");
        double b = scanner.nextDouble();

        System.out.print("Введите значение переменной c: ");
        double c = scanner.nextDouble();

        double discriminant = b*b - 4*a*c;

        if (discriminant < 0) {
            System.out.println("У уравнения нет действительных корней.");
        } else {
            double x1 = (-b + Math.sqrt(discriminant)) / (2*a);
            double x2 = (-b - Math.sqrt(discriminant)) / (2*a);

            System.out.println("Первый корень уравнения: " + x1);
            System.out.println("Второй корень уравнения: " + x2);
        }

        scanner.close();
    }
}