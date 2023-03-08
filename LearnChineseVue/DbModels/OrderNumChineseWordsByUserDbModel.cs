using System.ComponentModel.DataAnnotations;

namespace LearnChineseVue.DbModels
{

    public class OrderNumChineseWordsByUserDbModel
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }

        public int ChineseWordId{ get; set; }
        public int GroupId { get; set; }
    }
}
