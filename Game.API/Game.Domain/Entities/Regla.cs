namespace Game.Domain.Entities
{
    public partial class Regla
    {
        public int IdRegla { get; set; }

        public string Movimiento { get; set; } = null!;

        public string VenceA { get; set; } = null!;

        public virtual ICollection<Ronda> Ronda { get; set; } = new List<Ronda>();
    }
}
