using BALTA.ContentContext.Enums;

namespace BALTA.ContentContext
{
    public class Lecture
    {
        public int Order { get; set; }
        public string Title { get; set; }

        public int DurationInMinutes { get; set; }

        public EcontentLevel Level { get; set; }
        
    }
}