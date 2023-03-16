using IssuesSystem.Bl.ViewModels;
using IssuesSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesSystem.Bl
{
    public interface ITicketsManager
    {
        List<TicketViewModel> GetAll();
        TicketViewModel? Get(int id);
        void Add(TicketViewModel ticket);

        void Delete(int id);    
        void Update(TicketViewModel ticket, int id);    

    }

}
