using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book4uAPI.Models
{
    public class Favoritos
    {
        public int idUsuario { get; set; }
        public string idLivro { get; set; }

        public Favoritos() { }

        public Favoritos(int IdUsuario, string IdLivro)
        {
            idUsuario = IdUsuario;
            idLivro = IdLivro;
        }
    }
}