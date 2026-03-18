using BuildingBlocks.CQRS;
using Catalog.API.Models;
using Marten;
using MediatR;

namespace Catalog.API.Products.CreateProduct
{
 public record CreateProductCommand(string Name,List<string> Category,string Description,string ImageFile,decimal Price)
        :ICommand<CreateProductResult>;
    public record CreateProductResult(Guid id);
    public class CreateProductHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {

            Product p = new Product();
            p.Name=command.Name;
            p.Category=command.Category;
            p.Description=command.Description;
            p.ImageFile=command.ImageFile;
            p.Price=command.Price;
            session.Store(p);
            await session.SaveChangesAsync(cancellationToken);

            return new CreateProductResult(p.Id);
                }
    }
}
