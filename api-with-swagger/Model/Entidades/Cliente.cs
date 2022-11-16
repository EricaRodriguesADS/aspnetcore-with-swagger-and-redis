namespace api_with_swagger.Model.Entidades
{
	public class Cliente
	{
		public int ID { get; set; }
		public string Nome { get; set; }
		public int CPF { get; set; }

		public IEnumerable<Produto> Produtos { get; set; }
	}
}
