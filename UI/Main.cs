using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Main : Form
    {
        #region inicializaciones
        BE.Auto BEAuto = new BE.Auto();
        BE.Auto autoSeleccionado = new BE.Auto();
        BLL.Auto BLLAuto = new BLL.Auto();
        #endregion

        #region Listar
        public Main()
        {
            InitializeComponent();
            
            BLL.Auto BLLAuto = new BLL.Auto();
            dtgAutos.DataSource = BLLAuto.Listar();           
        }
        #endregion

        #region Agregar
        private void btnAgregar_Click(object sender, EventArgs e)
        {
      
            BEAuto.Marca = txtMarca.Text;
            BEAuto.Modelo = txtModelo.Text;
            BEAuto.Patente = txtPatente.Text;
            BEAuto.Año = int.Parse(txtAño.Text);

            if (BLLAuto.Agregar(BEAuto))
            {
                MessageBox.Show($"El auto con la patente: {BEAuto.Patente} se agrego correctamente");
            }
            else
            {
                MessageBox.Show("No pudo cargarse el auto");
            }
            limpiarGrilla();
            limpiartxt();
        }


        #endregion

        #region grilla
        private void dtgAutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgAutos.SelectedRows.Count>0)
            {
                autoSeleccionado = ((BE.Auto)dtgAutos.SelectedRows[0].DataBoundItem);
                CompletarAuto(autoSeleccionado);
            }
        }

        public void CompletarAuto(BE.Auto auto)
        {
            txtID.Text = auto.ID.ToString();
            txtMarca.Text = auto.Marca;
            txtModelo.Text = auto.Modelo;
            txtPatente.Text = auto.Patente;
            txtAño.Text = auto.Año.ToString();
        }
        #endregion

        #region modificar
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (autoSeleccionado != null)
            {
                {
                    if (BLLAuto.Actualizar(new BE.Auto()
                    {
                        ID = int.Parse(txtID.Text),
                        Marca=txtMarca.Text,
                        Modelo= txtModelo.Text,
                        Patente = txtPatente.Text,
                        Año = int.Parse(txtAño.Text)
                    }
                    ))
                    {
                        MessageBox.Show("Auto modificado correctamente");
                        limpiarGrilla();
                        limpiartxt();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo modificar el Auto");
                    }
                }
            }
        }
        #endregion

        #region eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (autoSeleccionado != null)
            {
                if (BLLAuto.Borrar(autoSeleccionado))
                {
                    MessageBox.Show($"Auto con patente {autoSeleccionado.Patente} borrado");
                    limpiarGrilla();
                    limpiartxt();
                }
                else
                {
                    MessageBox.Show("Error al borrar el auto");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un auto para borrar");
            }
            
        }
        #endregion

        #region FuncionesGenerales
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void limpiarGrilla()
        {
            dtgAutos.DataSource = null;
            dtgAutos.DataSource = BLLAuto.Listar();
        }

        private void limpiartxt()
        {
            txtID.Clear();
            txtMarca.Clear();
            txtModelo.Clear();
            txtPatente.Clear();
            txtAño.Clear();
        }
        #endregion
    }
}
