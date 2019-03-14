namespace Programming_Reference_Website.Models
{
    public class TopicLanguage : ModelBase
    {
        public int TopicId { get; set; }

        public Topic Topic { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }
    }
}