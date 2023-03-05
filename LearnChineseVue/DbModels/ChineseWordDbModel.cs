namespace LearnChineseVue.DbModels
{
    public class ChineseWordDbModel
    {
        public int Id { get; set; }
        public string ChineseWord { get; set; }
        public string Translation { get; set; }
        public int GroupId { get; set; }
        public int Tones { get; set; }
        public string Pinyin { get; set; }
    }
}
