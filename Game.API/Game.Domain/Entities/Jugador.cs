
namespace Game.Domain.Entities
{
    public partial class Jugador
    {
        public int IdJugador { get; set; }

        public string NombreJugador { get; set; } = null!;

        public DateTime? FechaRegistro { get; set; }

        public virtual ICollection<Partida> PartidumIdJugador1Navigations { get; set; } = new List<Partida>();

        public virtual ICollection<Partida> PartidumIdJugador2Navigations { get; set; } = new List<Partida>();
    }
}
