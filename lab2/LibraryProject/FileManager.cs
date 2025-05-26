using System.IO;

namespace Library
{
    public static class FileManager
    {
        private static readonly string BooksFile = "books.txt";
        private static readonly string ReadersFile = "readers.txt";
        private static readonly string LoansFile = "loans.txt";
        private static readonly string ReturnsFile = "returns.txt";

        public static void SaveData(List<Book> books, List<Reader> readers, List<BookLoan> loans, List<BookReturn> returns)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(BooksFile))
                {
                    foreach (var book in books)
                    {
                        sw.WriteLine($"{book.ISBN}|{book.Title}|{book.Author}|{book.Year}|{book.IsAvailable}");
                    }
                }

                using (StreamWriter sw = new StreamWriter(ReadersFile))
                {
                    foreach (var reader in readers)
                    {
                        sw.WriteLine($"{reader.ReaderId}|{reader.FullName}|{reader.Address}|{reader.Phone}");
                    }
                }

                using (StreamWriter sw = new StreamWriter(LoansFile))
                {
                    foreach (var loan in loans)
                    {
                        sw.WriteLine($"{loan.LoanedBook.ISBN}|{loan.Borrower.ReaderId}|{loan.LoanDate}|{loan.DueDate}");
                    }
                }

                using (StreamWriter sw = new StreamWriter(ReturnsFile))
                {
                    foreach (var ret in returns)
                    {
                        sw.WriteLine($"{ret.ReturnedBook.ISBN}|{ret.Returner.ReaderId}|{ret.ReturnDate}|{ret.IsLate}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении данных: {ex.Message}");
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
                if (File.Exists(BooksFile))
                {
                    using (StreamReader sr = new StreamReader(BooksFile))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            var parts = line.Split('|');
                            if (parts.Length == 5)
                            {
                                var book = new Book(parts[0], parts[1], parts[2], int.Parse(parts[3]));
                                book.IsAvailable = bool.Parse(parts[4]);
                                books.Add(book);
                            }
                        }
                    }
                }

                if (File.Exists(ReadersFile))
                {
                    using (StreamReader sr = new StreamReader(ReadersFile))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            var parts = line.Split('|');
                            if (parts.Length == 4)
                            {
                                var reader = new Reader(parts[1], parts[2], parts[3]);
                                typeof(Reader).GetProperty("ReaderId")?.SetValue(reader, int.Parse(parts[0]));
                                readers.Add(reader);
                            }
                        }
                    }
                }

                if (File.Exists(LoansFile) && books.Count > 0 && readers.Count > 0)
                {
                    using (StreamReader sr = new StreamReader(LoansFile))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            var parts = line.Split('|');
                            if (parts.Length == 4)
                            {
                                var book = books.FirstOrDefault(b => b.ISBN == parts[0]);
                                var reader = readers.FirstOrDefault(r => r.ReaderId == int.Parse(parts[1]));
                                if (book != null && reader != null)
                                {
                                    var loan = new BookLoan(book, reader, DateTime.Parse(parts[2]), 
                                               (DateTime.Parse(parts[3]) - DateTime.Parse(parts[2])).Days);
                                    loans.Add(loan);
                                }
                            }
                        }
                    }
                }

                if (File.Exists(ReturnsFile) && books.Count > 0 && readers.Count > 0)
                {
                    using (StreamReader sr = new StreamReader(ReturnsFile))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            var parts = line.Split('|');
                            if (parts.Length == 4)
                            {
                                var book = books.FirstOrDefault(b => b.ISBN == parts[0]);
                                var reader = readers.FirstOrDefault(r => r.ReaderId == int.Parse(parts[1]));
                                if (book != null && reader != null)
                                {
                                    var loan = loans.FirstOrDefault(l => l.LoanedBook.ISBN == book.ISBN && 
                                                                        l.Borrower.ReaderId == reader.ReaderId);
                                    if (loan != null)
                                    {
                                        var ret = new BookReturn(loan, DateTime.Parse(parts[2]));
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
                Console.WriteLine($"Ошибка при загрузке данных: {ex.Message}");
            }

            return (books, readers, loans, returns);
        }
    }
}