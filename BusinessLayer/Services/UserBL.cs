using ModelLayer.Services;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class UserBL : IUserBL
    {
        private readonly IUserRL iuserRL;
        public UserBL(IUserRL iUserRL)
        {
            this.iuserRL = iUserRL;
        }
        public string AddEmployee(EmployeeModel model)
        {
            try
            {
                return this.iuserRL.AddEmployee(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string UpdateEmployee(EmployeeModel model)
        {
            try
            {
                return this.iuserRL.UpdateEmployee(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string DeleteEmployee(int? id)
        {
            try
            {
                return this.iuserRL.DeleteEmployee(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            try
            {
                return this.iuserRL.GetAllEmployees();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public EmployeeModel GetEmpDataById(int? id)
        {
            try
            {
                return this.iuserRL.GetEmpDataById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
