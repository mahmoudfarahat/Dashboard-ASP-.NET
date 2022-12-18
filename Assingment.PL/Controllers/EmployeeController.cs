using Assingment.BLL.Interfaces;
using Assingment.BLL.Repositories;
using Assingment.DAL.Entities;
using Assingment.PL.Helper;
using Assingment.PL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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

        public IActionResult Index(string SearchValue ="")
        {
            if(string.IsNullOrEmpty(SearchValue))
            {
                var employees = _unitOfWork.EmployeeRepository.GetAll();
                var mappedEmployees = _mapper.Map<IEnumerable<EmployeeViewModel>>(employees);
                return View(mappedEmployees);
            }
            else
            {
                var employees = _unitOfWork.EmployeeRepository.Search(SearchValue);
                var mappedEmployees = _mapper.Map<IEnumerable<EmployeeViewModel>>(employees);
                return View(mappedEmployees);
            }
           
        }

        public IActionResult Details(int id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(id);
            if (employee is null)
                return NotFound();
           var employeeViewModel = _mapper.Map<EmployeeViewModel>(employee);
      
            return View(employeeViewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = _unitOfWork.DepartmentRepository.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                employeeViewModel.ImageName = DocumentSettings.UploadFile(employeeViewModel.Image, "imgs");
                var employee = _mapper.Map<Employee>(employeeViewModel);
                _unitOfWork.EmployeeRepository.Add(employee);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Departments = _unitOfWork.DepartmentRepository.GetAll();
            return View(employeeViewModel);
    
        }
        public IActionResult Edit(int id )
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(id);
            var employeeViewModel = _mapper.Map<EmployeeViewModel>(employee);
            ViewBag.Departments = _unitOfWork.DepartmentRepository.GetAll();
            return View(employeeViewModel);
        }
        [HttpPost]
        public IActionResult Edit(int id, EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                var employeeFromDatabase = _unitOfWork.EmployeeRepository.GetById(id);

                if (employeeViewModel.Image != null)
                {
                    if (employeeFromDatabase.ImageName != null)

                    {
                        string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imgs");
                        string filePath = Path.Combine(folderPath, employeeFromDatabase.ImageName);
                        System.IO.File.Delete(filePath);
                    }

                    employeeViewModel.ImageName = DocumentSettings.UploadFile(employeeViewModel.Image, "imgs");

                }

                var employee  = _mapper.Map(employeeViewModel, employeeFromDatabase);
                _unitOfWork.EmployeeRepository.Update(employee);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Departments = _unitOfWork.DepartmentRepository.GetAll();
            return View(employeeViewModel);
        }

       public IActionResult Delete(int id, EmployeeViewModel employeeViewModel)
        {
            var employee = _mapper.Map<Employee>(employeeViewModel)
 ;            _unitOfWork.EmployeeRepository.Remove(employee);
            return RedirectToAction(nameof(Index));
        }
   

    }
}
