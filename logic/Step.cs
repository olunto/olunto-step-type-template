using AppEngine.Common;
using Microsoft.Extensions.Logging;
using StepType.Models;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace StepType;

public sealed class Step : IStep
{
	private readonly Settings _settings;
	private readonly IStepContext _context;
	
	public Step(IStepContext context)
	{
		ArgumentNullException.ThrowIfNull(context);

		_context = context;
		_settings = JsonSerializer.Deserialize<Settings>(context.StepInfo.Settings);
	}

	public async Task InitializeAsync()
	{
		await Task.CompletedTask;
	}

	public async Task RunAsync()
	{
		await Task.CompletedTask;
	}

	public async Task InputAsync(string inboxId, IRow row)
	{
		// resolve

		var setting1 = _context.ValueExpressionHelper.Resolve<string>(row, _settings.Setting1);
		
		// process

		row.Column("Name2", ColumnType.String, setting1);

		_context.Logger.LogInformation("Setting1 : {Value}", setting1);

		// output

		await _context.OutputAsync(row, "Outbox1");
	}
}
