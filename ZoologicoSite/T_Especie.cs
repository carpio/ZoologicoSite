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
    
    public partial class T_Especie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_Especie()
        {
            this.T_Animal = new HashSet<T_Animal>();
        }
    
        public int ID { get; set; }
        public string Nombre_Vulgar { get; set; }
        public string Nombre_Científico { get; set; }
        public bool Peligro_De_Extincion { get; set; }
        public int ID_Familia { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Animal> T_Animal { get; set; }
        public virtual T_Familia T_Familia { get; set; }
    }
}