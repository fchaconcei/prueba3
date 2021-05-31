//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Partido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Partido()
        {
            this.TranscursoPartido = new HashSet<TranscursoPartido>();
        }
    
        public int idPartido { get; set; }
        public int idJugador1 { get; set; }
        public int idJugador2 { get; set; }
        public Nullable<short> PuntosJugador1 { get; set; }
        public Nullable<short> PuntosJugador2 { get; set; }
        public Nullable<System.DateTime> FechaHoraInicio { get; set; }
        public Nullable<System.DateTime> FechaHoraFin { get; set; }
        public long idTorneo { get; set; }
    
        public virtual Jugador Jugador { get; set; }
        public virtual Jugador Jugador1 { get; set; }
        public virtual Torneo Torneo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TranscursoPartido> TranscursoPartido { get; set; }
    }
}
