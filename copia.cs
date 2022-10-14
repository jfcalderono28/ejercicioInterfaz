using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Interfaz
{
    public partial class copia : Form
    {
        ArrayList tabla = new ArrayList();
       
        


        public copia()
        {
            InitializeComponent();
            this.CenterToScreen();
            
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            Empleado obj = new Empleado();
            double x;
            if (nombre.Text.Equals("") || cedula.Text.Equals("") || (telefono.Text.Equals("")))
            {

                MessageBox.Show("Rellene los campos faltantes!");
            }
            else if (double.TryParse(cedula.Text, out x) == false)
            {
                MessageBox.Show("Cedula no es un número o contiene letras");
            }
            else if (double.TryParse(telefono.Text, out x) == false)
            {
                MessageBox.Show("Telefono no es un número o contiene letras");
            }
            else
            {
                obj.setNombre(nombre.Text);
                obj.setCedula(cedula.Text);
                obj.setTelefono(telefono.Text);
                try
                {
                    obj.setNumeroHoras(Int32.Parse(horasTrabajadas.Text));

                }
                catch (FormatException)
                {
                    MessageBox.Show("El valor de horas trabajadas no es numerico");

                }
                try
                {
                    obj.setValorHora(Int32.Parse(valorHora.Text));

                }
                catch (FormatException)
                {
                    MessageBox.Show("El valor de la hora no es numerico");

                }


                nombre.Text = "";
                cedula.Text = "";
                telefono.Text = "";
                horasTrabajadas.Text = "";
                valorHora.Text = "";
                total.Text = "";

                try
                {
                    nombre.Text = obj.getNombre();
                    cedula.Text = Convert.ToString(obj.getCedula());
                    telefono.Text = Convert.ToString(obj.getTelefono());
                    horasTrabajadas.Text = Convert.ToString(obj.getNumeroHoras());
                    valorHora.Text = Convert.ToString(obj.getValorHora());
                }
                catch (Exception)
                {
                    MessageBox.Show("Error ");


                }

                try
                {

                    obj.calcular(obj.getNumeroHoras());
                    total.Text = Convert.ToString(obj.getTotal());

                    tabla.Add(obj);





                }
                catch (Exception)
                {
                    MessageBox.Show("Error al calcular");

                }
            }








        }

        private void mostrar_Click(object sender, EventArgs e)
        {

                int x = tabla.Count;
            
               
                if (x==0)
                {

                    MessageBox.Show("No existen datos que mostrar!");

                }
                else
                {
                    Empleado obj = new Empleado();
                    obj = (Empleado)tabla[x-1];
                    nombre.Text = obj.getNombre();
                    cedula.Text = Convert.ToString(obj.getCedula());
                    telefono.Text = Convert.ToString(obj.getTelefono());
                    horasTrabajadas.Text = Convert.ToString(obj.getNumeroHoras());
                    valorHora.Text = Convert.ToString(obj.getValorHora());
                    obj.calcular(obj.getNumeroHoras());
                    total.Text = Convert.ToString(obj.getTotal());
                }
            

        }


        private void limpiar_Click(object sender, EventArgs e)
        {
            nombre.Text = "";
            cedula.Text = "";
            telefono.Text = "";
            horasTrabajadas.Text = "";
            valorHora.Text = "";
            total.Text = "";
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
          
 

        }

        private void nombreTabla_TextChanged(object sender, EventArgs e)
        {

        }

        private void buscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            //Application.Run(new Form2());
        }

        private void btnBuscar_Click_2(object sender, EventArgs e)
        {
            //buscar.ShowDialog();
            int size = tabla.Count;
            String cedula = Convert.ToString(boxCedula.Text);

            if (size == 0)
            {
                //error.Text = "Usuario no encontrado";
            }
            else
            {
                
                
                foreach (var item in tabla)
                {
                    Empleado temp = (Empleado)item;
                  
                    
                    if (!(temp.getCedula().Equals(cedula)))
                    {
                        error.Text = "Usuario no encontrado";
                       


                    }
                    else
                    {

                        txtBoxNombre.Text = temp.getNombre();
                        txtBoxCedulaMostrar.Text = temp.getCedula();
                        txtBoxTel.Text = temp.getTelefono();
                        txtBoxTrabajadas.Text = Convert.ToString(temp.getNumeroHoras());
                        txtBoxValor.Text = Convert.ToString(temp.getValorHora());
                        txtBoxTotal.Text = Convert.ToString(temp.getTotal());
                        error.Text = "";
                        break;
                    }
                }
            }
        }

        private void txtBoxCedula_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
    
}
