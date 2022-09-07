using System.Net.Sockets;
using System.Xml.Linq;
using WebAppDETAug2022.Models;

namespace WebAppDETAug2022.Services
{
    public class TicketService
    {
        static List<Tickets> Tickets { get; }
        static int nextId = 3;
        static TicketService()
        {
            Tickets = new List<Tickets>
                {
                new Tickets{Match= "INDIA VS PAKISTAN "   ,Price=5000,Id=1},
                new Tickets{Match= "Sri Lanka VS INDIA"   ,Price=4000,Id=2},
                new Tickets{Match= " INDIA VS Afghanistan",Price=3000,Id=3}
            };
        }

        public static List<Tickets> GetAll() => Tickets;

        public static Tickets? Get(int id) => Tickets.FirstOrDefault(p => p.Id == id);

        public static void Add(Tickets ticket)
        {
            ticket.Id = nextId++;
            Tickets.Add(ticket);
        }

        public static void Delete(int id)
        {
            var ticket = Get(id);
            if (ticket is null)
                return;

            Tickets.Remove(ticket);
        }

        public static void Update(Tickets ticket)
        {
            var index = Tickets.FindIndex(p => p.Id == ticket.Id);
            if (index == -1)
                return;

            Tickets[index] = ticket;
        }
    }
}