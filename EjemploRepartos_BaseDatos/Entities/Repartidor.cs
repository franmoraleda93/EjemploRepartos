using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EjemploRepartos_database.Entities
{
    [Index("OidRepartidor", Name = "UQ__Repartid__B3B5F7C3134C16C8", IsUnique = true)]
    public partial class Repartidor
    {
        public Repartidor()
        {
            Reparto = new HashSet<Reparto>();
        }

        [Key]
        [Column("id_Repartidor")]
        public int IdRepartidor { get; set; }
        [Column("oid_Repartidor")]
        [StringLength(50)]
        [Unicode(false)]
        public string OidRepartidor { get; set; } = null!;
        [Column("fecha_Creacion", TypeName = "datetime")]
        public DateTime FechaCreacion { get; set; }
        [Column("fecha_Modificacion", TypeName = "datetime")]
        public DateTime FechaModificacion { get; set; }

        [InverseProperty("IdRepartidorNavigation")]
        public virtual ICollection<Reparto> Reparto { get; set; }
    }
}
