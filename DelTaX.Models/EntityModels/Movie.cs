using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelTaX.Models.EntityModels
{
    public class Movie
    {
        public int Id { get; set; }
        public string MovieName { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        public int ProducerId { get; set; }

    }
}
