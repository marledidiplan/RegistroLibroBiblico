using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq.Expressions;
using RegistroLibrosBiblicos.Entidades;
using RegistroLibrosBiblicos.BLL;

namespace RegistroLibrosBiblicos.UI.Consulta
{
    public partial class rConsultaLibro : Form
    {
        public rConsultaLibro()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            Expression<Func<LibroBiblico, bool>> filtro = b=> true;
            int id;
            switch (FiltrarcomboBox.SelectedIndex)
            {
                case 0://Id
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = b => b.LibroId == id;
                    break;
                case 1://Fecha
                    filtro = b => b.Fecha >= DesdedateTimePicker.Value && (b.Fecha <= HastadateTimePicker.Value);
                    break;
                case 2: //Descripcion
                    filtro = b=> b.Descripcion.Equals(CriteriotextBox.Text) && (b.Fecha >= DesdedateTimePicker.Value && b.Fecha <= HastadateTimePicker.Value);
                    break;
                case 3://Tipo
                    filtro = b=> b.Tipo.Equals(CriteriotextBox.Text) && (b.Fecha >= DesdedateTimePicker.Value && b.Fecha <= HastadateTimePicker.Value);
                    break;
            }
            ConsultadataGridView.DataSource = BLL.LibroBiblicoBLL.GetList(filtro);
        }
    }
}
