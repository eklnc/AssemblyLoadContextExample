using ApplicationDomainExample;
using System;

namespace Application_B
{
	public class Plugin_B : IPlugin
	{
		private static string Value => "This is Plugin_B";

		public void DoProcess()
		{
			Console.WriteLine(Value);
		}
	}
}
