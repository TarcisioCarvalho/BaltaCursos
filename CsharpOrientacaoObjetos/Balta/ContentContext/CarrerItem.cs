using BALTA.NotificationContext;

namespace BALTA.ContentContext
{
    public class CarrerItem : Base
    {
        public int Order { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Course Course { get; set; }

        public CarrerItem(int order,string title,string description,Course course)
        {
            if(course == null) AddNotification(new Notification("Course","Curso Inválido"));
            Order = order;
            Title = title;
            Description = description;
            Course = course;
        }
    }
}