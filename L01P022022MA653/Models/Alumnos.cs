using Microsoft.AspNetCore.Mvc.Rendering;

namespace L01P022022MA653.Models
{
    public class Alumnos
    {
        public int id { get; set; }
        public string codigo { get; set; } = string.Empty;
        public string nombre { get; set; } = string.Empty;
        public string apellidos { get; set; } = string.Empty;
        public int dui { get; set; }
        public int estado { get; set; }

        public string EstadoTexto => estado == 1 ? "Activo" : "Inactivo";

        // Lista de estados disponibles
        public static List<SelectListItem> EstadosDisponibles => new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Activo" },
            new SelectListItem { Value = "0", Text = "Inactivo" }
        };
    }
}
