using api_with_swagger.Model.Entidades;

namespace api_with_swagger.Model
{
	public interface IProdutoService
	{
		Task<IEnumerable<Produto>> ObterProdutos(int id);
	}
}
