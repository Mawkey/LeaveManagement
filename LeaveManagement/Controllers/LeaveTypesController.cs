using AutoMapper;
using LeaveManagement.Contracts;
using LeaveManagement.Data;
using LeaveManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeRepository repo;
        private readonly IMapper mapper;

        public LeaveTypesController(ILeaveTypeRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        // GET: LeaveTypesController
        public ActionResult Index()
        {
            List<LeaveType> leaveTypes = repo.FindAll().ToList();
            var model = mapper.Map<List<LeaveType>, List<LeaveTypeVM>>(leaveTypes);
            return View(model);
        }

        // GET: LeaveTypesController/Details/5
        public ActionResult Details(int id)
        {
            if (!repo.Exists(id))
            {
                return NotFound();
            }

            LeaveType leaveType = repo.FindById(id);
            LeaveTypeVM model = mapper.Map<LeaveTypeVM>(leaveType);

            return View(model);
        }

        // GET: LeaveTypesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaveTypeVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                LeaveType leaveType = mapper.Map<LeaveType>(model);
                leaveType.DateCreated = DateTime.Now;
                bool isSuccessful = repo.Create(leaveType);

                if (!isSuccessful)
                {
                    ModelState.AddModelError("", "Something went wrong...");
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong...");

                return View(model);
            }
        }

        // GET: LeaveTypesController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!repo.Exists(id))
            {
                return NotFound();
            }

            LeaveType leaveType = repo.FindById(id);
            LeaveTypeVM model = mapper.Map<LeaveTypeVM>(leaveType);

            return View(model);
        }

        // POST: LeaveTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LeaveTypeVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                LeaveType leaveType = mapper.Map<LeaveType>(model);
                bool isSuccessful = repo.Update(leaveType);
                if (!isSuccessful)
                {
                    ModelState.AddModelError("", "Something went wrong...");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong...");
                return View(model);
            }
        }

        // GET: LeaveTypesController/Delete/5
        public ActionResult Delete(int id)
        {
            LeaveType leaveType = repo.FindById(id);
            if (leaveType == null)
            {
                return NotFound();
            }

            bool isSuccessful = repo.Delete(leaveType);

            if (!isSuccessful)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: LeaveTypesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, LeaveTypeVM model)
        {
            try
            {
                LeaveType leaveType = repo.FindById(id);
                if (leaveType == null)
                {
                    return NotFound();
                }

                bool isSuccessful = repo.Delete(leaveType);

                if (!isSuccessful)
                {
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
