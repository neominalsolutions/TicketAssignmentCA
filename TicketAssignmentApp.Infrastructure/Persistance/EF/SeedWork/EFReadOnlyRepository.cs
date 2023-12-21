using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TicketAssignment.Domain.SeedWork;

namespace TicketAssignmentApp.Infrastructure.Persistance.EF.SeedWork
{
    public abstract class EFReadOnlyRepository<TEntity, TContext> : IReadOnlyRepository<TEntity>
      where TEntity : Entity
      where TContext : DbContext
    {
        protected readonly TContext context; // Dependecy Inversion, DbContext türeyen tüm dblere bu altyapı sayesinde bağlantı kurabilirim.
        protected readonly DbSet<TEntity> table;


        public EFReadOnlyRepository(TContext context)
        {
            this.context = context;
            // instance almayı unututğumuzdan bug oluştu.
            table = this.context.Set<TEntity>();
        }
        public IReadOnlyList<TEntity> FindAll()
        {
            return table.ToList();
        }

        public TEntity FindById(string key)
        {
            return table.Find(key);
        }

        public IQueryable<TEntity> FindWithCriteria(Expression<Func<TEntity, bool>> lambda)
        {
            return table.Where(lambda);
        }
    }
}
