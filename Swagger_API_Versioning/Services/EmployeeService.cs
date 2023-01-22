using Swagger_API_Versioning.Interfaces;
using Swagger_API_Versioning.Models;

namespace Swagger_API_Versioning.Services
{
    public class EmployeeService : IEmployeeService
    {
        List<Employee> _employees = new List<Employee>();

        public EmployeeService()
        {
            int i;
            for (i = 1; i < 5; i++)
            {
                _employees.Add(
                new Employee()
                {
                    Employee_ID = i,
                    Employee_Name = $"Employee {i}",
                    Employee_Age = i + 1
                });
            }
        }

        public List<Employee> GetAll()
        {
            return _employees;
        }
    }
}
