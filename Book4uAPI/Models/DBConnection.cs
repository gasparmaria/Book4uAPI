using Book4uAPI.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Book4uAPI.Models
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

        public List<Livro> ListarLivros()
        {
            MySqlDataReader reader;
            sql = "SELECT * FROM tbLivro;";
            MySqlCommand cmd = new MySqlCommand(sql, conn2);
            reader = cmd.ExecuteReader();
            List<Livro> lista = new List<Livro>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    lista.Add(new Livro(reader["idLivro"].ToString(), reader["titulo"].ToString(), reader["autor"].ToString(), reader["link"].ToString()));

                }
            }
            return lista;
        }

        public String BuscarLivro(string titulo)
        {
            sql = String.Format("SELECT * FROM tbLivro WHERE titulo = {0}", titulo);
            MySqlCommand cmd = new MySqlCommand(sql, conn2);
            var dados = cmd.ExecuteReader();
            return dados.ToString();
        }

        public bool VerificarLogin(string login, string senha)
        {
            sql = String.Format("SELECT * FROM tbUsuario WHERE login = {0} AND senha = {1}", login, senha);
            MySqlCommand cmd = new MySqlCommand(sql, conn2);
            var dados = cmd.ExecuteReader();

            if (dados.HasRows)
                return true;
            else
                return false;
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            MySqlCommand sql = new MySqlCommand("INSERT INTO tbUsuario VALUES(DEFAULT, @login, @senha, @nome)", conn2);
            sql.Parameters.Add("@login", MySqlDbType.VarChar).Value = usuario.login;
            sql.Parameters.Add("@senha", MySqlDbType.VarChar).Value = usuario.senha;
            sql.Parameters.Add("@nome", MySqlDbType.VarChar).Value = usuario.nome;
            sql.ExecuteNonQuery();
        }

        public void EditarUsuario(Usuario usuario)
        {
            MySqlCommand sql = new MySqlCommand("UPDATE tbUsuario SET login = @login, senha = @senha, nome = @nome WHERE idUsuario = @idUsuario", conn2);
            sql.Parameters.Add("@login", MySqlDbType.VarChar).Value = usuario.login;
            sql.Parameters.Add("@senha", MySqlDbType.VarChar).Value = usuario.senha;
            sql.Parameters.Add("@nome", MySqlDbType.VarChar).Value = usuario.nome;
            sql.Parameters.Add("@idUsuario", MySqlDbType.Int32).Value = usuario.idUsuario;
            sql.ExecuteNonQuery();
        }

        public List<Favoritos> ListarFavoritos(int usuario)
        {
            MySqlDataReader reader;
            sql = String.Format("SELECT * FROM tbFavoritos WHERE fkUsuario = {0}", usuario);
            MySqlCommand cmd = new MySqlCommand(sql, conn2);
            reader = cmd.ExecuteReader();
            List<Favoritos> lista = new List<Favoritos>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    lista.Add(new Favoritos(int.Parse(reader["fkUsuario"].ToString()), reader["fkLivro"].ToString()));
                }
            }
            return lista;
        }

        public void Fechar()
        {
            conn2.Close();
        }
    }
}
