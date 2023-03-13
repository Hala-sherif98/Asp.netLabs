using AspLab2.Models.Domains;
using AspLab2.Models.Views;
using Microsoft.AspNetCore.Mvc;

namespace AspLab2.Controllers
{
    public class TicketsController : Controller
    {
        public IActionResult GetAll()
        {

            var tickets = Ticket.GetTickets();  
            return View(tickets);
        }

        [HttpGet]
        public IActionResult AddToForm(TicketVM ticket)
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAction(TicketVM ticket)
        {

            var ticketsAdded = Ticket.GetTickets();
            var ticketVM = new Ticket()
            {
                CreatedDate = DateTime.Now,
                Description = ticket.Description,
                Severity= ticket.Severity,
                IsClosed = ticket.IsClosed,

            };

            ticketsAdded.Add(ticketVM);
            return View ("GetAll",ticketsAdded);
        }        
    }
}
