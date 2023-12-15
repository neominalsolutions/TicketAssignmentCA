using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TicketAssignment.Domain.SeedWork;

namespace TicketAssignmentApp.Infrastructure.Persistance.Dapper
{
  public abstract class DapperRepository<TEntity, TContext> : IRepository<TEntity>
    where TEntity : Entity
    where TContext : DbContext
  {
    public void Create(TEntity entity)
    {
      throw new NotImplementedException();
    }

    public void Delete(string key)
    {
      throw new NotImplementedException();
    }

    public IReadOnlyList<TEntity> FindAll()
    {
      throw new NotImplementedException();
    }

    public TEntity FindById(string key)
    {
      throw new NotImplementedException();
    }

    public IQueryable<TEntity> FindWithCriteria(Expression<Func<TEntity, bool>> lambda)
    {
      throw new NotImplementedException();
    }

    public void Update(TEntity entity)
    {
      throw new NotImplementedException();
    }
  }
}
