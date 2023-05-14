public class Career
{
    public Career()
    {
        Itens = new List<CarrerItem>();
    }

    public Guid Id { get; set; }
    public string? Title { get; set; }
    public List<CarrerItem> Itens { get; set; }
}