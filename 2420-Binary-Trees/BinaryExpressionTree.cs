using System;
using System.Collections.Generic;
using System.Collections;

namespace BinaryTrees {
	public class BinaryExpressionTree {
		BinarySearchTree<int> tree = new BinarySearchTree<int>();
		Stack<Node<int>> ops = new Stack<Node<int>> ();
		Stack<Node<int>> operands = new Stack<Node<int>> ();
		public BinaryExpressionTree( string expression ) {
			bool isOp = false;
			foreach (string foo in expression.Split ()) {
				if (!isOp) {
					Node<int> node = new Node<int> (Int32.Parse(foo));
					operands.Push (node);
				} else {
					Node<int> node = new Node<int> (foo.ToCharArray()[0]);
					while (ops.Count != 0 && !IsWorthy (node, ops.Peek ())) {
						Combine (operands, ops);
					}
					ops.Push (node);
				}
				isOp = !isOp;
			}
			while (ops.Count != 0) {
				Combine (operands, ops);
			}
			tree.root = operands.Pop ();
		}
		private bool IsWorthy( Node<int> a, Node<int> b ) {
			return GetPriority(a.value) > GetPriority(b.value);
		}
		private int GetPriority( int value ) {
			switch( value ) {
			case 43:
			case 45:
				return 0;
			case 42:
			case 47:
				return 1;
			}
			return 0;
		}
		private void Combine( Stack<Node<int>> operands, Stack<Node<int>> ops ) {
			Node<int> root = ops.Pop ();
			root.nodes[0] = operands.Pop ();
			root.nodes[1] = operands.Pop ();
			operands.Push (root);
		}
		public int Eval() {
			return Eval (tree.root);
		}
		public int Eval( Node<int> node ) {
			if (node.nodes [0] == null && node.nodes [1] == null) {
				return node.value;
			} else {
				switch (node.value) {
				case 43:
					return Eval(node.nodes [1]) + Eval(node.nodes [0]);
				case 45:
					return Eval(node.nodes [1]) - Eval(node.nodes [0]);
				case 42:
					return Eval(node.nodes [1]) * Eval(node.nodes [0]);
				case 47:
					return Eval(node.nodes [1]) / Eval(node.nodes [0]);
				}
				return 0;
			}
		}
	}
}
