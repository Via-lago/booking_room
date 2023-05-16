using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using booking_room.Controller;

namespace booking_room.View
{
    public class MenuView
    {
        public void Pilihtabel()
        {
            Console.WriteLine("================ Pilih Tabel ================");
            Console.WriteLine("1.Universitas");
            Console.WriteLine("2.Education");
            Console.WriteLine("================");
        }
    }
}
