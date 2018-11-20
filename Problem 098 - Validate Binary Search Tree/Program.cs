using System;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Xml.Schema;

namespace Problem_098___Validate_Binary_Search_Tree
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var a1 = new int?[] {5, 1, 4, null, null, 3, 6};
            var a2 = new int?[] {2, 1, 3};
            var a3 = new int?[] {0, -1};
            var a4 = new int?[] {1, 1};
            var a5 = new int?[] {10, 5, 15, null, null, 6, 20};
            var tree = GetTreeFromArray(a3);
            Console.WriteLine(new Solution().IsValidBST(tree));
        }

        public static TreeNode GetTreeFromArray(int?[] arr, int startIdx = 0)
        {
            if (arr.Length - startIdx <= 0)
                return null;
            if (arr[startIdx] == null)
                return null;
            var root = new TreeNode((int) arr[startIdx])
            {
                left = GetTreeFromArray(arr, startIdx * 2 + 1),
                right = GetTreeFromArray(arr, startIdx * 2 + 2)
            };
            return root;
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int x)
        {
            val = x;
        }
    }

    public class Solution
    {
//        public bool IsValidBST(TreeNode root, int? greaterThan = null, int? lessThan = null)
//        {
//            if (root == null)
//                return true;
//            if (greaterThan != null && root.val <= greaterThan)
//                return false;
//            if (lessThan != null && root.val >= lessThan)
//                return false;
//            if (root.left != null && root.left.val >= root.val)
//                return false;
//            if (root.right != null && root.right.val <= root.val)
//                return false;
//            return IsValidBST(root.left, greaterThan, root.val) && IsValidBST(root.right, root.val, lessThan);
//        }

        public bool IsValidBST(TreeNode root, int? greaterThan = null, int? lessThan = null)
        {
            if (root == null)
                return true;
            if (greaterThan != null && root.val <= greaterThan
                || lessThan != null && root.val >= lessThan
                || root.left != null && root.left.val >= root.val
                || root.right != null && root.right.val <= root.val)
                return false;
            return IsValidBST(root.left, greaterThan, root.val) && IsValidBST(root.right, root.val, lessThan);
        }
    }
}