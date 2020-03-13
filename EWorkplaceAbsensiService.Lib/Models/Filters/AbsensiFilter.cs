using System.Collections.Generic;


namespace EWorkplaceAbsensiService.Lib.Models.Filters
{
    public enum SortBy
    {
        ASC,
        DESC
    }

    public class AbsensiFilter
    {
        public AbsensiFilter()
        {
            Ids = new List<long>();
        }
        public string Username { get; set; }

        public string Name { get; set; }
        public string State { get; set; }
        public string Approval { get; set; }
        public string CheckIn { get; set; }
        public string HeadDivision { get; set; }

        public string NotState { get; set; }
        public string ApprovalByAdmin { get; set; }
        public SortBy? SortByUsername { get; set; }

        public SortBy? SortByDate { get; set; }
        public List<long> Ids { get; set; }
    }
}
