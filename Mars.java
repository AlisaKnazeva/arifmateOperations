import java.util.Scanner;

public class Mars {
    public static void main(String[] args) {
        double gravityOnMars = 3.711;
        Scanner scanner = new Scanner(System.in);

        System.out.println("Введите ваш вес на Земле: ");
        double weightOnEarth = scanner.nextDouble();

        double weightOnMars = weightOnEarth / 9.81 * gravityOnMars;

        System.out.println("Ваш вес на Марсе составит примерно " + weightOnMars + " кг");
    }
}