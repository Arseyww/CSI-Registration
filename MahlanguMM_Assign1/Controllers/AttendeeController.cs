using MahlanguMM_Assign1.Data;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using MahlanguMM_Assign1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MahlanguMM_Assign1.Controllers
{
    public class AttendeeController : Controller
    {
        private readonly IConferenceRepository _conferenceRepository;


        public AttendeeController(IConferenceRepository conferenceRepository)
        {
            _conferenceRepository = conferenceRepository;
        }
        [HttpGet]
        public IActionResult Check()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Check([Required] string email)
        {
            if (ModelState.IsValid)
            {
                var attendee = _conferenceRepository.GetAttendeeByEmail(email);
                if (attendee == null)
                {
                    return RedirectToAction("Register", new { email });
                }
                else
                {
                    ViewBag.ErrorMessage = "You are already registered for the conference!";
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Register(string email)
        {
            PopulateCapacityDLL();
            var attendee = new Attendee
            {
                Email = email
            };
            return View(attendee);
        }
        [HttpPost]
        public IActionResult Register(Attendee attendee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _conferenceRepository.AddAttendee(attendee);
                    _conferenceRepository.SaveChanges();
                    return View("Confirmation", attendee);
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes." +
                    "Try again, and if the problem persists, " +
                   "contact your system administrator.");
                }
            }
            PopulateCapacityDLL(attendee.CapacityId);
            return View(attendee);
        }
        [HttpGet]
        public IActionResult List()
        {
            return View(_conferenceRepository.GetAllAttendeesWithCapacityDetails()
            .OrderBy(a => a.Name));
        }
        private void PopulateCapacityDLL(object selectedCapacity = null)
        {
            ViewBag.Capacities = new SelectList(_conferenceRepository.GetCapacities()
            .OrderBy(c => c.CapacityName),
            "CapacityId", "CapacityName", selectedCapacity);
        }

    }
}