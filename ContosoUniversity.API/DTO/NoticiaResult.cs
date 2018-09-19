using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.API.DTO
{
    public class NoticiaResult
    {
        public int Count => Noticias.Count();
        public IList<Noticia> Noticias { get; set; }

        public NoticiaResult()
        {
            Noticias = new List<Noticia>();
        }
    }
}