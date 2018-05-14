using System;
using System.Collections.Generic;
using System.Text;

namespace Latin_Hypercube
{
    struct LHs
    {
        public double position;
        public int index;
    }
    class MergeSort
    {
        public LHs[] mergesort(LHs[] CV, int n)
        {
            if (n == 1) return CV;
            int k = n / 2;
            LHs[] l2 = new LHs[k];
            if ((n % 2) != 0)
                k++;
            LHs[] l1 = new LHs[k];
            for (int i = 0; i < k; i++)
                l1[i] = CV[i];
            for (int j = k; j < n; j++)
                l2[j - k] = CV[j];
            l1 = mergesort(l1, l1.Length);
            l2 = mergesort(l2, l2.Length);
            return merge(l1, l2);
        }

        private LHs[] merge(LHs[] a, LHs[] b)
        {
            LHs[] c = new LHs[a.Length + b.Length];
            int k = 0; int p = 0; int q = 0;
            while (a.Length > p && b.Length > q)
            {
                if (a[p].position > b[q].position)
                    c[k++] = b[q++];
                else
                    c[k++] = a[p++];
            }
            while (a.Length > p)
                c[k++] = a[p++];
            while (b.Length > q)
                c[k++] = b[q++];

            return c;
        }
    }
}
