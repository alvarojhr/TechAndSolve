using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechAndSolve_AlvaroHernandez.Models
{
    public class FileContext : DbContext
    {
        public FileContext(DbContextOptions<FileContext> options) : base(options)
        {

        }

        public DbSet<FileUpload> FileUploads { get; set; }

    }
}
