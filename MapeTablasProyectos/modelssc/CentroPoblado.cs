using System;
using System.Collections.Generic;

namespace MapeTablasProyectos.modelssc;

public partial class CentroPoblado
{
    public int Id { get; set; }

    public long Coddane { get; set; }

    public string Nombrecentro { get; set; } = null!;

    public string? Tipo { get; set; }

    public string FkMunicipio { get; set; } = null!;

    public sbyte? Activo { get; set; }

    public DateTime FechaSistema { get; set; }

    public string Login { get; set; } = null!;
}
