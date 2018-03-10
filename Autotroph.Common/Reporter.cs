using System;
using System.Collections.Generic;
using System.Text;

namespace Autotroph.Common
{
	public class Reporter
	{
		// thread-safe handling
		private static object _sync = new object();

		private static string BuildMessage( string loc, string msg, object[] args )
		{
			string format = msg;

			if ( !string.IsNullOrWhiteSpace( loc ) )
			{
				format = string.Format( "{0}: {1}", loc, msg );
			}

			return string.Format( format, args );
		}

		public static void Info( string loc, string msg, params object[] args )
		{
			string line = BuildMessage( loc, msg, args );

			lock ( _sync )
			{
				Console.WriteLine( line );
			}
		}

		public static void Success( string loc, string msg, params object[] args )
		{
			string line = BuildMessage( loc, msg, args );

			lock ( _sync )
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine( line );
				Console.ResetColor();
			}
		}

		public static void Warning( string loc, string msg, params object[] args )
		{
			string line = BuildMessage( loc, msg, args );

			lock ( _sync )
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine( line );
				Console.ResetColor();
			}
		}

		public static void Error( string loc, string msg, params object[] args )
		{
			string line = BuildMessage( loc, msg, args );

			lock ( _sync )
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine( line );
				Console.ResetColor();
			}
		}
	}
}
