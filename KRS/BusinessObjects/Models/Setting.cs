using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Setting
    {
        public int SettingId { get; set; }
        public string? SettingName { get; set; }
        public int? SettingType { get; set; }
        public string? SettingValue { get; set; }
        public int? AccountId { get; set; }

        public virtual Account? Account { get; set; }
    }
}
