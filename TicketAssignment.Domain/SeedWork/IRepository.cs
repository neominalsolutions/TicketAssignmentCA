using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TicketAssignment.Domain.SeedWork
{
  // TEntity Entity kalıtım alan sınıflar
  // stateful
  public interface IReadOnlyRepository<TEntity>
  {
    IReadOnlyList<TEntity> FindAll();
    TEntity FindById(string key);
    IQueryable<TEntity> FindWithCriteria(Expression<Func<TEntity, bool>> lambda);
  }

  // stateless
  public interface IWriteOnlyRepository<TEntity>
  {
    void Create(TEntity entity);
    void Update(TEntity entity);
    void Delete(string key);
  }

  // Interface Seggragation ile Read Write sorumluluklarını birbirinden ayırmış olduk
  // Entity olmayan bir nesneyi kabul etmiyoruz code defensing
  public interface IRepository<TEntity>:IReadOnlyRepository<TEntity>
    ,IWriteOnlyRepository<TEntity> where TEntity:Entity
  {

  }
}
