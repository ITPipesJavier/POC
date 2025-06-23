using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IDatabaseProvider
    {
        T QuerySingle<T>(string sql, object parameters);
        IEnumerable<T> Query<T>(string sql, object parameters);
        int Execute(string sql, object parameters);
    }
}
