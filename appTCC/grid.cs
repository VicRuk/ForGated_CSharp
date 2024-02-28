using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace appTCC
{
    class grid 
    {
        public int id { get; set; }
        public String deteccao { get; set; }
        public String comodo { get; set; } 
        public DateTime tempo { get; set; }

        public char Ativos { get; set; }

        public static DataTable GetDados(bool ativos)
        {
            var dt = new DataTable();
            var sql = "SELECT deteccao, comodo, tempo from proximidade order by cod_proximidade desc";

            try
            {
                using (var cn = new conexao().conectar)
                {
                    cn.Open();
                    using (var da = new MySqlDataAdapter(sql, cn))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        public int cod { get; set; }
        public double temperatura { get; set; }
        public String comodo2 { get; set; }
        public DateTime time { get; set; }

        public char Ativo { get; set; }

        public static DataTable GetIncendio(bool ativo)
        {
            var dt = new DataTable();
            var sql = "SELECT temperatura, comodo, tempo from incendio order by cod_incendio desc";

            try
            {
                using (var cn = new conexao().conectar)
                {
                    cn.Open();
                    using (var da = new MySqlDataAdapter(sql, cn))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        public int codG { get; set; }
        public double detect { get; set; }
        public String comodo3 { get; set; }
        public DateTime data { get; set; }

        public char Activo { get; set; }

        public static DataTable GetGas(bool activo)
        {
            var dt = new DataTable();
            var sql = "SELECT deteccao, comodo, tempo from gas order by cod_gas desc";

            try
            {
                using (var cn = new conexao().conectar)
                {
                    cn.Open();
                    using (var da = new MySqlDataAdapter(sql, cn))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }
    }


}
