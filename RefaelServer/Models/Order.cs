namespace RefaelServer.Models
{
    public class Order
    {
        public int OrderId { get; set; } 
        public List<OrderItem> Items { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
    }
}
