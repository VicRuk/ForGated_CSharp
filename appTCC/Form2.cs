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
    public partial class Form2 : Form
    {
        private bool correnteEletricaLigada = true;

        private bool sensorMovimento = true;
        public Form2()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1  .ShowDialog();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

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
                        case "Sensor de Movimento":
                            // Processar valor do sensor de movimento (value é uma string)   
                            textBox1.Text = value;

                            i.setTempo(DateTime.Now);
                            i.setReg_proximidade(value);
                            i.insert_dados();
                            i.insert_dadosUP();
                            if (value == "Movimento detectado")
                            {
                                pictureBox5.Visible = false;
                                pictureBox20.Visible = true;
                                panel5.BackColor = Color.FromArgb(232, 0, 0);
                                label4.BackColor = Color.FromArgb(232, 0, 0);
                                textBox1.BackColor = Color.FromArgb(232, 0, 0);
                            }
                            else if (value == "Sem movimento")
                            {
                                panel5.BackColor = Color.FromArgb(231, 247, 237);
                                label4.BackColor = Color.FromArgb(231, 247, 237);
                                textBox1.BackColor = Color.FromArgb(231, 247, 237);
                            }
                            break;

                    }
                }
            }
            porta.Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
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
                            temptxt.Text = value + "°C";

                            i.setTempo(DateTime.Now);
                            i.setReg_incendio(value);
                            i.insert_dados_incendio();
                            i.insert_dados_incendioUP();
                            /*if (value > 15 || value < 25)
                            {
                                textBox3.Text = "Temperatura boa e estável";
                                panel8.BackColor = Color.FromArgb(231, 247, 237);
                                pictureBox11.BackColor = Color.FromArgb(231, 247, 237);
                                pictureBox17.BackColor = Color.FromArgb(231, 247, 237);
                                pictureBox16.BackColor = Color.FromArgb(231, 247, 237);
                                pictureBox12.BackColor = Color.FromArgb(231, 247, 237);
                                label1.BackColor = Color.FromArgb(231, 247, 237);
                                temptxt.BackColor = Color.FromArgb(231, 247, 237);
                                label1.BackColor = Color.FromArgb(231, 247, 237);
                                textBox3.BackColor = Color.FromArgb(231, 247, 237);
                            }
                            else if(risk > 26 || risk < 35)
                            {
                                textBox3.Text = "Temperatura razoável";
                                panel8.BackColor = Color.FromArgb(231, 247, 237);
                                pictureBox11.BackColor = Color.FromArgb(231, 247, 237);
                                pictureBox17.BackColor = Color.FromArgb(231, 247, 237);
                                pictureBox16.BackColor = Color.FromArgb(231, 247, 237);
                                pictureBox12.BackColor = Color.FromArgb(231, 247, 237);
                                label1.BackColor = Color.FromArgb(231, 247, 237);
                                temptxt.BackColor = Color.FromArgb(231, 247, 237);
                                label1.BackColor = Color.FromArgb(231, 247, 237);
                                textBox3.BackColor = Color.FromArgb(231, 247, 237);
                            }
                            else if(risk > 36)
                            {
                                panel8.BackColor = Color.FromArgb(323,0,0);
                                pictureBox11.BackColor = Color.FromArgb(232, 0, 0);
                                pictureBox17.BackColor = Color.FromArgb(232, 0, 0);
                                pictureBox16.BackColor = Color.FromArgb(232, 0, 0);
                                pictureBox12.BackColor = Color.FromArgb(232, 0, 0);
                                label1.BackColor = Color.FromArgb(232, 0, 0);
                                temptxt.BackColor = Color.FromArgb(232, 0, 0);
                                label1.BackColor = Color.FromArgb(232, 0, 0);
                                textBox3.BackColor = Color.FromArgb(232, 0, 0);
                                textBox3.Text = "Temperatura alta de mais";
                            }*/
                            break;

                    }
                }
            }
            porta.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        insert i = new insert();
        private void button11_Click(object sender, EventArgs e)
        {
            /*SerialPort porta = new SerialPort("COM4", 9600);
            porta.Open();
            string port = porta.ReadLine();
            textBox1.Text = port;
            porta.Close();

            i.setTempo(DateTime.Now);
            i.setReg_proximidade(port);
            i.insert_dados();*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
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

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
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
                            textBox2.Text = value;

                            i.setTempo(DateTime.Now);
                            i.setReg_gas(value);
                            i.insert_dados_gas();
                            i.insert_dados_gasUP();
                            if (value == "Vazamento de gas detectado")
                            {
                                panel3.BackColor = Color.FromArgb(232, 0, 0);
                                pictureBox7.BackColor = Color.FromArgb(232, 0, 0);
                                pictureBox15.BackColor = Color.FromArgb(232, 0, 0);
                                pictureBox4.BackColor = Color.FromArgb(232, 0, 0);
                                label3.BackColor = Color.FromArgb(232, 0, 0);
                                textBox2.BackColor = Color.FromArgb(232, 0, 0);
                                //MessageBox.Show("PERIGO! Desligue a energia do sistema, será desligada automaticamente em 10 segundos");
                            }
                            else if (value == "Nenhum vazamento detectado")
                            {
                                panel3.BackColor = Color.FromArgb(231, 247, 237);
                                pictureBox7.BackColor = Color.FromArgb(231, 247, 237);
                                pictureBox15.BackColor = Color.FromArgb(231, 247, 237);
                                pictureBox4.BackColor = Color.FromArgb(231, 247, 237);
                                label3.BackColor = Color.FromArgb(231, 247, 237);
                                textBox2.BackColor = Color.FromArgb(231, 247, 237);
                            }
                            break;
                    }
                }
            }
            porta.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (correnteEletricaLigada)
            {
                /*SerialPort porta = new SerialPort("COM4", 9600);
                porta.Open();
                porta.Write("DesligarCorrente\n");*/
                correnteEletricaLigada = false;
                MessageBox.Show("A corrente elétrica foi desligada.");
                label7.Text = "Ligar";
                /*porta.Close();*/
            }
            else
            {
                /*SerialPort porta = new SerialPort("COM4", 9600);
                porta.Open();
                porta.Write("LigarCorrente\n");*/
                correnteEletricaLigada = true;
                MessageBox.Show("A corrente elétrica foi ligada.");
                label7.Text = "Desligar";
                /*porta.Close();*/
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
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
                        case "Sensor de Movimento":
                            // Processar valor do sensor de movimento (value é uma string)   
                            textBox1.Text = value;

                            i.setTempo(DateTime.Now);
                            i.setReg_proximidade(value);
                            i.insert_dados();
                            i.insert_dadosUP();
                            if(value == "Movimento detectado")
                            {
                                pictureBox5.Visible = false;
                                pictureBox20.Visible = true;
                                panel5.BackColor = Color.FromArgb(232, 0, 0);
                                label4.BackColor = Color.FromArgb(232, 0, 0);
                                textBox1.BackColor = Color.FromArgb(232, 0, 0);
                            }
                            else if(value == "Sem movimento")
                            {
                                panel5.BackColor = Color.FromArgb(231, 247, 237);
                                label4.BackColor = Color.FromArgb(231, 247, 237);
                                textBox1.BackColor = Color.FromArgb(231, 247, 237);
                            }
                            break;

                        case "Sensor de Temperatura":
                            temptxt.Text = value + "°C";

                            i.setTempo(DateTime.Now);
                            i.setReg_incendio(value);
                            i.insert_dados_incendio();
                            i.insert_dados_incendioUP();
                            /*if (value > 15 || value < 25)
                            {
                                textBox3.Text = "Temperatura boa e estável";
                                panel8.BackColor = Color.FromArgb(231, 247, 237);
                                pictureBox11.BackColor = Color.FromArgb(231, 247, 237);
                                pictureBox17.BackColor = Color.FromArgb(231, 247, 237);
                                pictureBox16.BackColor = Color.FromArgb(231, 247, 237);
                                pictureBox12.BackColor = Color.FromArgb(231, 247, 237);
                                label1.BackColor = Color.FromArgb(231, 247, 237);
                                temptxt.BackColor = Color.FromArgb(231, 247, 237);
                                label1.BackColor = Color.FromArgb(231, 247, 237);
                                textBox3.BackColor = Color.FromArgb(231, 247, 237);
                            }
                            else if(risk > 26 || risk < 35)
                            {
                                textBox3.Text = "Temperatura razoável";
                                panel8.BackColor = Color.FromArgb(231, 247, 237);
                                pictureBox11.BackColor = Color.FromArgb(231, 247, 237);
                                pictureBox17.BackColor = Color.FromArgb(231, 247, 237);
                                pictureBox16.BackColor = Color.FromArgb(231, 247, 237);
                                pictureBox12.BackColor = Color.FromArgb(231, 247, 237);
                                label1.BackColor = Color.FromArgb(231, 247, 237);
                                temptxt.BackColor = Color.FromArgb(231, 247, 237);
                                label1.BackColor = Color.FromArgb(231, 247, 237);
                                textBox3.BackColor = Color.FromArgb(231, 247, 237);
                            }
                            else if(risk > 36)
                            {
                                panel8.BackColor = Color.FromArgb(323,0,0);
                                pictureBox11.BackColor = Color.FromArgb(232, 0, 0);
                                pictureBox17.BackColor = Color.FromArgb(232, 0, 0);
                                pictureBox16.BackColor = Color.FromArgb(232, 0, 0);
                                pictureBox12.BackColor = Color.FromArgb(232, 0, 0);
                                label1.BackColor = Color.FromArgb(232, 0, 0);
                                temptxt.BackColor = Color.FromArgb(232, 0, 0);
                                label1.BackColor = Color.FromArgb(232, 0, 0);
                                textBox3.BackColor = Color.FromArgb(232, 0, 0);
                                textBox3.Text = "Temperatura alta de mais";
                            }*/
                            break;

                        case "Sensor de Gas":
                            textBox2.Text = value;

                            i.setTempo(DateTime.Now);
                            i.setReg_gas(value);
                            i.insert_dados_gas();
                            i.insert_dados_gasUP();
                            if(value == "Vazamento de gas detectado")
                            {
                                panel3.BackColor = Color.FromArgb(232, 0, 0);
                                pictureBox7.BackColor = Color.FromArgb(232, 0, 0);
                                pictureBox15.BackColor = Color.FromArgb(232, 0, 0);
                                pictureBox4.BackColor = Color.FromArgb(232, 0, 0);
                                label3.BackColor = Color.FromArgb(232, 0, 0);
                                textBox2.BackColor = Color.FromArgb(232, 0, 0);
                                //MessageBox.Show("PERIGO! Desligue a energia do sistema, será desligada automaticamente em 10 segundos");
                            }
                            else if(value == "Nenhum vazamento detectado")
                            {
                                panel3.BackColor = Color.FromArgb(231, 247, 237);
                                pictureBox7.BackColor = Color.FromArgb(231, 247, 237);
                                pictureBox15.BackColor = Color.FromArgb(231, 247, 237);
                                pictureBox4.BackColor = Color.FromArgb(231, 247, 237);
                                label3.BackColor = Color.FromArgb(231, 247, 237);
                                textBox2.BackColor = Color.FromArgb(231, 247, 237);
                            }
                            break;
                    }
                }
            }
            // Lê dados da porta serial (dados enviados pelo Arduino)
            porta.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            if (sensorMovimento)
            {
                timer1.Enabled = false;
            }
            else
            {
                timer1.Enabled = true;
            }
        }
    }
}
