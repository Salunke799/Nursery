using Abp.Application.Services;
using Abp.Collections.Extensions;
using Microsoft.EntityFrameworkCore;
using NurseryAngularApplication.Model.Farmers;
using NurseryAngularApplication.Model.Farmers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryAngularApplication.Model.AppService.Farmers
{
    public class FarmerRepository : ApplicationService, IFarmerRepository
    {
        private readonly NursaryContext _nursaryContext;

        public FarmerRepository(NursaryContext nursaryContext)
        {
            _nursaryContext = nursaryContext;

        }
        public async Task<List<FarmerListDto>> GetAllFarmer(int? NurseryId)
        {
            var query = new List<FarmerListDto>();
            try
            {
                query = (from b in _nursaryContext.Farmers.Where(x => x.IsDeleted == false).
                            Include(x => x.Nursery).
                            Include(x => x.State).Include(x => x.District).Include(x => x.Tehsil)
                            .WhereIf(NurseryId != null, x => x.NurseryId == NurseryId)
                         select new FarmerListDto()
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

        public async Task<FarmerListDto> EditFarmer(int Id)
        {
            var query = new FarmerListDto();
            try
            {
                query = await (from b in _nursaryContext.Farmers.Where(x => x.IsDeleted == false && x.Id == Id).
                             Include(x => x.Nursery).
                             Include(x => x.State).Include(x => x.District).Include(x => x.Tehsil)
                               select new FarmerListDto()
                               {
                                   Id = b.Id,
                                   Nursery = b.Nursery.NurseryName,
                                   FirstName = b.FirstName,
                                   MiddleName = b.MiddleName,
                                   LastName = b.LastName,
                                   TehsilId = b.TehsilId,
                                   StateId = b.StateId,
                                   State = b.State.StateName,
                                   DistrictId = b.DistrictId,
                                   District = b.District.DistrictName,
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
        public async Task<int> AddFarmer(CreateorEditFarmer input)
        {
            Farmer cd = new Farmer();
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
            await _nursaryContext.Farmers.AddAsync(cd);
            await _nursaryContext.SaveChangesAsync();

            return input.Id;
        }
        public async Task<int> DeleteFarmer(int FarmerId)
        {
            int result = 0;
            var farmer = await _nursaryContext.Farmers.FirstOrDefaultAsync(x => x.Id == FarmerId);
            if (farmer != null)
            {
                farmer.IsDeleted = true;
                _nursaryContext.Farmers.Update(farmer);
                result = await _nursaryContext.SaveChangesAsync();
            }
            return result;
        }
        public async Task UpdateFarmer(CreateorEditFarmer input)
        {
            var getdata = _nursaryContext.Farmers.Where(x => x.Id == input.Id).FirstOrDefault();
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
            _nursaryContext.Farmers.Update(getdata);
            //Commit the transaction
            await _nursaryContext.SaveChangesAsync();

        }


    }
}
