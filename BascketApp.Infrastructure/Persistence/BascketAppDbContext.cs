using System;
using System.Reflection;
using BascketApp.Application.Common;
using BascketApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BascketApp.Infrastructure.Persistence
{
    public class BascketAppDbContext : DbContext, IBascketAppDbContext
    {
        public BascketAppDbContext(DbContextOptions<BascketAppDbContext> options) : base(options)
        {
        }

        public DbSet<Bascket> Basckets { get; set; } 

        public DbSet<BascketArticle> BascketArticles { get; set; }

        public async Task<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity) where TEntity : class
        {
            return await base.AddAsync(entity);
        }

        public async Task RemoveAsync<TEntity>(TEntity entity) where TEntity : class
        {
            base.Remove(entity);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }

         
        public async Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            base.Update(entity!);
            await SaveChangesAsync(); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<BascketArticle>()
            //    .HasOne<Bascket>(e => e.Bascket)
            //    .WithMany(es => es.Articles)
            //    .HasForeignKey(e => e.BascketId);
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
