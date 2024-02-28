using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace appTCC
{
    class login : conexao
    {
        private string email;
        private string pass;

        public void setEmail(string email)
        {
            this.email = email;
        }
        public string getEmail()
        {
            return this.email;
        }
        public void setPass(string pass)
        {
            this.pass = pass;
        }
        public string getPass()
        {
            return this.pass;
        }

        public int consultar_login()
        {
            this.abriconexao();

            string mSQL = "select count(email) from usuario where email = '" + getEmail() + "' and senha = '" + getPass() + "'";

            MySqlCommand cmd = new MySqlCommand(mSQL, conectar);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            Int32 resultado_query = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            int valor_login;
            valor_login = resultado_query;
            this.fecharconexao();
            return valor_login;
        }


    }
}
