using AsteriskApiTest.JsonWorkerAssembly.Filters;

namespace AsteriskApiTest.JsonWorkerAssembly
{
    /// <summary>
    /// Конекст запроса
    /// </summary>
    public class RequestContext<T> where T : BaseFilterContext
    {
        public string Service { get; set; }

        public string Method { get; set; }

        public string Object { get; set; }

        public T FilterContext { get; set; }
    }
}
