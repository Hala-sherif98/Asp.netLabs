using Microsoft.AspNetCore.Mvc;
using TicketsSystem.BL.Managers.Departments;
using TicketsSystem.BL.Managers.Developers;
using TicketsSystem.BL.Managers.Tickets;
using TicketsSystem.BL.ViewModels.Tickets;

namespace TicketsSystem.MVC.Controllers
{
    public class TicketsController : Controller
    {

        private readonly ITicketManager _ticketsManager;
        private readonly IDeveopersManager _deveopersManager;
        private readonly IDepartmentsManager _departmentsManager;

        public TicketsController(ITicketManager ticketsManager, DevelopersManager developersManager , IDepartmentsManager departmentsManager )
        {
            _ticketsManager = ticketsManager;
            _departmentsManager = departmentsManager;
            _deveopersManager = developersManager;
        }
        public IActionResult GetAll()
        {
            return View(_ticketsManager.GetAllTickets());
        }

        public IActionResult Details(int id)
        {
            var TicketVm = _ticketsManager.GetTicketDetails(id);
            if (TicketVm is null)
            {
                return NotFound();
            }

            return View(TicketVm);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var TicketVM = _ticketsManager.GetForEdit(id);

            ViewBag.Departments = _departmentsManager.GetAll();
            ViewBag.Developers = _deveopersManager.GetAll();
            return View(TicketVM);
        }

        [HttpPost]
        public IActionResult Edit(EditTicket ticketVm)
        {
            _ticketsManager.Update(ticketVm);
            return RedirectToAction(nameof(Details), new { id = ticketVm.Id });
        }
    }
    }

