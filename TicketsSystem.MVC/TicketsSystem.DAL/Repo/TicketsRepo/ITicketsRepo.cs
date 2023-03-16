using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsSystem.DAL.Context;
using TicketsSystem.DAL.Models;

namespace TicketsSystem.DAL.Repo.TicketsRepo
{
    public interface ITicketsRepo
    {


        Ticket? GetTDetails(int id);
        IQueryable <Ticket> GetAll();

        void Update(Ticket ticket);

        void Save();



    }
}
