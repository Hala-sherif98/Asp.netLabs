using Asplab3.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Xml.Linq;

namespace Asplab3.Models.View
{
    public class TicketVM
    {
        public string Description { get; init; } = string.Empty;
        [Display(Name = "Is Closed")]
        public bool IsClosed { get; init; }
        public Severity Severity { get; init; }

        [Display(Name = "Department")]
        public  Guid DepartmentId  { get; init; }

        [Display(Name = "Developers")]
        public List<Guid> DevelopersIds { get; init; } = new();




    }
}
