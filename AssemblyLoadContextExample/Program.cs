using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;

namespace ApplicationDomainExample
{
	class Program
	{
		private static readonly Dictionary<string, IPlugin> Plugins = new Dictionary<string, IPlugin>();

		private static string PluginPath => @"C:\git\AssemblyLoadContextExample\AssemblyLoadContextExample\Plugins";

		static void Main(string[] args)
		{
			Console.WriteLine("Start the application");

			LoadPlugins();

			foreach (var key in Plugins.Keys)
			{
				Plugins[key].DoProcess();
			}

			Console.WriteLine("Finished the application");
			Console.ReadKey();
		}

		private static void LoadPlugins()
		{
			foreach (var dll in Directory.GetFiles(PluginPath, "*.dll"))
			{
				var assemblyLoadContext = new AssemblyLoadContext(dll);
				Assembly assembly = assemblyLoadContext.LoadFromAssemblyPath(dll);
				var plugin = Activator.CreateInstance(assembly.GetTypes()[0]) as IPlugin;
				Plugins.Add(Path.GetFileNameWithoutExtension(dll), plugin);
			}
		}
	}
}
