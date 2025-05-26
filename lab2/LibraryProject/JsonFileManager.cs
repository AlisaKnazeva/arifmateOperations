using System.Text.Json;

namespace Library
{
    public static class JsonFileManager
    {
        private static readonly string DataFile = "library_data.json";
        private static readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        public static void SaveData(List<Book> books, List<Reader> readers, List<BookLoan> loans, List<BookReturn> returns)
        {
            try
            {
                var data = new
                {
                    Books = books,
                    Readers = readers,
                    Loans = loans.Select(l => new
                    {
                        BookISBN = l.LoanedBook.ISBN,
                        ReaderId = l.Borrower.ReaderId,
                        LoanDate = l.LoanDate,
                        DueDate = l.DueDate
                    }),
                    Returns = returns.Select(r => new
                    {
                        BookISBN = r.ReturnedBook.ISBN,
                        ReaderId = r.Returner.ReaderId,
                        ReturnDate = r.ReturnDate,
                        IsLate = r.IsLate
                    })
                };

                string jsonString = JsonSerializer.Serialize(data, Options);
                File.WriteAllText(DataFile, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении JSON данных: {ex.Message}");
            }
        }

        public static (List<Book>, List<Reader>, List<BookLoan>, List<BookReturn>) LoadData()
        {
            var books = new List<Book>();
            var readers = new List<Reader>();
            var loans = new List<BookLoan>();
            var returns = new List<BookReturn>();

            try
            {
                if (File.Exists(DataFile))
                {
                    string jsonString = File.ReadAllText(DataFile);
                    var data = JsonSerializer.Deserialize<LibraryData>(jsonString);

                    if (data != null)
                    {
                        books = data.Books ?? new List<Book>();
                        readers = data.Readers ?? new List<Reader>();

                        // Восстановление выдач
                        if (data.Loans != null)
                        {
                            foreach (var loanData in data.Loans)
                            {
                                var book = books.FirstOrDefault(b => b.ISBN == loanData.BookISBN);
                                var reader = readers.FirstOrDefault(r => r.ReaderId == loanData.ReaderId);
                                if (book != null && reader != null)
                                {
                                    var loan = new BookLoan(book, reader, loanData.LoanDate, 
                                                         (loanData.DueDate - loanData.LoanDate).Days);
                                    loans.Add(loan);
                                }
                            }
                        }

                        // Восстановление возвратов
                        if (data.Returns != null)
                        {
                            foreach (var returnData in data.Returns)
                            {
                                var book = books.FirstOrDefault(b => b.ISBN == returnData.BookISBN);
                                var reader = readers.FirstOrDefault(r => r.ReaderId == returnData.ReaderId);
                                if (book != null && reader != null)
                                {
                                    var loan = loans.FirstOrDefault(l => l.LoanedBook.ISBN == book.ISBN && 
                                                                        l.Borrower.ReaderId == reader.ReaderId);
                                    if (loan != null)
                                    {
                                        var ret = new BookReturn(loan, returnData.ReturnDate);
                                        returns.Add(ret);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке JSON данных: {ex.Message}");
            }

            return (books, readers, loans, returns);
        }

        private class LibraryData
        {
            public List<Book>? Books { get; set; }
            public List<Reader>? Readers { get; set; }
            public List<LoanData>? Loans { get; set; }
            public List<ReturnData>? Returns { get; set; }
        }

        private class LoanData
        {
            public string BookISBN { get; set; } = string.Empty;
            public int ReaderId { get; set; }
            public DateTime LoanDate { get; set; }
            public DateTime DueDate { get; set; }
        }

        private class ReturnData
        {
            public string BookISBN { get; set; } = string.Empty;
            public int ReaderId { get; set; }
            public DateTime ReturnDate { get; set; }
            public bool IsLate { get; set; }
        }
    }
}