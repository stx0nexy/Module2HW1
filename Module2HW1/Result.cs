

namespace Module2HW1
{
	public class Result
	{
		private readonly bool status;
		private readonly string message;

		public bool Status
		{
			get => status;
		}

		public string Message
		{
			get => message;
		}

		public Result(bool status, string message)
		{
			this.status = status;
			this.message = message;
		}
	}
}
