using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentService.Data;
using PaymentService.Models;

namespace PaymentService.Controllers
{
    [ApiController]
    [Route("api/pagamentos")]
    public class PaymentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly HttpClient _httpClient;

        public PaymentsController(AppDbContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet]
        public async Task<IActionResult> GetPayments()
        {
            var payments = await _context.Payments.ToListAsync();
            return Ok(payments);
        }

        [HttpPost]
        public async Task<IActionResult> ProcessPayment([FromBody] Payment payment)
        {
            var order = await _httpClient.GetFromJsonAsync<Order>($"https://localhost:7104/api/pedidos/{payment.OrderId}");
            if (order == null)
            {
                return NotFound("Pedido não encontrado.");
            }

            payment.Status = "Paid";
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return Ok(payment);
        }
    }

    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public bool IsPaid { get; set; }
    }
}