using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsSystem.BL.ViewModels.Ticket;
using TicketsSystem.BL.ViewModels.Tickets;
using TicketsSystem.DAL.Models;
using TicketsSystem.DAL.Repo.DevelopersRepo;
using TicketsSystem.DAL.Repo.TicketsRepo;

namespace TicketsSystem.BL.Managers.Tickets
{
    public class TicketManager : ITicketManager
    {

        private readonly ITicketsRepo _ticketsRepo;
        private readonly IDevelopersRepo _developersRepo;

        public TicketManager(ITicketsRepo ticketsRepo , IDevelopersRepo developersRepo)
        {
            _ticketsRepo = ticketsRepo;
            _developersRepo = developersRepo;
        }
        public List<ReadTicket> GetAllTickets()
        {
            var TicketFromDB = _ticketsRepo.GetAll();
            return TicketFromDB.Select(t => new ReadTicket(t.Id, t.Description, t.Severity, t.DepartmentId)).ToList();
        }

        public EditTicket? GetForEdit(int id)
        {
            Ticket? TicketFromDB = _ticketsRepo.GetTDetails(id);
            if (TicketFromDB is null)
            {
                return null;
            }
            return new EditTicket(Id: TicketFromDB.Id,
                Description: TicketFromDB.Description,
                DepartmentId:TicketFromDB.DepartmentId,
                Severity:TicketFromDB.Severity,
                developersId: TicketFromDB.Developers.Select(d=> d.Id).ToArray());
        }
    

        public TicketDetails? GetTicketDetails(int id)
        {
            Ticket? TicketFromDB = _ticketsRepo.GetTDetails(id);
            if (TicketFromDB is null)
            {
                return null;
            }

            return new TicketDetails(
                Id: TicketFromDB.Id,
                Description: TicketFromDB.Description,
                Severity: TicketFromDB.Severity,
                DepartmentName: TicketFromDB.Department?.Name ?? "",
                DevelopersNumber: TicketFromDB.Developers.Count());
        }

        public void Update(EditTicket ticketVM)
        {
            Ticket? entityToUpdate = _ticketsRepo.GetTDetails(ticketVM.Id);
            if (entityToUpdate is null)
            {
                return;
            }
            entityToUpdate.Description = ticketVM.Description;
            entityToUpdate.DepartmentId = ticketVM.DepartmentId;
            entityToUpdate.Developers = GetDevelopersByIds(ticketVM.developersId);
            _ticketsRepo.Update(entityToUpdate);
            _ticketsRepo.Save();
        }

        private ICollection<Developer> GetDevelopersByIds(int[] DevelopersId)
        {
            var developers =_developersRepo.GetAll();
            return developers.Where(i => DevelopersId.Contains(i.Id)).ToList();
        }
    }
}
