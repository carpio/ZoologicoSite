//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZoologicoSite
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_Pais
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_Pais()
        {
            this.T_Animal = new HashSet<T_Animal>();
            this.T_Ciudades = new HashSet<T_Ciudades>();
        }
    
        public int ID { get; set; }
        public string Nombre_Pais { get; set; }
        public int ID_Continente { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Animal> T_Animal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Ciudades> T_Ciudades { get; set; }
        public virtual T_Continente T_Continente { get; set; }
    }
}
