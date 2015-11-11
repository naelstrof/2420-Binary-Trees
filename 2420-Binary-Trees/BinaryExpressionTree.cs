using System;
using System.Collections.Generic;
using System.Collections;

namespace BinaryTrees {
	public class BinaryExpressionTree : BinarySearchTree<double> {
		Stack<Node<double>> ops = new Stack<Node<double>> ();
		Stack<Node<double>> operands = new Stack<Node<double>> ();
		public BinaryExpressionTree( string expression ) {
			bool isOp = false;
			foreach (string foo in expression.Split ()) {
				if (!isOp) {
					Node<double> node = new Node<double> (Double.Parse(foo));
					operands.Push (node);
				} else {
					Node<double> node = new Node<double> (foo.ToCharArray()[0]);
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
			root = operands.Pop ();
		}
		private bool IsWorthy( Node<double> a, Node<double> b ) {
			return GetPriority(a.value) > GetPriority(b.value);
		}
		private int GetPriority( double value ) {
			switch( (int)value ) {
			case 43:
			case 45:
				return 0;
			case 42:
			case 47:
				return 1;
			}
			return 0;
		}
		private void Combine( Stack<Node<double>> operands, Stack<Node<double>> ops ) {
			Node<double> root = ops.Pop ();
			root.nodes[0] = operands.Pop ();
			root.nodes[1] = operands.Pop ();
			operands.Push (root);
		}
		public double Eval() {
			return Eval (root);
		}
		public double Eval( Node<double> node ) {
			if (node.nodes [0] == null && node.nodes [1] == null) {
				return node.value;
			} else {
				switch ((int)node.value) {
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
