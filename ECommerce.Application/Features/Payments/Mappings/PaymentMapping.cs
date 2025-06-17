using AutoMapper;
using ECommerce.Application.Features.Payments.DTOs;
using ECommerce.Domain.Entities.Payment;

namespace ECommerce.Application.Features.Payments.Mappings;

public class PaymentMapping : Profile
{
    public PaymentMapping()
    {
        CreateMap<Payment, PaymentDto>().ReverseMap();
    }
}
