namespace Game.Domain.Entities
{
    public partial class Partida
    {
        public int IdPartida { get; set; }

        public int IdJugador1 { get; set; }

        public int IdJugador2 { get; set; }

        public int? Ganador { get; set; }

        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        public virtual Jugador IdJugador1Navigation { get; set; } = null!;

        public virtual Jugador IdJugador2Navigation { get; set; } = null!;

        public virtual ICollection<Ronda> Ronda { get; set; } = new List<Ronda>();
    }

}
