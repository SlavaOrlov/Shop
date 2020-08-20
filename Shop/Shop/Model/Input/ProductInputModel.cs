using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Api.Model.Input
{
    public class ProductInputModel
    {
		public string Name { get; set; }
		public int Price { get; set; }
		public string Size { get; set; }
		public string Color { get; set; }
		public int Weight { get; set; }
		public string Manufacturer { get; set; }
		public int YearOfManufacture { get; set; }
		public int ConsumedPower { get; set; }
		public string? Grill { get; set; }
		public string? TypeOfGrill { get; set; }
		public string? TypeOfControl { get; set; }
		public string? AutomaticCooking { get; set; }
		public string? Manage { get; set; }
		public string? DustСollector { get; set; }
		public string? Filter { get; set; }
		public string? PowerSupply { get; set; }
		public int? Volume { get; set; }
		public string? HeatingElement { get; set; }
		public string? Material { get; set; }
	}
}
