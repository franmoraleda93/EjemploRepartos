using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EjemploRepartos_database.Entities
{
    [Index("OidCliente", Name = "UQ__Cliente__F4A8EA77C93AEB25", IsUnique = true)]
    public partial class Cliente
    {
        public Cliente()
        {
            Pedido = new HashSet<Pedido>();
        }

        [Key]
        [Column("id_Cliente")]
        public int IdCliente { get; set; }
        [Column("oid_Cliente")]
        [StringLength(50)]
        [Unicode(false)]
        public string OidCliente { get; set; } = null!;
        [Column("fecha_Creacion", TypeName = "datetime")]
        public DateTime FechaCreacion { get; set; }
        [Column("fecha_Modificacion", TypeName = "datetime")]
        public DateTime FechaModificacion { get; set; }

        [InverseProperty("IdClienteNavigation")]
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
