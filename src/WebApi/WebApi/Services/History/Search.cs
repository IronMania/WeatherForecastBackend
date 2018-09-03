namespace WebApi.Services.History
{
    public class Search
    {
        public Search( string searchName)
        {
            SearchName = searchName;
            SearchCount = 1;
        }
        public int Id { get; protected set; }
        public string SearchName { get; private set; }
        public int SearchCount { get; private set; }

        public void ItemSearched()
        {
            SearchCount++;
        }
    }
}