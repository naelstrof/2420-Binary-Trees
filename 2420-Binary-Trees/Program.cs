using System;
using System.Diagnostics;
using System.Collections;

namespace BinaryTrees {
	class MainClass {
		public static void Main (string[] args) {
			UnitTest ();
		}
		public static void d() {
			Console.WriteLine ("Done!");
		}
		public static void UnitTest() {
			Console.WriteLine ("----- Testing BinarySearchTree<int> -----");
			Console.Write ("Creating new BinarySearchTree of type <int>...");
			BinarySearchTree<int> test = new BinarySearchTree<int> (); d ();
			Console.Write ("Adding value 50...");
			test.Add (50); d ();
			Console.Write ("Adding value 25...");
			test.Add (25); d ();
			Console.Write ("Adding value 75...");
			test.Add (75); d ();
			Console.Write ("Checking for correct structure (25/50\\75)...");
			Debug.Assert (test.root.value == 50);
			Debug.Assert (test.root.nodes[0].value == 25);
			Debug.Assert (test.root.nodes[1].value == 75);
			d ();
			Console.Write ("Checking if BinarySearchTree.Contains(75) works...");
			Debug.Assert (test.Contains(75)); d ();
			Console.Write ("Testing BinarySearchTree.TraversePre()...");
			Debug.Assert( test.TraversePre ((x) => Console.Write (x.value + " ")) == "50 25 75 "); d ();
			Console.Write ("Testing BinarySearchTree.TraverseInOrder()...");
			Debug.Assert( test.TraverseInOrder ((x) => Console.Write (x.value + " ")) == "25 50 75 "); d ();
			Console.Write ("Testing BinarySearchTree.TraversePost()...");
			Debug.Assert( test.TraversePost ((x) => Console.Write (x.value + " ")) == "25 75 50 "); d ();
			Console.WriteLine ("----- Testing BinarySearchTree<string> -----");
			Console.Write ("Creating new BinarySearchTree of type <string> with custom IComparer...");
			BinarySearchTree<string> foo = new BinarySearchTree<string> ( new StringComparer() ); d ();
			Console.Write ("Adding value Urist McSmashes...");
			foo.Add ("Urist McSmashes"); d ();
			Console.Write ("Adding value Gordon Freeman...");
			foo.Add ("Gordon Freeman"); d ();
			Console.Write ("Adding value Winston Smith...");
			foo.Add ("Winston Smith"); d ();
			Console.Write ("Checking for correct structure (Gordon Freeman/Urist McSmashes\\Winston Smith)...");
			Debug.Assert (foo.root.value == "Urist McSmashes");
			Debug.Assert (foo.root.nodes[0].value == "Gordon Freeman");
			Debug.Assert (foo.root.nodes[1].value == "Winston Smith");
			d ();
			Console.WriteLine ("----- Testing BinaryExpressionTree -----");
			Console.Write ("Creating new BinaryExpressionTree with expression \"5 + 2 * 8 - 6 / 4\"...");
			BinaryExpressionTree bar = new BinaryExpressionTree ("5 + 2 * 8 - 6 / 4"); d ();
			Console.Write ("Checking for correct structure...");
			Debug.Assert( bar.TraverseInOrder ((x) => Console.Write (x.value + " ")) == "4 47 6 45 8 42 2 43 5 ");
			Debug.Assert( bar.root.value == 45 ); // -
			Debug.Assert( bar.root.nodes[0].value == 47 ); // /
			Debug.Assert( bar.root.nodes[0].nodes[0].value == 4 );
			Debug.Assert( bar.root.nodes[0].nodes[1].value == 6 );
			Debug.Assert( bar.root.nodes[1].value == 43 ); // +
			Debug.Assert( bar.root.nodes[1].nodes[1].value == 5 ); 
			Debug.Assert( bar.root.nodes[1].nodes[0].value == 42 ); // *
			Debug.Assert( bar.root.nodes[1].nodes[0].nodes[0].value == 8 );
			Debug.Assert( bar.root.nodes[1].nodes[0].nodes[1].value == 2 );
			d ();
			Console.Write ("Checking for correct answer \"5 + 2 * 8 - 6 / 4\" = " + (5.0 + 2.0 * 8.0 - 6.0 / 4.0) + "...");
			Debug.Assert (bar.Eval () == (5.0 + 2.0 * 8.0 - 6.0 / 4.0)); d ();
			Console.WriteLine ("Everything appears to be in order! Although asserts in C# don't actually end execution so there's no real way for me to know!");
		}
		public class StringComparer : IComparer {
			public int Compare( object a, object b ) {
				string c = (string)a;
				string d = (string)b;
				return c.ToCharArray()[0] - d.ToCharArray()[0];
			}
		}
	}
}
