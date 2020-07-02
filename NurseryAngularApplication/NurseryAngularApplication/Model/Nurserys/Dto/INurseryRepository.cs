using Abp.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryAngularApplication.Model.Nurserys.Dto
{
    public interface INurseryRepository : IApplicationService
    {      
        Task<List<NurseryListDto>> GetAllNursey();
        Task<NurseryListDto> NurseryEdit(int Id);
        Task<int> AddNursery(NurseryDto input);
        Task<int> DeleteNursery(int? nurseryid);
        Task UpdateNursery(NurseryDto input);
    }
}
