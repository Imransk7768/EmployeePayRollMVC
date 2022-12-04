using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public interface IUserRL
    {
        public string AddEmployee(EmployeeModel emp);
        public string UpdateEmployee(EmployeeModel model);
        public string DeleteEmployee(int? id);
        public IEnumerable<EmployeeModel> GetAllEmployees();
        public EmployeeModel GetEmpDataById(int? id);

    }
}
