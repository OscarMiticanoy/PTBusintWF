using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTBusintWF.Modelo
{
    class Cliente
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public float presupuesto { get; set; }
        public bool activo { get; set; }
        public DateTime fecha { get; set; }

        public Cliente(int codigo, string nombre, float presupuesto, bool activo, DateTime fecha)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.presupuesto = presupuesto;
            this.activo = activo;
            this.fecha = fecha;
        }
    }
}
