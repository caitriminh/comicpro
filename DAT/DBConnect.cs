using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace DAT
{
    public class DbConnect
    {
        protected SqlConnection Connection = new SqlConnection("server=125.212.221.113;uid=caitriminh; database=comicpro; password=Diemthuong@2809;");
        public static bool ExecuteProcNonQuery(string query, params SqlParameter[] paramList)
        {
            using (var con = new SqlConnection("server=125.212.221.113;uid=caitriminh; database=comicpro; password=Diemthuong@2809;"))
            {
                using (var cmd = con.CreateCommand())
                {
                    //{
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = query;
                    cmd.Parameters.AddRange(paramList.ToArray());
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //}
                    //catch (Exception)
                    //{
                    //    success = false;
                    //}
                    cmd.Parameters.Clear();
                    return true;
                }
            }
        }

        public static bool LoadDataProc(string procName, ref DataTable targetTb, params SqlParameter[] paramList)
        {
            StringBuilder callDefinition = new StringBuilder();
            callDefinition.Append(string.Format("ExecuteStoredProc: EXEC dbo.[{0}] ", procName));
            for (int i = 0; i < paramList.Count(); i++)
            {
                callDefinition.Append(string.Format("{0}='{1}'", paramList[i].ParameterName, paramList[i].Value));
                if (i < paramList.Count() - 1)
                {
                    callDefinition.Append(",");
                }
            }
            callDefinition.Append("\n");
            string debugSql = (callDefinition.ToString());
            Debug.Write(debugSql);
            return LoadData(procName, ref targetTb, CommandType.StoredProcedure, paramList);
        }

        public static bool LoadData(string sqlQuery, ref DataTable targetTb, CommandType cmdType,
            params SqlParameter[] paramList)
        {
            using (var con = new SqlConnection("server=125.212.221.113;uid=caitriminh; database=comicpro; password=Diemthuong@2809;"))
            {
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = sqlQuery;
                    cmd.Parameters.AddRange(paramList);
                    con.Open();
                    var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    if (targetTb == null)
                    {
                        targetTb = new DataTable();
                    }
                    else
                    {
                        ResetTable(targetTb);
                    }
                    //targetTb = new DataTable();
                    targetTb.Load(reader);
                    AllowEditColumn(targetTb);
                    reader.Close();
                    //}
                    //catch (SqlException)
                    //{
                    //    //XtraMessageBox.Show(ex.Message);
                    //    //XtraMessageBox.Show("Đọc dữ liệu thất bại.");
                    //    success = false;
                    //    //Process.GetCurrentProcess().Kill()
                    //}
                    cmd.Parameters.Clear();
                    return true;
                }
            }
        }

        private static void AllowEditColumn(DataTable dt)
        {
            foreach (DataColumn col in dt.Columns)
            {
                col.AllowDBNull = true;
                col.ReadOnly = false;
            }
        }

        private static void ResetTable(DataTable dt)
        {
            dt.Clear();
            dt.Columns.Clear();
        }
    }
}
