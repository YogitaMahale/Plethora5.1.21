using Microsoft.AspNetCore.Mvc.Rendering;
using plathora.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace plathora.Services
{
 public    interface IBusinessContactUsservices
    {
        Task CreateAsync(BusinessContactUs  obj);
        BusinessContactUs GetById(int id);
        Task UpdateAsync(BusinessContactUs obj);
       
        IEnumerable<BusinessContactUs> GetAll();
    }
}
