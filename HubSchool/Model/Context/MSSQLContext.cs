using Microsoft.EntityFrameworkCore;
using System;

namespace HubSchool.Model.Context
{
    public class MSSQLContext : DbContext
    {
        public MSSQLContext(DbContextOptions<MSSQLContext> options)
            : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }      
    }
}
