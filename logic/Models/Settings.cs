using System.Text.Json.Serialization;

namespace StepType.Models;

internal class Settings
{
	[JsonRequired]
	public string Setting1 { get; set; }
}
