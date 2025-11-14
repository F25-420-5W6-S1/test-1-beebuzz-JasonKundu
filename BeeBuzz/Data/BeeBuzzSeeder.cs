using BeeBuzz.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Text.Json;

namespace BeeBuzz.Data
{
    public class BeeBuzzSeeder
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hosting;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public BeeBuzzSeeder(ApplicationDbContext context,
            IWebHostEnvironment hosting,
            RoleManager<IdentityRole<int>> roleManager)
        {
            _db = context;
            _hosting = hosting;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            _db.Database.EnsureCreated();

            // Add roles
            await _roleManager.CreateAsync(new IdentityRole<int>("Admin"));

            if (_db.Users.Any()) return;

            // Load and add data
            string baseDirectory = "Data/Mock";
            _db.Users.AddRange(GetObjects<ApplicationUsers>($"{baseDirectory}/users.json"));
            _db.SaveChanges();

            _db.OrganizationsSet.AddRange(GetObjects<Organizations>($"{baseDirectory}/organizations.json"));
            _db.SaveChanges();

            _db.BeeHivesSet.AddRange(GetObjects<BeeHives>($"{baseDirectory}/beehives.json"));
            _db.SaveChanges();
            
        }

        private IEnumerable<T> GetObjects<T>(string path)
        {
            // Get hackathons
            var seederFile = Path.Combine(_hosting.ContentRootPath, path);

            if (!File.Exists(seederFile))
                throw new FileNotFoundException($"File not found: {seederFile}");

            var json = File.ReadAllText(seederFile);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<IEnumerable<T>>(json, options);
        }


    }
}
