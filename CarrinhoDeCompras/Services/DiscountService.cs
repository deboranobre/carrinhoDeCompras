using CarrinhoDeCompras.DataObject;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarrinhoDeCompras.Services
{
	public class DiscountService : IDiscountService
	{
		private string FilePath = @"/DataSource/discounts.json";
		public DataObject.DiscountVO GetByCode(string code)
		{
			DiscountVO discount = new DiscountVO();
			var location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			FilePath = location + FilePath;
			
			// read JSON directly from a file
			using (StreamReader file = File.OpenText(FilePath))
			{
				var data = file.ReadToEnd();
				var listOfDiscoounts = JsonConvert.DeserializeObject<List<DiscountVO>>(data);

				discount = listOfDiscoounts.FirstOrDefault(x => x.code.Equals(code));
			}

			return discount;

		}
	}
}
