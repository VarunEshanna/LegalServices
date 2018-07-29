using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace TestFramework
{
    class RepositoryHandler
    {
        public static void upsertTestMethodData(TestMethodDataEntity testMethodDataEntity)
        {
            string connstring = "Server=127.0.0.1; Port=5432; User Id=postgres; Password=admin; Database=TestFramework;";
            NpgsqlConnection connection = null;
            try
            {
                String timeStamp = (DateTime.Now).ToString("yyyy/MM/dd HH:mm:ss");
                connection = new NpgsqlConnection(connstring);
                connection.Open();

                String selectQuery = "select COUNT(*) from testmethoddata where testclassname = :testclassname and testmethodname = :testmethodname and testdatareference = :testdatareference";
                NpgsqlCommand command = new NpgsqlCommand(selectQuery, connection);
                command.Parameters.Add(new NpgsqlParameter("testclassname", testMethodDataEntity.TestClassName));
                command.Parameters.Add(new NpgsqlParameter("testmethodname", testMethodDataEntity.TestMethodName));
                command.Parameters.Add(new NpgsqlParameter("testdatareference", testMethodDataEntity.TestDataReference));
                Int64 count = (Int64)command.ExecuteScalar();
                if(count == 0)
                {
                    NpgsqlCommand command2 = new NpgsqlCommand("insert into testmethoddata (testmethodname, testclassname, testdatareference, result, message, lastruntimestamp) values(:testmethodname, :testclassname, :testdatareference, :result, :message, :lastruntimestamp)", connection);
                    command2.Parameters.Add(new NpgsqlParameter("testmethodname", testMethodDataEntity.TestMethodName));
                    command2.Parameters.Add(new NpgsqlParameter("testclassname", testMethodDataEntity.TestClassName));
                    command2.Parameters.Add(new NpgsqlParameter("testdatareference", testMethodDataEntity.TestDataReference));
                    command2.Parameters.Add(new NpgsqlParameter("result", testMethodDataEntity.Result));
                    command2.Parameters.Add(new NpgsqlParameter("lastruntimestamp", timeStamp));
                    if (!testMethodDataEntity.Result)
                    {
                        command2.Parameters.Add(new NpgsqlParameter("message", testMethodDataEntity.Message));
                    }
                    else
                    {
                        command2.Parameters.Add(new NpgsqlParameter("message", ""));
                    }
                    command2.ExecuteNonQuery();
                }
                else
                {
                    NpgsqlCommand command2 = new NpgsqlCommand("update testmethoddata set result = :result, message = :message, lastruntimestamp = :lastruntimestamp where testmethodname = :testmethodname and testclassname= :testclassname and testdatareference = :testdatareference", connection);
                    command2.Parameters.Add(new NpgsqlParameter("testmethodname", testMethodDataEntity.TestMethodName));
                    command2.Parameters.Add(new NpgsqlParameter("testclassname", testMethodDataEntity.TestClassName));
                    command2.Parameters.Add(new NpgsqlParameter("testdatareference", testMethodDataEntity.TestDataReference));
                    command2.Parameters.Add(new NpgsqlParameter("result", testMethodDataEntity.Result));
                    if (!testMethodDataEntity.Result)
                    {
                        command2.Parameters.Add(new NpgsqlParameter("message", testMethodDataEntity.Message));
                    }
                    else
                    {
                        command2.Parameters.Add(new NpgsqlParameter("message", ""));
                    }
                    command2.Parameters.Add(new NpgsqlParameter("lastruntimestamp", timeStamp));
                    command2.ExecuteNonQuery();
                }
            }catch(Exception ex)
            {
                String ErrorMessage = ex.Message;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
