using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book4uAPI.Models
{
    public class Livro
    {
        public string idLivro { get; set; }
        public string titulo { get; set; }
        public string autor { get; set; }
        public string link { get; set; }

        public Livro() { }

        public Livro(string IdLivro, string Titulo, string Autor, string Link)
        {
            this.idLivro = IdLivro;
            this.titulo = Titulo;   
            this.autor = Autor;
            this.link = Link;
        }
    }
}