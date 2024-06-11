import javax.swing.*;
import java.time.DayOfWeek;
import java.time.LocalDate;
import java.time.Month;
import java.time.format.TextStyle;
import java.util.Locale;

public class zad9 {
    public static void main() {
        int year = Integer.parseInt(JOptionPane.showInputDialog("Введите год (1900-2100): "));
        String monthInput = JOptionPane.showInputDialog("Введите месяц (число от 1 до 12 или сокращенное название от Янв. до Дек.): ");
        Month month;
        if (Character.isDigit(monthInput.charAt(0))) {
            month = Month.of(Integer.parseInt(monthInput));
        } else {
            month = Month.valueOf(monthInput.toUpperCase().charAt(0) + monthInput.toLowerCase().substring(1));
        }

        LocalDate date = LocalDate.of(year, month, 1);
        date = date.minusDays(1);

        String[] daysOfWeek = {"Пн", "Вт", "Ср", "Чт", "Пт", "Сб", "Вс"};
        String[][] calendar = new String[6][7];

        int row = 0;
        for (int i = 1; i <= month.length(false); i++) {
            DayOfWeek dayOfWeek = date.getDayOfWeek();
            int col = dayOfWeek.getValue() % 7;
            calendar[row][col] = String.valueOf(i);

            date = date.plusDays(1);
            if (col == 6) {
                row++;
            }
        }

        StringBuilder calendarString = new StringBuilder();
        calendarString.append(month.getDisplayName(TextStyle.FULL, Locale.getDefault())).append(" ").append(year).append("\n");
        for (String day : daysOfWeek) {
            calendarString.append(day).append("\t");
        }
        calendarString.append("\n");

        for (int i = 0; i < 6; i++) {
            for (int j = 0; j < 7; j++) {
                if (calendar[i][j] != null) {
                    calendarString.append(calendar[i][j]).append("\t");
                } else {
                    calendarString.append("\t");
                }
            }
            calendarString.append("\n");
        }

        JOptionPane.showMessageDialog(null, calendarString.toString(), "Календарь", JOptionPane.INFORMATION_MESSAGE);
    }
}