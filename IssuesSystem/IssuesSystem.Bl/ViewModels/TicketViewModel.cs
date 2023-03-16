using IssuesSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesSystem.Bl.ViewModels
{
    public record TicketViewModel(int Id, string Title, String Description, Severity Severity)
    {
        public string DescriptionMarkup => $"<h4> {Description} </h4?";
        public string TitleMarkup => $"<h4> {Title} </h4?";
        public string SeverityMarkup => $"<h4> {Severity} </h4?";
        public string IdMarkup => $"<h4> {Id} </h4?";

    };

}
