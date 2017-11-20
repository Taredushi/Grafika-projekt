using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biometria_1
{
    static class MaskTables
    {
        public static int[,] Blur = new[,]
        {
            {1, 1, 1},
            {1, 1, 1},
            {1, 1, 1}
        };

        public static int[,] PrewittHorizontal = new int[,]
        {
            {-1, -1, -1},
            {0, 0, 0},
            {1, 1, 1}
        };
        public static int[,] PrewittVertical = new int[,]
        {
            {-1, 0, 1},
            {-1, 0, 1},
            {-1, 0, 1}
        };

        public static int[,] SobelVertical = new int[,]
        {
            {-1, 0, 1},
            {-2, 0, 2},
            {-1, 0, 1}
        };
        public static int[,] SobelHorizontal = new int[,]
        {
            {1, 2, 1},
            {0, 0, 0},
            {-1, -2, -1}
        };

        public static int[,] LaplaceHorizontal = new int[,]
        {
            {0, -1, 0},
            {0, 2, 0},
            {0, -1, 0}
        };
        public static int[,] LaplaceVertical = new int[,]
        {
            {0, 0, 0},
            {-1, 2, -1},
            {0, 0, 0}
        };
        public static int[,] LaplaceDiagonal = new int[,]
        {
            {-1, 0, -1},
            {0, 4, 0},
            {-1, 0, -1}
        };
        //
        public static int[,] NaroznikWschod = new int[,]
        {
            {-1, 1, 1},
            {-1, -2, 1},
            {-1, 1, 1}
        };
        public static int[,] NaroznikZachod = new int[,]
        {
            {-1, -1, 1},
            {-1, -2, 1},
            {1, 1, 1}
        };
        public static int[,] PolnocnyZachodNaroznik = new int[,]
        {
            {1, 1, 1},
            {1, -2, -1},
            {1, -1, -1}
        };

        public static int[,] PoludniowyWschodNaroznik = new int[,]
        {
            {1, 1, -1},
            {1, -2, -1},
            {1, 1, -1}
        };

        public static int[,] Gauss = new int[,]
        {
            {2, 4, 5, 4, 2},
		    {4, 9, 12, 9, 4},
		    {5, 12, 15, 12, 5},
		    {4, 9, 12, 9, 4},
		    {2, 4, 5, 4, 2}
        };
    }
}
