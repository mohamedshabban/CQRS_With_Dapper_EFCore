using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ApplicationLayer.Commands.Products
{
	public partial record DeleteProductByIdCommand : IRequest<string>
	{
		[Required]
		public int ProductId { get; set; }
	}
}
