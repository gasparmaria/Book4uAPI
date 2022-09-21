using Book4uAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Book4uAPI.Controllers
{
    public class LivroController : ApiController
    {
        DBConnection dbConnection;

        public List<Livro> Get(int id)
        {
            return dbConnection.ListarLivros();
        }

        public string GetSpecified(string titulo)
        {
            return dbConnection.BuscarLivro(titulo);
        }
    }
}
