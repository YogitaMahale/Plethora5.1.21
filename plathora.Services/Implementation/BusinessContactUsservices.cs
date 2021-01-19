using Microsoft.AspNetCore.Mvc.Rendering;
using plathora.Entity;
using plathora.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plathora.Services.Implementation
{
    public class BusinessContactUsservices : IBusinessContactUsservices
    {
        private readonly ApplicationDbContext _context;
        public BusinessContactUsservices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(BusinessContactUs  obj)
        {
            await _context.BusinessContactUs.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

     
        public IEnumerable<BusinessContactUs> GetAll() =>_context.BusinessContactUs.ToList();
        public BusinessContactUs getbyid(int id) =>
            _context.BusinessContactUs.Where(x => x.Id == id).FirstOrDefault();

        public BusinessContactUs GetById(int id)=>      
            _context.BusinessContactUs.Where(x => x.Id  == id).FirstOrDefault();
        

        public async Task UpdateAsync(BusinessContactUs obj)
        {
            _context.Update(obj);
            await _context.SaveChangesAsync();
        }
      
    }
}
