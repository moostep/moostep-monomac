using System;
using MonoMac.AppKit;
using MonoMac.Foundation;
using System.Drawing;

namespace HelloWorldXibless
{
	public class AppDelegate : NSApplicationDelegate
	{
		public override void FinishedLaunching (NSObject notification)
		{
			var appName = NSProcessInfo.ProcessInfo.ProcessName;

			CreateMenu (appName);

			var window = new NSWindow (
				new RectangleF (0, 0, 400, 300),
				NSWindowStyle.Titled,
				NSBackingStore.Buffered,
				false) {
				Title =  appName
			};

			window.CascadeTopLeftFromPoint (new PointF (20, 20));
			window.MakeKeyAndOrderFront (null);
		}

		void CreateMenu (string appName)
		{
			var mainMenu = new NSMenu();

			var appMenuItem = new NSMenuItem ();
			mainMenu.AddItem (appMenuItem);

			var appMenu = new NSMenu ();

			var quitMenuItem = new NSMenuItem (String.Format ("Quit {0}", appName), "q", delegate {
				NSApplication.SharedApplication.Terminate(mainMenu);
			});

			appMenu.AddItem (quitMenuItem);

			appMenuItem.Submenu = appMenu;

			NSApplication.SharedApplication.MainMenu = mainMenu;
		}
	}
}

