using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarrinhoDeCompras.DataObject;

namespace CarrinhoDeCompras.Services
{
	interface IProductService
	{
		//crud
		List<ProductVO> GetAll();

		ProductVO GetByID(int id);
	}
}
