using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TicketsSystem.DAL.Models;
using TicketsSystem.DAL.Repo.DepartmentsRepo;
using TicketsSystem.DAL.Repo.DevelopersRepo;

namespace TicketsSystem.BL.Managers.Departments
{
    public class DepartmentsManager : IDepartmentsManager
    {
        private readonly IDepartmentsRepo _departmentsRepo;
        public DepartmentsManager (IDepartmentsRepo departmentsRepo)
        {
            _departmentsRepo = departmentsRepo;
        }
        public List <Department> GetAll()
        {
            var departmentsFromDb = _departmentsRepo.GetAll();
            return departmentsFromDb.Select(d => new Department(d.Id, d.Name)).ToList ();

        }

    }
}

