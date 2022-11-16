namespace api_with_swagger.Model.Entidades
{
	public class Produto
	{
		public int ID { get; }
		public String Nome { get; }


		public Produto(int id, string nome)
		{
	  	 ID = id;
			 Nome = nome;
		}
	}
}
