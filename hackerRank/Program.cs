using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

internal class Solution
{
	private static void Main(String[] args)
	{
	}

	public static DateTime UnixTimeStampToDateTime( double unixTimeStamp )
	{
	    // Unix timestamp is seconds past epoch
	    System.DateTime dtDateTime = new DateTime(1970,1,1,0,0,0,0,System.DateTimeKind.Utc);
	    dtDateTime = dtDateTime.AddSeconds( unixTimeStamp ).ToLocalTime();
	    return dtDateTime;
	}
}
