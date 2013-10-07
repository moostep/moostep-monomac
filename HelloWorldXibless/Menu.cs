using System;
using System.Collections;
using System.Collections.Generic;
using MonoMac.AppKit;

namespace HelloWorldXibless
{
	public class Menu : IEnumerable, IEnumerable<MenuItem>
	{
		List<MenuItem> items;
		NSMenu nsmenu;

		public Menu(string title = "")
		{
			items = new List<MenuItem> ();
			nsmenu = new NSMenu (title);
			nsmenu.AutoEnablesItems = false;
		}

		public IEnumerator GetEnumerator ()
		{
			foreach (var item in items)
				yield return item;
		}

		IEnumerator<MenuItem> IEnumerable<MenuItem>.GetEnumerator ()
		{
			foreach (var item in items)
				yield return item;
		}

		public int Count
		{
			get { return items.Count; }
		}

		public MenuItem this[int index]
		{
			get { return items [index]; }
		}

		public void Remove (MenuItem item)
		{
			nsmenu.RemoveItem (item);
			items.Remove (item);
		}

		public void Add (MenuItem item)
		{
			items.Add (item);
			nsmenu.AddItem (item);
		}

		public void AddAll (IEnumerable<MenuItem> items)
		{
			foreach (var item in items)
				Add (item);
		}

		public void Add (IEnumerable<MenuItem> items)
		{
			AddAll (items);
		}

		public string Title
		{
			get { return nsmenu.Title; }
			set { nsmenu.Title = value; }
		}

		public static implicit operator NSMenu (Menu me)
		{
			return me.nsmenu;
		}
	}

	public class MenuItem
	{
		NSMenuItem nsitem;

		public MenuItem (string title, string charCode = "", EventHandler handler = null)
		{
			if (title == "-")
			{
				nsitem = NSMenuItem.SeparatorItem;
			}
			else
			{
				nsitem = new NSMenuItem (title, charCode, handler);
			}
		}

		public MenuItem (Menu submenu)
		{
			nsitem = new NSMenuItem ();
			nsitem.Submenu = submenu;
		}

		public static implicit operator NSMenuItem (MenuItem me)
		{
			return me.nsitem;
		}

		public string Title
		{
			get { return nsitem.Title; }
			set { nsitem.Title = value; }
		}

		public bool Enabled
		{
			get { return nsitem.Enabled; }
			set { nsitem.Enabled = value; }
		}
	}
}