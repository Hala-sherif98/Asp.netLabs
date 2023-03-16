using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsSystem.DAL.Models;

namespace TicketsSystem.BL.Managers.Developers
{
    public interface IDeveopersManager
    {
        List <Developer> GetAll();
    }
}
