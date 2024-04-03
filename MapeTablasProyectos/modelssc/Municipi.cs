using System;
using System.Collections.Generic;

namespace MapeTablasProyectos.modelssc;

public partial class Municipi
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Dane { get; set; } = null!;

    public double Poder { get; set; }

    public double Prioridad { get; set; }

    public string Tipogas { get; set; } = null!;

    public string? PucCosteoGas { get; set; }

    public string? PucCosteoInvenGas { get; set; }

    public int? Departamento { get; set; }

    /// <summary>
    /// Metros Sobre el Nivel del MAR Provisional para el Calculo del Factor de Corrección
    /// </summary>
    public double? Msnm { get; set; }

    public string? MercadoCreeg { get; set; }

    /// <summary>
    /// Fk agencia desde base de datos ESP1
    /// </summary>
    public int? FkAgencia { get; set; }

    public string Dian18 { get; set; } = null!;

    public virtual ICollection<Barrio> Barrios { get; set; } = new List<Barrio>();
}
