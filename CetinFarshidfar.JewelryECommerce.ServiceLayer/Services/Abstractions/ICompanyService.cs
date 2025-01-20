using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.ServiceLayer.Services.Abstractions
{
    public interface ICompanyService
    {
        Task CreateComApplicationAsync(ComApplicationAddVM comApplicationAddVM);
        Task<Guid> GetCompanyIdByCoFounderAsync(Guid coFounderId);
        Task<UpdateCompanyVM> GetCompanyByIdAsync(Guid companyId);
        Task<bool> UpdateCompanyAsync(UpdateCompanyVM updateCompanyVM);
    }
}
