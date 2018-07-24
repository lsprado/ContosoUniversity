using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.WebApplication.Models.APIViewModels
{
    public class CoursesResult
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public int Credits { get; set; }

    }
}