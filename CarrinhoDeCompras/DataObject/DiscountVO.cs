using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrinhoDeCompras.DataObject
{
	// ReSharper disable once InconsistentNaming
	public class DiscountVO
	{
		public string code { get; set; }
		public DiscountType type { get; set; }
		public float amount { get; set; }

		public enum DiscountType
		{
			Percentage,
			Fixed
		}
	}
}



