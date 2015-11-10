using System;

namespace BinaryTrees {
	class MainClass {
		public static void Main (string[] args) {
			BinaryExpressionTree work = new BinaryExpressionTree ("5 + 2 * 8 - 6 / 4");
			Console.WriteLine (work.Eval ());
			Console.WriteLine (5 + 2 * 8 - 6 / 4);
		}
	}
}
