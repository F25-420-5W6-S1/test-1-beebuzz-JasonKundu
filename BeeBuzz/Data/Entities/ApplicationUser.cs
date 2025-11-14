using Microsoft.AspNetCore.Identity;

namespace BeeBuzz.Data.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {


        public ICollection<BeeHive>? ManagedBeeHives { get; set; }

    }
}
