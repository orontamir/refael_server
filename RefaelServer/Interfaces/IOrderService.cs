using RefaelServer.Models;

namespace RefaelServer.Interfaces
{
    public interface IOrderService
    {
        Task<bool> SubmitOrder(Order order);
    }
}
