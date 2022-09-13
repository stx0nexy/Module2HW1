using System;

namespace Module2HW1
{
	public static class Actions
	{
		private static readonly Logger logger = Logger.GetLogger();

		public static Result StartMet()
		{
			logger.AddLog(new Log(DateTime.Now, LogType.Info, $"Start method: {nameof(StartMet)}"));
			return new Result(true, "Start method completed.");
		}

		public static Result SkipMet()
		{
			logger.AddLog(new Log(DateTime.Now, LogType.Warning, $"Skipped logic in method: {nameof(SkipMet)}"));
			return new Result(true, "Skipped logic in method");
		}

		public static Result BrokeMet()
		{
			logger.AddLog(new Log(DateTime.Now, LogType.Error, $"Broke method: {nameof(BrokeMet)}"));
			return new Result(false, "I broke a logic");
		}
	}
}
