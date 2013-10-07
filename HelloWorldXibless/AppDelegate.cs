using System;
using System.Linq;
using System.Drawing;
using MonoMac.Foundation;
using MonoMac.AppKit;

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
			var products = new [] { "Xamarin.iOS", "Xamarin.Android", "Xamarin.Mac" };

            Menu menu = null;
            MenuItem addNew = null;
            MenuItem newItem = null;

            addNew = new MenuItem("Add new menu item", "", delegate {
                addNew.Enabled = false;

                newItem = new MenuItem(new Menu("New Menu") {
                    new MenuItem("Remove this menu", "", delegate {
                        addNew.Enabled = true;
                        menu.Remove(newItem);
                    })
                });

                menu.Add(newItem);
            });

			menu = new Menu {
				new MenuItem(
					new Menu {
                        addNew,
                        new MenuItem("-"),
                        new MenuItem("Quit", "q", delegate {
                            NSApplication.SharedApplication.Terminate(NSApplication.SharedApplication.MainMenu);
                        })
                    }
                ),
				new MenuItem(new Menu("Xamarin Products") {
					from product in products select new MenuItem(product, "",  delegate {
						Console.WriteLine("Clicked product item: " + product);
					})
				}),
			};

            NSApplication.SharedApplication.MainMenu = menu;
		}
	}
}

