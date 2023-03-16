using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsSystem.DAL.Models;
using TicketsSystem.DAL.Context;

namespace TicketsSystem.DAL.Repo.TicketsRepo
{
    public class TicketsRepo : ITicketsRepo
    {

        private readonly TicketContext _context;

        public TicketsRepo(TicketContext context)

        {

            _context = context;
        }

        public IQueryable<Ticket> GetAll()
        {
            return _context.Tickets;
        }


        public Ticket? GetTDetails(int id)
        {
            return _context.Set<Ticket>()
           .Include(p => p.Developers)
           .Include(p => p.Department)
           .FirstOrDefault(p => p.Id == id);

        }

        public void Update(Ticket ticket) { }

        public void Save()
        {
            _context.SaveChanges();
        }




    }
}
