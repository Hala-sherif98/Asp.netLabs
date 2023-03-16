using IssuesSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesSystem.Bl.ViewModels
{
    public record AddViewModel(string Description, string Title, Severity Severity);

}
