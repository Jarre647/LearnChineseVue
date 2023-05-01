namespace LearnChineseVue.Models
{
    public class CRMResponse
    {
        public List<AccountsViewModel> Accounts { get; set; } = new List<AccountsViewModel>();
        public List<RoleViewModel> Roles { get; set; } = new List<RoleViewModel>();
    }
}
