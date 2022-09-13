using System;
using System.IO;
using System.Text;

namespace Module2HW1
{
	public enum LogType
	{
		Info,
		Warning,
		Error
	}
	public class Log
	{
		private readonly DateTime time;
		private readonly LogType type;
		private readonly string mess;

		public Log(DateTime time, LogType type, string mess)
		{
			this.time = time;
			this.type = type;
			this.mess = mess;
		}

		public override string ToString()
		{
			return String.Format("{0}: {1}: {2}", time, type, mess);
		}
	}

	public class Logger
	{
		private const int Size = 30;
        private static Logger? logger;
		private readonly Log[] logs;
		private int length;

		public static Logger GetLogger()
		{
			if (logger == null)
			{
				logger = new Logger();
			}
			return logger;
		}

		private Logger()
		{
			logs = new Log[Size];
			length = 0;
		}

		public void AddLog(Log log)
		{
			if (length >= Size)
			{
				throw new ArgumentOutOfRangeException("Over space for log!");
			}
			Console.WriteLine(log.ToString());
			logs[length++] = log;
		}

		public void PrintLoggers()
		{
			foreach (var log in logs)
			{
				if (log == null)
				{
					break;
				}
				Console.WriteLine(log.ToString());
			}
		}

		public void PrintToFile()
		{
			using (FileStream fstream = new FileStream("log.txt", FileMode.Create))
			{
				StringBuilder textLogs = new StringBuilder();
				foreach (var log in logs)
				{
					if (log == null)
					{
						break;
					}
					textLogs.Append($"{log.ToString()}\n");
				}
				byte[] array = Encoding.Default.GetBytes(textLogs.ToString());
				fstream.Write(array, 0, array.Length);
				Console.WriteLine("Logs wrote in the file!");
			}
		}
	}

}
