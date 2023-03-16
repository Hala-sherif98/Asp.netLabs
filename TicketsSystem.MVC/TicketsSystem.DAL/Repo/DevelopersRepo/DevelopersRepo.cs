using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TicketsSystem.DAL.Context;
using TicketsSystem.DAL.Models;

namespace TicketsSystem.DAL.Repo.DevelopersRepo
{
    public class DevelopersRepo : IDevelopersRepo
    {
        private readonly TicketContext _context;

        public DevelopersRepo(TicketContext context)
        {
            _context = context;
        }

        public IQueryable<Developer> GetAll()
        {
            return _context.Developers;
        }


    }
}
