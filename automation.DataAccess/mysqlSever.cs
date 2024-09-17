using MySql.Data.MySqlClient;
using System.Data;


namespace automation.DataAccess
{
    internal sealed class mysqlSever
    {
        private readonly string MySqlConnStr;


        public mysqlSever()
        {


            MySqlConnStr = "";
        }
        public void fnSetParameters(List<MySqlParameter> paramList, string mySqlParam, MySqlDbType mySqlDbType, object value)
        {
            MySqlParameter mySqlParameter = new MySqlParameter(mySqlParam, mySqlDbType);
            mySqlParameter.Value = value;
            paramList.Add(mySqlParameter);
        }
        private void SetupParameters(MySqlCommand cmd, List<MySqlParameter> mySqlParmList)
        {
            foreach (var parameter in mySqlParmList)
            {
                cmd.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
            }
        }         
        public DataSet fnMySqlRetriveDs(string procedureName, List<MySqlParameter> mySqlParmList)
        {
            try
            {
                DataSet _ds;
                using (MySqlConnection con = new MySqlConnection(MySqlConnStr))
                {
                    using (MySqlCommand cmd = new MySqlCommand(procedureName, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;

                        SetupParameters(cmd, mySqlParmList);

                        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                        {
                            _ds = new DataSet();
                            sda.Fill(_ds);
                            return _ds;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<DataSet> fnMySqlRetriveDsAsync(string str_ProcedureName, List<MySqlParameter> MySqlParmList)
        {
            DataSet _ds;
            using (MySqlConnection con = new MySqlConnection(MySqlConnStr))
            {
                using (MySqlCommand cmd = new MySqlCommand(str_ProcedureName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;

                    for (int i = 0; i < MySqlParmList.Count; i++)
                    {
                        cmd.Parameters.AddWithValue(MySqlParmList[i].ParameterName, MySqlParmList[i].Value);
                    }
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        _ds = new DataSet();
                        await sda.FillAsync(_ds);
                        return _ds;
                    }
                }
            }
        }
        public Task<DataSet> fnMySqlExcuteTextAsync(string str_Query)
        {
            return MySqlHelper.ExecuteDatasetAsync(MySqlConnStr, str_Query);
        }
    }
}
