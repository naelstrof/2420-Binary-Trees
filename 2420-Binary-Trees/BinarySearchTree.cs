using System;
using System.Collections.Generic;
using System.Collections;

namespace BinaryTrees {
	public class Node<Type> where Type : IComparable {
		public Type value { get; set; }
		public Node<Type>[] nodes = new Node<Type>[2];
		public Node( Type value ) {
			this.value = value;
		}
	}
	public class BinarySearchTree<Type> where Type : IComparable {
		public IComparer comp = null;
		public Node<Type> root;
		public BinarySearchTree() {
		}
		public BinarySearchTree(IComparer custom ) {
			comp = custom;
		}
		public void Add(Type value) {
			Add (value, this.root);
		}
		public void Add(Type value, Node<Type> node) {
			if (this.root == null) {
				this.root = new Node<Type> (value);
				return;
			}
			int test;
			if (comp != null) {
				test = Convert.ToInt32 (comp.Compare (value, node.value) > 0);
			} else {
				test = Convert.ToInt32 (value.CompareTo (node.value) > 0);
			}
			if ( node.nodes [test] == null ) {
				node.nodes [test] = new Node<Type> (value);
				return;
			}
			Add (value, node.nodes [test]);
		}
		public bool Contains( Type value ) {
			return Contains( value, this.root );
		}
		public bool Contains( Type value, Node<Type> node ) {
			if (value.CompareTo(node.value) == 0) {
				return true;
			}
			return Contains( value, node.nodes[Convert.ToInt32(value.CompareTo(node.value) > 0)] );
		}
		public string TraversePre( Action< Node<Type> > method ) {
			return TraversePre (method, this.root);
		}
		public string TraversePre( Action< Node<Type> > method, Node<Type> node, string str = "" ) {
			method (node);
			str += node.value.ToString () + " ";
			if (node.nodes [0] != null) {
				str = TraversePre (method, node.nodes [0], str);
			}
			if (node.nodes [1] != null) {
				str = TraversePre (method, node.nodes [1], str);
			}
			return str;
		}
		public string TraverseInOrder( Action< Node<Type> > method ) {
			return TraverseInOrder (method, this.root);
		}
		public string TraverseInOrder( Action< Node<Type> > method, Node<Type> node, string str = "" ) {
			if (node.nodes [0] != null) {
				str = TraverseInOrder (method, node.nodes [0], str);
			}
			method (node);
			str += node.value.ToString() + " ";
			if (node.nodes [1] != null) {
				str = TraverseInOrder (method, node.nodes [1], str);
			}
			return str;
		}
		public string TraversePost( Action< Node<Type> > method ) {
			return TraversePost (method, this.root);
		}
		public string TraversePost( Action< Node<Type> > method, Node<Type> node, string str = "" ) {
			if (node.nodes [0] != null) {
				str = TraverseInOrder (method, node.nodes [0], str);
			}
			if (node.nodes [1] != null) {
				str = TraverseInOrder (method, node.nodes [1], str);
			}
			method (node);
			str += node.value.ToString () + " ";
			return str;
		}
	}
}
