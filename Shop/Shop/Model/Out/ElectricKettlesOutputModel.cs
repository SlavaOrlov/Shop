namespace Shop.Api.Model.Out
{
    public class ElectricKettlesOutputModel
    {
		public int Id { get; set; }
		public string Category { get; set; }
		public string Name { get; set; }
		public int Price { get; set; }
		public string Size { get; set; }
		public string Color { get; set; }
		public int Weight { get; set; }
		public string Manufacturer { get; set; }
		public int YearOfManufacture { get; set; }
		public int ConsumedPower { get; set; }
		public int? Volume { get; set; }
		public string? HeatingElement { get; set; }
		public string? Material { get; set; }
	}
}
