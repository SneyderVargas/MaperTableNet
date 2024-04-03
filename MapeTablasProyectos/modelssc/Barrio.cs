using System;
using System.Collections.Generic;

namespace MapeTablasProyectos.modelssc;

public partial class Barrio
{
    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Login { get; set; } = null!;

    public long? Zona { get; set; }

    public string Ruta { get; set; } = null!;

    public string Municipio { get; set; } = null!;

    public string Sector { get; set; } = null!;

    public int? Activo { get; set; }

    /// <summary>
    /// Ubicacion SUI para efectos de Informe SUI
    /// </summary>
    public int? UbicacionSui { get; set; }

    public virtual Municipi MunicipioNavigation { get; set; } = null!;
}
