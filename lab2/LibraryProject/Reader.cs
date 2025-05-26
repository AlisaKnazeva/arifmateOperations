namespace Library;

public class Reader
{
    public int ReaderId { get; }
    public string FullName { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    private static int s_readerIdSeed = 1;

    public Reader(string fullName, string address, string phone)
    {
        ReaderId = s_readerIdSeed++;
        FullName = fullName;
        Address = address;
        Phone = phone;
    }

    public string GetReaderInfo()
    {
        return $"ID: {ReaderId}, ФИО: {FullName}, Адрес: {Address}, Телефон: {Phone}";
    }
}