namespace BeeBuzz.Data.Entities.Relationships
{
    // many to many ralationships
    public class OrganizationsUsers
    {
        public ApplicationUsers? User { get; set; }
        public Organizations? Organisation { get; set; }
    }
}
