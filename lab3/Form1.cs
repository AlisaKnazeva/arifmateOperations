using System;
using System.Windows.Forms;
using Library; // Добавьте эту директиву для работы с вашими классами

namespace prac1
{
    public partial class Form1 : Form
    {
        private List<Book> books;
        private List<Reader> readers;
        private List<BookLoan> loans;
        private List<BookReturn> returns;

        public Form1()
        {
            InitializeComponent();
            LoadInitialData();
        }

        private void LoadInitialData()
        {
            // Загрузка или инициализация данных
            (books, readers, loans, returns) = JsonFileManager.LoadData();
            
            if (books.Count == 0)
            {
                books = new List<Book>
                {
                    new Book("978-5-699-12014-7", "Война и мир", "Лев Толстой", 1869),
                    new Book("978-5-17-090194-5", "Преступление и наказание", "Федор Достоевский", 1866)
                };
            }

            if (readers.Count == 0)
            {
                readers = new List<Reader>
                {
                    new Reader("Иванов Иван Иванович", "ул. Ленина, 10", "+7(123)456-78-90"),
                    new Reader("Петрова Анна Сергеевна", "пр. Мира, 15", "+7(987)654-32-10")
                };
            }

            UpdateOutput();
        }

        private void UpdateOutput()
        {
            textBoxOutput.Clear();
            textBoxOutput.AppendText("=== Книги ===\r\n");
            foreach (var book in books)
            {
                textBoxOutput.AppendText(book.GetBookInfo() + "\r\n");
            }

            textBoxOutput.AppendText("\r\n=== Читатели ===\r\n");
            foreach (var reader in readers)
            {
                textBoxOutput.AppendText(reader.GetReaderInfo() + "\r\n");
            }

            textBoxOutput.AppendText("\r\n=== Выдачи ===\r\n");
            foreach (var loan in loans)
            {
                textBoxOutput.AppendText(loan.GetLoanInfo() + "\r\n");
            }

            textBoxOutput.AppendText("\r\n=== Возвраты ===\r\n");
            foreach (var ret in returns)
            {
                textBoxOutput.AppendText(ret.GetReturnInfo() + "\r\n");
            }
        }

        private void BtnSaveText_Click(object sender, EventArgs e)
        {
            try
            {
                FileManager.SaveData(books, readers, loans, returns);
                MessageBox.Show("Данные успешно сохранены в текстовые файлы", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLoadText_Click(object sender, EventArgs e)
        {
            try
            {
                (books, readers, loans, returns) = FileManager.LoadData();
                UpdateOutput();
                MessageBox.Show("Данные успешно загружены из текстовых файлов", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSaveJson_Click(object sender, EventArgs e)
        {
            try
            {
                JsonFileManager.SaveData(books, readers, loans, returns);
                MessageBox.Show("Данные успешно сохранены в JSON", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLoadJson_Click(object sender, EventArgs e)
        {
            try
            {
                (books, readers, loans, returns) = JsonFileManager.LoadData();
                UpdateOutput();
                MessageBox.Show("Данные успешно загружены из JSON", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}