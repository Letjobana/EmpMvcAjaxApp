using ECommerceApp.Models;
using ECommerceApp.Persistance;
using ECommerceApp.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceApp.Repositories.Concrets
{
    public class DesignationRepository : IDesignationRepository
    {
        private readonly ApplicationDbContext context;

        public DesignationRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Designation> GetDesignations()
        {
            try
            {
                return context.Designations.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
