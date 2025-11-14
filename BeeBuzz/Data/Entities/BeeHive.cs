using System;

namespace BeeBuzz.Data.Entities
{
    public enum BeeHiveStatus
    {
        Active,
        Inactive 
    }

    public enum BeeHiveDeactivationReason
    {
        Dead,
        Sold
    }

    public class BeeHive
    {
        public string Location { get; set; }
        public BeeHiveStatus Status { get; set; }
        public BeeHiveDeactivationReason DeactivationReason { get; set; }
    }
}
