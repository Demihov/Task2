using System.Collections.Generic;
using Part1.Models;

namespace Part1
{
    public class BinaryTree<T>
    {
        private Node<T> root;

        public delegate void TreeHandler(object sender, TreeEventArgs e);

        public event TreeHandler Notify;

        public Node<T> Find(int key)
        {
            Node<T> current = root;

            while (current.Key != key)
            {
                if(key < current.Key)
                {
                    current = current.Left;
                }
                else if(key > current.Key)
                {
                    current = current.Right;
                }

                if (current == null)
                {
                    return null;
                }
            }

            Notify?.Invoke(this,new TreeEventArgs($"{typeof(T)} was found"));
            return current;
        }
        public void Insert(T node, int _key)
        {
            Node<T> newNode = new Node<T>(node);
            newNode.Key = _key;
            if (root == null)
            {
                root = newNode;
                Notify?.Invoke(this, new TreeEventArgs($"{typeof(T)} was added"));
                return;
            }

            InsertRec(root, newNode);
        }
        private void InsertRec(Node<T> _root, Node<T> newNode)
        {
            if (newNode.Key >= _root.Key)
            {
                if (_root.Right == null)
                {
                    Notify?.Invoke(this, new TreeEventArgs($"{typeof(T)} was added"));
                    _root.Right = newNode;
                }
                else
                {
                    InsertRec(_root.Right, newNode);
                }
            }
            else
            {
                if (_root.Left == null)
                {
                    Notify?.Invoke(this, new TreeEventArgs($"{typeof(T)} was added"));
                    _root.Left = newNode;
                }
                else
                {
                    InsertRec(_root.Left, newNode);
                }
            }
        }

        public IEnumerable<T> GetEnumeratorInOrder()
        {
            return InOrder(root);
        }
        public IEnumerable<T> GetEnumeratorPostOrder()
        {
            return PostOrder(root);
        }
        public IEnumerable<T> GetEnumeratorPreOrder()
        {
            return PreOrder(root);
        }

        private IEnumerable<T> InOrder(Node<T> _root)
        {
            if (_root != null)
            {
                foreach (var item in InOrder(_root.Left))
                {
                    yield return item;
                }

                yield return _root.Data;

                foreach (var item in InOrder(_root.Right))
                {
                    yield return item;
                }
            }
        }

        private IEnumerable<T> PostOrder(Node<T> _root)
        {
            if (_root != null)
            {
                foreach (var item in PostOrder(_root.Left))
                {
                    yield return item;
                }

                foreach (var item in PostOrder(_root.Right))
                {
                    yield return item;
                }

                yield return _root.Data;
            }
        }

        private IEnumerable<T> PreOrder(Node<T> _root)
        {
            if (_root != null)
            {
                yield return _root.Data;

                foreach (var item in PreOrder(_root.Left))
                {
                    yield return item;
                }

                foreach (var item in PreOrder(_root.Right))
                {
                    yield return item;
                }
            }
        }
        
        public void DeleteKey(int _key)
        {
            root = DeleteRec(root, _key);
        }

        Node<T> DeleteRec(Node<T> root, int key)
        {
            if (root == null) return root;

            if (key < root.Key)
                root.Left = DeleteRec(root.Left, key);
            else if (key > root.Key)
                root.Right = DeleteRec(root.Right, key);
 
            else 
            { 
                if (root.Left == null)
                    return root.Right;
                else if (root.Right == null)
                    return root.Left;
 
                root.Key = MinValue(root.Right);

                root.Right = DeleteRec(root.Right, root.Key);
            }
            Notify?.Invoke(this, new TreeEventArgs($"{typeof(T)} was removed"));
            return root;
        }
        int MinValue(Node<T> _root)
        {
            int minv = _root.Key;
            while (_root.Left != null)
            {
                minv = _root.Left.Key;
                _root = _root.Left;
            }
            return minv;
        }
    }
}
