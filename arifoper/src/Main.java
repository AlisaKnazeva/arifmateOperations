import java.io.*;
import java.util.ArrayList;
import java.util.List;
import java.util.Random;
import javax.swing.JOptionPane;

public class Main {
    public static void main(String[] args) {
        // Создаем два файла и записываем в них рандомные числа
        try {
            FileWriter file1 = new FileWriter("file1.txt");
            FileWriter file2 = new FileWriter("file2.txt");
            BufferedWriter writer1 = new BufferedWriter(file1);
            BufferedWriter writer2 = new BufferedWriter(file2);

            Random random = new Random();
            for (int i = 0; i < 10; i++) {
                int num1 = random.nextInt(1000) + 1;
                int num2 = random.nextInt(1000) + 1;
                writer1.write((num1 + "\n"));
                writer2.write((num2 + "\n"));
            }

            writer1.close();
            writer2.close();
        } catch (IOException e) {
            e.printStackTrace();
        }

        // Отображаем окно выбора арифметической операции
        String operation = JOptionPane.showInputDialog("Выберите операцию (+, -, *, /):");

        // Считываем числа из файлов и выполняем выбранную операцию
        try {
            BufferedReader reader1 = new BufferedReader(new FileReader("file1.txt"));
            BufferedReader reader2 = new BufferedReader(new FileReader("file2.txt"));

            List<Integer> nums1 = new ArrayList<>();
            List<Integer> nums2 = new ArrayList<>();

            String line;
            while ((line = reader1.readLine()) != null) {
                nums1.add(Integer.parseInt(line));
            }

            while ((line = reader2.readLine()) != null) {
                nums2.add(Integer.parseInt(line));
            }

            List<Integer> result = new ArrayList<>();
            for (int i = 0; i < nums1.size(); i++) {
                int temp = 0;
                int num1 = nums1.get(i);
                int num2 = nums2.get(i);

                if (operation.equals("+")) {
                    temp = (num1 + num2);
                    result.add(temp);
                } else if (operation.equals("-")) {
                    temp = (num1 - num2);
                    result.add(temp);
                } else if (operation.equals("*")) {
                    temp = (num1 * num2);
                    result.add(temp);
                } else if (operation.equals("/")) {
                    temp = (num1 / num2);
                    result.add(temp);
                }
            }

            JOptionPane.showMessageDialog(null, "Результат:n" + nums1 + nums2 + result);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}