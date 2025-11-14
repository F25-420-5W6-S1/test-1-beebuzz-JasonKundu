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

    public class BeeHives
    {
        public int Id { get; set; }
        public int BeeHiveUserId { get; set; } // user id 
        public ApplicationUsers? User { get; set; } // user
        
        public string Location { get; set; }
        public BeeHiveStatus Status { get; set; }
        public BeeHiveDeactivationReason DeactivationReason { get; set; }
    }
}
