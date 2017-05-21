using System;
using System.Data;

namespace AsteriskApiTest
{
    /// <summary>
    /// Сервис получения данных по звонкам
    /// </summary>
    /// <remarks>Методы из MySqlCallsAdapter</remarks>
    public interface IRingsService
    {
        /// <summary>
        /// Завершенны звонки
        /// </summary>
        DataTable GetCompleteRings(DateTime start, DateTime end);

        /// <summary>
        /// Завершенны звонки
        /// </summary>
        DataTable GetCompleteRingsByKeyList(string keysList);

        /// <summary>
        /// Текущие звонки
        /// </summary>
        DataTable GetCurrentRings();

        /// <summary>
        /// Текущий звонок 
        /// </summary>
        /// <param name="num_from">Номер</param>
        DataTable GetCurrentRing(string num_to);

        /// <summary>
        /// Текущий звонок если не сработал обычный алгоритм
        /// по идее это такой звонок к-й был пропущен
        /// </summary>
        /// <param name="num_to"></param>
        /// <returns></returns>
        DataTable GetCurrentRingIfMissed(string num_to);

        /// <summary>
        /// Данные для отчета по стоимости разговоров
        /// </summary>
        DataTable GetCallsForBillingReport(DateTime start, DateTime end);

        DataTable ReportByOperators(DateTime start, DateTime end);

        DataTable GetActivitiPeers(DateTime start, DateTime end);

        DataTable GetOperatorsNotTacker(DateTime start, DateTime end);

        DataTable GetCallCenterAnaliticalIndexes(DateTime start, DateTime end);

        void SetQueueTimeout(long seconds);
    }
}
