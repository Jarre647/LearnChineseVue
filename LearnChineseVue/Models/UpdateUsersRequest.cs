using LearnChineseVue.Models.InsertModels;

namespace LearnChineseVue.Models
{
    public class UpdateUsersRequest
    {
        public List<UpdateUserInsertModel> Users { get; set; } = new List<UpdateUserInsertModel>();
    }
}
