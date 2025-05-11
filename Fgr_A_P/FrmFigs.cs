using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fgr_A_P
{
    public partial class FrmFigs : Form
    {
        public FrmFigs()
        {
            InitializeComponent();
        }

        //public void SetPictureBox(Image img)
        //{
        //    picCnv.Image = img;
        //}

        private void cmbFig_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlParametros.Controls.Clear();
            string figura = cmbFig.SelectedItem.ToString();

            switch (figura)
            {
                case "Triángulo":
                    AddParametro("Base", "txtBase");
                    AddParametro("Altura", "txtAltura");
                    AddParametro("Lado A", "txtLadoA");
                    AddParametro("Lado B", "txtLadoB");
                    AddParametro("Lado C", "txtLadoC");
                    picCnv.Image = Image.FromFile(Path.Combine(Application.StartupPath, "imgs", "triangle.png"));
                    
                    break;
                case "Círculo":
                    AddParametro("Radio", "txtRadio");
                    picCnv.Image = Image.FromFile(Path.Combine(Application.StartupPath, "imgs", "circle.png"));
                    break;
                case "Cuadrado":
                    AddParametro("Lado", "txtLado");
                    picCnv.Image = Image.FromFile(Path.Combine(Application.StartupPath, "imgs", "square.png"));
                    break;
                case "Rectángulo":
                    AddParametro("Base", "txtBase");
                    AddParametro("Altura", "txtAltura");
                    picCnv.Image = Image.FromFile(Path.Combine(Application.StartupPath, "imgs", "rectangle.png"));
                    break;
                case "Trapecio":
                    AddParametro("Base 1", "txtBase1");
                    AddParametro("Base 2", "txtBase2");
                    AddParametro("Altura", "txtAltura");
                    AddParametro("Lado 1", "txtLado1");
                    AddParametro("Lado 2", "txtLado2");
                    picCnv.Image = Image.FromFile(Path.Combine(Application.StartupPath, "imgs", "trap.png"));
                    break;
                case "Rombo":
                    AddParametro("Diagonal 1", "txtDiagonal1");
                    AddParametro("Diagonal 2", "txtDiagonal2");
                    AddParametro("Lado", "txtLado");
                    picCnv.Image = Image.FromFile(Path.Combine(Application.StartupPath, "imgs", "rombo.png"));
                    break;
                case "Elipse":
                    AddParametro("Semi-eje mayor", "txtSemiEjeMayor");
                    AddParametro("Semi-eje menor", "txtSemiEjeMenor");
                    picCnv.Image = Image.FromFile(Path.Combine(Application.StartupPath, "imgs", "elipse.png"));
                    break;
                case "Polígono regular":
                    AddParametro("Número de lados", "txtNumLados");
                    AddParametro("Longitud del lado", "txtLongitudLado");
                    picCnv.Image = Image.FromFile(Path.Combine(Application.StartupPath, "imgs", "poli.png"));
                    break;
                default:
                    break;
            }
        }

        private void AddParametro(string labelText, string textboxName)
        {
            int y = pnlParametros.Controls.Count / 2 * 30;
            var lbl = new Label { Text = labelText, Location = new Point(10, y) };
            var txt = new TextBox { Name = textboxName, Location = new Point(120, y), Width = 130 };
            pnlParametros.Controls.Add(lbl);
            pnlParametros.Controls.Add(txt);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                IFgr figuraObj = CrearFiguraDesdeUI();
                double area = figuraObj.GetArea();
                double perimetro = figuraObj.GetPerimeter();
                lblArea.Text = $"Área: {area:F2}";
                lblPerimetro.Text = $"Perímetro: {perimetro:F2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private IFgr CrearFiguraDesdeUI()
        {
            string fig = cmbFig.SelectedItem.ToString();
            double ParseOrError(string name)
            {
                var txt = pnlParametros.Controls.Find(name, true).FirstOrDefault() as TextBox;
                if (txt == null || string.IsNullOrWhiteSpace(txt.Text))
                    throw new ArgumentException($"Falta {name}");
                if (!double.TryParse(txt.Text, out double v) || v <= 0)
                    throw new ArgumentException($"{name} debe ser mayor que 0");
                return v;
            }

            switch (fig)
            {
                case "Triángulo":
                    return new Triangle
                    {
                        Base = (float)ParseOrError("txtBase"),
                        Height = (float)ParseOrError("txtAltura"),
                        Side1 = (float)ParseOrError("txtLadoA"),
                        Side2 = (float)ParseOrError("txtLadoB"),
                        Side3 = (float)ParseOrError("txtLadoC")
                    };
                case "Círculo":
                    return new Circle
                    {
                        Radius = (float)ParseOrError("txtRadio")
                    };
                case "Cuadrado":
                    return new Square
                    {
                        Side = (float)ParseOrError("txtLado")
                    };
                case "Rectángulo":
                    return new Rectangle
                    {
                        Width= (float)ParseOrError("txtBase"),
                         Length= (float)ParseOrError("txtAltura")
                    };
                case "Trapecio":
                    return new Trapezoid
                    {
                        Base1 = (float)ParseOrError("txtBase1"),
                        Base2 = (float)ParseOrError("txtBase2"),
                        Height = (float)ParseOrError("txtAltura"),
                        Side1 = (float)ParseOrError("txtLado1"),
                        Side2 = (float)ParseOrError("txtLado2")
                    };
                case "Rombo":
                    return new Rhombus
                    {
                        Diagonal1 = (float)ParseOrError("txtDiagonal1"),
                        Diagonal2 = (float)ParseOrError("txtDiagonal2"),
                        Side = (float)ParseOrError("txtLado")
                    };
                case "Elipse":
                    return new Elipse
                    {
                        SemiMajorAxis = (float)ParseOrError("txtSemiEjeMayor"),
                        SemiMinorAxis = (float)ParseOrError("txtSemiEjeMenor")
                    };
                case "Polígono regular":
                    return new RegularPoly
                    {
                        NumberOfSides = (int)ParseOrError("txtNumLados"),
                        SideLength = (float)ParseOrError("txtLongitudLado")
                    };
                default:
                    throw new NotSupportedException("Figura no soportada");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in pnlParametros.Controls)
            {
                if (ctrl is TextBox txt)
                {
                    txt.Clear();
                }
            }
            lblArea.Text = "Área: ";
            lblPerimetro.Text = "Perímetro: ";
        }
    }
}
