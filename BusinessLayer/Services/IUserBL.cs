using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IUserBL
    {
        public string AddEmployee(EmployeeModel model);
        public string UpdateEmployee(EmployeeModel model);
        public string DeleteEmployee(int? id);
        public IEnumerable<EmployeeModel> GetAllEmployees();
        public EmployeeModel GetEmpDataById(int? id);

    }
}
