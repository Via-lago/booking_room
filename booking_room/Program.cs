using System.Data.SqlClient;
using System.Data;
using booking_room;
using System.Transactions;
using System.Data.Common;

public class Program
{
    private static readonly string connectionString =

         "Data Source=LAPTOP-N3R9H5VB\\MSSQLSERVER02;database= db_booking_room;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
    public static void Main()
    {
        var menu = new Menu();

        // Memanggil Menu
        Menu.daftarmenu();

    }

}