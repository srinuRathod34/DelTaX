using DelTaX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelTaX.Entities.Entity
{
    public class Producer
    {
        public int Id { get; set; }
        public string ProducerName { get; set; }
        //public Gender Gender { get; set; }
        public ICollection<Movie>? Movie { get; set; }

    }
}
