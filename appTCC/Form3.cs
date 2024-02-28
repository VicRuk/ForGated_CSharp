using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace appTCC
{
    public partial class Form3 : Form
    {
        DataTable dt = new DataTable();
        public Form3()
        {
            InitializeComponent();
            Inicializar();
        }
        private void Inicializar()
        {
            dt = grid.GetIncendio(true);
            dgvIncendio.DataSource = dt;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.ShowDialog();
            this.Close();
        }
        insert i = new insert();
        private void timer1_Tick(object sender, EventArgs e)
        {
            SerialPort porta = new SerialPort("COM4", 9600);
            porta.Open();

            while (porta.IsOpen)
            {
                string data = porta.ReadLine();
                // Divide os dados em partes com base nos identificadores
                string[] parts = data.Split(':');

                if (parts.Length == 2)
                {
                    string identifier = parts[0].Trim();
                    string value = parts[1].Trim();

                    // Faça algo com os valores com base nos identificadores
                    switch (identifier)
                    {
                        case "Sensor de Temperatura":
                            // Processar valor do sensor de gás (value é uma string)
                            temptxt.Text = value + "°C";
                            ///int risk = int.Parse(value);

                            i.setTempo(DateTime.Now);
                            i.setReg_incendio(value);
                            i.insert_dados_incendio();
                            i.insert_dados_incendioUP();
                            /*if (risk > 15 || risk <25)
                            {
                                textBox3.Text = "Temperatura boa e estável";
                            }
                            else if(risk > 26 || risk < 35)
                            {
                                textBox3.Text = "Temperatura razoável";
                            }
                            else if(risk > 36)
                            {
                                textBox3.Text = "Temperatura alta de mais";
                            }*/
                            break;
                    }
                }
            }
            porta.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FiltrarGrade();
        }
        private void FiltrarGrade()
        {
            if (txtSearch.Text == "")
                dt.DefaultView.RowFilter = null;
            else if (IsNumeric(txtSearch.Text))
                dt.DefaultView.RowFilter = string.Format("[{0}] = {1}", "temperatura", txtSearch.Text); 
            dgvIncendio.DataSource = dt;

        }
        private bool IsNumeric(string valor)
        {
            return valor.All(char.IsNumber);
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
