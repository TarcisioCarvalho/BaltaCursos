namespace BALTA.NotificationContext
{
    public sealed class Notification
    {
        public Notification(string message, string property)
        {
            Message = message;
            Property = property;
        }

        public string Message { get; set; }
        public string Property { get; set; }
    }
}