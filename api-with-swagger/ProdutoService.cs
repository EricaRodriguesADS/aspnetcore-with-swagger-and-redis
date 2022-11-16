using api_with_swagger.Model;
using api_with_swagger.Model.Entidades;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace api_with_swagger
{
	public class ProdutoService : IProdutoService
	{
		private readonly IConnectionMultiplexer _redisCache;
		private readonly IDatabaseAsync _redisDBAsync;
		public ProdutoService(IConnectionMultiplexer redisCache)
		{
			_redisCache = redisCache;
			_redisDBAsync = redisCache.GetDatabase();
		}

		public async Task<IEnumerable<Produto>> ObterProdutos(int id)
		{
			var cacheKey = "Produto";
			var produto = new List<Produto>();

			var json = await _redisDBAsync.StringGetAsync(cacheKey);
			if (!json.IsNull)
			{
				produto = JsonConvert.DeserializeObject<List<Produto>>(json);
			}
			else
			{
				produto = new List<Produto>() { new Produto(1, "Prefixado"), new Produto(2, "Selic"), new Produto(3, "IPCA") };
				await _redisDBAsync.StringSetAsync(cacheKey, JsonConvert.SerializeObject(produto));
			}

			return produto.Where(p=> p.ID == id);
		}
	}
}
