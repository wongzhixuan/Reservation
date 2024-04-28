using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation
{
    class Program
    {
        public static List<Reservation> reserve = new List<Reservation>()
        {
            new Reservation() { FirstName = "Jack", LastName = "Lim", ReserveDate = new DateTime(2024, 01, 05, 23, 15, 00), Pax = 10},
            new Reservation() { FirstName = "Lee", LastName = "Foo", ReserveDate = new DateTime(2023, 03, 04, 19, 00, 00), Pax = 5},
            new Reservation() { FirstName = "Terry", LastName = "Poh", ReserveDate = new DateTime(2024, 01, 09, 10, 00, 00), Pax = 3},
            new Reservation() { FirstName = "Leong", LastName = "Sean", ReserveDate = new DateTime(2024, 01, 09, 12, 30, 00), Pax = 8}
        };
        static void Main(string[] args)
        {
            // Sort the reservation based on reservation date in ascending order
            reserve.Sort((x, y) => DateTime.Compare(x.ReserveDate, y.ReserveDate));

            int totalRooms = 0;

            for (int i = 0; i < reserve.Count(); i++)
            {
                // ignore the title if the current reservation has the same date with the previous one
                if (!hasSameReservationDateWithPreviousCustomer(i))
                {
                    totalRooms = 0; // reset total rooms needed
                    Console.WriteLine($"\n###### Customer List for date {(reserve[i].ReserveDate).ToString("dd/MM/yyyy")} #####");

                    Console.WriteLine("\n====== Customer List =======");
                }

                // calculate the rooms required based on the number of pax for each reservation
                int roomsRequired = (int)Math.Ceiling((double)reserve[i].Pax / 2);
                // sum up rooms needed for reservations with same reservation date
                totalRooms += roomsRequired;

                Console.WriteLine($"Customer : Customer Name : {reserve[i].FirstName} {reserve[i].LastName} ({Convert.ToInt32(reserve[i].Pax)}) - {roomsRequired} rooms required.");

                // prints the total rooms needed (ignored when next customer has the same reservation date)
                if (!hasSameReservationDateWithNextCustomer(i))
                {
                    Console.WriteLine("\n====== ROOM Required =======");

                    Console.WriteLine(totalRooms);
                }
            }

        }

        static bool hasSameReservationDateWithPreviousCustomer(int index)
        {
            if (index == 0)
            {
                return false;
            }

            if (DateTime.Equals(reserve[index].ReserveDate.Date, reserve[index - 1].ReserveDate.Date))
            {
                return true;
            }

            return false;
        }

        static bool hasSameReservationDateWithNextCustomer(int index)
        {
            if (index == reserve.Count() - 1)
            {
                return false;
            }

            if (DateTime.Equals(reserve[index].ReserveDate.Date, reserve[index + 1].ReserveDate.Date))
            {
                return true;
            }

            return false;
        }

    }

}
