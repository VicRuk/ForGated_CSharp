using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appTCC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            login l = new login();
            l.setEmail(txt_email.Text);
            l.setPass(txt_pass.Text);
            l.consultar_login();

            int valor = l.consultar_login();

            if(valor == 1)
            {
                Form2 f2 = new Form2();
                f2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Email e Senha Inválidos", "Acesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
