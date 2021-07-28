using System.Collections.Generic;

namespace LeetCode
{
    class Solution
    {
        private void Update(int[] tree, int i, int val)
        {
            while (i < tree.Length)
            {
                tree[i] += val;
                i += i & -i;
            }
        }

        private int GetSum(int[] tree, int i)
        {
            int s = 0;
            while (i > 0)
            {
                s += tree[i];
                i -= i & -i;
            }
            return s;
        }

        public int[] ProcessQueries(int[] queries, int m)
        {
            var tree = new int[2 * m + 1];
            var result = new int[queries.Length];
            var dictionary = new Dictionary<int, int>();
            for (var i = 1; i <= m; ++i)
            {
                dictionary[i] = i + m;
                Update(tree, i + m, 1);
            }

            for (var i = 0; i < queries.Length; i++)
            {
                var query = queries[i];
                result[i] = GetSum(tree, dictionary[query]) - 1;
                Update(tree, dictionary[query], -1);
                Update(tree, m, 1);
                dictionary[query] = m;
                m--;
            }
            return result;
        }
    }
}
