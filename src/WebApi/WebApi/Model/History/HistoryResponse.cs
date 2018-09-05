using System.Collections.Generic;

namespace WebApi.Model.History
{
    public class HistoryResponse
    {
        public HistoryResponse(IList<string> searchResults)
        {
            SearchResults = searchResults;
        }

        public IList<string> SearchResults { get; }
    }
}