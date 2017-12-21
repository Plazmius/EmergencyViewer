using System;
using System.ComponentModel;

namespace EmergencyViewer.Data.Entities
{
	public class EmergencyEvent
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime OccuranceDate { get; set; }
		public EmergencyEventType EventType { get; set; }
		public int InfoSourceId { get; set; }
	}

	public enum EmergencyEventType
	{
		[Description("Natural disaster")]
		NaturalDisaster,
		[Description("Production accident")]
		ProductionAccident,
		[Description("Accident")]
		Accident,
		[Description("Crime")]
		Crime,
		[Description("Homicide")]
		Homicide,
		[Description("Household problem")]
		HouseholdProblem
	}
}
