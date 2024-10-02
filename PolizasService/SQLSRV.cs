using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ReadXMLPremium
{
    public class SQLSRV
    {
        public SqlConnection gSqlConnection = new SqlConnection();

        public SQLSRV()
        {
            try
            {
                string gCadenaConexion =
                            $@"Data Source={App.config.dbInstance};
                                Initial Catalog={App.config.dbDatabase};
                                Integrated Security=False;
                                MultipleActiveResultSets=True;
                                User Id={App.config.dbUser};
                                Password={App.config.dbPass};";

                this.gSqlConnection.ConnectionString = gCadenaConexion.Trim();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public int Conecta()
        {
            try
            {
                if (this.gSqlConnection.State == ConnectionState.Closed)
                {
                    this.gSqlConnection.Open();
                }

                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                App.logs.add("Error Conecta: " + gSqlConnection.DataSource + ex.StackTrace);
                return 0;
            }
        }

        public void Desconecta()
        {
            try
            {
                this.gSqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public SqlDataReader EjecutarLecturaDeDatos(string p_sentencia)
        {
            try
            {
                SqlCommand comando = new SqlCommand(p_sentencia, this.gSqlConnection);
                return comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                App.logs.add("Error - SQL Lectura de datos : " + p_sentencia + " - " + ex.Message);
                return null;
            }
        }
        public int EjecutaSimpleQuery(string query)
        {

            try
            {
                SqlCommand comando = new SqlCommand(query, this.gSqlConnection);
                return comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                App.logs.add("Error - SQL Lectura de datos : " + query + " - " + ex.Message);
                return 0;
            }
        }

        public List<string[]> EjecutaQuery(string query)
        {
            List<string[]> resultados = new List<string[]>();

            try
            {
                SqlCommand comando = new SqlCommand(query, this.gSqlConnection);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    string[] fila = new string[reader.FieldCount];

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        fila[i] = reader[i].ToString();
                    }

                    resultados.Add(fila);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                App.logs.add("Error - SQL Lectura de datos : " + query + " - " + ex.Message);
            }

            return resultados;
        }
    }
}
