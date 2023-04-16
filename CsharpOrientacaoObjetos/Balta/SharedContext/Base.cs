using BALTA.NotificationContext;

namespace BALTA.SharedContext
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