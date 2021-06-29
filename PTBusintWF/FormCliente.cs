using PTBusintWF.Conexion;
using PTBusintWF.Modelo;
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
    public partial class FormCliente : Form
    {
        private readonly FormClienteInfo _parent;

        public int codigo;
        public string nombre;
        public float presupuesto;
        public DateTime fecha;

        public FormCliente(FormClienteInfo parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void updateInfo()
        {
            label5.Text = "Actualizar estudiante";
            registrar.Text = "Actualizar";
            textBox1.Text = codigo.ToString();
            textBox2.Text = nombre;
            textBox3.Text = presupuesto.ToString();
            
        }

        private void FormCliente_Load(object sender, EventArgs e)
        {

        }

        public void clear()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
        }

        private void registrar_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length < 3)
            {
                MessageBox.Show("campo codigo esta vacio");
                return;
            }
            if (textBox2.Text.Trim().Length < 3)
            {
                MessageBox.Show("campo estudiante esta vacio");
                return;
            }
            if (textBox3.Text.Trim().Length == 0)
            {
                MessageBox.Show("campo presupuesto esta vacio");
                return;
            }
            if (registrar.Text == "Registrar")
            {
                Cliente cliente = new Cliente(Int32.Parse(textBox1.Text), textBox2.Text.Trim(), Convert.ToSingle(textBox3.Text, CultureInfo.CreateSpecificCulture("es-ES")), true, dateTimePicker1.Value);
                DBClientes.addCliente(cliente);
                clear();
            }
            if (registrar.Text == "Actualizar")
            {
                Cliente cliente = new Cliente(Int32.Parse(textBox1.Text), textBox2.Text.Trim(), Convert.ToSingle(textBox3.Text, CultureInfo.CreateSpecificCulture("es-ES")), true, dateTimePicker1.Value);
                DBClientes.updateCliente(cliente, codigo);
                
            }

            _parent.display();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
