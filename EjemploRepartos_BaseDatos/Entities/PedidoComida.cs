using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EjemploRepartos_database.Entities
{
    public partial class PedidoComida
    {
        [Key]
        [Column("id_Pedido")]
        public int IdPedido { get; set; }
        [Key]
        [Column("id_Comida")]
        public int IdComida { get; set; }
        [Column("cantidad")]
        public int Cantidad { get; set; }
        [Column("fecha_Creacion", TypeName = "datetime")]
        public DateTime FechaCreacion { get; set; }
        [Column("fecha_Modificacion", TypeName = "datetime")]
        public DateTime FechaModificacion { get; set; }

        [ForeignKey("IdComida")]
        [InverseProperty("PedidoComida")]
        public virtual MaeComida IdComidaNavigation { get; set; } = null!;
        [ForeignKey("IdPedido")]
        [InverseProperty("PedidoComida")]
        public virtual Pedido IdPedidoNavigation { get; set; } = null!;
    }
}
