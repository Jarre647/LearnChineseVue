using Microsoft.EntityFrameworkCore;

namespace LearnChineseVue.DbModels
{
    [Keyless]
    public class OrderNumChineseWordsByUserDbModel
    {
        public string UserId { get; set; }

        public int ChineseWordId{ get; set; }
        public int GroupId { get; set; }
    }
}
