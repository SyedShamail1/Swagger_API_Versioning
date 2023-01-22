using Swagger_API_Versioning.Interfaces;
using Swagger_API_Versioning.Models;

namespace Swagger_API_Versioning.Services
{
    public class DepartmentService : IDepartmentService
    {
        List<Department> _departments = new List<Department>();

        public DepartmentService()
        {
            for (int i = 1; i < 5; i++)
            {
                _departments.Add(
                new Department()
                {
                    Department_ID = i,
                    Department_Name = $"Department {i}",
                    Department_Age = i + 1
                }
                );
            }
        }
        
        public List<Department> GetAll()
        {
            return _departments;
        }
    }
}
