namespace Library;

public class BookReturn
{
    public Book ReturnedBook { get; }
    public Reader Returner { get; }
    public DateTime ReturnDate { get; }
    public bool IsLate { get; }

    public BookReturn(BookLoan loan, DateTime returnDate)
    {
        ReturnedBook = loan.LoanedBook;
        Returner = loan.Borrower;
        ReturnDate = returnDate;
        IsLate = returnDate > loan.DueDate;
        loan.LoanedBook.IsAvailable = true; 
    }

    public string GetReturnInfo()
    {
        return $"Книга: {ReturnedBook.Title}, Читатель: {Returner.FullName}, Дата возврата: {ReturnDate.ToShortDateString()}, {(IsLate ? "Просрочено" : "В срок")}";
    }
}