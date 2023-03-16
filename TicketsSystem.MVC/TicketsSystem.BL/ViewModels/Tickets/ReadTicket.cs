using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsSystem.DAL.Models;

namespace TicketsSystem.BL.ViewModels.Ticket
{
 

  public record ReadTicket(int Id, string Description, Severity Severity, int DepartmentId);
    
}
