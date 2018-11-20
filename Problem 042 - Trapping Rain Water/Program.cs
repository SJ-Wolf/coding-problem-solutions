using System;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;

namespace Problem_42___Trapping_Rain_Water
{
    public class Solution
    {
        public static int movePointer(int[] height, bool goUp, int startIndex = 0)
        {
            var curHeight = height[startIndex];
            var endIndex = -1;
            for (var i = startIndex + 1; i < height.Length; i++)
            {
                var nextHeight = height[i];
                if (
                    ((goUp && nextHeight < curHeight)
                     || (!goUp && nextHeight > curHeight)))
                {
                    endIndex = i - 1;
                    break;
                }

                curHeight = nextHeight;
            }

            return endIndex == -1 ? height.Length - 1 : endIndex;
        }

        public static int moveDownAndUp(int[] height, int startIndex = 0, bool includeStartHeight = false)
        {
            var moveDown = movePointer(height, goUp: false, startIndex: startIndex);
            var moveUp = movePointer(height, goUp: true, startIndex: moveDown);
            return moveUp;
        }

        public int Trap(int[] height)
        {
            if (height.Length <= 2)
                return 0;

            var finalIndex = height.Length - 1;
            while (finalIndex > 0 && height[finalIndex - 1] > height[finalIndex])
                finalIndex--;
            var initialIndex = movePointer(height, goUp: true, startIndex: 0);
            var startIndex = initialIndex;
            var water = 0;

            while (startIndex < finalIndex)
            {
                var endIndex = startIndex + 1;

                var largestEndIndex = endIndex;
                while (endIndex < finalIndex && height[endIndex] < height[startIndex])
                {
                    endIndex++;
                    if (height[largestEndIndex] < height[endIndex])
                        largestEndIndex = endIndex;
                }

                if (endIndex == finalIndex)
                    endIndex = largestEndIndex;


                while (startIndex < finalIndex && height[startIndex + 1] > height[endIndex])
                {
                    startIndex++;
                }

                var waterLevel = Math.Min(height[startIndex], height[endIndex]);

                var existingWater = 0;

                for (var i = startIndex + 1; i < endIndex; i++)
                {
                    existingWater += height[i];
                }

                var additionalWater =
                    Math.Max(0, (waterLevel * (endIndex - startIndex - 1) - existingWater));
                water += additionalWater;

                startIndex = endIndex;
            }

            return water;
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            var s = new Solution();
            Console.WriteLine(s.Trap(new[] {9, 6, 8, 8, 5, 6, 3}));
        }
    }
}