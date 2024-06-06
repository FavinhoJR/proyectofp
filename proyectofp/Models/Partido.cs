namespace proyectofp.Models
{
    public class Partido
    {
        public DateTime Fecha { get; set; }
        public string Sede { get; set; }
        public Equipo EquipoLocal { get; set; }
        public Equipo EquipoVisitante { get; set; }
        public int MarcadorLocal { get; set; }
        public int MarcadorVisitante { get; set; }
        public string Arbitro { get; set; }
    }
}