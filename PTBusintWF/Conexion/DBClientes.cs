using MySql.Data.MySqlClient;
using PTBusintWF.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTBusintWF.Conexion
{
    class DBClientes
    {
        public static MySqlConnection GetConection()
        {
            string sql = "datasource=localhost;port=3306;username=root;password=;database=pruebabusint";
            MySqlConnection con = new MySqlConnection(sql);
            try
            {
                con.Open();
            }
            catch(MySqlException ex )
            {
                MessageBox.Show("Conetion: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return con;
        }

        public static void addCliente(Cliente cliente)
        {
            string sql = "INSERT INTO clientes VALUES (@codigo, @nombre, @presupuesto, @activo, @fecha)";
            MySqlConnection con = GetConection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@codigo", MySqlDbType.Int32).Value = cliente.codigo;
            cmd.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = cliente.nombre;
            cmd.Parameters.Add("@presupuesto", MySqlDbType.Float).Value = cliente.presupuesto;
            cmd.Parameters.Add("@activo", MySqlDbType.Bit).Value = cliente.activo;
            cmd.Parameters.Add("@fecha", MySqlDbType.DateTime).Value = cliente.fecha;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Agregado correcto", "informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("fallo en insercion \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();

        }

        public static void updateCliente(Cliente cliente, int codigo)
        {
            string sql = "UPDATE clientes SET  nombre=@nombre, presupuesto=@presupuesto, fecha=@fecha WHERE codigo=@codigo";
            MySqlConnection con = GetConection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@codigo", MySqlDbType.Int32).Value = codigo;
            cmd.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = cliente.nombre;
            cmd.Parameters.Add("@presupuesto", MySqlDbType.Float).Value = cliente.presupuesto;
            cmd.Parameters.Add("@fecha", MySqlDbType.DateTime).Value = cliente.fecha;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("actualizado correcto", "informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("fallo en actualizacion \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();

        }

        public static void deleteCliente( int codigo)
        {
            string sql = "DELETE FROM clientes WHERE codigo=@codigo";
            MySqlConnection con = GetConection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@codigo", MySqlDbType.Int32).Value = codigo;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("borrado correcto", "informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("fallo en borrado \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static void displayandSeach(string query, DataGridView dgv)
        {
            string sql = query;
            MySqlConnection con = GetConection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dgv.DataSource = tbl;
            con.Close();
        }
    }
}
