using System;
using System.Collections.Generic;
using System.Text;

namespace HelloBlazor.Common.Model
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Year { get; set; }
    }
}
