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
			var window = new NSWindow (
				new RectangleF (0, 0, 400, 300),
				NSWindowStyle.Titled,
				NSBackingStore.Buffered,
				false) {
				Title =  "Hello World Xibless"
			};

			window.CascadeTopLeftFromPoint (new PointF (20, 20));
			window.MakeKeyAndOrderFront (null);
		}
	}
}

