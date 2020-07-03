using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryAngularApplication.Model.Employee.Dto
{

    public interface IEmployeeRepository : IApplicationService
    {
        public Task<List<EmployeeListDto>> GetAllEmployee(int? NurseryId);
        Task<int> AddEmployee(CreateorEditEmployeeDto input);
        Task<int> DeleteEmployee(int EmployeeId);
        Task<EmployeeListDto> EditEmployee(int Id);
        Task UpdateEmployee(CreateorEditEmployeeDto input);
    }
}
