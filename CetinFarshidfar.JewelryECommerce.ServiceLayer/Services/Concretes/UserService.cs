using AutoMapper;
using CetinFarshidfar.JewelryECommerce.DataAccessLayer.UnitOfWorks;
using CetinFarshidfar.JewelryECommerce.EntityLayer.Entitites;
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Users;
using CetinFarshidfar.JewelryECommerce.ServiceLayer.AutoMapper.Users;
using CetinFarshidfar.JewelryECommerce.ServiceLayer.Extensions;
using CetinFarshidfar.JewelryECommerce.ServiceLayer.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CetinFarshidfar.JewelryECommerce.ServiceLayer.Services.Concretes
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly ClaimsPrincipal _user;

        public UserService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
        {
            this.unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public async Task<IdentityResult> CreateUserAsync(UserRegisterVM userRegisterVM)
        {
            var map = new AppUser() { Email = userRegisterVM.Email, FullName = userRegisterVM.FullName, PhoneNumber = userRegisterVM.PhoneNumber };
            map.UserName = userRegisterVM.Email;
            var result = await userManager.CreateAsync(map, userRegisterVM.Password);
            if (result.Succeeded)
            {
                return result;
            }
            else
                return result;
        }

        public async Task<(IdentityResult identityResult, string? email)> DeleteUserAsync(Guid userId)
        {
            var user = await GetAppUserByIdAsync(userId);
            var result = await userManager.DeleteAsync(user);
            if (result.Succeeded)
                return (result, user.Email);
            else
                return (result, null);
        }

        public async Task<List<AppRole>> GetAllRolesAsync()
        {
            return await roleManager.Roles.ToListAsync();
        }

        public async Task<List<UserVM>> GetAllUsersWithRoleAsync()
        {
            var users = await userManager.Users.ToListAsync();
            var map = mapper.Map<List<UserVM>>(users);


            foreach (var item in map)
            {
                var findUser = await userManager.FindByIdAsync(item.Id.ToString());
                var role = string.Join("", await userManager.GetRolesAsync(findUser));

                item.Role = role;
            }

            return map;
        }

        public async Task<UserVM> GetUserWithRoleAsync()
        {
            var currentUserId = _user.GetLoggedInUserId();
            var currentUser = await userManager.FindByIdAsync(currentUserId.ToString());
            var map = mapper.Map<UserVM>(currentUser);
            var currenUserRole = string.Join("", await userManager.GetRolesAsync(currentUser));
            var role = string.Join("", await userManager.GetRolesAsync(currentUser));
            map.Role = role;
            return map;
        }
        public async Task<bool> ProfileSettingsUpdateAsync(UserVM user)
        {
            try
            {
                var currentUser = await userManager.FindByIdAsync(user.Id.ToString());
                currentUser.FullName = user.FullName;
                currentUser.PhoneNumber = user.PhoneNumber;
                var result = await userManager.UpdateAsync(currentUser);
                if (result.Succeeded)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<AppUser> GetAppUserByIdAsync(Guid userId)
        {
            return await userManager.FindByIdAsync(userId.ToString());
        }

        public async Task<string> GetUserRoleAsync(AppUser user)
        {
            return string.Join("", await userManager.GetRolesAsync(user));
        }

        public async Task<IdentityResult> UpdateUserAsync(UserUpdateVM userUpdateVM)
        {
            var user = await GetAppUserByIdAsync(userUpdateVM.Id);
            var userRole = await GetUserRoleAsync(user);

            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                await userManager.RemoveFromRoleAsync(user, userRole);
                var findRole = await roleManager.FindByIdAsync(userUpdateVM.RoleId.ToString());
                await userManager.AddToRoleAsync(user, findRole.Name);
                return result;
            }
            else
                return result;
        }

        public async Task<UserProfileVM> GetUserProfileAsync()
        {
            var userId = _user.GetLoggedInUserId();

            var getUser = await unitOfWork.GetRepository<AppUser>().GetAsync(x => x.Id == userId);
            var map = mapper.Map<UserProfileVM>(getUser);

            return map;
        }

        public async Task<bool> ChangePasswordAsync(UserNewPasswordVM userNewPasswordVM)
        {
            var userId = _user.GetLoggedInUserId();
            var user = await GetAppUserByIdAsync(userId);
            var isVerified = await userManager.CheckPasswordAsync(user, userNewPasswordVM.CurrentPassword);
            if (isVerified)
            {
                var result = await userManager.ChangePasswordAsync(user, userNewPasswordVM.CurrentPassword, userNewPasswordVM.ConfirmNewPassword);
                if (result.Succeeded)
                {
                    await userManager.UpdateSecurityStampAsync(user);
                    await signInManager.SignOutAsync();
                    await signInManager.PasswordSignInAsync(user, userNewPasswordVM.ConfirmNewPassword, true, false);
                    await unitOfWork.SaveAsync();
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> UserProfileUpdateAsync(UserProfileVM userProfileVM)
        {
            var userId = _user.GetLoggedInUserId();
            var user = await GetAppUserByIdAsync(userId);
            var isVerified = await userManager.CheckPasswordAsync(user, userProfileVM.CurrentPassword);
            if (isVerified && userProfileVM.NewPassword != null)
            {
                var result = await userManager.ChangePasswordAsync(user, userProfileVM.CurrentPassword, userProfileVM.NewPassword);
                if (result.Succeeded)
                {
                    await userManager.UpdateSecurityStampAsync(user);
                    await signInManager.SignOutAsync();
                    await signInManager.PasswordSignInAsync(user, userProfileVM.NewPassword, true, false);

                    mapper.Map(userProfileVM, user);


                    await userManager.UpdateAsync(user);
                    await unitOfWork.SaveAsync();

                    return true;
                }
                else
                    return false;
            }
            else if (isVerified)
            {
                await userManager.UpdateSecurityStampAsync(user);
                mapper.Map(userProfileVM, user);


                await userManager.UpdateAsync(user);
                await unitOfWork.SaveAsync();
                return true;
            }
            else
                return false;
        }
    }
}
