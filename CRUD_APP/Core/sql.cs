using System;
using System.Linq;

using System.Data;
using Microsoft.Data.SqlClient;

using Dapper.Contrib.Extensions;
using Dapper;
using System.Windows.Forms;


namespace framework.core_app
{
    public class Sql : IDatabase
    {
        private string _connectionStr;
        private SqlConnection connection;
        public Sql(IReadConfig readconfig)
        {
            _connectionStr = readconfig.getString();
        }

        public void connect()
        {
            try
            {
                connection = new SqlConnection(_connectionStr);
                connection.Open();
                Console.WriteLine("connect");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public T[] Query<T>() where T : class, BaseEntity
        {
            try
            {
                var connection = new SqlConnection(_connectionStr);

                return connection.GetAll<T>().ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
        public T FindByUsn<T>(string constraints) where T : class, BaseEntity
        {
            try
            {
                var connection = new SqlConnection(_connectionStr);
                if (connection == null)
                    throw new ArgumentNullException("000");
                string sql = $"SELECT * FROM {typeof(T).Name} WHERE  username='{constraints}'";
                var t = connection.QueryFirstOrDefault<T>(sql);
                return t;
               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                // Log the exception or rethrow it as needed
                throw;
            }
        }

        public bool Save<T>(T entity) where T : class, BaseEntity
        {
            try
            {
                var connection = new SqlConnection(_connectionStr);
                if (connection == null)
                    throw new ArgumentNullException("000");

                var result = connection.Insert<T>(entity);
                    return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
        public bool Update<T>(T entity) where T : class, BaseEntity
        {
            try
            {
                var connection = new SqlConnection(_connectionStr);
                if (connection == null)
                    throw new ArgumentNullException("000");
                bool res = false;
                res = Dapper.Contrib.Extensions.SqlMapperExtensions.Update<T>(connection, entity);
                MessageBox.Show(res.ToString());

                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public T Get<T>(string id) where T:class,BaseEntity
        {
            try
            {
                using (var connection = new SqlConnection(_connectionStr))
                {
                    T res = (T)connection.Get<T>(id);
                    return res;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
        public bool remove<T>(T entity) where T : class, BaseEntity
        {
            try
            {
                using (var connection = new SqlConnection(_connectionStr))
                {
                    return connection.Delete<T>(entity);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }

        }
    }
}
