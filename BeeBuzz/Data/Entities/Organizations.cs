namespace BeeBuzz.Data.Entities
{
    public class Organizations
    {
        int OrganizationId { get; set; }
        int UniqueId { get; set; } // gov. id 
        public ICollection<ApplicationUser> Users { get; set; } // users (not nullable because there is at least one user per organization

    }
}
