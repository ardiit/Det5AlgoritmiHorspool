using System;
using System.Collections.Generic;

namespace Det5AlgoritmiHorspoolit
{
    class Program
    {
        static void Main(string[] args)
        {
			IDictionary<string, string> LOTR = new Dictionary<string, string>
			{
				{ "Lord of the Ring", "There is only one Lord of the Ring." },
				{ "to", "Only one who can bend it to his will" },
				{ "And", "And he does not share power." },
				{ "future", "Even the smallest person can change the course of the future." },
				{ "simple", "Oh, it’s quite simple. If you are a friend." },
				{ "speak", "You speak the password, and the doors will open."},
			};

			foreach(KeyValuePair<string, string> keyValuePair in LOTR)
            {
				Console.WriteLine();
                int[] arr = SearchString(keyValuePair.Key, keyValuePair.Value);
				foreach(int i in arr)
                {
					Console.Write(i);
                }
            }

		}


		public static int[] SearchString(string pat, string str)
		{
			List<int> retVal = new List<int>();
			int m = pat.Length;
			int n = str.Length;

			int[] badChar = new int[1000];

			BadCharHeuristic(pat, m, ref badChar);

			int s = 0;
			while (s <= (n - m))
			{
				int j = m - 1;

				while (j >= 0 && pat[j] == str[s + j])
					--j;

				if (j < 0)
				{
					retVal.Add(s);
					s += (s + m < n) ? m - badChar[str[s + m]] : 1;
				}
				else
				{
					s += Math.Max(1, j - badChar[str[s + j]]);
				}
			}

			return retVal.ToArray();
		}

		private static void BadCharHeuristic(string str, int size, ref int[] badChar)
		{
			int i;

			for (i = 0; i < 256; i++)
				badChar[i] = -1;

			for (i = 0; i < size; i++)
				badChar[(int)str[i]] = i;
		}

	}

}
