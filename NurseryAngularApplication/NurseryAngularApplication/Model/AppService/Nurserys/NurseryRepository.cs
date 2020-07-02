using Microsoft.EntityFrameworkCore;
using NurseryAngularApplication.Model.Nurserys;
using NurseryAngularApplication.Model.Nurserys.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryAngularApplication.Model.AppService.Nurserys
{
    public class NurseryRepository: NurseryAppServiceBase, INurseryRepository
    {
        private readonly NursaryContext _nursaryContext;

        public NurseryRepository(NursaryContext nursaryContext)
        {
            _nursaryContext = nursaryContext;
        }

        public async Task<List<NurseryListDto>> GetAllNursey()
        {
            var nurserys = new List<NurseryListDto>();
            try
            {
                nurserys = (from b in _nursaryContext.Nurserys.Where(x => x.IsDeleted == false).
                            Include(x => x.State).Include(x => x.District).Include(x => x.Tehsil)
                            select new NurseryListDto()
                            {
                                Id = b.Id,
                                NurseryName = b.NurseryName,
                                FirstName = b.FirstName,
                                MiddleName = b.MiddleName,
                                LastName = b.LastName,
                                StateName = b.State.StateName,
                                StateId = b.StateId,
                                DistrictId = b.DistrictId,
                                DistrictName = b.District.DistrictName,
                                TehsilId = b.TehsilId,
                                TehsilName = b.Tehsil.TehsilName,
                                EmailId = b.EmailId,
                                ContactNumber = b.ContactNumber
                            }).ToList();

                return nurserys;
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public async Task<int> AddNursery(NurseryDto input)
        {
            Nursery cd = new Nursery();
            cd.NurseryName = input.NurseryName;
            cd.FirstName = input.FirstName;
            cd.MiddleName = input.MiddleName;
            cd.LastName = input.LastName;
            cd.StateId = input.StateId;
            cd.DistrictId = input.DistrictId;
            cd.EmailId = input.EmailId;
            cd.ContactNumber = input.ContactNumber;
            cd.CreationDate = DateTime.Now;
            cd.IsDeleted = false;
            cd.TehsilId = input.TehsilId;
            await _nursaryContext.Nurserys.AddAsync(cd);
            await _nursaryContext.SaveChangesAsync();

            return input.Id;
        }

        public async Task<NurseryListDto> NurseryEdit(int Id)
        {
            var nurserys = new NurseryListDto();
            try
            {
                nurserys = await (from b in _nursaryContext.Nurserys.Where(x => x.IsDeleted == false && x.Id == Id).
                             Include(x => x.State).Include(x => x.District).Include(x => x.Tehsil)
                                  select new NurseryListDto()
                                  {
                                      Id = b.Id,
                                      NurseryName = b.NurseryName,
                                      FirstName = b.FirstName,
                                      MiddleName = b.MiddleName,
                                      LastName = b.LastName,
                                      StateName = b.State.StateName,
                                      StateId = b.StateId,
                                      DistrictId = b.DistrictId,
                                      DistrictName = b.District.DistrictName,
                                      TehsilId = b.TehsilId,
                                      TehsilName = b.Tehsil.TehsilName,
                                      EmailId = b.EmailId,
                                      ContactNumber = b.ContactNumber
                                  }).FirstOrDefaultAsync();

                return nurserys;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> DeleteNursery(int? nurseryid)
        {
            int result = 0;
            var post = await _nursaryContext.Nurserys.FirstOrDefaultAsync(x => x.Id == nurseryid);
            if (post != null)
            {
                post.IsDeleted = true;
                _nursaryContext.Nurserys.Update(post);
                result = await _nursaryContext.SaveChangesAsync();
            }
            return result;
        }

        public async Task UpdateNursery(NurseryDto input)
        {
            var getdata = _nursaryContext.Nurserys.Where(x => x.Id == input.Id).FirstOrDefault();
            getdata.NurseryName = input.NurseryName;
            getdata.FirstName = input.FirstName;
            getdata.MiddleName = input.MiddleName;
            getdata.LastName = input.LastName;
            getdata.StateId = input.StateId;
            getdata.DistrictId = input.DistrictId;
            getdata.EmailId = input.EmailId;
            getdata.ContactNumber = input.ContactNumber;
            getdata.CreationDate = DateTime.Now;
            getdata.IsDeleted = false;
            getdata.TehsilId = input.TehsilId;
            _nursaryContext.Nurserys.Update(getdata);
            //Commit the transaction
            await _nursaryContext.SaveChangesAsync();

        }

    }
}
