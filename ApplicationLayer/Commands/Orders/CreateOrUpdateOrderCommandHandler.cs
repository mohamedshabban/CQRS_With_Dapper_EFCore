using ApplicationLayer.Data;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationLayer.Commands.Orders
{
	public class CreateOrUpdateOrderCommandHandler : IRequestHandler<CreateOrUpdateOrderCommand, bool>
	{
		public bool IsActive { get; set; }
		public DateTime OrderedDate { get; set; }
		private readonly IConfiguration configuration;
		private readonly AppDBContext _dBContext;

		public CreateOrUpdateOrderCommandHandler(IConfiguration configuration, AppDBContext dBContext)
		{
			this.configuration = configuration;
			_dBContext = dBContext;
		}
		public async Task<bool> Handle(CreateOrUpdateOrderCommand command, CancellationToken cancellationToken)
		{
			if (command.OrderId > 0)
			{
				var order = _dBContext.Orders
					.FirstOrDefault(order => order.OrderId == command.OrderId);
				if (order == null)
				{
					order.OrderDetails = command.OrderDetails;
				}
				_dBContext.Orders.Update(order);
				await _dBContext.SaveChangesAsync();
				return true;
			}
			else
			{
				_dBContext.Orders.Add(new DomainLayer.Order()
				{
					OrderId = command.OrderId,
					OrderDetails = command.OrderDetails,
					IsActive = true,
					OrderedDate = DateTime.Now
				});
				await _dBContext.SaveChangesAsync();
				return true;
			}

		}
	}
}
