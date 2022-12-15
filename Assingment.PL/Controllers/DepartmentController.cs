using Assingment.BLL.Interfaces;
using Assingment.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assingment.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentRepository _repository;

        public DepartmentController(IDepartmentRepository repository)
        {
            _repository = repository;

        }

        public IActionResult Index()
        {
            var departments = _repository.GetAll();

            return View(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if(ModelState.IsValid)
            {
                _repository.Add(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        public IActionResult Edit(int? id)
        {
            if (id is null)
                return NotFound();
            var department = _repository.GetById(id);
            if (department is null)
                return NotFound();

            return View(department);
        }
        [HttpPost]
        public IActionResult Edit(int id,Department department)
        {
            if (id != department.Id)
                return NotFound();
            if (ModelState.IsValid)
            {
                _repository.Update(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        public IActionResult Details(int? id)
        {
            if (id is null)
                return NotFound();
            var department = _repository.GetById(id);
            if (department is null)
                return NotFound();

            return View(department);
        }
        [HttpGet]
        public IActionResult Delete(int id, Department department)
        {
            if (id != department.Id)
                return NotFound();
            _repository.Delete(department);
            return RedirectToAction(nameof(Index));
        }
    }
}
