using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AsteriskApiTest
{
    /// <summary>
    /// Сервис получения данных по звонкам
    /// </summary>
    /// <remarks>Методы из MySqlCallsAdapter</remarks>
    public interface IRingsService
    {
        /// <summary>
        /// Данные для отчета по стоимости разговоров
        /// </summary>
        DataTable GetCallsForBillingReport(DateTime start, DateTime end);
    }
}
