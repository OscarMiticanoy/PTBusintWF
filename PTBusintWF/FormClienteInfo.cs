using PTBusintWF.Conexion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTBusintWF
{
    public partial class FormClienteInfo : Form
    {

        FormCliente formcliente;

        public FormClienteInfo()
        {
            InitializeComponent();
            formcliente = new FormCliente(this);

        }

        public void display()
        {
            DBClientes.displayandSeach("SELECT codigo, nombre, presupuesto, activo, fecha FROM clientes", dataGridView1);
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {

            formcliente.clear();
            formcliente.ShowDialog();
        }

        private void FormClienteInfo_Shown_1(object sender, EventArgs e)
        {
            display();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            DBClientes.displayandSeach("SELECT codigo, nombre, presupuesto, activo, fecha FROM clientes WHERE nombre LIKE'%"+tbSearch.Text+"%'", dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                formcliente.clear();
                formcliente.codigo = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                formcliente.nombre = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                formcliente.presupuesto = Convert.ToSingle(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(), CultureInfo.CreateSpecificCulture("es-ES"));
                
                formcliente.updateInfo();
                formcliente.ShowDialog();
                return;
            }
            if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("seguro decea borrar el cliente", "informacion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DBClientes.deleteCliente(Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()));
                    display();
                }
            }
        }
    }
}
