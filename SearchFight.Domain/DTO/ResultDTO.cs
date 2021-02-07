using SearchFight.ApplicationDomain.Enums;

namespace SearchFight.ApplicationDomain.DTO
{
    public class ResultDTO
    {
        public ResultDTO() { }

        public SearchResponseCode ResponseCode { get; set; }

        public long Results { get; set; }

    }
}
