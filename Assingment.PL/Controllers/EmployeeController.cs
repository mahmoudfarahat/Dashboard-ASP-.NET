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
        private IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var employees = _repository.GetAll();
            return View(employees);
        }

        public IActionResult Details(int id)
        {
            var employee = _repository.GetById(id);
            if (employee is null)
                return NotFound();
            return View(employee);
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
    
        }




    }
}
