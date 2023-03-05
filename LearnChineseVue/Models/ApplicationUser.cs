using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LearnChineseVue.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(70)]
        [Required]
        public string NickName { get; set; }

    }
}
