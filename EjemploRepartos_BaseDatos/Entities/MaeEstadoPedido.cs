using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EjemploRepartos_database.Entities
{
    public partial class MaeEstadoPedido
    {
        public MaeEstadoPedido()
        {
            Pedido = new HashSet<Pedido>();
        }

        [Key]
        [Column("id_MaeEstadoPedido")]
        public int IdMaeEstadoPedido { get; set; }
        [Column("valor")]
        [StringLength(50)]
        [Unicode(false)]
        public string Valor { get; set; } = null!;
        [Column("descripcion")]
        [StringLength(150)]
        [Unicode(false)]
        public string Descripcion { get; set; } = null!;
        [Column("habilitado")]
        public bool Habilitado { get; set; }
        [Column("fecha_Creacion", TypeName = "datetime")]
        public DateTime FechaCreacion { get; set; }
        [Column("fecha_Modificacion", TypeName = "datetime")]
        public DateTime FechaModificacion { get; set; }

        [InverseProperty("IdEstadoPedidoNavigation")]
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
