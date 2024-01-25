using DomainLayer;
using MediatR;
using System.Collections.Generic;

namespace ApplicationLayer.Queries.Orders
{
	public record GetAllOrdersQuery : IRequest<IList<Order>>;
}
