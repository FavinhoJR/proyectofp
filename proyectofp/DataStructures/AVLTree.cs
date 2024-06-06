using System;
using System.Collections.Generic;

namespace proyectofp.DataStructures
{
    public class AVLTreeNode<T>
    {
        public T Value;
        public AVLTreeNode<T> Left;
        public AVLTreeNode<T> Right;
        public int Height;

        public AVLTreeNode(T value)
        {
            Value = value;
            Height = 1;
        }
    }

    public class AVLTree<T> where T : IComparable
    {
        private AVLTreeNode<T> root;

        // Obtener la altura de un nodo
        private int Height(AVLTreeNode<T> node)
        {
            return node?.Height ?? 0;
        }

        // Rotación simple a la derecha
        private AVLTreeNode<T> RightRotate(AVLTreeNode<T> y)
        {
            AVLTreeNode<T> x = y.Left;
            AVLTreeNode<T> T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;
            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;

            return x;
        }

        // Rotación simple a la izquierda
        private AVLTreeNode<T> LeftRotate(AVLTreeNode<T> x)
        {
            AVLTreeNode<T> y = x.Right;
            AVLTreeNode<T> T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;
            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;

            return y;
        }

        // Obtener el factor de balance de un nodo
        private int GetBalance(AVLTreeNode<T> node)
        {
            return node == null ? 0 : Height(node.Left) - Height(node.Right);
        }

        // Método para insertar un nodo
        public void Insert(T value)
        {
            root = Insert(root, value);
        }

        private AVLTreeNode<T> Insert(AVLTreeNode<T> node, T value)
        {
            if (node == null)
                return new AVLTreeNode<T>(value);

            int cmp = value.CompareTo(node.Value);
            if (cmp < 0)
                node.Left = Insert(node.Left, value);
            else if (cmp > 0)
                node.Right = Insert(node.Right, value);
            else
                return node;

            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;

            int balance = GetBalance(node);

            if (balance > 1 && value.CompareTo(node.Left.Value) < 0)
                return RightRotate(node);

            if (balance < -1 && value.CompareTo(node.Right.Value) > 0)
                return LeftRotate(node);

            if (balance > 1 && value.CompareTo(node.Left.Value) > 0)
            {
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }

            if (balance < -1 && value.CompareTo(node.Right.Value) < 0)
            {
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }

            return node;
        }

        // Método para eliminar un nodo
        public void Delete(T value)
        {
            root = Delete(root, value);
        }

        private AVLTreeNode<T> Delete(AVLTreeNode<T> root, T value)
        {
            if (root == null) return root;

            int cmp = value.CompareTo(root.Value);
            if (cmp < 0)
                root.Left = Delete(root.Left, value);
            else if (cmp > 0)
                root.Right = Delete(root.Right, value);
            else
            {
                if ((root.Left == null) || (root.Right == null))
                {
                    AVLTreeNode<T> temp = root.Left ?? root.Right;

                    if (temp == null)
                    {
                        temp = root;
                        root = null;
                    }
                    else
                        root = temp;
                }
                else
                {
                    AVLTreeNode<T> temp = MinValueNode(root.Right);

                    root.Value = temp.Value;

                    root.Right = Delete(root.Right, temp.Value);
                }
            }

            if (root == null)
                return root;

            root.Height = Math.Max(Height(root.Left), Height(root.Right)) + 1;

            int balance = GetBalance(root);

            if (balance > 1 && GetBalance(root.Left) >= 0)
                return RightRotate(root);

            if (balance > 1 && GetBalance(root.Left) < 0)
            {
                root.Left = LeftRotate(root.Left);
                return RightRotate(root);
            }

            if (balance < -1 && GetBalance(root.Right) <= 0)
                return LeftRotate(root);

            if (balance < -1 && GetBalance(root.Right) > 0)
            {
                root.Right = RightRotate(root.Right);
                return LeftRotate(root);
            }

            return root;
        }

        private AVLTreeNode<T> MinValueNode(AVLTreeNode<T> node)
        {
            AVLTreeNode<T> current = node;
            while (current.Left != null)
                current = current.Left;
            return current;
        }

        // Método para buscar un nodo
        public T Find(T value)
        {
            return Find(root, value);
        }

        private T Find(AVLTreeNode<T> node, T value)
        {
            if (node == null)
                return default(T);

            int cmp = value.CompareTo(node.Value);
            if (cmp < 0)
                return Find(node.Left, value);
            else if (cmp > 0)
                return Find(node.Right, value);
            else
                return node.Value;
        }

        // Método para convertir el árbol en una lista
        public List<T> ToList()
        {
            List<T> list = new List<T>();
            InOrderTraversal(root, list);
            return list;
        }

        private void InOrderTraversal(AVLTreeNode<T> node, List<T> list)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left, list);
                list.Add(node.Value);
                InOrderTraversal(node.Right, list);
            }
        }
    }
}

