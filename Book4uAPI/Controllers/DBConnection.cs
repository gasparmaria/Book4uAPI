using Book4uAPI.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Book4uAPI.Controllers
{
    public class DBConnection 
    {
        MySqlConnection conn2;

        static string host = "localhost";
        static string database = "dbBook4u";
        static string userDB = "root";
        static string password = "12345678";
        public static string strProvider = "server=" + host +
                                            ";Database=" + database +
                                            ";User ID=" + userDB +
                                            ";Password=" + password;

        public static Boolean novo = false;
        public String sql;

        public DBConnection()
        {
            conn2 = new MySqlConnection(strProvider);
            conn2.Open();
        }

        public List<Livro> BuscaTodos()
        {
            MySqlDataReader reader;
            sql = "SELECT * FROM tbLivro;";
            MySqlCommand cmd = new MySqlCommand(sql, conn2);
            reader = cmd.ExecuteReader();
            List<Livro> l = new List<Livro>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    l.Add(new Livro(int.Parse(reader["idLivro"].ToString()), reader["detalhes"].ToString(), int.Parse(reader["numPag"].ToString()), reader["titulo"].ToString(), reader["autor"].ToString()));

                }
            }
            return l;
        }

        public String BuscarLivro(string titulo)
        {
            MySqlDataReader reader;
            sql = String.Format("SELECT * FROM tbLivro WHERE titulo = {0}", titulo);
            MySqlCommand cmd = new MySqlCommand(sql, conn2);
            var dados = cmd.ExecuteReader();
            return dados.ToString();
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            MySqlDataReader reader;
            MySqlCommand sql = new MySqlCommand("INSERT INTO tbUsuario VALUES(DEFAULT, @login, @senha, @nome)", conn2);
            sql.Parameters.Add("@login", MySqlDbType.VarChar).Value = usuario.login;
            sql.Parameters.Add("@senha", MySqlDbType.VarChar).Value = usuario.senha;
            sql.Parameters.Add("@nome", MySqlDbType.VarChar).Value = usuario.nome;
            sql.ExecuteNonQuery();
        }

        public void EditarUsuario(Usuario usuario)
        {
            MySqlDataReader reader;
            MySqlCommand sql = new MySqlCommand("UPDATE tbUsuario SET login = @login, senha = @senha, nome = @nome WHERE idUsuario = @idUsuario", conn2);
            sql.Parameters.Add("@login", MySqlDbType.VarChar).Value = usuario.login;
            sql.Parameters.Add("@senha", MySqlDbType.VarChar).Value = usuario.senha;
            sql.Parameters.Add("@nome", MySqlDbType.VarChar).Value = usuario.nome;
            sql.Parameters.Add("@idUsuario", MySqlDbType.Int32).Value = usuario.idUsuario;
            sql.ExecuteNonQuery();
        }

        public void Fechar()
        {
            conn2.Close();
        }
    }
}
