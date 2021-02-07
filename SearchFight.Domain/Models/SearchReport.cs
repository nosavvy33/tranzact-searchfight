using System.Collections.Generic;

namespace SearchFight.ApplicationDomain.Models
{
    public class SearchReport
    {
        public string SearchTotalWinner { get; set; }
        
        public List<Search> SearchWinners { get; set; }
        
        public List<Search> SearchResults { get; set; }
    }
}
