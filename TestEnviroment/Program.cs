using LaporanKtmAPI.Model;
using LaporanKtmLibrary.Common;

var today = DateOnly.FromDateTime(DateTime.Today);
var yesterday = DateOnly.FromDateTime(DateTime.Today.AddDays(-1));
var twoDaysAgo = DateOnly.FromDateTime(DateTime.Today.AddDays(-2));
var list = new List<Laporan>
{
    new Laporan("John", "john@example.com", "1010101010", State.Start, twoDaysAgo),
    new Laporan("Bob", "bob@example.com", "5757575757", State.MengeditLaporan, yesterday),
    new Laporan("Eve", "eve@example.com", "9393939393", State.Ketemu, today)
};
int index = Search<Laporan>.ByNim(list, new Laporan("", "", "1010101010", State.Start, default));
Console.WriteLine(index);

Console.WriteLine("\nSebelum Sort");
foreach(Laporan laporan in list)
{
    Console.WriteLine("Nama : " + laporan.Name);
}   

Sort<Laporan>.ByDate(list, l => l.Date.ToDateTime(default));
Console.WriteLine("\nSetelah Sort");
foreach (Laporan laporan in list)
{
    Console.WriteLine("Nama : " + laporan.Name);
}