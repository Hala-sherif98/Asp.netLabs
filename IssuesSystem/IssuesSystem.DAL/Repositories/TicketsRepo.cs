using IssuesSystem.DAL.Context;
using IssuesSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesSystem.DAL.Repositories
{
    //in this class we will implement all the abstracted methods 
   public class TicketsRepo : ITicketsRepo
   {
        private readonly IssuesContext _context;
        public TicketsRepo(IssuesContext context) {

            _context = context;
        }
        
        public void Add(Ticket ticket)
        {
            _context.Tickets.Add(ticket);   
        }

        public IEnumerable<Ticket>  GetAll()
        {
            return _context.Tickets.AsNoTracking(); //No tracked  for better performance
        }

        public Ticket? Get(int id)
        {
            return _context.Tickets.Find(id);
        }

        //empty fuction to force business to call it in cass we want to allow tracking
        public void Update(Ticket ticket)
        {
            //var TicketToEdit = _context.Tickets.First(); //no need as get by id will track the object
            //TicketToEdit.Title = "hello";  //no need as it is business resposnibility
            //_context.SaveChanges();  //no need as we have the function already

            //_context.Tickets.Update(ticket);  will work without tracking
            //_context.Entry(ticket).State= EntityState.Modified;  will work without tracking

        }

        public void Delete(int id)
        {
            var TicketToDelete = Get(id);
            if (TicketToDelete != null) { 
            _context.Tickets.Remove(TicketToDelete);
            }

        }

        public int SaveChanges()
        {
            return _context.SaveChanges();  // returns number of affected Rows
        }



    }
}
