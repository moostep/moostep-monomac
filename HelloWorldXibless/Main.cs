using System;
using MonoMac.AppKit;

namespace HelloWorldXibless
{
	class MainClass
	{
		static void Main (string[] args)
		{
			NSApplication.Init ();
			var application = NSApplication.SharedApplication;

			application.Delegate = new AppDelegate ();
			application.Run ();
		}
	}
}