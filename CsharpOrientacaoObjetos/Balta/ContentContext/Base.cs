using BALTA.NotificationContext;

namespace BALTA.ContentContext
{
    public abstract class Base : Notifiable
    {
        protected Base()
        {
             Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}