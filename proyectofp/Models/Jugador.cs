namespace proyectofp.Models
{
    public class Jugador : IComparable
    {
        public string Nombre { get; set; }
        public int Goles { get; set; }
        public int Asistencias { get; set; }
        public int TarjetasAmarillas { get; set; }
        public int TarjetasRojas { get; set; }
        public string Posicion { get; set; }
        public string EquipoActual { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Jugador other = obj as Jugador;
            if (other != null)
                return this.Nombre.CompareTo(other.Nombre);
            else
                throw new ArgumentException("Object is not a Jugador");
        }
    }
}
