using ECommerce.Application.Abstractions.Persistence;
using ECommerce.Domain.Entities.Product;

namespace ECommerce.Application.Features.Products.Commands
{
    public class CreateProductCommandHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateProductCommand command)
        {
            var product = new Product
            {
                Name = command.Name,
                Description = command.Description,
                Price = command.Price,
                CategoryId = command.CategoryId,
                BrandId = command.BrandId
            };

            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
