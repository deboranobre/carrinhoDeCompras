using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarrinhoDeCompras.DataObject;

namespace CarrinhoDeCompras.Services
{
	interface IDiscountService
	{
		DiscountVO GetByCode(string code);
	}
}
