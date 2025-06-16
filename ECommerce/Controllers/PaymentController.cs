using System.Security.Claims;
using ECommerce.Application.Abstractions.Services.Payment;
using ECommerce.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreatePayment(Guid orderId, decimal amount, Guid paymentMethodId)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return Unauthorized();

        var payment = await _paymentService.CreatePaymentAsync(orderId, amount, paymentMethodId, userId);
        return Ok(payment);
    }

    [HttpPost("{id:guid}/process")]
    public async Task<IActionResult> ProcessPayment(Guid id)
    {
        var result = await _paymentService.ProcessPaymentAsync(id);
        if (!result)
            return BadRequest("To‘lovni amalga oshirishda xatolik yuz berdi.");

        return Ok("To‘lov muvaffaqiyatli amalga oshirildi.");
    }

    [HttpGet("history")]
    public async Task<IActionResult> GetMyPayments()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return Unauthorized();

        var history = await _paymentService.GetPaymentHistoryByUserIdAsync(Guid.Parse(userId));
        return Ok(history);
    }

    [HttpPut("{id:guid}/status")]
    public async Task<IActionResult> UpdatePaymentStatus(Guid id, [FromQuery] PaymentStatus status)
    {
        var modifiedBy = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        await _paymentService.UpdatePaymentStatusAsync(id, status, modifiedBy);
        return Ok("Status yangilandi.");
    }
}
