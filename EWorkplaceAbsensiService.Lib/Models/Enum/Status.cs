using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EWorkplaceAbsensiService.Lib.Models.Enum
{
    //[DefaultValue (Pending)]
    public enum Status
    {
        Pending = 0,
        ApprovedByHR = 1,
        ApprovedBySM = 2,
        RejectedByHR = 3,
        RejectedBySM = 4
    }
}
