namespace LearnChineseVue.Models
{
    public class SaveChineseWordRequestModel
    {
        public string ChineseWord { get; set; }
        public string Translation { get; set; }
        public int GroupId { get; set; }
        public int Tones { get; set; }
        public string Pinyin { get; set; }
    }
}
