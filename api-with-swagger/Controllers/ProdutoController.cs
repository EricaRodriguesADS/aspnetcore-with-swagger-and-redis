using api_with_swagger.Model;
using Microsoft.AspNetCore.Mvc;

namespace api_with_swagger.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProdutoController : ControllerBase
	{
		private readonly IProdutoService _produtoService;

		public ProdutoController(IProdutoService ProdutoService)
		{
			_produtoService = ProdutoService;
		}

		[HttpGet(Name = "Buscar")]
		public async Task<IActionResult> ObterProdutos(int id)
		{
			var produtos = await _produtoService.ObterProdutos(id);

			return Ok(produtos);
		}	
	}
}