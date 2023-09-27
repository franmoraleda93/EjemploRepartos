using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EjemploRepartos_database.Entities
{
    public partial class RepartoUbicacion
    {
        [Key]
        [Column("id_RepartoUbicacion")]
        public int IdRepartoUbicacion { get; set; }
        [Column("id_Reparto")]
        public int IdReparto { get; set; }
        [Column("ubicacion")]
        [StringLength(150)]
        [Unicode(false)]
        public string Ubicacion { get; set; } = null!;
        [Column("ultima")]
        public bool Ultima { get; set; }
        [Column("fecha_Creacion", TypeName = "datetime")]
        public DateTime FechaCreacion { get; set; }
        [Column("fecha_Modificacion", TypeName = "datetime")]
        public DateTime FechaModificacion { get; set; }

        [ForeignKey("IdReparto")]
        [InverseProperty("RepartoUbicacion")]
        public virtual Reparto IdRepartoNavigation { get; set; } = null!;
    }
}
