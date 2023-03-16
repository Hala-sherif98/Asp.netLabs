using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TicketsSystem.DAL.Context;
using TicketsSystem.DAL.Models;

namespace TicketsSystem.DAL.Repo.DepartmentsRepo
{
    public class DepartmentsRepo : IDepartmentsRepo
    {
        private readonly TicketContext _context;

        public DepartmentsRepo(TicketContext context)
        {
            _context = context;
        }

        public IEnumerable<Department> GetAll()
        {
            return _context.Departments;
        }
    }
}
