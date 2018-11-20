using System;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace Problem_23___Merge_k_sorted_lists
{
    /**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
    using System.Collections.Generic;

    public class Solution
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            var currentNodes = new SortedDictionary<int, List<ListNode>>();
            foreach (var node in lists)
            {
                List<ListNode> currentList;
                currentNodes.TryGetValue(node.val, out currentList);
                if (currentList == null)
                    currentNodes[node.val] = new List<ListNode> {node};
                else
                    currentList.Add(node);
            }

            ListNode outputHead = null;
            ListNode outputPrevNode = null;

            while (currentNodes.Count > 0)
            {
                var minValueNodes = currentNodes.Values.First();
                var value = minValueNodes[0].val;
                currentNodes.Remove(value);
                foreach (var curNode in minValueNodes)
                {
                    // add value to output ListNode
                    var outputCurNode = new ListNode(value);
                    if (outputHead == null)
                        outputHead = outputCurNode;
                    else
                    {
                        outputPrevNode.next = outputCurNode;
                    }

                    outputPrevNode = outputCurNode;

                    // get next value in each list
                    var nextNode = curNode.next;
                    if (nextNode != null)
                    {
                        List<ListNode> currentList;
                        currentNodes.TryGetValue(nextNode.val, out currentList);
                        if (currentList == null)
                            currentNodes[nextNode.val] = new List<ListNode> {nextNode};
                        else
                            currentList.Add(nextNode);
                    }
                }
            }

            return outputHead;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int x)
        {
            val = x;
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            var lists = new int[][]
            {
                new int[] {1, 4, 5},
                new int[] {1, 3, 4},
                new int[] {2, 6}
            };

            var s = new Solution();
            var sortedListNode = s.MergeKLists(lists.Select(arr => CreateListNodeFromArray(arr)).ToArray());
            Console.WriteLine(string.Join(", ", 
                CreateArrayFromListNode(sortedListNode)));
        }

        public static ListNode CreateListNodeFromArray(int[] arr)
        {
            ListNode head = null;
            ListNode prevNode = null;
            foreach (var x in arr)
            {
                var curNode = new ListNode(x);
                if (head == null)
                    head = curNode;
                else
                {
                    prevNode.next = curNode;
                }

                prevNode = curNode;
            }

            return head;
        }

        public static int[] CreateArrayFromListNode(ListNode n)
        {
            var arr = new List<int>();
            while (n != null)
            {
                arr.Add(n.val);
                n = n.next;
            }

            return arr.ToArray();
        }
    }
}