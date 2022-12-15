﻿using Assingment.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment.BLL.Repositories
{
    public class UnitOfWork : IunitOfWork
    {
        public UnitOfWork(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
        {
            EmployeeRepository = employeeRepository;
            DepartmentRepository = departmentRepository;
        }

        public IEmployeeRepository EmployeeRepository { get ; set  ; }
        public IDepartmentRepository DepartmentRepository { get ; set ; }
    }
}
