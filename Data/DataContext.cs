using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using therapyFlow.Modules.Management.Models;
using therapyFlow.Modules.Note;

namespace therapyFlow.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<NoteModel> Notes => Set<NoteModel>();
        public DbSet<ClientModel> Clients => Set<ClientModel>();
    }
}