using System;

namespace Models
{
    public class Gato
    {
        public int Id_Gato { get; set; }
        public int Id_Protectora { get; set; }
        public string Nombre_Gato { get; set; } = "";
        public string Raza { get; set; } = "";
        public int Edad { get; set; }
        public bool Esterilizado { get; set; }
        public string Sexo { get; set; } = "";
        public string Descripcion_Gato { get; set; } = "";
        public string Descripcion_Gato_En { get; set; } = ""; // Nueva descripción en inglés
        public string Imagen_Gato { get; set; } = "";
        public bool Visible { get; set; } = true;

        public Gato() { }

        public Gato(int id_Protectora, string nombre_Gato, string raza, int edad, bool esterilizado, string sexo, string descripcion_Gato, string descripcion_Gato_En, string imagen_Gato, bool visible)
        {
            Id_Protectora = id_Protectora;
            Nombre_Gato = nombre_Gato;
            Raza = raza;
            Edad = edad;
            Esterilizado = esterilizado;
            Sexo = sexo;
            Descripcion_Gato = descripcion_Gato;
            Descripcion_Gato_En = descripcion_Gato_En; // Asignación del campo en inglés
            Imagen_Gato = imagen_Gato;
            Visible = visible;
        }

        public void MostrarDetalles()
        {
            string estadoEsterilizado = Esterilizado ? "Sí" : "No";
            Console.WriteLine($"Gato: {Nombre_Gato}, Raza: {Raza}, Edad: {Edad} años, Esterilizado: {estadoEsterilizado}, Sexo: {Sexo}");
            Console.WriteLine($"Descripción: {Descripcion_Gato}");
            Console.WriteLine($"Description (in English): {Descripcion_Gato_En}"); // Mostrar descripción en inglés
        }
    }
}
