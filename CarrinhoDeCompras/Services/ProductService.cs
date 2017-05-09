using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarrinhoDeCompras.DataObject;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace CarrinhoDeCompras.Services
{
	public class ProductService : IProductService
	{
		private string FilePath = @"/DataSource/products.json";
		public List<ProductVO> GetAll()
		{
			var location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			FilePath = location+ FilePath;
			// read JSON directly from a file
			using (StreamReader file = File.OpenText(FilePath))
			{
				var data = file.ReadToEnd();
				var listOfProducts = JsonConvert.DeserializeObject<List<ProductVO>>(data);
				return listOfProducts;
			}
		}

		public ProductVO GetByID(int id)
		{
			throw new NotImplementedException();
		}
	}
}
