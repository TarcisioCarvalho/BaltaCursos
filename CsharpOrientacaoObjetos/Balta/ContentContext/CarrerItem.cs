namespace BALTA.ContentContext
{
    public class CarrerItem
    {
        public int Order { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Course Course { get; set; }

        public CarrerItem(int order,string title,string description,Course course)
        {
            Order = order;
            Title = title;
            Description = description;
            Course = course;
        }
    }
}