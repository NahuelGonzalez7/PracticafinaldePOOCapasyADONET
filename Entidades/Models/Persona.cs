using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Models
{
    public abstract class Persona
    {
        #region Propiedades Autoimplementadas
        public int ID { get; set; }
        public string  Nombre { get; set; }
        public string Apellido { get; set; }
        #endregion

        #region Constructores
        public Persona()
        {
        }

        public Persona(int iD, string nombre, string apellido)
        {
            ID = iD;
            Nombre = nombre;
            Apellido = apellido;
        }
        #endregion
    }
}
