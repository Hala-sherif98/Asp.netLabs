using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsSystem.DAL.Models;

namespace TicketsSystem.BL.ViewModels.Tickets
{
    public record TicketDetails(int DevelopersNumber, string DepartmentName , int Id, string Description, Severity Severity );

}
