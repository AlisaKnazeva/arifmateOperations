using Library;
using System.Text.Json;

var (books, readers, loans, returns) = JsonFileManager.LoadData();

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

BookLoan? loan1 = null;
BookLoan? loan2 = null;

try
{
    if (loans.Count == 0)
    {
        loan1 = new BookLoan(books[0], readers[0], DateTime.Now, 14);
        loans.Add(loan1);
        Console.WriteLine("Книга выдана:");
        Console.WriteLine(loan1.GetLoanInfo());
        
        loan2 = new BookLoan(books[1], readers[1], DateTime.Now, 7);
        loans.Add(loan2);
        Console.WriteLine("\nКнига выдана:");
        Console.WriteLine(loan2.GetLoanInfo());
    }
    else
    {
        Console.WriteLine("Загруженные выдачи книг:");
        foreach (var loan in loans)
        {
            Console.WriteLine(loan.GetLoanInfo());
        }
    }
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}");
    return; 
}

if (returns.Count == 0)
{
    if (loan1 != null)
    {
        var return1 = new BookReturn(loan1, DateTime.Now.AddDays(10));
        returns.Add(return1);
        Console.WriteLine("\nКнига возвращена:");
        Console.WriteLine(return1.GetReturnInfo());
    }

    if (loan2 != null)
    {
        var return2 = new BookReturn(loan2, DateTime.Now.AddDays(8));
        returns.Add(return2);
        Console.WriteLine("\nКнига возвращена:");
        Console.WriteLine(return2.GetReturnInfo());
    }
}
else
{
    Console.WriteLine("\nЗагруженные возвраты книг:");
    foreach (var ret in returns)
    {
        Console.WriteLine(ret.GetReturnInfo());
    }
}

Console.WriteLine("\nИнформация о книгах:");
foreach (var book in books)
{
    Console.WriteLine(book.GetBookInfo());
}

Console.WriteLine("\nИнформация о читателях:");
foreach (var reader in readers)
{
    Console.WriteLine(reader.GetReaderInfo());
}

JsonFileManager.SaveData(books, readers, loans, returns);
FileManager.SaveData(books, readers, loans, returns);

Console.WriteLine("\nДанные сохранены в файлы.");