namespace Nouran.Domain.Entities
{
    public class City
    {
        public int Id { get; }
        public string Title { get; }

        public City(string title)
        {
            Title=title;
        }
    }
}