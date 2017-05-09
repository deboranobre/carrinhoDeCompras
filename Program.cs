using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarrinhoDeCompras.DataObject;
using CarrinhoDeCompras.Services;
using Newtonsoft.Json;

namespace CarrinhoDeCompras
{
	class Program
	{
		static void Main(string[] args)
		{
			ProductService productService = new ProductService();
			DiscountService discountService = new DiscountService();

			List<ProductVO> products = productService.GetAll();
			List<ProductVO> carProducts = new List<ProductVO>();

			Console.WriteLine("-- Bem-vindo ao Carrinho de Compras!");

			int productID;
			string addMore = "s";

			while (addMore.Equals("s")) 
			{
				Console.WriteLine("Digite  o ID do produto que deseja adicionar:");
				if (int.TryParse(Console.ReadLine(), out productID))
				{
					ProductVO product = products.FirstOrDefault(p => p.id.Equals(productID));

					if (product != null)
					{
						carProducts.Add(product);
						Console.WriteLine("Produto " + product.name + " foi adicionado com sucesso!");
					}
					else
					{
						Console.WriteLine("ID invalido. Por favor tente novamente.");
					}
				}
				else
				{
					Console.WriteLine("ID invalido. Por favor tente novamente.");
				}

				Console.WriteLine("Deseja adicionar outro produto [s/n]?");
				addMore = Console.ReadLine().ToLower();
			}

			string hasCoupon = "s";
			DiscountVO discount = new DiscountVO();

			while (hasCoupon.Equals("s"))
			{
				Console.WriteLine("Deseja adicionar um cupom de desconto [s/n]?");
				hasCoupon = Console.ReadLine().ToLower();

				if (hasCoupon.Equals("s"))
				{
					Console.WriteLine("Digite o cupom de desconto:");
					string code = Console.ReadLine();

					discount = discountService.GetByCode(code);

					if (discount != null)
					{
						Console.WriteLine("O desconto foi aplicado.");
					}
					else
					{
						Console.WriteLine("Desconto invalido.");
					}
				}
			}

			float total = 0;
			foreach (ProductVO product in carProducts)
			{
				Console.WriteLine(product.id + "   " + product.name + "   " + product.price);
				total += product.price;
			}

			if (discount != null)
			{
				float totalDiscount; 
				if (discount.type == DiscountVO.DiscountType.Fixed)
				{
					totalDiscount = discount.amount;
					total -= totalDiscount;
				}
				else
				{
					totalDiscount = (total * discount.amount) / 100;
					total -= totalDiscount;
				}

				Console.WriteLine("Descontos: -" + totalDiscount);
			}

			Console.WriteLine("Total: " + total);
			Console.ReadLine();
		}
	}
}
