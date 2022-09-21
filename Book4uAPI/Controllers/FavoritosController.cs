using Book4uAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book4uAPI.Controllers
{
    public class FavoritosController : Controller
    {
        DBConnection dbConnection;

        public List<Favoritos> Get(int usuario)
        {
            return dbConnection.ListarFavoritos(usuario);
        }
    }
}