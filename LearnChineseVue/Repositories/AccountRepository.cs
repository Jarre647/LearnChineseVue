using LearnChineseVue.Data;
using LearnChineseVue.Models;
using LearnChineseVue.Repositories.Contracts;
using LearnChineseVue.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LearnChineseVue.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public AccountRepository(UserManager<ApplicationUser> userManager,
                                 ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<AccountViewModel> GetAccountByName(string accountName)
        {
            var getAcc = await _userManager.FindByEmailAsync(accountName);

            var response = new AccountViewModel
            {
                UserId = getAcc.Id
            };
            return response;
        }

        public async Task<List<AccountsViewModel>> GetAllAccountsAsync()
        {
            var res = await (from u in _context.Users
                             join ur in _context.UserRoles on u.Id equals ur.UserId into subur
                             from ur in subur.DefaultIfEmpty()
                             select new AccountsViewModel
                             {
                                 UserId = u.Id,
                                 UserName = u.UserName,
                                 RoleId = ur.RoleId

                             }).ToListAsync();
            return res;
        }

        public async Task<List<RoleViewModel>> GetAllRolesAsync()
        {
            return await _context.Roles.Select(item => new RoleViewModel
            {
                RoleId = item.Id,
                Name = item.Name
            }).ToListAsync();
        }
    }
}
