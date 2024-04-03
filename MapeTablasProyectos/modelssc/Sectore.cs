using System;
using System.Collections.Generic;

namespace MapeTablasProyectos.modelssc;

public partial class Sectore
{
    public string Codigo { get; set; } = null!;

    public string Descripcio { get; set; } = null!;

    public string? Ruta { get; set; }

    public string Municipio { get; set; } = null!;

    public string? Ciclo { get; set; }

    public string? TipoGas { get; set; }

    public int? Estacion { get; set; }

    public int? Mercado { get; set; }

    public int? Dane { get; set; }

    public virtual EstacionesSurga? EstacionNavigation { get; set; }
}
