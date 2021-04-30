namespace Nouran.Domain.Entities
{
    public class Country
    {
        public int Id { get; }
        public string Title { get; }

        public Country(string title)
        {
            Title=title;
        }
    }
}