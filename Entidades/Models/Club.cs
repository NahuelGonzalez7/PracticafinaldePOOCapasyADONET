using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Models
{
    public class Club
    {
        #region Propiedades Autoimplementadas
        public int ID { get; set; }
        public string  Nombre { get; set; }
        public string  Domicilio { get; set; }
        public string Telefono { get; set; }
        #endregion

        #region Constructores

        public Club() { }

        public Club(int iD, string nombre, string domicilio, string telefono)
        {
            ID = iD;
            Nombre = nombre;
            Domicilio = domicilio;
            Telefono = telefono;
        }
        #endregion
    }
}
