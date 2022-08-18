using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book4uAPI.Models
{
    public class Livro
    {
        public int idLivro { get; set; }
        public string detalhes { get; set; }
        public int numPag { get; set; }
        public string titulo { get; set; }
        public string autor { get; set; }

        public Livro() { }

        public Livro(int IdLivro, string Detalhes, int NumPag, string Titulo, string Autor)
        {
            this.idLivro = IdLivro;
            this.detalhes = Detalhes;
            this.numPag = NumPag;
            this.titulo = Titulo;   
            this.autor = Autor;
        }
    }
}