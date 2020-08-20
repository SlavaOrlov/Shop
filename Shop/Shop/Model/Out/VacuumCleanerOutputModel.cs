namespace Shop.Api.Model.Out
{
    public class VacuumCleanerOutputModel
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
		public string? Manage { get; set; }
		public string? DustСollector { get; set; }
		public string? Filter { get; set; }
		public string? PowerSupply { get; set; }
	}
}
