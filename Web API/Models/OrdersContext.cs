using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class OrdersContext : DbContext
    {
            public DbSet<Order> Orders { get; set; }
            public OrdersContext(DbContextOptions<OrdersContext> options)
                : base(options)
            {
                Database.EnsureCreated();
            }
    }

}
