namespace Library;

public class Reader
{
    // Свойства читателя
    public int ReaderId { get; }
    public string FullName { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    private static int s_readerIdSeed = 1;

    // Конструктор читателя
    public Reader(string fullName, string address, string phone)
    {
        ReaderId = s_readerIdSeed++;
        FullName = fullName;
        Address = address;
        Phone = phone;
    }

    // Метод для получения информации о читателе
    public string GetReaderInfo()
    {
        return $"ID: {ReaderId}, ФИО: {FullName}, Адрес: {Address}, Телефон: {Phone}";
    }
}