using System.Collections.Generic;

namespace Programming_Reference_Website.Models
{
    public class Topic : ModelBase
    {

        public Topic()
        {
            TopicLanguages = new List<TopicLanguage>();
            WebResources = new List<WebResource>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<TopicLanguage> TopicLanguages { get; set; }

        public List<WebResource> WebResources { get; set; }
    }
}