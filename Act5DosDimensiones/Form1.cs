using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Act5DosDimensiones
{

    public partial class Form1 : Form
    {
        private const int Filas = 5;
        private const int Columnas = 5;
        private int[,] matriz;

        public Form1()
        {
            InitializeComponent();
            GenerarMatrizAleatoria();
        }

        private void GenerarMatrizAleatoria()
        {
            matriz = new int[Filas, Columnas];
            Random rnd = new Random();

            for (int i = 0; i < Filas; i++)
            {
                for (int j = 0; j < Columnas; j++)
                {
                    matriz[i, j] = rnd.Next(1, 101); // Números aleatorios entre 1 y 100
                }
            }

            MostrarMatriz();
        }

        private void MostrarMatriz()
        {
            dgvMatriz.Rows.Clear();
            dgvMatriz.Columns.Clear();

            // Configurar la cuadrícula
            dgvMatriz.ColumnCount = Columnas;

            for (int i = 0; i < Filas; i++)
            {
                dgvMatriz.Rows.Add();
                for (int j = 0; j < Columnas; j++)
                {
                    dgvMatriz.Rows[i].Cells[j].Value = matriz[i, j];
                }
            }
        }




        private void btnBuscar_Click_1(object sender, EventArgs e)
        {

            int numeroBuscado;
            if (int.TryParse(txtNumero.Text, out numeroBuscado))
            {
                bool encontrado = false;
                for (int i = 0; i < Filas; i++)
                {
                    for (int j = 0; j < Columnas; j++)
                    {
                        if (matriz[i, j] == numeroBuscado)
                        {
                            MessageBox.Show($"El número {numeroBuscado} fue encontrado en la posición ({i + 1}, {j + 1}).");
                            encontrado = true;
                            break;
                        }
                    }
                    if (encontrado)
                        break;
                }
                if (!encontrado)
                    MessageBox.Show($"El número {numeroBuscado} no fue encontrado en la matriz.");
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un número entero válido.");
            }

        }
    }

}
