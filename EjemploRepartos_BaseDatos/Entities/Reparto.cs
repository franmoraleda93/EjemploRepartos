using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EjemploRepartos_database.Entities
{
    [Index("IdPedido", Name = "UQ__Reparto__4AC0D554245B8FE2", IsUnique = true)]
    public partial class Reparto
    {
        public Reparto()
        {
            RepartoUbicacion = new HashSet<RepartoUbicacion>();
        }

        [Key]
        [Column("id_Reparto")]
        public int IdReparto { get; set; }
        [Column("id_Pedido")]
        public int IdPedido { get; set; }
        [Column("id_Repartidor")]
        public int IdRepartidor { get; set; }
        [Column("fecha_Creacion", TypeName = "datetime")]
        public DateTime FechaCreacion { get; set; }
        [Column("fecha_Modificacion", TypeName = "datetime")]
        public DateTime FechaModificacion { get; set; }

        [ForeignKey("IdPedido")]
        [InverseProperty("Reparto")]
        public virtual Pedido IdPedidoNavigation { get; set; } = null!;
        [ForeignKey("IdRepartidor")]
        [InverseProperty("Reparto")]
        public virtual Repartidor IdRepartidorNavigation { get; set; } = null!;
        [InverseProperty("IdRepartoNavigation")]
        public virtual ICollection<RepartoUbicacion> RepartoUbicacion { get; set; }
    }
}
