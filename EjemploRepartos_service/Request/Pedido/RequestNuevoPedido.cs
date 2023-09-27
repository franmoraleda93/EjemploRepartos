namespace EjemploRepartos_service.Request.Pedido
{
    public class RequestNuevoPedido
    {
        public string Destino { get; set; }
        public string? Observaciones { get; set; }
        public List<RequestPedidoComida> Comidas { get; set; }
    }

    public class RequestPedidoComida
    {
        public int IdComida { get; set; }
        public int Cantidad { get; set; }
    }
}
