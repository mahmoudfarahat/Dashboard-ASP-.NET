﻿using Assingment.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment.BLL.Interfaces
{
    public interface IDepartmentRepository
    {
        Department GetById(int? id);

        IEnumerable<Department> GetAll();

        int Add(Department department);

        int Update(Department department);


        int Delete(Department department);
    }
}
