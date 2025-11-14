namespace BeeBuzz.Data.Entities
{
    public class organizations
    {
        public int OrganizationId { get; set; }
        public int UniqueId { get; set; } // gov. id 
        public ICollection<ApplicationUsers>? Users { get; set; } // users (not nullable because there is at least one user per organization

    }
}
