using APIDemo.Models;

namespace APIDemo.Services
{
    public class TicketService
    {


 static List<Ticket> Tickets { get; }

        static TicketService()
        {
            Tickets = new List<Ticket>
                {
                   new Ticket{ Id= 1, BookedFor= "Sujith", Price=500, Qty= 200},
                   new Ticket{ Id= 2, BookedFor= "kushal", Price=400, Qty= 20},
                   new Ticket{ Id= 3, BookedFor= "dhanush", Price=300, Qty= 200},
                   new Ticket{ Id= 4, BookedFor= "abhi", Price=200, Qty= 50},
                     new Ticket{ Id= 5, BookedFor= "nanc", Price=800, Qty= 10},
                };
        }

        public static List<Ticket> GetAll() => Tickets;

        public static Ticket Get(int id)
        {
            Ticket ticket = Tickets.FirstOrDefault(p => p.Id == id);
            return ticket;
        }
    }
}
