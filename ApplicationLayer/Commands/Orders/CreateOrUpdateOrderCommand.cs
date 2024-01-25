using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ApplicationLayer.Commands.Orders
{
	public record CreateOrUpdateOrderCommand : IRequest<bool>
	{
		public int OrderId { get; set; }
		[Required]
		public string OrderDetails { get; set; }
	}
}
