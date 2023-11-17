using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TicketAssignment.Domain.SeedWork;

namespace TicketAssignmentApp.Infrastructure.Persistance.EF
{
  // TEntity:Entity code defencing 
  // Grasp Polymophisim yapısını ve Liskov Substitution principle
  // Base sınıf özelliklerini koruyayarak bir çok db işlemini baseEFCrud repository üzerinden yaptığımız protected variations da aynı zamanda uygulamış oluruz.
  // Generic Repository Pattern : 
  // EFCrudRepository EFReadOnlyRepository select işlemlerini kalıtım alıp üzerinen write işlemlerini IWriteOnlyRepository üzerinden ekledik
  public abstract class EFCrudRepository<TEntity, TContext> : EFReadOnlyRepository<TEntity,TContext>, IWriteOnlyRepository<TEntity> 
    where TEntity:Entity
    where TContext: DbContext
  {
    protected readonly TContext context; // Dependecy Inversion, DbContext türeyen tüm dblere bu altyapı sayesinde bağlantı kurabilirim.
    protected readonly DbSet<TEntity> table;
    
    public EFCrudRepository(TContext context):base(context) // Dependecy Injection
    {
      this.context = context;
      this.table = context.Set<TEntity>();
    }

    public virtual void Create(TEntity entity)
    {
      this.table.Add(entity);
      this.context.SaveChanges();
    }

    public virtual void Delete(string key)
    {
      var entity = this.table.Find(key);

      if(entity is not null)
      {
        this.table.Remove(entity);
        this.context.SaveChanges();
      }
    }

    public virtual void Update(TEntity entity)
    {
      this.table.Update(entity);
      this.context.SaveChanges();
    }
  }
}
