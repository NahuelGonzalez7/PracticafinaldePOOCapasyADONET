using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos.AdmModels;
using Entidades.Models;

namespace WebClub
{
    public partial class WebClub : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MostrarJugadores();
                LlenarComboPuesto();
                LlenarComboBuscarxPuesto();
            }
        }

        #region Mostrar
        public void MostrarJugadores()
        {
            gridJugadores.DataSource = AdmJugador.Listar();
            gridJugadores.DataBind();
        }
        #endregion

        #region Llenar Combos
        public void LlenarComboPuesto()
        {
            DataTable dt = AdmJugador.ListarPuesto();
            ddlPuesto.DataSource = dt;
            ddlPuesto.DataValueField = dt.Columns["Puesto"].ToString();
            ddlPuesto.DataTextField = dt.Columns["Puesto"].ToString();
            ddlPuesto.DataBind();
        }
        public void LlenarComboBuscarxPuesto()
        {
            DataTable dt = AdmJugador.ListarPuesto();
            ddlJugadorxPuesto.Items.Add("[TODOS]");
            foreach (DataRow item in dt.Rows)
            {
                ddlJugadorxPuesto.Items.Add(item["Puesto"].ToString());
            }
        }
        #endregion

        #region Botones
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Jugador jugador = new Jugador()
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text),
                Puesto = ddlPuesto.SelectedValue
            };

            int filasAfectadas = AdmJugador.Insertar(jugador);

            if (filasAfectadas > 0)
            {
                MostrarJugadores();
            }
        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Jugador jugador = new Jugador()
            {
                ID = Convert.ToInt32(txtID.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text),
                Puesto = ddlPuesto.SelectedValue
            };

            int filasAfectadas = AdmJugador.Modificar(jugador);

            if (filasAfectadas > 0)
            {
                MostrarJugadores();
            }
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);

            int filasAfectadas = AdmJugador.Eliminar(id);

            if (filasAfectadas > 0)
            {
                MostrarJugadores();
            }
        }
        #endregion

        #region Seleccionador
        protected void ddlJugadorxPuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = ddlJugadorxPuesto.SelectedValue;
            if (item == "[TODOS]")
            {
                MostrarJugadores();
            }
            else
            {
                gridJugadores.DataSource = AdmJugador.traerPorPuesto(item);
                gridJugadores.DataBind();
            }
        }
        #endregion
    }
}