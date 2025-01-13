using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Domain.Entities
{
    public class Jugador
    {
        public int IdJugador { get; set; }

        public string NombreJugador { get; set; } = null!;

        public DateTime? FechaRegistro { get; set; }

    }
}
