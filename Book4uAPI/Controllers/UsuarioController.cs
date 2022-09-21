using Book4uAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace Book4uAPI.Controllers
{
    public class UsuarioController : ApiController
    {
        DBConnection dbConnection;

        public bool Get(string login, string senha)
        {
            return dbConnection.VerificarLogin(login, senha);
        }

        public void Post(Usuario usuario)
        {
            dbConnection.CadastrarUsuario(usuario);
        }

        public void Put(Usuario usuario)
        {
            dbConnection.EditarUsuario(usuario);
        }
    }
}
