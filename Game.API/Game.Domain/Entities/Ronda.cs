using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Domain.Entities
{
    public partial class Ronda
    {
        public int IdRonda { get; set; }

        public int IdPartida { get; set; }

        public int RondaNumero { get; set; }

        public string MovimientoJugador1 { get; set; } = null!;

        public string MovimientoJugador2 { get; set; } = null!;

        public string Resultado { get; set; } = null!;

        public int? IdRegla { get; set; }

        public virtual Partida IdPartidaNavigation { get; set; } = null!;

        public virtual Regla? IdReglaNavigation { get; set; }
    }
}
