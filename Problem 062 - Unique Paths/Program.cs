namespace Problem_062___Unique_Paths
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public int UniquePaths(int m, int n)
        {
            return GetLatticePaths(new int[m+1, n+1], m, n);
        }

        public static int GetLatticePaths(int[,] lattice, int n, int m)
        {
            if (lattice[n, m] != 0)
                return lattice[n, m];
            if (n == 0 || m == 0)
            {
                lattice[n, m] = 1;
            }
            else
            {
                lattice[n, m] = GetLatticePaths(lattice, n - 1, m) + GetLatticePaths(lattice, n, m - 1);
            }

            return lattice[n, m];
        }
    }
}