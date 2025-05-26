namespace Library;

public class Book
{
    public string ISBN { get; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public bool IsAvailable { get; set; }

    public Book(string isbn, string title, string author, int year)
    {
        ISBN = isbn;
        Title = title;
        Author = author;
        Year = year;
        IsAvailable = true; 
    }

    public string GetBookInfo()
    {
        return $"ISBN: {ISBN}, Название: {Title}, Автор: {Author}, Год: {Year}, Доступность: {(IsAvailable ? "Да" : "Нет")}";
    }
}