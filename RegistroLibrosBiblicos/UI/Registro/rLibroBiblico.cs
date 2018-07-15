using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RegistroLibrosBiblicos.Entidades;

namespace RegistroLibrosBiblicos.UI.Registro
{
    public partial class rLibroBiblico : Form
    {
        public rLibroBiblico()
        {
            InitializeComponent();
        }
        public LibroBiblico LlenaClase()
        {
            LibroBiblico libroB = new LibroBiblico();
            libroB.Descripcion = DescripciontextBox.Text;
            libroB.Fecha = FechadateTimePicker.Value;
            libroB.Tipo = TipocomboBox.Text;
            libroB.Siglas = SiglatextBox.Text;

            return libroB;

        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            LibroBiblico libroB = new LibroBiblico();
            libroB = LlenaClase();
            bool paso = false;

            if(!HayErrores())
            {
                if (IdnumericUpDown.Value == 0)
                    paso = BLL.LibroBiblicoBLL.Guardar(libroB);
                else
                    paso = BLL.LibroBiblicoBLL.Modificar(LlenaClase());
                if (paso)
                    MessageBox.Show("GUARDADO" ,"EXITO!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("No se pudo Guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (paso)
                {
                    Nuevobutton.PerformClick();
                    MessageBox.Show("Guardado!!", "Exito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("No se pudo guardar!!", "Fallo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);


            }



        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            IdnumericUpDown.Value = 0;
            FechadateTimePicker.Value = DateTime.Now;
            DescripciontextBox.Clear();
            TipocomboBox.SelectedIndex = 0;
            SiglatextBox.Clear();
            errorProvider.Clear();
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);
            if (BLL.LibroBiblicoBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo Eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
        private bool HayErrores()
        {
            bool HayErrores = false;
            if(String.IsNullOrWhiteSpace(DescripciontextBox.Text))
            {
                errorProvider.SetError(DescripciontextBox, "Descrpcion vacia");
                HayErrores = true;

            }

            if(String.IsNullOrWhiteSpace(SiglatextBox.Text))
            {
                errorProvider.SetError(SiglatextBox, "Siglas Vacia");
                HayErrores = true;
            }
            return HayErrores;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);
            LibroBiblico libro = new LibroBiblico();

            if(libro !=null)
            {
                DescripciontextBox.Text = libro.Descripcion;
                FechadateTimePicker.Value = libro.Fecha;
                TipocomboBox.Text = libro.Tipo;
                SiglatextBox.Text = libro.Siglas;
            }
            else
                MessageBox.Show("No se encontro", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
