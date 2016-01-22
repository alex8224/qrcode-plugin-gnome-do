// 
//  QRCodeAction.cs
//  
//  Author:
//       Alex Zhang <alex8224@gmail.com>
// 
//  Copyright © 2016 Alex Zhang <alex8224@gmail.com>
// 
//  This library is free software; you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as
//  published by the Free Software Foundation; either version 2.1 of the
//  License, or (at your option) any later version.
// 
//  This library is distributed in the hope that it will be useful, but
//  WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
//  Lesser General Public License for more details.
// 
//  You should have received a copy of the GNU Lesser General Public
//  License along with this library; if not, write to the Free Software
//  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA

using System;
using System.Linq;
using System.Collections.Generic;
using Do.Platform;

using Do.Universe;
using System.Diagnostics;

namespace QRCode
{
	public class QRCodeAction: Act
	{
		public QRCodeAction ()
		{
		}

		public override string Name {
			get {

				return "生成二维码";
			}
		}

		public override string Description {
			get {
				return Name;
			}
		}

		public override string Icon {
			get {
				return "gtk-open";
			}
		}

		public override bool SupportsItem (Item item)
		{
			return true;
		}

		public override System.Collections.Generic.IEnumerable<Type> SupportedItemTypes {
			get {
				yield return typeof(Item);
			}
		}
			
		public override IEnumerable<Item> Perform(IEnumerable<Item> items, IEnumerable<Item> modItems)
		{
			
			ITextItem item = items.First () as ITextItem;

			String qrcode_content = item.Text;
			Process qrencode = System.Diagnostics.Process.Start ("/usr/bin/qrencode", String.Format("-s 6 -o /tmp/qrcode.png {0}", qrcode_content));
			qrencode.WaitForExit ();
			Process feh = System.Diagnostics.Process.Start("/usr/bin/qiv", "/tmp/qrcode.png");
			feh.WaitForExit();
			yield break;
		}
	}
	}


