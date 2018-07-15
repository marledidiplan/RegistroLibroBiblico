using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RegistroLibrosBiblicos.UI.Registro;
using RegistroLibrosBiblicos.UI.Consulta;

namespace RegistroLibrosBiblicos
{
    public partial class MenuP : Form
    {
        public MenuP()
        {
            InitializeComponent();
        }

        private void registroLibroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rLibroBiblico LibroBiblico = new rLibroBiblico();
            LibroBiblico.MdiParent = this;
            LibroBiblico.Show();
               
        }

        private void MenuP_Load(object sender, EventArgs e)
        {
          

        }

        private void consutarLibroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rConsultaLibro ConsultaLibro = new rConsultaLibro();
            ConsultaLibro.MdiParent = this;
            ConsultaLibro.Show();
        }
    }
}
