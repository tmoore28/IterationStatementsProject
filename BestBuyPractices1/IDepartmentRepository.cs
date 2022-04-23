using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyPractices1
{
    public interface IDepartmentRepository
    {
        public IEnumerable<Department> GetAllDepartments();
    }
}
