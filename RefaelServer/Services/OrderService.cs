using RefaelServer.Interfaces;
using RefaelServer.Models;

namespace RefaelServer.Services
{
    public class OrderService : IOrderService
    {
        public async Task<bool> SubmitOrder(Order order)
        {
            try
            {
                //Oron TODO: insert to Database
                LogService.LogInformation("Order Received:");
                LogService.LogInformation($"Subtotal: {order.Subtotal}");
                LogService.LogInformation($"Tax: {order.Tax}");
                LogService.LogInformation($"Total: {order.Total}");
            }
            catch (Exception ex) 
            {
                LogService.LogError($"Exception when save order into data base. Error message: {ex.Message}");
                return false;
            }

           
            return true;
        }
    }
}
