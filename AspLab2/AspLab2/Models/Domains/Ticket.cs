namespace AspLab2.Models.Domains
{
    public class Ticket
    {
        public DateTime CreatedDate { get; set; }
        public string? Description { get; set; }

        public bool IsClosed { get; set; }

        public Severity Severity { get; set; }

        public Ticket()
        {
            CreatedDate = DateTime.Now;

        }
        public Ticket(DateTime createdDate, string decription, bool isClosed, Severity severity)
        {
            CreatedDate = DateTime.Now;
            Description = decription;
            IsClosed = isClosed;
            Severity = severity;
        }

        public static List<Ticket> GetTickets()
    => new() {
                new Ticket
                {
                    CreatedDate = DateTime.Now,
                    Description = "this ticket for USA",
                    IsClosed= true,
                    Severity = Severity.Low
                },
                new Ticket
                {
                    CreatedDate = DateTime.Now.AddHours(1).AddMinutes(2),
                    Description = "this ticket for KSA",
                    IsClosed= true,
                    Severity = Severity.Medium
                },
                new Ticket {

                    CreatedDate = DateTime.Now.AddHours(2).AddMinutes(4),
                    Description = "this ticket for KSA",
                    IsClosed= false,
                    Severity = Severity.High

                },
                new Ticket {


                    CreatedDate = DateTime.Now.AddHours(3).AddMinutes(6),
                    Description = "this ticket for UAE",
                    IsClosed= false,
                    Severity = Severity.Low

                },

                new Ticket {


                    CreatedDate = DateTime.Now.AddHours(4).AddMinutes(8),
                    Description = "this ticket for UAE",
                    IsClosed= false,
                    Severity = Severity.High

    }

    };
    }
}
