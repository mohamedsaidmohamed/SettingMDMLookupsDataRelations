using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;
using Z.EntityFramework.Extensions;
namespace Persistence.Repositories
{
    public class MDMRepository
    {
       private  readonly SafeerContext safeerContext;
        public MDMRepository()
        {
            safeerContext = new SafeerContext();
        }

        public async Task<List<Major>>  GetMajors() 
        {
            return await safeerContext.Majors.ToListAsync();
        }
        public async Task<List<MinistryMajor>> GetMinistryMajors()
        {
            return await safeerContext.MinistryMajors .ToListAsync();
        }

        public async Task<int> UpdateMajors(List<Major> Majors) 
        { 
            safeerContext.UpdateRange(Majors);
            return await safeerContext.SaveChangesAsync();
        }
        public async Task<int> UpdateMajors(List<int> Majors,int ministryMajorCode)
        {
            return  await safeerContext.Majors.Where(x => Majors.Contains(x.BusinessCode.Value)).UpdateAsync(x => new Major { MinistryMajorCode = ministryMajorCode }) ;
        }
    }
}
