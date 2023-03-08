namespace LearnChineseVue.Models
{
    public class UpdateChineseWordRequest
    {
        public string? UserName { get; set; }
        public int Id { get; set; }
        public string ChineseWord { get; set; }
        public string Translation { get; set; }
        public int Tones { get; set; }
        public string Pinyin { get; set; }
        public int GroupId { get; set; }
    }
}
