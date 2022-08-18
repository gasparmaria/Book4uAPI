using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book4uAPI.Models
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public string nome { get; set; }
    }
}