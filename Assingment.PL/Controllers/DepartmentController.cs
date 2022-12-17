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
        private IunitOfWork _unitOfWork;

        public DepartmentController(IunitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public IActionResult Index()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();
            //ViewData["message"] = "All Departments";
            ViewBag.Message = "All Departments";
         
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
                _unitOfWork.DepartmentRepository.Add(department);
                TempData["Message"] = "Department is Successfully Added";
                return RedirectToAction(nameof(Index));
            }
          

            return View(department);
        }

        public IActionResult Edit(int?  id)
        {
            if (id is null)
                return NotFound();
            var department = _unitOfWork.DepartmentRepository.GetById(id);
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
                _unitOfWork.DepartmentRepository.Update(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        public IActionResult Details(int? id)
        {
            if (id is null)
                return NotFound();
            var department = _unitOfWork.DepartmentRepository.GetById(id);
            if (department is null)
                return NotFound();

            return View(department);
        }
        [HttpGet]
        public IActionResult Delete(int id, Department department)
        {
            if (id != department.Id)
                return NotFound();
            _unitOfWork.DepartmentRepository.Remove(department);
            return RedirectToAction(nameof(Index));
        }
    }
}
