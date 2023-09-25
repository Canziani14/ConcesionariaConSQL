using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Auto : BE.ICrud<BE.Auto>
    {
        string connectionString = @"Data Source=DESKTOP-NOJ7B2G\SQLEXPRESS;Initial Catalog=Concesionaria;Integrated Security=True";

        #region Agregar
        public bool Agregar(BE.Auto objAdd)
        {
            string queryAgregar = $"Insert into Auto (Marca, Modelo, Patente, Año) VALUES ('{objAdd.Marca}', '{objAdd.Modelo}', '{objAdd.Patente}', {objAdd.Año})";
            bool returnValue = false;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();

            command.Connection = connection;
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = queryAgregar;

            connection.Open();

            if (command.ExecuteNonQuery() > 0)
            {
                returnValue = true;
            }

            connection.Close();

            return returnValue;
        }
        #endregion

        #region Listar
        public List<BE.Auto> Listar()
        {
            string querySelect = "select * from auto";
            List<BE.Auto> autos = new List<BE.Auto>();
            SqlDataReader reader;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            DataTable table = new DataTable();

            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = querySelect;

            connection.Open();

            reader = command.ExecuteReader();
            table.Load(reader);

            connection.Close();

            foreach (DataRow item in table.Rows)
            {
                autos.Add(new BE.Auto()
                {
                    ID = item.Field<int>("ID"),
                    Marca=item.Field<string>("Marca"),
                    Modelo = item.Field<string>("Modelo"),
                    Patente=item.Field<string> ("Patente"),
                    Año=item.Field<int>("Año")
                });

            }

            return autos;
        }
        #endregion

        #region Actualizar
        public bool Actualizar(BE.Auto objActualizar)
        {
            bool returnValue = false;
            string queryActualizar = $"update auto set Marca='{objActualizar.Marca}', Modelo='{objActualizar.Modelo}', Patente='{objActualizar.Patente}', año='{objActualizar.Año}' where id= {objActualizar.ID}";

            SqlConnection connection = new SqlConnection(connectionString) ;
            SqlCommand command = new SqlCommand();
            
            command.Connection=connection;
            command.CommandType = CommandType.Text;
            command.CommandText = queryActualizar;

            connection.Open();
            if (command.ExecuteNonQuery()>0)
            {
                returnValue = true;
            }
            connection.Close();

            return returnValue;
        }
        #endregion

        #region Borrar
        public bool Borrar(BE.Auto objBorrar)
        {
            bool returnValue = false;
            string queryBorrar = $"delete from auto where id= {objBorrar.ID}";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();

            command.Connection=connection;
            command.CommandType = CommandType.Text;
            command.CommandText = queryBorrar;

            connection.Open();
            if (command.ExecuteNonQuery()>0)
            {
                returnValue = true;
            }
            connection.Close();
            return returnValue;
        }
        #endregion
       
    }
}
