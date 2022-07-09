using DelTaX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelTaX.Entities.Entity
{
    public class Actor
    {
        public int Id { get; set; }
        public string ActorName { get; set; } = null!;
        //public int? Age { get; set; }
        //public Gender Gender { get; set; }
        //public RoleType KeyRole { get; set; }

        public ICollection<ActorMovieMapping>? actorMovieMappings { get; set; }
    }
}
