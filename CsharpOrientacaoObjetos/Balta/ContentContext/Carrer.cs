namespace BALTA.ContentContext
{
    public class Carrer:Content
    {
        public IList<CarrerItem> Items { get; set; }

        public int TotalCourses => Items.Count;
        //Expression Body

        public Carrer(string title, string url):
        base(title,url)
        {
            Items = new List<CarrerItem>();
        }
    }

    
}