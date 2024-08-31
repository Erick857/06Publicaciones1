using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _06Publicaciones.Controllers;

 namespace _06Publicaciones.Views.Ciudades
 {
    public partial class frm_Ciudades : Form
    {
        private string id;
        public frm_Ciudades(string id )
        {
            InitializeComponent();
            this.id = id;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frm_Ciudades_Load(object sender, EventArgs e)
        {
            
            PaisesController _paises = new PaisesController();
            comboBox1.DataSource = _paises.todos();
            comboBox1.DisplayMember = "Detalle";
            comboBox1.ValueMember = "IdPais";
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            CiudadesController _ciudadesController = new CiudadesController();

            
            string nombreCiudad = textBox1.Text; 
            int idPais = Convert.ToInt32(comboBox1.SelectedValue);

            
            if (string.IsNullOrWhiteSpace(nombreCiudad))
            {
                MessageBox.Show("El nombre de la ciudad no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            if (string.IsNullOrEmpty(this.id))
            {
                
                bool success = _ciudadesController.Create(nombreCiudad, idPais);

                if (success)
                {
                    MessageBox.Show("Ciudad creada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); 
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al crear la ciudad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
               
                bool success = _ciudadesController.Update(this.id, nombreCiudad, idPais);

                if (success)
                {
                    MessageBox.Show("Ciudad actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); 
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al actualizar la ciudad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var confirmResult = MessageBox.Show("¿Estas seguro de que deseas cancelar? Se perderán los cambios no guardados.",
                                                "Confirmar Cancelación",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {

                this.Close();
            }
        }
    }
}

