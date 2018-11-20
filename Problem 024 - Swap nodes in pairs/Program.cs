using System;
using System.Collections.Generic;

namespace Problem_24___Swap_nodes_in_pairs
{
    /**
     * Definition for singly-linked list.
     * public class ListNode {
     *     public int val;
     *     public ListNode next;
     *     public ListNode(int x) { val = x; }
     * }
     */
    public class Solution
    {
        public ListNode SwapPairs(ListNode head)
        {
            ListNode newHead = null;
            var curNode = head;
            var isOdd = true;
            ListNode prevNode = null;
            ListNode prevPrevNode = null;
            while (curNode != null)
            {
                var nextNode = curNode.next;
                if (newHead == null)
                {
                    if (nextNode == null)
                        return curNode;
                    newHead = nextNode;
                }

                if (isOdd)
                {
                    prevNode = curNode;
                }
                else
                {
                    if (prevPrevNode != null)
                        prevPrevNode.next = curNode;
                    curNode.next = prevNode;
                    prevNode.next = nextNode;
                    prevPrevNode = prevNode;
                }

                curNode = nextNode;
                isOdd = !isOdd;
            }

            return newHead;
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
            var s = new Solution();
            Console.WriteLine(string.Join(", ",
                CreateArrayFromListNode(s.SwapPairs(CreateListNodeFromArray(new int[] {1})))));
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