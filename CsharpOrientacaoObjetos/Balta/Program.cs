// See https://aka.ms/new-console-template for more information
using BALTA.ContentContext;

var articles = new List<Article>();
articles.Add(new Article("CSharp","Entendendo #"));
articles.Add(new Article("Java","Entendendo Java"));


/* foreach(var article in articles)
{
    System.Console.WriteLine(article.Id);
    System.Console.WriteLine(article.Title);
    System.Console.WriteLine(article.Url);
}
 */
IList<Course> courses =  new List<Course>();
Course courseCSharp = new Course("CSharp","c-sharp");
Course courseOop = new Course("OOP","oop-balta");
Course courseDotnet = new Course(".Net","dotnet-balta");

courses.Add(courseCSharp);
courses.Add(courseOop);
courses.Add(courseDotnet);

Carrer carrerDotnet = new Carrer("Especialista Em Dotnet","especialista-dotnet");


CarrerItem carrerItem1 = new CarrerItem(3,".Net","",null);
CarrerItem carrerItem2 = new CarrerItem(2,"OOP","",courseOop);
CarrerItem carrerItem3 = new CarrerItem(1,"CSharp","",courseCSharp);

carrerDotnet.Items.Add(carrerItem1);
carrerDotnet.Items.Add(carrerItem2);
carrerDotnet.Items.Add(carrerItem3);


IList<Carrer> carrers = new List<Carrer>();
carrers.Add(carrerDotnet);

foreach (var carrer in carrers)
{
    System.Console.WriteLine(carrer.Title);
    foreach (var carrerItem in carrer.Items.OrderBy(x => x.Order))
    {
        System.Console.WriteLine($"{carrerItem.Order} -- {carrerItem.Title}");
        System.Console.WriteLine($"{carrerItem.Course?.Title}");

        foreach (var notification in carrerItem.Notifications)
        {
            System.Console.WriteLine($"{notification.Message} --- {notification.Property}");
        }
    }
}