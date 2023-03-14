using Asplab3.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Asplab3.Models.View
{
    public class EditTicketVM
    {
        
        public Guid Id { get; set; }

        public string Description { get; init; } = string.Empty; 

        [Display(Name = "Is Closed")]
        public bool IsClosed { get; init; } //checkbox

        [Display(Name = "Department")]
    
        public Guid DepartmentId { get; init; } //=> CountryId

        public Severity Severity { get; init; } //=> Select

        [Display(Name = "Developers")]
        public List<Guid> DevelopersIds { get; init; } = new();
    }
}
