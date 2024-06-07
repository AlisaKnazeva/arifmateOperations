import java.util.Scanner;

public class Pifagor {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.println("Введите значение первого катета в см: ");
        double sideA = scanner.nextDouble();

        System.out.println("Введите значение второго катета в см: ");
        double sideB = scanner.nextDouble();

        double hypotenuse = Math.sqrt(Math.pow(sideA, 2) + Math.pow(sideB, 2));

        System.out.println("Гипотенуза прямоугольного треугольника равна: " + hypotenuse + "см");
    }
}