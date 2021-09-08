using ApplicationDomainExample;
using System;

namespace Application_A
{
	public class Plugin_A : IPlugin
	{
		private static string Value => "This is Plugin_A";

		public void DoProcess()
		{
			Console.WriteLine(Value);
		}
	}
}
