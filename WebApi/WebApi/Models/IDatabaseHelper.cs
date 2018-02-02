using EF.Diagnostics.Profiling;
using System.Data;


namespace WebApi.Models
{
    public interface IDatabaseHelper
    {
        /// <summary>
        /// Gets the profiled connection (with NanoProfiler).
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="currentSession">The current session.</param>
        /// <returns>IDbConnection.</returns>
        IDbConnection GetProfiledConnection(
            string connectionString, ProfilingSession currentSession);
    }
}