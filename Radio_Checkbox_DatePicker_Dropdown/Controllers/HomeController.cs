using Microsoft.AspNetCore.Mvc;
using Radio_Checkbox_DatePicker_Dropdown.Data;
using Radio_Checkbox_DatePicker_Dropdown.Models;
using System.Diagnostics;

namespace Radio_Checkbox_DatePicker_Dropdown.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new ScheduleViewModel
            {
                Physicians = _context.Physicians.ToList(),
                Professions = _context.Professions.ToList(),
                SelectedDate = DateOnly.FromDateTime(DateTime.Today)
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(ScheduleViewModel model)
        {
            var schedule = new Schedule
            {
                SelectedPhysician = model.SelectedPhysician,
                SelectedProfession = model.SelectedProfession,
                IsMale = model.IsMale,
                IsFemale = model.IsFemale,
                SelectedDate = model.SelectedDate.ToDateTime(new TimeOnly())
            };

            _context.Schedules.Add(schedule);
            _context.SaveChanges();

            return RedirectToAction("ViewSchedules");
        }

        public IActionResult ViewSchedules()
        {
            var schedules = _context.Schedules.ToList();
            return View(schedules);
        }

        [HttpGet]
        public IActionResult ManagePhysicians()
        {
            return View(_context.Physicians.ToList());
        }

        [HttpPost]
        public IActionResult AddPhysician(string name)
        {
            _context.Physicians.Add(new Physician { Name = name });
            _context.SaveChanges();
            return RedirectToAction("ManagePhysicians");
        }

        [HttpPost]
        public IActionResult RemovePhysician(int id)
        {
            var physician = _context.Physicians.Find(id);
            if (physician != null)
            {
                _context.Physicians.Remove(physician);
                _context.SaveChanges();
            }
            return RedirectToAction("ManagePhysicians");
        }

        [HttpGet]
        public IActionResult ManageProfessions()
        {
            return View(_context.Professions.ToList());
        }

        [HttpPost]
        public IActionResult AddProfession(string name)
        {
            _context.Professions.Add(new Profession { Name = name });
            _context.SaveChanges();
            return RedirectToAction("ManageProfessions");
        }

        [HttpPost]
        public IActionResult RemoveProfession(int id)
        {
            var profession = _context.Professions.Find(id);
            if (profession != null)
            {
                _context.Professions.Remove(profession);
                _context.SaveChanges();
            }
            return RedirectToAction("ManageProfessions");
        }
    }
}
