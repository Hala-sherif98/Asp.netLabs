using AspLab2.Models.Domains;

namespace AspLab2.Models.Views
{
    public record TicketVM(string? Description, bool IsClosed, Severity Severity);
     
}
