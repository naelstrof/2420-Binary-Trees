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
		public Node<Type> root;
		public void Add(Type value) {
			Add (value, this.root);
		}
		public void Add(Type value, Node<Type> node) {
			if (this.root == null) {
				this.root = new Node<Type> (value);
				return;
			}
			int test = Convert.ToInt32 (value.CompareTo(node.value) > 0);
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
		public void TraversePre( Action< Node<Type> > method ) {
			TraversePre (method, this.root);
		}
		public void TraversePre( Action< Node<Type> > method, Node<Type> node ) {
			method (node);
			if (node.nodes [0] != null) {
				TraversePre (method, node.nodes [0]);
			}
			if (node.nodes [1] != null) {
				TraversePre (method, node.nodes [1]);
			}
		}
		public void TraverseInOrder( Action< Node<Type> > method ) {
			TraverseInOrder (method, this.root);
		}
		public void TraverseInOrder( Action< Node<Type> > method, Node<Type> node ) {
			if (node.nodes [0] != null) {
				TraverseInOrder (method, node.nodes [0]);
			}
			method (node);
			if (node.nodes [1] != null) {
				TraverseInOrder (method, node.nodes [1]);
			}
		}
		public void TraversePost( Action< Node<Type> > method ) {
			TraversePost (method, this.root);
		}
		public void TraversePost( Action< Node<Type> > method, Node<Type> node ) {
			if (node.nodes [0] != null) {
				TraverseInOrder (method, node.nodes [0]);
			}
			if (node.nodes [1] != null) {
				TraverseInOrder (method, node.nodes [1]);
			}
			method (node);
		}
	}
}
