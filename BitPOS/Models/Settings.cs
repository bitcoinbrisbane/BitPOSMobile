using System;
using System.Collections.Generic;

namespace BitPOS
{
	public class Settings
	{
		public static Settings Instance
		{
			get { return new Settings(); }
		}

		public String Key { get { return "q65ghPZWRBh3HrZgAWqFQgLK68rvIiZp0j7sf3+1oDzx4YDbI/P0WqQCoRKqYsb/BAD+Cet1aaE9oDyAb6lyNQ=="; } }
		public String Password { get { return "Test1234"; }}
		public Boolean TestNet { get { return false; }}

		public ICollection<IOrder> Orders { get; set; }

		public ICollection<String> EncodedOrderIds { get; set; }
	}
}