
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------


namespace PX.Models
{

using System;
    using System.Collections.Generic;
    
public partial class Conductor
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Conductor()
    {

        this.Vehiculo = new HashSet<Vehiculo>();

    }


    public int Id { get; set; }

    public string Tipo_Licencia { get; set; }

    public int Dpi { get; set; }

    public string Nombre { get; set; }

    public int Telefono { get; set; }

    public int Edad { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Vehiculo> Vehiculo { get; set; }

}

}
