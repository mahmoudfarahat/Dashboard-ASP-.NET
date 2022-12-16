using Assingment.BLL.Interfaces;
using Assingment.BLL.Repositories;
using Assingment.DAL.Entities;
using Assingment.PL.Models;
using AutoMapper;
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
        private IMapper _mapper;

        public EmployeeController(IunitOfWork  unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var employees = _unitOfWork.EmployeeRepository.GetAll();
            var mappedEmployees = _mapper.Map<IEnumerable<EmployeeViewModel>>(employees);
            return View(mappedEmployees);
        }

        public IActionResult Details(int id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(id);
            if (employee is null)
                return NotFound();
            EmployeeViewModel employeeViewModel = new EmployeeViewModel()
            {
                Id = employee.Id,
                Address = employee.Address,
                DateOfCreation = employee.DateOfCreation,
                Email = employee.Email,
                HireDate = employee.HireDate,
                IsActive = employee.IsActive,
                Name = employee.Name,
                Salary = employee.Salary
            };

            return View(employeeViewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                var employee = _mapper.Map<Employee>(employeeViewModel);
                _unitOfWork.EmployeeRepository.Add(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employeeViewModel);
    
        }




    }
}
