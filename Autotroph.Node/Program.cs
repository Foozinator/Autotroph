using System;
using System.Linq;
using Autotroph.Common;

namespace Autotroph.Node
{
    class Program
    {
		private const string _loc = "PROG";

        static void Main(string[] args)
        {
			Reporter.Success( _loc, "Start" + ( ( args != null && args.Length > 0 ) ? ": " + args.Aggregate( ( a, b ) => string.Format( "\"{0}\", \"{1}\"", a, b ) ) : string.Empty ) );
        }
    }
}