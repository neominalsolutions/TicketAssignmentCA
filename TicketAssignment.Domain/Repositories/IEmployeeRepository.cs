using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAssignment.Domain.Entities;
using TicketAssignment.Domain.SeedWork;

namespace TicketAssignment.Domain.Repositories
{
  // Domain nesnelerine tanımlanan interfaceler sayesinde entity spesific ekstra sorumluklar verilebilir.
  // Domain katmanına veritabanı altyapı servisleri ile haberleşmek interfaceler tanımlayıp bu arayüzler üzerinden Domain ile Infra katmanının birbirine bağımlılığı zayıflaştırdık.
  public interface IEmployeeRepository:ICrudRepository<Employee>
  {
    /// <summary>
    /// Çalışanı atanmış görevler ile birlikte load et
    /// </summary>
    /// <param name="employeId"></param>
    /// <returns></returns>
    Employee FindEmployeeWithTickets(string employeId);
  }
}
