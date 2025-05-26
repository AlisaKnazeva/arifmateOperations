namespace Library;

public class BookLoan
{
    public Book LoanedBook { get; }
    public Reader Borrower { get; }
    public DateTime LoanDate { get; }
    public DateTime DueDate { get; }

    public BookLoan(Book book, Reader reader, DateTime loanDate, int loanDays)
    {
        if (!book.IsAvailable)
            throw new InvalidOperationException("Книга уже выдана другому читателю");

        LoanedBook = book;
        Borrower = reader;
        LoanDate = loanDate;
        DueDate = loanDate.AddDays(loanDays);
        book.IsAvailable = false; 
    }

    public string GetLoanInfo()
    {
        return $"Книга: {LoanedBook.Title}, Читатель: {Borrower.FullName}, Дата выдачи: {LoanDate.ToShortDateString()}, Срок возврата: {DueDate.ToShortDateString()}";
    }
}