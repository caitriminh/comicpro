﻿using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ComicPro2019
{
    internal class ExecSQL
    {
        //Ghi chú: Cài đặt thư viện: Dapper để sử dụng
        public static long Insert<T>(T entityToInsert) where T : class
        {
            using (var connection = new SqlConnection(ConfigDatabase.CONNECTION_STRINGS))
            {
                connection.Open();
                return connection.Insert(entityToInsert);
            }
        }

        public static bool Update<T>(T entityToUpdate) where T : class
        {
            using (var connection = new SqlConnection(ConfigDatabase.CONNECTION_STRINGS))
            {
                connection.Open();
                return connection.Update(entityToUpdate);
            }
        }

        public static bool Delete<T>(T entityToDelete) where T : class
        {
            using (var connection = new SqlConnection(ConfigDatabase.CONNECTION_STRINGS))
            {
                connection.Open();
                return connection.Delete(entityToDelete);
            }
        }
        public static DataTable ExecProcedureDataAsDataTable(string ProcedureName, object parametter = null)
        {
            using (var connection = new SqlConnection(ConfigDatabase.CONNECTION_STRINGS))
            {
                connection.Open();
                var reader = connection.ExecuteReader(ProcedureName, param: parametter, commandType: CommandType.StoredProcedure);
                DataTable table = new DataTable();
                table.Load(reader);
                return table;
            }
        }

        public static async Task<DataTable> ExecProcedureDataAsyncAsDataTable(string ProcedureName, object parametter = null)
        {
            return await WithConnection(async c =>
            {
                var reader = await c.ExecuteReaderAsync(ProcedureName, param: parametter, commandType: CommandType.StoredProcedure);
                DataTable table = new DataTable();
                table.Load(reader);
                return table;
            });

        }


        public static DataTable ExecQueryDataAsDataTable(string T_SQL, object parametter = null)
        {
            using (var connection = new SqlConnection(ConfigDatabase.CONNECTION_STRINGS))
            {
                connection.Open();
                var reader = connection.ExecuteReader(T_SQL, param: parametter, commandType: CommandType.Text);
                DataTable table = new DataTable();
                table.Load(reader);
                return table;
            }
        }

        public static async Task<DataTable> ExecQueryDataAsyncAsDataTable(string T_SQL, object parametter = null)
        {
            return await WithConnection(async c =>
            {
                var reader = await c.ExecuteReaderAsync(T_SQL, param: parametter, commandType: CommandType.Text);
                DataTable table = new DataTable();
                table.Load(reader);
                return table;
            });

        }

        public static IEnumerable<T> ExecProcedureData<T>(string ProcedureName, object parametter = null)
        {
            using (var connection = new SqlConnection(ConfigDatabase.CONNECTION_STRINGS))
            {
                connection.Open();
                return connection.Query<T>(ProcedureName, param: parametter, commandType: CommandType.StoredProcedure);
            }
        }

        public static T ExecProcedureDataFistOrDefault<T>(string ProcedureName, object parametter = null)
        {
            using (var connection = new SqlConnection(ConfigDatabase.CONNECTION_STRINGS))
            {
                connection.Open();
                return connection.QueryFirstOrDefault<T>(ProcedureName, parametter, commandType: CommandType.StoredProcedure);
            }
        }

        //public static Tuple<T1, T2, T3> ExecProcMultiResult<T1, T2, IEnu T3>(string ProcedureName, object parametter = null)
        //{
        //    using (var connection = new SqlConnection(ConfigDatabase.CONNECTION_STRINGS))
        //    {
        //        connection.Open();
        //        using (var multi = connection.QueryMultiple(ProcedureName, param: parametter))
        //        {
        //            var t1 = multi.Read<T1>().FirstOrDefault();
        //            var t2 = multi.Read<T2>().FirstOrDefault();
        //            var t3 = multi.Read<T3>().ToList();

        //            return new Tuple<T1, T2, T3>(t1, t2, t3);
        //        }
        //    }
        //}

        public static async Task<IEnumerable<T>> ExecProcedureDataAsync<T>(string ProcedureName, object parametter = null)
        {

            return await WithConnection(async c =>
            {
                return await c.QueryAsync<T>(ProcedureName, parametter, commandType: CommandType.StoredProcedure);
            });


        }

        public static T ExecProcedureDataFirstOrDefaultAsync<T>(string ProcedureName, object parametter = null)
        {
            using (var connection = new SqlConnection(ConfigDatabase.CONNECTION_STRINGS))
            {
                connection.Open();
                return connection.QueryFirstOrDefaultAsync<T>(ProcedureName, parametter, commandType: CommandType.StoredProcedure).Result;
            }
        }

        public static int ExecProcedureNonData(string ProcedureName, object parametter = null)
        {
            using (var connection = new SqlConnection(ConfigDatabase.CONNECTION_STRINGS))
            {
                connection.Open();
                //return affectedRows 
                return connection.Execute(ProcedureName, parametter, commandType: CommandType.StoredProcedure);
            }
        }

        public static int ExecProcedureNonDataAsync(string ProcedureName, object parametter = null)
        {
            using (var connection = new SqlConnection(ConfigDatabase.CONNECTION_STRINGS))
            {
                connection.Open();
                return connection.ExecuteAsync(ProcedureName, parametter, commandType: CommandType.StoredProcedure).Result;
            }
        }

        public static IEnumerable<T> ExecQueryData<T>(string T_SQL, object parametter = null)
        {
            using (var connection = new SqlConnection(ConfigDatabase.CONNECTION_STRINGS))
            {
                connection.Open();
                return connection.Query<T>(T_SQL, parametter, commandType: CommandType.Text);
            }
        }

        public static T ExecQueryDataFistOrDefault<T>(string T_SQL, object parametter = null)
        {
            using (var connection = new SqlConnection(ConfigDatabase.CONNECTION_STRINGS))
            {
                connection.Open();
                return connection.QueryFirstOrDefault<T>(T_SQL, parametter, commandType: CommandType.Text);
            }
        }

        public static async Task<IEnumerable<T>> ExecQueryDataAsync<T>(string T_SQL, object parametter = null)
        {
            return await WithConnection(async c =>
            {
                return await c.QueryAsync<T>(T_SQL, parametter, commandType: CommandType.Text);
            });
        }

        public static T ExecQueryDataFirstOrDefaultAsync<T>(string T_SQL, object parametter = null)
        {
            using (var connection = new SqlConnection(ConfigDatabase.CONNECTION_STRINGS))
            {
                connection.Open();
                return connection.QueryFirstOrDefaultAsync<T>(T_SQL, parametter, commandType: CommandType.Text).Result;
            }
        }

        public static int ExecQueryNonData(string T_SQL, object parametter = null)
        {
            using (var connection = new SqlConnection(ConfigDatabase.CONNECTION_STRINGS))
            {
                connection.Open();
                return connection.Execute(T_SQL, parametter, commandType: CommandType.Text);
            }
        }

        public static async Task<int> ExecQueryNonDataAsync(string T_SQL, object parametter = null)
        {

            return await WithConnection(async c =>
            {
                return await c.ExecuteAsync(T_SQL, parametter, commandType: CommandType.Text);
            });



        }

        public static async Task<T> WithConnection<T>(Func<IDbConnection, Task<T>> getData)
        {

            using (var connection = new SqlConnection(ConfigDatabase.CONNECTION_STRINGS))
            {
                await connection.OpenAsync(); // Asynchronously open a connection to the database
                return await getData(connection); // Asynchronously execute getData, which has been passed in as a Func<IDBConnection, Task<T>>
            }

        }

        public static object ExecProcedureSacalar(string ProcedureName, object parametter = null)
        {
            using (var connection = new SqlConnection(ConfigDatabase.CONNECTION_STRINGS))
            {
                connection.Open();
                return connection.ExecuteScalar<object>(ProcedureName, parametter, commandType: CommandType.StoredProcedure);
            }

        }

        public static object ExecProcedureSacalarAsync(string ProcedureName, object parametter = null)
        {
            using (var connection = new SqlConnection(ConfigDatabase.CONNECTION_STRINGS))
            {
                connection.Open();
                return connection.ExecuteScalarAsync<object>(ProcedureName, parametter, commandType: CommandType.StoredProcedure).Result;
            }

        }

        public static object ExecQuerySacalar(string T_SQL, object parametter = null)
        {
            using (var connection = new SqlConnection(ConfigDatabase.CONNECTION_STRINGS))
            {
                connection.Open();
                return connection.ExecuteScalar<object>(T_SQL, parametter, commandType: CommandType.Text);
            }

        }

        public static object ExecQuerySacalarAsync(string T_SQL, object parametter = null)
        {
            using (var connection = new SqlConnection(ConfigDatabase.CONNECTION_STRINGS))
            {
                connection.Open();
                return connection.ExecuteScalarAsync<object>(T_SQL, parametter, commandType: CommandType.Text).Result;
            }

        }


    }
}
