using ECommerceApp.Models;
using System.Collections.Generic;

namespace ECommerceApp.Repositories.Abstracts
{
    public interface IDesignationRepository
    {
        IEnumerable<Designation> GetDesignations();
    }
}
