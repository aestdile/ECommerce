using AutoMapper;
using ECommerce.Application.DTOs.Order;
using ECommerce.Domain.Entities.Order;

namespace ECommerce.Application.Features.Orders.Mappings;

public class OrderMapping : Profile
{
    public OrderMapping()
    {
        CreateMap<Order, OrderDto>().ReverseMap();
    }
}
