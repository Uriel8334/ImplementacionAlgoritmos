using Figuras;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.MonthCalendar;

namespace ImplementacionAlgoritmos
{
    public partial class FrmCircle : Form
    {
        //definicion de un objeto tipo Circle
        private Circle ObjCircle = new Circle();

        //aplicando Singleton
        private static FrmCircle instance;



        public FrmCircle()
        {
            InitializeComponent();

            UIStyleUtility.ApplyStylesToForm(this);

        }
        //aplicando Singleton
        public static FrmCircle GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FrmCircle();
            }
            return instance;
        }

        //metodo para cargar los datos
        private void FrmCircle_Load(object sender, EventArgs e)
        {
            //Inicializacion de los datos y controles 
            //llamanda de la funcion InitializeData.
            ObjCircle.InitializeData(txtRadius, txtPerimeter, txtArea, picCanvas);
        }

        //metodo para calcular el area y el perimetro de un circulo
        private void btnCalculate_Click(object sender, EventArgs e)
        {

            //lectura de datos
            //llamada a la funcion ReadData.
            ObjCircle.ReadData(txtRadius);
            //calculo del perimetro de un circulo
            //llamada a la funcion PerimeterCircle
            ObjCircle.PerimeterCircle();
            //calculo del area de un circulo
            //llamada a la funcion AreaCircle
            ObjCircle.AreaCircle();
            //impresion de datos.
            //llamada a la funcion PrintData
            ObjCircle.PrintData(txtPerimeter, txtArea);
            //graficacion de un circulo
            // llamada a la funcion PlotShape
            ObjCircle.PlotShape(picCanvas);

        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            //inicializacion de los datos y controles.
            //llamada a la funcion InitializeData.
            ObjCircle.InitializeData(txtRadius, txtPerimeter, txtArea, picCanvas);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            //cerrar el formulario
            this.Close();
        }

        private void btnAlgorithDis_Click(object sender, EventArgs e)
        {
            ObjCircle.ReadData(txtRadius);
            ObjCircle.PerimeterCircle();
            ObjCircle.AreaCircle();
            ObjCircle.PrintData(txtPerimeter, txtArea);
            // Pasar el DataGridView directamente para actualización en tiempo real
            ObjCircle.AlgoritmoDiscretizacion(picCanvas, dataGridView1);
        }

        private void btnAlgorithPMedio_Click(object sender, EventArgs e)
        {
            ObjCircle.ReadData(txtRadius);
            ObjCircle.PerimeterCircle();
            ObjCircle.AreaCircle();
            ObjCircle.PrintData(txtPerimeter, txtArea);
            // Pasar el DataGridView directamente para actualización en tiempo real
            ObjCircle.AlgoritmoPuntoMedio(picCanvas, dataGridView1);
        }

        private void picCanvas_Click(object sender, EventArgs e)
        {
            if (ModifierKeys != Keys.Control) // Si no se está presionando Ctrl
            {
                // Obtener las coordenadas del clic
                MouseEventArgs mouseEvent = e as MouseEventArgs;
                if (mouseEvent != null)
                {
                    // Pasar las coordenadas al método de manejo de clics
                    ObjCircle.HandleCanvasClick(mouseEvent.X, mouseEvent.Y);
                }
            }
        }
    }
}
