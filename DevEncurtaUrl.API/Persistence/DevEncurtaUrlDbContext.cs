using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevEncurtaUrl.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevEncurtaUrl.API.Persistence
{
    public class DevEncurtaUrlDbContext : DbContext
    {
        //private int _currentIndex = 1;

        public DevEncurtaUrlDbContext(DbContextOptions<DevEncurtaUrlDbContext> options) : base(options)
        {
            //Links = new List<ShortenedCustomLink>();
        }

        public DbSet<ShortenedCustomLink> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<ShortenedCustomLink>(e => {
                e.HasKey(h => h.Id);
            });
        }

        //public List<ShortenedCustomLink> Links { get; set; }

        // public void Add (ShortenedCustomLink link) {
        //     link.Id = _currentIndex;
            
        //     _currentIndex++;
            
        //     Links.Add(link);
        // }
    }
}