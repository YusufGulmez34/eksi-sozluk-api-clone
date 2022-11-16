using EksiSozlukAPI.Domain.Entities;
using EksiSozlukAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozlukTest
{
    public class TestDbContext : EksiSozlukAPIDbContext
    {
        public TestDbContext(DbContextOptions options) : base(options)
        {
        }

    }
}
