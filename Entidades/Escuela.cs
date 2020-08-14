namespace Project_Carthage.Entidades
{
    class Escuela
    {
        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value.ToUpper(); }
        }

        public int YearOfCreation { get; set; }

        public string Pais { get; set; }

        public string Ciudad { get; set; }

        public TiposEscuela TipoEscuela { get; set; }

        public Escuela(string nombre, int year) => (Nombre, YearOfCreation) = (nombre, year);

        public Escuela(string nombre, int year, TiposEscuela tipo, string pais="", string ciudad ="")
        {
            (Nombre, YearOfCreation) = (nombre, year);
            Pais = pais;
            Ciudad = ciudad;
        }

        public override string ToString()
        {
            string newLine = System.Environment.NewLine;
            return $"Nombre: \"{Nombre}\", Tipo: {TipoEscuela} {newLine} Pais: {Pais}, Ciudad: {Ciudad}";
        }

    }
}