using Microsoft.AspNetCore.Identity;
using BeeBuzz.Data.Entities;

namespace BeeBuzz.Data.Entities
{
    //public enum Role{
    //    Default, Admin

    //}
    public class ApplicationUsers : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Organizations Organization { get; set; }
        public int OrganizationId { get; set; }
        public ICollection<BeeHives>? ManagedBeeHives { get; set; }

    }
}
