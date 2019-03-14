using System.Collections.Generic;

namespace Programming_Reference_Website.Models
{
    public class Language : ModelBase
    {
        public Language()
        {
            TopicLanguages = new List<TopicLanguage>();
            WebResources = new List<WebResource>();
        }
        public string Name { get; set; }

        public byte[] Photo { get; set; }

        public List<TopicLanguage> TopicLanguages { get; set; }

        public List<WebResource> WebResources { get; set; }
    }
}