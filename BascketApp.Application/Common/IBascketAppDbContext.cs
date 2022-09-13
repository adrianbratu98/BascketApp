using System;
using System.Threading.Tasks;
using BascketApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BascketApp.Application.Common
{
    public interface IBascketAppDbContext
    {
        DbSet<Bascket> Basckets { get; set; }
        DbSet<BascketArticle> BascketArticles { get; set; }
        Task<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity) where TEntity : class;
        Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class;
        Task RemoveAsync<TEntity>(TEntity entity) where TEntity : class;
        Task SaveChangesAsync();
    }
}

