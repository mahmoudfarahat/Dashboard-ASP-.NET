using Assingment.BLL.Interfaces;
using Assingment.BLL.Repositories;
using Assingment.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assingment.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private IunitOfWork _unitOfWork;

        public EmployeeController(IunitOfWork  unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var employees = _unitOfWork.EmployeeRepository.GetAll();
            return View(employees);
        }

        public IActionResult Details(int id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(id);
            if (employee is null)
                return NotFound();
            return View(employee);
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.EmployeeRepository.Add(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
    
        }




    }
}
