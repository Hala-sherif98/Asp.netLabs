using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsSystem.BL.ViewModels.Tickets;
using TicketsSystem.DAL.Models;
using TicketsSystem.DAL.Repo.DevelopersRepo;

namespace TicketsSystem.BL.Managers.Developers
{
    public class DevelopersManager : IDeveopersManager
    {
        private readonly IDevelopersRepo _developersRepo;

        public DevelopersManager(IDevelopersRepo developersRepo)
        {
            _developersRepo = developersRepo;
        }
        public List<Developer> GetAll()
        {
            var developerFromDb = _developersRepo.GetAll();
            return developerFromDb.Select(d => new Developer (d.Id, d.Name)).ToList(); 
        }
    }
}
