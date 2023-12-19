using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketAssignment.Domain.SeedWork
{
  // Kurallar: Günlük en fazla 6 saatlik bir görev tanımlaması yapılabilir
  // Eğer iş 6 saat üzerinde bir iş ise Haftalık görev tanımlaması şeklinde yapılmalıdır.
  // Eğer ki günlük atanan iş miktarı + atanacak olan iş miktarı 6 saatin altındaysa günlük görev atama algoritması uygulanır. 6 saatin üstünde ve 30 saatin altında bir görev ataması ise ve görev atanacak olan çalışanın haftalık iş yük toplamı + atanacak görev toplamı 30 saat altında ise haftalık görev ataması üstünde ise aylık görev ataması yapılmalıdır. 120 saat maksimum atanacak olan görev atama saati olup. Bir ay içerisinde 120 saatin üstünde bir görev ataması yapılmamalıdır. Haftlaık görev atamasının üsütne çıkan çalışanlara görev aylık atama algoritması ile yapılır. 
    public interface ITicketAssignment
    {
        void AssignTicket(string ticketId, string employeeId, int estimatedHour);
    }
}
