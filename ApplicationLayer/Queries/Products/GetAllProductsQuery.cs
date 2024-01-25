using DomainLayer;
using MediatR;
using System.Collections.Generic;

namespace ApplicationLayer.Queries.Products
{
	public record GetAllProductsQuery : IRequest<IList<Product>>;
}
