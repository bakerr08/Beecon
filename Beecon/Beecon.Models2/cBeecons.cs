using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Beecon.Models2
{
	public class cBeecons
	{
		List<cBeecon> oBeecons;

		public List<cBeecon> Beecons
		{
			get { return oBeecons; }
			set { oBeecons = value; }
		}

		// Custom Constructor
		public cBeecons()
		{
			oBeecons = new List<cBeecon>();
		}
		public int Count
		{
			get { return oBeecons.Count; }
		}
	}
}

