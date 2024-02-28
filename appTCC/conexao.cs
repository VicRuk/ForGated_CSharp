using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace appTCC
{
    class conexao
    {
        public MySqlConnection conectar;
        public string servidor;
        public string database;
        public string usuario;
        public string senha; 

        public conexao()
        {
            inicializar();
        }

        public void inicializar()
        {
            servidor = "127.0.0.1";
            database = "systemtcc";
            usuario = "root";
            senha = "";
            string conexaostring;
            conexaostring = "SERVER=" + servidor + ";" + "DATABASE=" +
                database + ";" + "UID=" + usuario + ";" + "PASSWORD=" + senha + ";";
            conectar = new MySqlConnection(conexaostring);
        } 

        public bool abriconexao()
        {
            try
            {
                conectar.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        System.Windows.Forms.MessageBox.Show("Não foi possível conectar.");
                        break;
                    case 1045:
                        System.Windows.Forms.MessageBox.Show("Email e senha invávlidos! Verifique.");
                        break;
                }
                return false;
            }
        }

        public bool fecharconexao()
        {
            try
            {
                conectar.Close();
                return true;
            }
            catch(MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
