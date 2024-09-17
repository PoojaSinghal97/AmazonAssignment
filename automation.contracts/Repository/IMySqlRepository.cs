using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automation.contracts.Repository
{
    public interface IMySqlRepository
    {
        DataSet Excute(string ProcedureName,Dictionary<string, (MySqlDbType, object)> parameters);
        Task<DataSet> ExcuteAsyc(String ProcedureName, Dictionary<string, (MySqlDbType, object)> parameters);
        Task<DataSet> Save(string query);
        Task<DataSet> GetData(string query);
    }
}
