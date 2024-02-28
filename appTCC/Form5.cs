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
    public partial class Form5 : Form
    {
        DataTable dt = new DataTable();
        public Form5()
        {
            InitializeComponent();
            Inicializar();
        }
        private void Inicializar()
        {
            dt = grid.GetGas(true);
            dgvGas.DataSource = dt;
        }
        private void button13_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
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

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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
                        case "Sensor de Gas":
                            // Processar valor do sensor de gás (value é uma string)
                            textBox2.Text = value;
                            i.setTempo(DateTime.Now);
                            i.setReg_gas(value);
                            i.insert_dados_gas();
                            i.insert_dados_gasUP();
                            if (value == "Vazamento de gas detectado")
                            {
                                panel2.BackColor = Color.FromArgb(232, 0, 0);
                                pictureBox7.BackColor = Color.FromArgb(232, 0, 0);
                                pictureBox15.BackColor = Color.FromArgb(232, 0, 0);
                                label3.BackColor = Color.FromArgb(232, 0, 0);
                                textBox2.BackColor = Color.FromArgb(232, 0, 0);
                                //MessageBox.Show("PERIGO! Desligue a energia do sistema, será desligada automaticamente em 10 segundos");
                            }
                            else if (value == "Nenhum vazamento detectado")
                            {
                                panel2.BackColor = Color.FromArgb(231, 247, 237);
                                pictureBox7.BackColor = Color.FromArgb(231, 247, 237);
                                pictureBox15.BackColor = Color.FromArgb(231, 247, 237);
                                label3.BackColor = Color.FromArgb(231, 247, 237);
                                textBox2.BackColor = Color.FromArgb(231, 247, 237);
                            }
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
            dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "deteccao", txtSearch.Text);
            dgvGas.DataSource = dt;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
