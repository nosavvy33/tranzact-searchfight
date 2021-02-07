using SearchFight.ApplicationDomain.DTO;

namespace SearchFight.ApplicationDomain.Models
{
    public class Search
    {
        public string SearchEngine { get; set; }

        public string SearchQuery { get; set; }

        //public long TotalResults { get; set; }
        public ResultDTO TotalResults { get; set; }
    }
}
