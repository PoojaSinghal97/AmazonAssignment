using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using automation.contracts.Repository;

namespace automation.DataAccess
{
    public   class MySqlRepository: IMySqlRepository
    {
         
        public DataSet Excute(String ProcedureName, Dictionary<string, (MySqlDbType, object)> parameters)
        {
            mysqlSever mySqlHelper = new mysqlSever();
            List<MySqlParameter> paramList = new List<MySqlParameter>();

            foreach (var param in parameters)
            {
                mySqlHelper.fnSetParameters(paramList, param.Key, param.Value.Item1, param.Value.Item2);
            }
            DataSet ds = mySqlHelper.fnMySqlRetriveDs(ProcedureName, paramList);
            return ds;
        }
        public async Task<DataSet> ExcuteAsyc(String ProcedureName, Dictionary<string, (MySqlDbType, object)> parameters)
        {
            mysqlSever mySqlHelper = new mysqlSever();
            List<MySqlParameter> paramList = new List<MySqlParameter>();

            foreach (var param in parameters)
            {
                mySqlHelper.fnSetParameters(paramList, param.Key, param.Value.Item1, param.Value.Item2);
            }
            DataSet ds = await mySqlHelper.fnMySqlRetriveDsAsync(ProcedureName, paramList);
            return ds;
        }
        public async Task<DataSet> Save(string query)
        {
            mysqlSever mySqlHelper = new mysqlSever();
            DataSet ds = await mySqlHelper.fnMySqlExcuteTextAsync(query);
            return ds;
        }
        public async Task<DataSet> GetData(string query)
        {
            mysqlSever mySqlHelper = new mysqlSever();
            DataSet ds = await mySqlHelper.fnMySqlExcuteTextAsync(query);
            return ds;
        }
    }
}
