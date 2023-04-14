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
            if(course == null) throw new Exception("O Curso não pode ser nullo");
            Order = order;
            Title = title;
            Description = description;
            Course = course;
        }
    }
}