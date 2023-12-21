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
    // TEntity:Entity code defencing 
    // Grasp Polymophisim yapısını ve Liskov Substitution principle
    // Base sınıf özelliklerini koruyayarak bir çok db işlemini baseEFCrud repository üzerinden yaptığımız protected variations da aynı zamanda uygulamış oluruz.
    // Generic Repository Pattern : 
    // EFCrudRepository EFReadOnlyRepository select işlemlerini kalıtım alıp üzerinen write işlemlerini IWriteOnlyRepository üzerinden ekledik
    public abstract class EFCrudRepository<TEntity, TContext> : EFReadOnlyRepository<TEntity, TContext>, IWriteOnlyRepository<TEntity>
      where TEntity : Entity
      where TContext : DbContext
    {
        protected readonly TContext context; // Dependecy Inversion, DbContext türeyen tüm dblere bu altyapı sayesinde bağlantı kurabilirim.
        protected readonly DbSet<TEntity> table;

        public EFCrudRepository(TContext context) : base(context) // Dependecy Injection
        {
            this.context = context;
            table = context.Set<TEntity>();
        }

        public virtual void Create(TEntity entity)
        {
            table.Add(entity);
            //this.context.Add<TEntity>(entity);
            context.SaveChanges();
        }

        public virtual void Delete(string key)
        {
            var entity = table.Find(key);

            if (entity is not null)
            {
                table.Remove(entity);
                context.SaveChanges();
            }
        }

        public virtual void Update(TEntity entity)
        {
            table.Update(entity);
            context.SaveChanges();
        }
    }
}
