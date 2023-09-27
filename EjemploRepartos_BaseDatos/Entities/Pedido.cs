using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EjemploRepartos_database.Entities
{
    public partial class Pedido
    {
        public Pedido()
        {
            PedidoComida = new HashSet<PedidoComida>();
        }

        [Key]
        [Column("id_Pedido")]
        public int IdPedido { get; set; }
        [Column("id_EstadoPedido")]
        public int IdEstadoPedido { get; set; }
        [Column("id_Cliente")]
        public int IdCliente { get; set; }
        [Column("destino")]
        [StringLength(150)]
        [Unicode(false)]
        public string Destino { get; set; } = null!;
        [Column("observaciones")]
        [StringLength(150)]
        [Unicode(false)]
        public string? Observaciones { get; set; }
        [Column("fecha_Creacion", TypeName = "datetime")]
        public DateTime FechaCreacion { get; set; }
        [Column("fecha_Modificacion", TypeName = "datetime")]
        public DateTime FechaModificacion { get; set; }

        [ForeignKey("IdCliente")]
        [InverseProperty("Pedido")]
        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        [ForeignKey("IdEstadoPedido")]
        [InverseProperty("Pedido")]
        public virtual MaeEstadoPedido IdEstadoPedidoNavigation { get; set; } = null!;
        [InverseProperty("IdPedidoNavigation")]
        public virtual Reparto? Reparto { get; set; }
        [InverseProperty("IdPedidoNavigation")]
        public virtual ICollection<PedidoComida> PedidoComida { get; set; }
    }
}
