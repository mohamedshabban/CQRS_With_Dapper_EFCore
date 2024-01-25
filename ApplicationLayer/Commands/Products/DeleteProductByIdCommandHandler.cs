using Dapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationLayer.Commands.Products
{
	public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, string>
	{
		private readonly IConfiguration _configuration;
		public DeleteProductByIdCommandHandler(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public async Task<string> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
		{
			var sql = "DELETE FROM Products WHERE ProductId = @ProductId";
			using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				connection.Open();
				_ = await connection.ExecuteAsync(sql, new { ProductId = command.ProductId });
				return "Product Deletion Successful";
			}
		}
	}

}
