using APIDemo.Models;
using APIDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        [HttpGet]
        [Route("tickets")]
        public List<Ticket> Get()
        {
            return TicketService.GetAll();

        }
        [HttpGet]
        [Route("tickets/{id}")]
        public Ticket Get(int Id)
        {
            Ticket t = TicketService.Get(Id);
            return t;
        }
    }
}