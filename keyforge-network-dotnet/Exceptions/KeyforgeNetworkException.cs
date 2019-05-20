using System;
using System.Collections.Generic;
using System.Text;

namespace KeyforgeNetwork.Exceptions
{
	public class KeyforgeNetworkException : Exception
	{
		public KeyforgeNetworkException()
		{
		}

		public KeyforgeNetworkException(string message)
			: base(message)
		{
		}

		public KeyforgeNetworkException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
