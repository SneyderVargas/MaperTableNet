using System;
using System.Collections.Generic;

namespace MapeTablasProyectos.modelssc;

public partial class EstacionesSurga
{
    /// <summary>
    /// Especifica el Codigo de la Estacion
    /// </summary>
    public int IdEstacion { get; set; }

    public string Nombre { get; set; } = null!;

    public string Municipio { get; set; } = null!;

    public string Tipogas { get; set; } = null!;

    public int TipogasSui { get; set; }

    public string Servicio { get; set; } = null!;

    /// <summary>
    /// Item par especificar el mercado dependienso de los valores quer envien para el informe
    /// </summary>
    public string? MercadoCreg { get; set; }

    public string? OrdenInforme { get; set; }

    public int? Cabecera { get; set; }

    public long? PucInvenTrib { get; set; }

    public long? PucCostoTrib { get; set; }

    public long? PucInvenNiif { get; set; }

    public long? PucCostoNiif { get; set; }

    public string? Solicitante { get; set; }

    public string? Centro { get; set; }

    /// <summary>
    /// CODIGO DE MATERIAL SAP
    /// </summary>
    public string? Material { get; set; }

    /// <summary>
    /// Linea de producto en SAP
    /// </summary>
    public string? Sector { get; set; }

    public virtual ICollection<Sectore> Sectores { get; set; } = new List<Sectore>();
}
