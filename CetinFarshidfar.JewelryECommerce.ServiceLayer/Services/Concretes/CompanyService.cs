using AutoMapper;
using CetinFarshidfar.JewelryECommerce.DataAccessLayer.UnitOfWorks;
using CetinFarshidfar.JewelryECommerce.EntityLayer.Entitites;
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Companies;
using CetinFarshidfar.JewelryECommerce.ServiceLayer.Extensions;
using CetinFarshidfar.JewelryECommerce.ServiceLayer.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.ServiceLayer.Services.Concretes
{
    public class CompanyService : ICompanyService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public CompanyService(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task CreateComApplicationAsync(ComApplicationAddVM comApplicationAddVM)
        {
            try
            {
                var map = mapper.Map<CompanyApplication>(comApplicationAddVM);
                await unitOfWork.GetRepository<CompanyApplication>().AddAsync(map);
                await unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                // Hata durumunda loglama veya başka işlemler yapılabilir
                throw new InvalidOperationException("Bir hata oluştu", ex);
            }
        }

        public async Task<UpdateCompanyVM> GetCompanyByIdAsync(Guid companyId)
        {
            var company = await unitOfWork.GetRepository<Company>().GetAsync(c=>c.Id==companyId);
            var map = mapper.Map<UpdateCompanyVM>(company);
            return map;
        }

        public async Task<Guid> GetCompanyIdByCoFounderAsync(Guid coFounderId)
        {
            var company = await unitOfWork.GetRepository<Company>().GetAsync(c=>c.CoFounderId==coFounderId);
            return company.Id;
        }

        public async Task<bool> UpdateCompanyAsync(UpdateCompanyVM updateCompanyVM)
        {
            try
            {
                var company = await unitOfWork.GetRepository<Company>().GetAsync(c => c.Id == updateCompanyVM.Id);
                mapper.Map(updateCompanyVM, company);
                company.ModifiedBy = _user.GetLoggedInEmail();
                company.ModifiedDate = DateTime.Now;
                await unitOfWork.GetRepository<Company>().UpdateAsync(company);
                await unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex) { 
                return false;
            }
        }
    }
}
