using MetroTicketSystem.Data;
using MetroTicketSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace MetroTicketSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDbContext context = new AppDbContext();
            //adding stations
            Station station01 = new Station()
            { Name = "S1", Location = " Oman" };

            Station station02 = new Station()
            { Name = "S2", Location = " Qater" };

            Station station03 = new Station()
            { Name = "S3", Location = " UAE" };

            context.Stations.AddRange(station01, station02, station03);
            context.SaveChanges();

            // adding trains
            Train train01 = new Train()
            { Number = "Metro-101", Capacity = 200 };
            Train train02 = new Train()
            { Number = "Metro-202", Capacity = 250 };
            Train train03 = new Train()
            { Number = "Metro-3023", Capacity = 300 };

            context.Trains.AddRange(train01, train02, train03);
            context.SaveChanges();

            // adding tickets 
            Ticket ticket01 = new Ticket()
            {
                PassengerName = "Sara",
                Price = 20,
                TravelDate= DateTime.Now.AddDays(1),
                TrainId=train01.Id,
                StationId=station01.Id,
            };
            Ticket ticket02 = new Ticket()
            {
                PassengerName = "Ahmad",
                Price = 30,
                TravelDate = DateTime.Now.AddDays(2),
                TrainId = train01.Id,
                StationId = station02.Id,
            };
            Ticket ticket03 = new Ticket()
            {
                PassengerName = "Muna",
                Price = 18,
                TravelDate = DateTime.Now.AddDays(3),
                TrainId = train02.Id,
                StationId = station03.Id,
            };

            Ticket ticket04 = new Ticket()
            {
                PassengerName = "Huda",
                Price = 45,
                TravelDate = DateTime.Now.AddDays(4),
                TrainId = train02.Id,
                StationId = station01.Id,
            };
            Ticket ticket05 = new Ticket()
            {
                PassengerName = "Hamad",
                Price = 20,
                TravelDate = DateTime.Now.AddDays(5),
                TrainId = train03.Id,
                StationId = station02.Id,
            };
            context.Tickets.AddRange(ticket01, ticket02, ticket03, ticket04, ticket05);
            context.SaveChanges();

            //1.get all tickets
            Console.WriteLine("     1. All TICKETS   ");

            var allTickets= context.Tickets.ToList();
            foreach( var ticket in allTickets )
            {
                Console.WriteLine($"ID: {ticket.Id}, Passenger: {ticket.PassengerName}, Price: {ticket.Price}, Date: {ticket.TravelDate:yyyy-MM-dd}");
            }

            //2. get tickets with price greater than 20
            Console.WriteLine("     2. Tickets with price greater than 20  ");
            var ticketsPriceGreaterThan20 = context.Tickets.Where(t => t.Price > 20).ToList();
            foreach (var ticket in ticketsPriceGreaterThan20)
            {
                Console.WriteLine($"Passenger: {ticket.PassengerName}, Price: {ticket.Price}");
            }

            // 3. Get the first ticket for a specific passenger
            Console.WriteLine(" 3. First Ticket for Sara ==========");
            var firstTicketForAhmad = context.Tickets.FirstOrDefault(t => t.PassengerName == "Sara");
            if (firstTicketForAhmad != null)
            {
                Console.WriteLine($"Passenger: {firstTicketForAhmad.PassengerName}, Price: {firstTicketForAhmad.Price}, TrainId: {firstTicketForAhmad.TrainId}, StationId: {firstTicketForAhmad.StationId}");
            }
            else
            {
                Console.WriteLine("No ticket found for Ahmad");
            }

            // 4. Count all tickets
            Console.WriteLine("   4. Count all tickets");
            var ticketCount = context.Tickets.Count();
            Console.WriteLine($"Total number of tickets: {ticketCount}");

            // 5. Order tickets by price descending
            Console.WriteLine("    5.  Tickets ordered by price descending  ");
            var ticketsOrderedByPrice = context.Tickets.OrderByDescending(t => t.Price).ToList();
            foreach (var ticket in ticketsOrderedByPrice)
            {
                Console.WriteLine($"Passenger: {ticket.PassengerName},{ticket.Id} Price: {ticket.Price}");
            }

            // 6. Load related data using Include() - Ticket + Train + Station
            Console.WriteLine(" 6. Tickets with train and station on details");
            var ticketsWithDetails = context.Tickets
                .Include(t => t.Train)
                .Include(t => t.Station)
                .ToList();

            foreach (var ticket in ticketsWithDetails)
            {
                Console.WriteLine($"Passenger: {ticket.PassengerName} | Train: {ticket.Train?.Number} | Station: {ticket.Station?.Name} | Price: {ticket.Price}");
            }




        }
    }
}
