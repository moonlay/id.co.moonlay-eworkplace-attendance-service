using System;
using System.Collections.Generic;
using System.Text;

namespace EWorkplaceAbsensiService.Lib.Models.Filters
{
    public class ProjectFilter
    {
        public ProjectFilter()
        {
            Ids = new List<long>();
        }
        public string projectName { get; set; }
        public string contract { get; set; }
        public int status { get; set; }
        public string workType { get; set; }
        public SortBy? SortByprojectName { get; set; }
        public List<long> Ids { get;set; }
    }

}
