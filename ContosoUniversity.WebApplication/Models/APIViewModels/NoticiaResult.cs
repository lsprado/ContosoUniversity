using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.WebApplication.Models.APIViewModels
{
    public class NoticiaResult
    {
        public int Count { get; set; }
        public IList<Noticia> Noticias { get; set; }
        
    }
}