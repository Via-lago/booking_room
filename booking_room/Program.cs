using System.Data.SqlClient;
using System.Data;
using System.Transactions;
using System.Data.Common;
using booking_room.View;
using booking_room.Context;

public class Program
{
    
    public static void Main()
    {
        using var connection = MyConnection.Get();
        var menu = new Menu();

        // Memanggil Menu
        Menu.daftarmenu(); 
    }

}