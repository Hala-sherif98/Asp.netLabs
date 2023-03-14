using Asplab3.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.Metrics;
using Asplab3.Models.View;



namespace Asplab3.Controllers
{
    public class TicketsController : Controller
    {

        public IActionResult GetAll()
        {
            var tickets = Ticket.GetTickets();
            return View(tickets);
        }


        [HttpGet]
        public IActionResult Form()
        {

            GetFormatBody();
            return View();
        }
        [HttpPost]
        public IActionResult Add(TicketVM TicketVM)
        {

            var developers = Developer.GetDevelopers();
            var selectedDevelopersIds = TicketVM.DevelopersIds;

            var selectedDeveloprs = developers
                .Where(d => selectedDevelopersIds.Contains(d.Id))
                .ToList();


            Ticket ticket = new Ticket
            {
                Description = TicketVM.Description,
                IsClosed = TicketVM.IsClosed,
                Severity = TicketVM.Severity,
                Department = Department.GetDepartments().First(d => d.Id == TicketVM.DepartmentId),
                Developers = selectedDeveloprs

            };


            Ticket._tickets.Add(ticket);
            return RedirectToAction(nameof(GetAll));
        }

        [HttpGet]
        public IActionResult EditForm(Guid id)
        {
            GetFormatBody();
            var TicketToEdit = Ticket._tickets.First(t => t.Id == id);
            var ticketVm = new EditTicketVM
            {
                Id = TicketToEdit.Id,
                Description = TicketToEdit.Description,
                IsClosed = TicketToEdit.IsClosed,
                Severity = TicketToEdit.Severity,
                DepartmentId = TicketToEdit.Department.Id,
                DevelopersIds = TicketToEdit.Developers.Select(d=> d.Id).ToList(),

            };

            return View("Edit",ticketVm);
        }

        [HttpPost]
        public IActionResult Edit(EditTicketVM ticketVM)
        {
            var selectedDevelopers = GetDevelopersByIds(ticketVM.DevelopersIds);

            var TicketToEdit =Ticket._tickets.First(a => a.Id == ticketVM.Id);

            TicketToEdit.Id = ticketVM.Id;
            TicketToEdit.Description = ticketVM.Description;
            TicketToEdit.Severity = ticketVM.Severity;
            TicketToEdit.IsClosed = ticketVM.IsClosed;
            TicketToEdit.Department = Department.GetDepartments().First(d=> d.Id == ticketVM.DepartmentId);
            var selectedDeveloprss = selectedDevelopers.ToList();
            TicketToEdit.Developers = selectedDevelopers;

            return RedirectToAction(nameof(GetAll));
        }




        public void GetFormatBody()
        {
            var departments = Department.GetDepartments();
            var departmentsList = departments
                .Select(department => new SelectListItem(department.Name, department.Id.ToString()));

            ViewBag.departments = departmentsList;


            var developers = Developer.GetDevelopers();
            var developersListItems = developers.Select(developer => new SelectListItem(developer.FirstName +" "+ developer.LastName, developer.Id.ToString()));
            ViewBag.developersListItems = developersListItems;
        }

        private static List<Developer> GetDevelopersByIds(List<Guid> selectedDevelopersIds)
        {
            var developers = Developer.GetDevelopers();
            var selectedDeveopers = developers
                .Where(d => selectedDevelopersIds.Contains(d.Id))
                .ToList();
            return selectedDeveopers;
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var TicketToDelete = Ticket._tickets.First(t => t.Id == id);
            Ticket._tickets.Remove(TicketToDelete);

            return RedirectToAction(nameof(GetAll));
        }

    }
}

