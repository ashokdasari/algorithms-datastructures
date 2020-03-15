using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTree
{
    public class BinarySearchTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private BinaryTreeNode<T> _root;
        private int _count;

        public void Add(T value)
        {
            if (this._root == null)
            {
                this._root = new BinaryTreeNode<T>(value);
            }
            else
            {
                this.AddToNode(_root, value);
            }
            this._count += 1;
        }

        private void AddToNode(BinaryTreeNode<T> node, T value)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.Left != null)
                {
                    this.AddToNode(node.Left, value);
                }
                else
                {
                    node.Left = new BinaryTreeNode<T>(value);
                }
            }
            else
            {
                if (node.Right != null)
                {
                    this.AddToNode(node.Right, value);
                }
                else
                {
                    node.Right = new BinaryTreeNode<T>(value);
                }
            }
        }

        public bool Remove(T value)
        {
            BinaryTreeNode<T> parent;
            var nodeToRemove = FindWithParent(value, out parent);
            if (nodeToRemove == null)
            {
                return false;
            }
            _count -= 1;
            if (nodeToRemove.Right == null)
            {
                if (parent == null)
                {
                    _root = nodeToRemove.Left;
                }
                if (nodeToRemove.Left != null)
                {
                    if (parent.Left == nodeToRemove)
                    {
                        parent.Left = nodeToRemove.Left;
                    }
                    else
                    {
                        parent.Right = nodeToRemove.Left;
                    }
                }
            }
            else
            {
                if (nodeToRemove.Right.Left == null)
                {
                    nodeToRemove.Right.Left = nodeToRemove.Left;
                    if (parent == null)
                    {
                        _root = nodeToRemove.Right;
                    }
                    else
                    {
                        if (parent.Left == nodeToRemove)
                        {
                            parent.Left = nodeToRemove.Right;
                        }
                        else
                        {
                            parent.Right = nodeToRemove.Right;
                        }
                    }

                }
                else
                {
                    BinaryTreeNode<T> leftMostNode = nodeToRemove.Right.Left, leftMostNodeParent = nodeToRemove.Right;

                    while (leftMostNode.Left != null)
                    {
                        leftMostNodeParent = leftMostNode;
                        leftMostNode = leftMostNode.Left;
                    }

                    leftMostNodeParent.Left = leftMostNode.Right;

                    leftMostNode.Left = nodeToRemove.Left;
                    leftMostNode.Right = nodeToRemove.Right;
                    if (parent == null)
                    {
                        _root = leftMostNode;
                    }
                    else
                    {
                        if (parent.Left == nodeToRemove)
                        {
                            parent.Left = leftMostNode;
                        }
                        else
                        {
                            parent.Right = leftMostNode;
                        }
                    }
                }
            }
            return true;
        }

        public int Count
        {
            get
            {
                return this._count;
            }
        }

        public void Clear()
        {
            this._root = null;
            this._count = 0;
        }

        public bool Contains(T value)
        {
            BinaryTreeNode<T> parent;
            return FindWithParent(value, out parent) != null;

        }

        private BinaryTreeNode<T> FindWithParent(T value, out BinaryTreeNode<T> parent)
        {
            BinaryTreeNode<T> current = _root;

            parent = null;

            while (current != null)
            {
                var result = current.CompareTo(value);
                if (result == 0)
                {
                    break;
                }
                else
                {
                    parent = current;
                    current = (result < 0 ? current.Right : current.Left);
                }
            }
            return current;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InOrderTraversal();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IEnumerator<T> InOrderTraversal()
        {
            if (_root != null)
            {
                var stack = new Stack<BinaryTreeNode<T>>();
                BinaryTreeNode<T> current = _root;
                bool goToLeftNext = true;
                stack.Push(current);
                while (stack.Count > 0)
                {
                    if (goToLeftNext)
                    {
                        while (current.Left != null)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }

                    yield return current.Value;
                    if (current.Right != null)
                    {
                        current = current.Right;
                        goToLeftNext = true;
                    }
                    else
                    {
                        current = stack.Pop();
                        goToLeftNext = false;
                    }
                }
            }
        }
    }
}
