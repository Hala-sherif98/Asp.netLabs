using IssuesSystem.Bl.ViewModels;
using IssuesSystem.DAL.Models;
using IssuesSystem.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace IssuesSystem.Bl
{
    public class TicketsManager : ITicketsManager
    {
        private readonly ITicketsRepo _ticketsRepo;

        public TicketsManager(ITicketsRepo ticketsRepo)
        {
            _ticketsRepo =  ticketsRepo;
        }

        public List<TicketViewModel> GetAll()
        {
            var TicketFromDB = _ticketsRepo.GetAll();
            return TicketFromDB.Select(t => new TicketViewModel(t.Id, t.Title, t.Description,t.Severity))
                .ToList();
        }

        public TicketViewModel Get(int id)
        {
            var TicketFromDB = _ticketsRepo.Get(id);
            if (TicketFromDB == null)
            {
                return null;
            }
            return new TicketViewModel(TicketFromDB.Id, TicketFromDB.Title, TicketFromDB.Description, TicketFromDB.Severity);

        }

        public void Add(TicketViewModel ticketVM)
        {
            var ticket = new Ticket
            {
                Title = ticketVM.Title,
                Description = ticketVM.Description,
                Severity = ticketVM.Severity,

            };

            _ticketsRepo.Add(ticket);
            _ticketsRepo.SaveChanges();
        }

        public void Delete(int id)
        {

            var TicketFromDB = Get(id);
            
            if (TicketFromDB != null)
            {
                _ticketsRepo.Delete(id);
                _ticketsRepo.SaveChanges();

            }

        }
        public void Update(TicketViewModel ticketVM, int id)
        {

            var TicketToEdit = _ticketsRepo.Get(id);
            TicketToEdit.Description = ticketVM.Description;
            TicketToEdit.Title = ticketVM.Title;
            TicketToEdit.Severity = ticketVM.Severity;

            _ticketsRepo.Update(TicketToEdit);
            _ticketsRepo.SaveChanges();



        }


    }
}
