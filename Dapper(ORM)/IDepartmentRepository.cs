using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper_ORM_
{
    public interface IDepartmentRepository
    {
       
            IEnumerable<Department> GetAllDepartments();
        
    }
}
