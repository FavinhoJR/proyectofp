namespace proyectofp.Models
{
    public class Equipo : IComparable
    {
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public string Entrenador { get; set; }
        public int Fundacion { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Equipo other = obj as Equipo;
            if (other != null)
                return this.Nombre.CompareTo(other.Nombre);
            else
                throw new ArgumentException("Object is not an Equipo");
        }
    }
}
