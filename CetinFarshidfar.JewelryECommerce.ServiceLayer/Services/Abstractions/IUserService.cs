using CetinFarshidfar.JewelryECommerce.EntityLayer.Entitites;
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.ServiceLayer.Services.Abstractions
{
    public interface IUserService
    {
        Task<List<UserVM>> GetAllUsersWithRoleAsync();
        Task<UserVM> GetUserWithRoleAsync();
        Task<bool> ChangePasswordAsync(UserNewPasswordVM userNewPasswordVM);
        Task<bool> ProfileSettingsUpdateAsync(UserVM user);
        Task<List<AppRole>> GetAllRolesAsync();
        Task<IdentityResult> CreateUserAsync(UserRegisterVM userRegisterVM);
        Task<IdentityResult> UpdateUserAsync(UserUpdateVM userUpdateVM);
        Task<(IdentityResult identityResult, string? email)> DeleteUserAsync(Guid userId);
        Task<AppUser> GetAppUserByIdAsync(Guid userId);
        Task<string> GetUserRoleAsync(AppUser user);
        Task<UserProfileVM> GetUserProfileAsync();
        Task<bool> UserProfileUpdateAsync(UserProfileVM userProfileVM);
    }
}
