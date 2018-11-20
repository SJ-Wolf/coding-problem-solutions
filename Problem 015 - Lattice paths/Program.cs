using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Problem_015___Lattice_paths
{
    internal class Program
    {
        public static BigInteger GetLatticePaths(BigInteger[,] lattice, int n, int m)
        {
            if (lattice[n, m] != 0)
                return lattice[n, m];
            if (n == 0 || m == 0)
            {
                lattice[n, m] = 1L;
            }
            else
            {
                lattice[n, m] = GetLatticePaths(lattice, n - 1, m) + GetLatticePaths(lattice, n, m - 1);
            }

            return lattice[n, m];
        }

        public static void Main(string[] args)
        {
            var lattice = new BigInteger[501, 501];
//            for (var n = 0; n < lattice.GetLength(0); n++)
//            {
//                for (var m = 0; m < lattice.GetLength(1); m++)
//                {
//                    GetLatticePaths(lattice, n, m);
//                }
//            }

            var mod = new BigInteger(1000000007);
            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                var input = Console.ReadLine().Split().Select(x => Convert.ToInt32(x)).ToArray();
                var output = GetLatticePaths(lattice, input[0], input[1]);
                Console.WriteLine(output % mod);
            }
        }
    }
}