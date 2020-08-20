namespace Shop.Api.Model.Out
{
    public class MicrowaveOutputModel
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
		public string? Grill { get; set; }
		public string? TypeOfGrill { get; set; }
		public string? TypeOfControl { get; set; }
		public string? AutomaticCooking { get; set; }
	}
}
