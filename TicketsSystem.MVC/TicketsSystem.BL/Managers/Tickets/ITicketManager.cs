using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsSystem.BL.ViewModels.Ticket;
using TicketsSystem.BL.ViewModels.Tickets;
using TicketsSystem.DAL.Models;


namespace TicketsSystem.BL.Managers.Tickets
{
    public interface ITicketManager
    {
        List <ReadTicket> GetAllTickets();
        TicketDetails GetTicketDetails (int id);
        void Update(EditTicket ticketVM);
        EditTicket? GetForEdit(int id);
    }
}
