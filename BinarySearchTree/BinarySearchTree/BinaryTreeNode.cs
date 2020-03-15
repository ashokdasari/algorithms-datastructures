using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BinarySearchTree
{
    public class BinaryTreeNode<T> : IComparable<T> where T : IComparable<T>
    {
        public T Value { get; set; }
        public BinaryTreeNode<T> Left { get; set; }

        public BinaryTreeNode<T> Right { get; set; }

        public BinaryTreeNode(T value)
        {
            this.Value = value;
        }

        public int CompareTo([AllowNull] T other)
        {
            return this.Value.CompareTo(other);
        }
    }

}
