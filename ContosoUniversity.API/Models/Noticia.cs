using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.API.Models
{
    /// <summary>
    /// Noticia
    /// </summary>
    public class Noticia
    {
        [Key]
        public int ID { get; set; }

        public string Title { get; set; }

        [Column(TypeName = "text")]
        public string Texto { get; set; }
    }
}