using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Business.Contract;
using EmployeeManagement.Service.Common;
using EmployeeManagement.Service.ViewModel;
using EmployeeManagement.Service.ViewModel.Param;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeBusinessAccess _businessAccess;

        public EmployeeController(ILogger<EmployeeController> logger,
            IEmployeeBusinessAccess businessAccess)
        {
            _logger = logger;
            _businessAccess = businessAccess;
        }

        // GET: EmployeeController
        public async Task<IActionResult> Index(string searchString)
        {
            var result = await _businessAccess.GetAllEmployeeAsync();
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.Trim();
                ViewData["CurrentFilter"] = searchString;
                result = result.Where(s => s.FullName.Contains(searchString)
                                        || s.Title.Contains(searchString)
                                        || s.DateOfJoining.ToString().Contains(searchString)
                                        || s.Salary.ToString().Contains(searchString)
                                        || s.Department.Contains(searchString)
                                        || s.Address.Contains(searchString)
                                       ).ToList();
            }
            return View(result);
        }

        // GET: EmployeeController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var param = new EmployeeViewModelParam() { ID = id };
            var result = await _businessAccess.GetEmployeeAsync(param);
            result.LineManagerIDs = (await _businessAccess.GetAllEmployeeAsync())
                .Where(v => v.ID == result.LineManagerID)
                .Select(v => new SelectListItem
                {
                    Text = v.FullName,
                    Value = v.ID.ToString(),
                    Selected = (v.ID == result.LineManagerID)
                }).ToList();
            return View(result);
        }

        // GET: EmployeeController/Create
        public async Task<IActionResult> Create()
        {
            var result = new EmployeeViewModel();
            result.LineManagerIDs = (await _businessAccess.GetAllEmployeeAsync())
                .Select(v => new SelectListItem
                {
                    Text = v.FullName,
                    Value = v.ID.ToString(),
                    Selected = false
                }).ToList();
            return View(result);
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] EmployeeViewModelParam param)
        {
            var result = await _businessAccess.CreateEmployeeAsync(param);
            if (result == null || !result.IsSuccess)
                ViewBag.ErrorMessage = result.Message;
            else
                return RedirectToAction(nameof(Index));
            return View();
        }

        // GET: EmployeeController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var param = new EmployeeViewModelParam() { ID = id };
            var result = await _businessAccess.GetEmployeeAsync(param);
            result.LineManagerIDs = (await _businessAccess.GetAllEmployeeAsync())
                .Where(v => v.ID != result.ID)
                .Select(v => new SelectListItem
                {
                    Text = v.FullName,
                    Value = v.ID.ToString(),
                    Selected = (v.ID == result.LineManagerID)
                }).ToList();
            return View(result);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] EmployeeViewModelParam param)
        {
            var result = await _businessAccess.UpdateEmployeeAsync(param);
            if (result == null || !result.IsSuccess)
                ViewBag.ErrorMessage = result.Message;
            else
                return RedirectToAction(nameof(Index));
            return View();
        }

        // GET: EmployeeController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var param = new EmployeeViewModelParam() { ID = id };
            var result = await _businessAccess.GetEmployeeAsync(param);
            return View(result);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, [FromForm] EmployeeViewModelParam param)
        {
            var result = await _businessAccess.DeleteEmployeeAsync(param);
            if (result == null || !result.IsSuccess)
                ViewBag.ErrorMessage = result.Message;
            else
                return RedirectToAction(nameof(Index));
            return View();
        }
    }
}
