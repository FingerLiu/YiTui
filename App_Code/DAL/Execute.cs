using System;
using System.Data;
using System.Xml;
using System.Data.SqlClient;

namespace YiTui.DAL
{
    public class Execute
    {
        public static string connectionString = @"Data Source=SOLO-PC\SQLEXPRESS;Initial Catalog=DB_MARKET;Persist Security Info=True;User ID=user;Password=w4532545"; //链接字符串   		


        #region 执行SQL 文本命令返回 int
        /// <summary>
        /// 执行SQL 文本命令返回 int
        /// </summary>
        /// <param name="commandText">Sql语句</param>
        /// <returns>返回int</returns>
        public static int ExecuteNonQuery(string commandText)
        {
            return SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, commandText);
        }

        /// <summary>
        /// 执行SQL 文本命令返回 int
        /// </summary>
        /// <param name="commandText">Sql语句</param>
        /// <param name="commandParameters">参数</param>
        /// <returns>0失败 ， 1 成功</returns>
        public static int ExecuteNonQuery(string commandText, SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, commandText, commandParameters);
        }

        #endregion

        #region 执行SQL 文本命令返回 DataSet
        /// <summary>
        /// 执行SQL 文本命令返回 DataSet
        /// </summary>
        /// <param name="commandText">Sql语句</param>
        /// <returns>返回DataSet</returns>
        public static DataSet ExecuteDataset(string commandText, string sqlConnection)
        {
            string connectionString = sqlConnection;
            return SqlHelper.ExecuteDataset(connectionString, CommandType.Text, commandText);
        }

        public static DataSet ExecuteDataset(string commandText)
        {
            return SqlHelper.ExecuteDataset(connectionString, CommandType.Text, commandText);
        }

        #endregion

        #region 执行SQL 文本命令返回 DataTable
        /// <summary>
        /// 执行SQL 文本命令返回 DataTable
        /// </summary>
        /// <param name="commandText">Sql语句</param>
        /// <returns>返回DataTable</returns>
        public static DataTable ExecuteDataTable(string commandText, string sqlConnection)
        {
            string connectionString = sqlConnection;
            DataSet ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, commandText);
            return ds.Tables[0];
        }
        public static DataTable ExecuteDataTable(string commandText)
        {
            DataSet ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, commandText);
            return ds.Tables[0];
        }
        #endregion

        #region 执行存储过程返回 int
        /// <summary>
        /// 执行存储过程返回 int
        /// </summary>
        /// <param name="commandProcedureName">Sql语句</param>
        /// <param name="commandParameters">存储过程参数</param>
        /// <returns>返回int</returns>
        public static int ExecuteProcNonQuery(string commandProcedureName, ref SqlParameter[] commandParameters, string sqlConnection)
        {
            string connectionString = sqlConnection;
            return SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, commandProcedureName, commandParameters);
        }

        public static int ExecuteProcNonQuery(string commandProcedureName, ref SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, commandProcedureName, commandParameters);
        }

        /// <summary>
        /// 执行存储过程返回 int
        /// </summary>
        /// <param name="commandProcedureName">Sql语句</param>
        /// <returns>返回int</returns>
        public static int ExecuteProcNonQuery(string commandProcedureName, string sqlConnection)
        {
            string connectionString = sqlConnection;
            return SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, commandProcedureName, null);
        }

        #endregion

        #region 执行存储过程返回 DataSet
        /// <summary>
        /// 执行存储过程返回 DataSet
        /// </summary>
        /// <param name="commandProcedureName">Sql语句</param>
        /// <param name="commandParameters">存储过程参数</param>
        /// <returns>返回DataSet</returns>
        public static DataSet ExecuteProcDataset(string commandProcedureName, ref SqlParameter[] commandParameters, string sqlConnection)
        {
            string connectionString = sqlConnection;
            return SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, commandProcedureName, commandParameters);
        }

        public static DataSet ExecuteProcDataset(string commandProcedureName, ref SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, commandProcedureName, commandParameters);
        }

        public static DataSet ExecuteProcDataset(string commandProcedureName)
        {
            return SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, commandProcedureName);
        }

        #endregion

        #region 执行存储过程返回 DataTable
        /// <summary>
        /// 执行存储过程返回 DataTable
        /// </summary>
        /// <param name="commandProcedureName">Sql语句</param>
        /// <param name="commandParameters">存储过程参数</param>
        /// <returns>返回DataSet</returns>
        public static DataTable ExecuteProcDataTable(string commandProcedureName, ref SqlParameter[] commandParameters, string sqlConnection)
        {
            string connectionString = sqlConnection;
            DataSet ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, commandProcedureName, commandParameters);
            return ds.Tables[0];
        }

        public static DataTable ExecuteProcDataTable(string commandProcedureName, ref SqlParameter[] commandParameters)
        {
            DataSet ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, commandProcedureName, commandParameters);
            return ds.Tables[0];
        }
        /// <summary>
        /// 执行存储过程返回 DataTable
        /// </summary>
        /// <param name="commandProcedureName">Sql语句</param>
        /// <returns>返回DataSet</returns>
        public static DataTable ExecuteProcDataTable(string commandProcedureName, string sqlConnection)
        {
            string connectionString = sqlConnection;
            DataSet ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, commandProcedureName, null);
            return ds.Tables[0];
        }

        public static DataTable ExecuteProcDataTable(string commandProcedureName)
        {
            DataSet ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, commandProcedureName, null);
            return ds.Tables[0];
        }


        #endregion

        #region 执行SQL 文本命令返回(带事务) int
        /// <summary>
        /// 执行SQL 文本命令返回(带事务) int
        /// </summary>
        /// <param name="commandText">Sql语句</param>
        /// <returns>返回int</returns>
        public static int ExecuteNonQuery(SqlTransaction transaction, string commandText)
        {
            return SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, commandText);
        }
        #endregion

        #region 执行SQL 文本命令返回(带事务) DataSet
        /// <summary>
        /// 执行SQL 文本命令返回(带事务) DataSet
        /// </summary>
        /// <param name="commandText">Sql语句</param>
        /// <returns>返回DataSet</returns>
        public static DataSet ExecuteDataset(SqlTransaction transaction, string commandText)
        {
            return SqlHelper.ExecuteDataset(transaction, CommandType.Text, commandText);
        }
        #endregion

        #region 执行SQL 文本命令返回(带事务) DataTable
        /// <summary>
        /// 执行SQL 文本命令返回(带事务) DataTable
        /// </summary>
        /// <param name="commandText">Sql语句</param>
        /// <returns>返回DataTable</returns>
        public static DataTable ExecuteDataTable(SqlTransaction transaction, string commandText)
        {
            DataSet ds = SqlHelper.ExecuteDataset(transaction, CommandType.Text, commandText);
            return ds.Tables[0];
        }
        #endregion

        #region 执行存储过程返回(带事务) int
        /// <summary>
        /// 执行存储过程返回(带事务) int
        /// </summary>
        /// <param name="commandProcedureName">Sql语句</param>
        /// <param name="commandParameters">存储过程参数</param>
        /// <returns>返回int</returns>
        public static int ExecuteProcNonQuery(SqlTransaction transaction, string commandProcedureName, ref SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure, commandProcedureName, commandParameters);
        }
        #endregion

        #region 执行存储过程返回(带事务) DataSet
        /// <summary>
        /// 执行存储过程返回(带事务) DataSet
        /// </summary>
        /// <param name="commandProcedureName">Sql语句</param>
        /// <param name="commandParameters">存储过程参数</param>
        /// <returns>返回DataSet</returns>
        public static DataSet ExecuteProcDataset(SqlTransaction transaction, string commandProcedureName, ref SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteDataset(transaction, CommandType.StoredProcedure, commandProcedureName, commandParameters);
        }
        #endregion

        #region 执行存储过程返回(带事务) DataTable
        /// <summary>
        /// 执行存储过程返回(带事务) DataTable
        /// </summary>
        /// <param name="commandProcedureName">Sql语句</param>
        /// <param name="commandParameters">存储过程参数</param>
        /// <returns>返回DataSet</returns>
        public static DataTable ExecuteProcDataTable(SqlTransaction transaction, string commandProcedureName, ref SqlParameter[] commandParameters)
        {
            DataSet ds = SqlHelper.ExecuteDataset(transaction, CommandType.StoredProcedure, commandProcedureName, commandParameters);
            return ds.Tables[0];
        }
        #endregion



    }
}