using KweziHealthESOP.Models;
using KweziHealthESOP.Services;
using Microsoft.AspNetCore.Mvc;

namespace KweziHealthESOP.Controllers
{
    public class StaffController : Controller
    {
        private readonly StaffService _staffService;

        public StaffController(StaffService staffService)
        {
            _staffService = staffService;
        }

        private bool IsAdmin()
        {
            return HttpContext.Session.GetString("IsAdmin")
                   == "true";
        }

        // READ - Display all staff
        public IActionResult Index()
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Login", "Access");
            }

            var staffMembers = _staffService.GetAllStaffMembers();

            return View(staffMembers);
        }

        // CREATE - Display form
        [HttpGet]
        public IActionResult Create()
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Login", "Access");
            }

            return View();
        }

        // CREATE - Save staff member
        [HttpPost]
        public IActionResult Create(StaffMember staffMember)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Login", "Access");
            }

            if (!ModelState.IsValid)
            {
                return View(staffMember);
            }

            _staffService.AddStaffMember(staffMember);

            return RedirectToAction(nameof(Index));
        }

        // UPDATE - Display edit form
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Login", "Access");
            }

            var staffMember =
                _staffService.GetStaffMemberById(id);

            if (staffMember == null)
            {
                return NotFound();
            }

            return View(staffMember);
        }

        // UPDATE - Save changes
        [HttpPost]
        public IActionResult Edit(
            int id,
            StaffMember staffMember)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Login", "Access");
            }

            if (!ModelState.IsValid)
            {
                return View(staffMember);
            }

            var updated =
                _staffService.UpdateStaffMember(
                    id,
                    staffMember);

            if (!updated)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        // DELETE
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Login", "Access");
            }

            var deleted =
                _staffService.DeleteStaffMember(id);

            if (!deleted)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}