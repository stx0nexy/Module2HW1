using System;

namespace Module2HW1
{
	public static class Starter
	{
		private const int Counter = 100;
		public static void Run()
		{
			Logger logger = Logger.GetLogger();
			Random random = new Random();
			int number;
			Result result;
			for (int i = 0; i < Counter; i++)
			{
				Console.WriteLine($"Current iteretion is {i}");
				number = random.Next(1, 4);
				result = default;
				switch (number)
				{
					case 1:
						{
							result = Actions.StartMet();
							break;
						}
					case 2:
						{
							result = Actions.SkipMet();
							break;
						}
					case 3:
						{
							result = Actions.BrokeMet();
							break;
						}
				}
				if (!result.Status)
				{
					logger.AddLog(new Log(DateTime.Now, LogType.Error, $"Action failed by a reason: {result.Message}"));
					break;
				}
			}
			logger.PrintToFile();
			Console.ReadKey();
		}
	}
}
