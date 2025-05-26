using Library;

var book1 = new Book("978-5-699-12014-7", "Война и мир", "Лев Толстой", 1869);
var book2 = new Book("978-5-17-090194-5", "Преступление и наказание", "Федор Достоевский", 1866);

var reader1 = new Reader("Иванов Иван Иванович", "ул. Ленина, 10", "+7(123)456-78-90");
var reader2 = new Reader("Петрова Анна Сергеевна", "пр. Мира, 15", "+7(987)654-32-10");

BookLoan loan1 = null;
BookLoan loan2 = null;

try
{
    loan1 = new BookLoan(book1, reader1, DateTime.Now, 14);
    Console.WriteLine("Книга выдана:");
    Console.WriteLine(loan1.GetLoanInfo());
    
    loan2 = new BookLoan(book2, reader2, DateTime.Now, 7);
    Console.WriteLine("\nКнига выдана:");
    Console.WriteLine(loan2.GetLoanInfo());
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}");
    return; 
}

if (loan1 != null)
{
    var return1 = new BookReturn(loan1, DateTime.Now.AddDays(10));
    Console.WriteLine("\nКнига возвращена:");
    Console.WriteLine(return1.GetReturnInfo());
}

if (loan2 != null)
{
    var return2 = new BookReturn(loan2, DateTime.Now.AddDays(8));
    Console.WriteLine("\nКнига возвращена:");
    Console.WriteLine(return2.GetReturnInfo());
}

Console.WriteLine("\nИнформация о книгах:");
Console.WriteLine(book1.GetBookInfo());
Console.WriteLine(book2.GetBookInfo());

Console.WriteLine("\nИнформация о читателях:");
Console.WriteLine(reader1.GetReaderInfo());
Console.WriteLine(reader2.GetReaderInfo());