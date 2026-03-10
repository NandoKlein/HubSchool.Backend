using Microsoft.EntityFrameworkCore;
using System;

namespace HubSchool.Model.Context
{
    public class MSSQLContext : DbContext
    {
        public MSSQLContext(DbContextOptions<MSSQLContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TurmaAlunos>()
                .HasKey(ta => new { ta.IdTurma, ta.IdAluno });

            modelBuilder.Entity<Frequencia>()
               .HasKey(ta => new { ta.IdAula, ta.IdAluno });

            modelBuilder.Entity<Homework>()
             .HasKey(ta => new { ta.IdAula, ta.IdAluno });
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<TurmaAlunos> TurmaAlunos { get; set; }
        public DbSet<Aula> Aulas { get; set; }
        public DbSet<Frequencia> Frequencias { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
    }
}
