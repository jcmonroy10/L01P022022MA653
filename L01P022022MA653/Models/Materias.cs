using Microsoft.AspNetCore.Mvc.Rendering;

namespace L01P022022MA653.Models
{
    public class Materias
    {
        public int id { get; set; }
        public string materia { get; set; } = string.Empty;
        public int unidades_valorativas { get; set; }
        public char estado { get; set; }

        // Convertimos el estado en texto
        public string EstadoTexto => estado switch
        {
            'A' => "Activa",
            'I' => "Inactiva",
            'P' => "Pendiente",
            _ => "Desconocido"
        };

        // Lista de estados disponibles
        public static List<SelectListItem> EstadosDisponibles => new List<SelectListItem>
        {
            new SelectListItem { Value = "A", Text = "Activa" },
            new SelectListItem { Value = "I", Text = "Inactiva" },
            new SelectListItem { Value = "P", Text = "Pendiente" }
        };
    }
}
