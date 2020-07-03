using Abp.Application.Services;
using Abp.Collections.Extensions;
using Microsoft.EntityFrameworkCore;
using NurseryAngularApplication.Model.Employee;
using NurseryAngularApplication.Model.Employee.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryAngularApplication.Model.AppService.Employees
{
    public class EmployeeRepository : ApplicationService, IEmployeeRepository
    {

        private readonly NursaryContext _nursaryContext;

        public EmployeeRepository(NursaryContext nursaryContext)
        {
            _nursaryContext = nursaryContext;
        }

        public async Task<List<EmployeeListDto>> GetAllEmployee(int? NurseryId)
        {
            var query = new List<EmployeeListDto>();
            try
            {
                query = (from b in _nursaryContext.EmployeeDetails.Where(x => x.IsDeleted == false).
                            Include(x => x.Nursery).
                            Include(x => x.State).Include(x => x.District).Include(x => x.Tehsil)
                            .WhereIf(NurseryId != null, x => x.NurseryId == NurseryId)
                         select new EmployeeListDto()
                         {
                             Id = b.Id,
                             Nursery = b.Nursery.NurseryName,
                             FirstName = b.FirstName,
                             MiddleName = b.MiddleName,
                             LastName = b.LastName,
                             State = b.State.StateName,
                             District = b.District.DistrictName,
                             Tehsil = b.Tehsil.TehsilName,
                             Email = b.Email,
                             DateofBirth = b.DateofBirth,
                             VillageName = b.VillageName,
                             ContactNumber = b.ContactNumber
                         }).ToList();

                return query;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<EmployeeListDto> EditEmployee(int Id)
        {
            var query = new EmployeeListDto();
            try
            {
                query = await (from b in _nursaryContext.EmployeeDetails.Where(x => x.IsDeleted == false && x.Id == Id).
                             Include(x => x.Nursery).
                             Include(x => x.State).Include(x => x.District).Include(x => x.Tehsil)

                               select new EmployeeListDto()
                               {
                                   Id = b.Id,
                                   Nursery = b.Nursery.NurseryName,
                                   FirstName = b.FirstName,
                                   MiddleName = b.MiddleName,
                                   LastName = b.LastName,
                                   StateId = b.StateId,
                                   State = b.State.StateName,
                                   DistrictId = b.DistrictId,
                                   District = b.District.DistrictName,
                                   TehsilId = b.TehsilId,
                                   Tehsil = b.Tehsil.TehsilName,
                                   Email = b.Email,
                                   DateofBirth = b.DateofBirth,
                                   VillageName = b.VillageName,
                                   ContactNumber = b.ContactNumber
                               }).FirstOrDefaultAsync();

                return query;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> AddEmployee(CreateorEditEmployeeDto input)
        {
            EmployeeDetail cd = new EmployeeDetail();
            cd.NurseryId = input.NurseryId;
            cd.FirstName = input.FirstName;
            cd.MiddleName = input.MiddleName;
            cd.LastName = input.LastName;
            cd.StateId = input.StateId;
            cd.DistrictId = input.DistrictId;
            cd.Email = input.Email;
            cd.ContactNumber = input.ContactNumber;
            cd.CreationDate = DateTime.Now;
            cd.IsDeleted = false;
            cd.TehsilId = input.TehsilId;
            cd.EducationType = input.EducationType;
            cd.GenderType = input.GenderType;
            cd.VillageName = input.VillageName;
            await _nursaryContext.EmployeeDetails.AddAsync(cd);
            await _nursaryContext.SaveChangesAsync();

            return input.Id;
        }

        public async Task<int> DeleteEmployee(int EmployeeId)
        {
            int result = 0;
            var employee = await _nursaryContext.EmployeeDetails.FirstOrDefaultAsync(x => x.Id == EmployeeId);
            if (employee != null)
            {
                employee.IsDeleted = true;
                _nursaryContext.EmployeeDetails.Update(employee);
                result = await _nursaryContext.SaveChangesAsync();
            }
            return result;
        }

        public async Task UpdateEmployee(CreateorEditEmployeeDto input)
        {
            var getdata = _nursaryContext.EmployeeDetails.Where(x => x.Id == input.Id).FirstOrDefault();
            getdata.NurseryId = input.NurseryId;
            getdata.FirstName = input.FirstName;
            getdata.MiddleName = input.MiddleName;
            getdata.LastName = input.LastName;
            getdata.StateId = input.StateId;
            getdata.DistrictId = input.DistrictId;
            getdata.Email = input.Email;
            getdata.ContactNumber = input.ContactNumber;
            getdata.CreationDate = DateTime.Now;
            getdata.IsDeleted = false;
            getdata.TehsilId = input.TehsilId;
            getdata.EducationType = input.EducationType;
            getdata.GenderType = input.GenderType;
            getdata.VillageName = input.VillageName;
            _nursaryContext.EmployeeDetails.Update(getdata);
            //Commit the transaction
            await _nursaryContext.SaveChangesAsync();

        }
    }
}
