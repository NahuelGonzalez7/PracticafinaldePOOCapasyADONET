using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Datos.AdmDB;

namespace Datos.AdmModels
{
    public static class AdmJugador
    {
        #region Listar
        public static List<Jugador> Listar()
        {
            string consultaSQL = "SELECT Id ,Nombre,Apellido,FechaNacimiento,Puesto FROM dbo.Jugador ";

            SqlCommand command = new SqlCommand(consultaSQL, AdminDB.ConectarBase());

            SqlDataReader reader;

            reader = command.ExecuteReader();

            List<Jugador> listaJugadores = new List<Jugador>();

            while (reader.Read())
            {
                listaJugadores.Add(new Jugador()
                {
                    ID = Convert.ToInt32(reader["ID"]),
                    Nombre = reader["Nombre"].ToString(),
                    Apellido = reader["Apellido"].ToString(),
                    FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]),
                    Puesto = reader["Puesto"].ToString()
                }
                );
            }

            AdminDB.ConectarBase().Close();
            reader.Close();

            return listaJugadores;
            //ToDo Funcionando OK
        }

        public static DataTable ListarPuesto()
        {
            string consultaSQL = "SELECT DISTINCT Puesto FROM dbo.Jugador ";

            SqlDataAdapter adapter = new SqlDataAdapter(consultaSQL, AdminDB.ConectarBase());

            DataSet ds = new DataSet();

            adapter.Fill(ds, "jugador");

            return ds.Tables["jugador"];

            //ToDo Funcionando OK
        }

        #endregion

        #region Traer Por Puesto
        public static DataTable traerPorPuesto(string puesto)
        {
            string consultaSQL = "SELECT Id ,Nombre,Apellido,FechaNacimiento,Puesto FROM dbo.Jugador WHERE Puesto = @Puesto";

            SqlDataAdapter adapter = new SqlDataAdapter(consultaSQL, AdminDB.ConectarBase());

            adapter.SelectCommand.Parameters.Add("@Puesto", SqlDbType.VarChar, 50).Value = puesto;

            DataSet ds = new DataSet();

            adapter.Fill(ds, "Puesto");
            return ds.Tables["Puesto"];

            //ToDo Funcionando OK
        }

        #endregion

        #region Operaciones de modificacion
        public static int Insertar(Jugador jugador)
        {
            string consultaSQL = "INSERT into dbo.Jugador(Nombre,Apellido,FechaNacimiento,Puesto) VALUES (@Nombre,@Apellido,@FechaNacimiento,@Puesto)";

            SqlCommand command = new SqlCommand(consultaSQL, AdminDB.ConectarBase());

            command.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = jugador.Nombre;
            command.Parameters.Add("@Apellido", SqlDbType.VarChar, 50).Value = jugador.Apellido;
            command.Parameters.Add("@FechaNacimiento", SqlDbType.Date).Value = jugador.FechaNacimiento;
            command.Parameters.Add("@Puesto", SqlDbType.VarChar, 50).Value = jugador.Puesto;

            int filasAfectadas = command.ExecuteNonQuery();

            AdminDB.ConectarBase().Close();

            return filasAfectadas;
            //ToDo Funcionando OK
        }

        public static int Modificar(Jugador jugador)
        {
            string consultaSQL = "UPDATE dbo.Jugador set Nombre = @Nombre, Apellido = @Apellido, FechaNacimiento = @FechaNacimiento, Puesto = @Puesto WHERE Id = @Id";

            SqlCommand command = new SqlCommand(consultaSQL, AdminDB.ConectarBase());

            command.Parameters.Add("@ID", SqlDbType.Int).Value = jugador.ID;
            command.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = jugador.Nombre;
            command.Parameters.Add("@Apellido", SqlDbType.VarChar, 50).Value = jugador.Apellido;
            command.Parameters.Add("@FechaNacimiento", SqlDbType.Date).Value = jugador.FechaNacimiento;
            command.Parameters.Add("@Puesto", SqlDbType.VarChar, 50).Value = jugador.Puesto;

            int filasAfectadas = command.ExecuteNonQuery();

            AdminDB.ConectarBase().Close();

            return filasAfectadas;
            // ToDo Funciona OK
        }

        public static int Eliminar(int id)
        {
            string consultaSQL = "DELETE from dbo.Jugador WHERE ID = @ID";

            SqlCommand command = new SqlCommand(consultaSQL, AdminDB.ConectarBase());

            command.Parameters.Add("@ID", SqlDbType.Int).Value = id;

            int filasAfectadas = command.ExecuteNonQuery();

            AdminDB.ConectarBase().Close();

            return filasAfectadas;

            // ToDo Funciona Ok
        }

        #endregion
    }
}
