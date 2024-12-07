using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
	public class Asset
	{
		// Asset model
		public Guid ID { get; set; }
		public string AssetName {  get; set; }
		public double InitalCost {  get; set; }
		public double SalvageValue {  get; set; }
		public DateTime AddedToInventory {  get; set; }
		public DateTime RemovedFromInventory {  get; set; }
		// NTS: Use dates to calc lifespan of item
	}
}
