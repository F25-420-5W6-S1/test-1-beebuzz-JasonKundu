using Microsoft.AspNetCore.Identity;
using BeeBuzz.Data.Entities;

namespace BeeBuzz.Data.Entities
{
    public class ApplicationUsers : IdentityUser<int>
    {
        
        public Organizations Organization { get; set; }
        public int OrganizationId { get; set; }
        public ICollection<BeeHives>? ManagedBeeHives { get; set; }

    }
}
