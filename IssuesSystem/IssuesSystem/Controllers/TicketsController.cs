

using IssuesSystem.Bl;
using IssuesSystem.Bl.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IssuesSystem.Controllers
{
    public class TicketsController : Controller
    {

        private readonly ITicketsManager _ticketsManager;

        public TicketsController(ITicketsManager ticketsManager)
        {
            _ticketsManager = ticketsManager;
        }
        public IActionResult GetAll()
        {
            return View(_ticketsManager.GetAll());
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
      
        public IActionResult Add(TicketViewModel ticket)
        {
            _ticketsManager.Add(ticket);
            return RedirectToAction(nameof(GetAll));
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var ticketToEdit = _ticketsManager.Get(id);
            return View(ticketToEdit);
        }
        [HttpPost]
        public IActionResult Edit(TicketViewModel ticket, int id)
        {
            _ticketsManager.Update(ticket, id);
            return RedirectToAction(nameof(GetAll));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _ticketsManager.Delete(id);
            return RedirectToAction(nameof(GetAll));
        }

    }
}
