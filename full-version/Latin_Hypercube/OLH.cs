using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace Latin_Hypercube
{
    struct result_ls
    {
        public int[,] LH;
        public double[,] x;
        public double f;
    }
    struct children
    {
        public int[,] child1;
        public int[,] child2;
    }
    struct Fitness
    {
       public double F;
       public double[,] Dist;
    }
    class OLH
    {
        //RandGenNormal RNG = new RandGenNormal();
        public int[,] constructing_Latin_hypercube(int N, int P,Random rr)
        {
            int[,] LH = new int[N , P];
            ArrayList squence = new ArrayList();
            for (int jj = 0; jj < N; jj++)
            {
                for (int ii = 0; ii < P; ii++)
                    squence.Add(ii);
                for (int ii = 0; ii < P; ii++)
                {
                    int count = squence.Count;
                    int rand = rr.Next(count);
                    int _fetch = Convert.ToInt32(squence[rand]);
                    squence.Remove(_fetch);
                    LH[jj, ii] = _fetch;
                }
            }
            return LH;
        }
        public int[,] reinitilize(int N, int P, Random rr)
        {
            int[,] LH = new int[N, P];
            ArrayList squence = new ArrayList();
            for (int jj = 0; jj < N; jj++)
            {
                for (int ii = 0; ii < P; ii++)
                    squence.Add(ii);
                for (int ii = 0; ii < P; ii++)
                {
                    int count = squence.Count;
                    int rand = rr.Next(count);
                    int _fetch = Convert.ToInt32(squence[rand]);
                    squence.Remove(_fetch);
                    LH[jj, ii] = _fetch;
                }
            }
            return LH;
        }
        public children complex_crossover(int[,] par1, int[,] par2, int P, int N)
        {
            children ch = new children();
            return ch;
        }
        //public double F( int[,] X,int N,int P)
        //{
        //    int[,] LH = (int[,])X.Clone();
        //    double Fit = 0;
        //    double[,] dist = new double[P,P];
        //    double sum = 0;
        //    for (int ii = 0; ii < P-1; ii++)
        //        for (int kk = ii + 1; kk < P; kk++)
        //        {
        //            sum = 0;
        //            for (int jj = 0; jj < N; jj++)
        //                sum += Math.Pow((LH[jj, ii] - LH[jj, kk]), 2);
        //            dist[ii, kk] = Math.Sqrt(sum);
        //        }
        //    for (int ii = 0; ii < P; ii++)
        //        for (int jj = 0; jj < P; jj++)
        //            if(dist[ii,jj]!=0)
        //            Fit += 1 / Math.Pow(dist[ii,jj], 2);
        //    return Fit;
        //}
        public double F(int[,] X, int N, int P)
        {
            int[,] LH = (int[,])X.Clone();
            double Fit = 0;
            double[,] dist = new double[P, P];
            double sum = 0;
            for (int ii = 0; ii < P - 1; ii++)
                for (int kk = ii + 1; kk < P; kk++)
                {
                    sum = 0;
                    for (int jj = 0; jj < N; jj++)
                        sum += Math.Pow((LH[jj, ii] - LH[jj, kk]), 2);
                    dist[ii, kk] = Math.Sqrt(sum);
                    Fit += 1 / Math.Pow(dist[ii, kk], 2);
                }
            return Fit;
        }
         public Fitness F(int[,] X, int N, int P,int differentiative)
        {
            Fitness Dist = new Fitness();
            int[,] LH = (int[,])X.Clone();
            double Fit = 0;
            double[,] dist = new double[P, P];
            double sum = 0;
            for (int ii = 0; ii < P - 1; ii++)
                for (int kk = ii + 1; kk < P; kk++)
                {
                    sum = 0;
                    for (int jj = 0; jj < N; jj++)
                        sum += Math.Pow((LH[jj, ii] - LH[jj, kk]), 2);
                    dist[ii, kk] = Math.Sqrt(sum);
                    Fit += 1 / Math.Pow(dist[ii, kk], 2);
                }
            Dist.F = Fit;
            Dist.Dist = (double[,])dist.Clone();
            return Dist;
        }
        //public double F_Local(int[,] X, int N, int P,ref double[,] dist,int p1,int p2,int n)
        //{
        //    int[,] LH = (int[,])X.Clone();
        //    double[,] NewDist = (double[,])dist.Clone();
        //    double sum = 0;
        //    double sum_value = 0;
        //    for (int kk = 0; kk < p1-1; kk++)
        //    {
        //        sum = 0;
        //        for (int jj = 0; jj < N; jj++)
        //            sum += Math.Pow((LH[jj, p1] - LH[jj, kk]), 2);
        //        NewDist[kk, p1] = Math.Sqrt(sum);
        //        sum_value += NewDist[kk, p1] - dist[kk, p1];

        //    }
        //    for (int kk = 0; kk < p2-1; kk++)
        //    {
        //        sum = 0;
        //        for (int jj = 0; jj < N; jj++)
        //            sum += Math.Pow((LH[jj, p2] - LH[jj, kk]), 2);
        //        NewDist[kk, p2] = Math.Sqrt(sum);
        //        sum_value += NewDist[kk, p2] - dist[kk, p2];
        //    }
        //        if (sum_value < 0)
        //            dist = (double[,])NewDist.Clone();
        //    return sum_value;
        //}
        public double F_Maximin(int[,] X, int N, int P)
        {
            int[,] LH = (int[,])X.Clone();
            int Min = 1000;
            int[,] min = new int[P,P];
            for (int ii = 0; ii < P-1; ii++)
                for (int jj = ii + 1; jj < P; jj++)
                {

                    int d = 0;
                    for (int kk = 0; kk < N; kk++)
                        {
                           d +=Convert.ToInt32(Math.Pow(LH[kk, ii] - LH[kk, jj],2));
                        }
                    Min =Convert.ToInt32(Math.Min(d, Min));
                    min[ii, jj] = d;
                }
            return Min;
        }
        public double fitness(double Fmax, double Fmin, double F)
        {
            return ((Fmax + Fmin) - F);
        }
        public double[] cumsum_function(Latin_Hypercube[] LHyper,int pop_no)
        {
            double sum=0;
            double[] cumsum=new double[pop_no+1];
            for (int ii = 0; ii < pop_no; ii++)
            {
                sum += LHyper[ii].Fitness;
            }
            for (int ii = 1; ii < pop_no; ii++)
            {
                cumsum[ii] = (LHyper[ii].Fitness / sum)+cumsum[ii-1];
            }
            cumsum[pop_no] = 1;
            return cumsum;
        }
        public double[] cumsum_function_for_local_searches(loca_searches ls, int ls_method)
        {
            double sum = 0;
            double[] cumsum = new double[ls_method + 1];
            sum += ls.result_insert;
            sum += ls.result_inverse;
            sum += ls.result_swap;
            cumsum[0] = 0;
            cumsum[1] = (ls.result_insert / sum);
            cumsum[2] = cumsum[1] + (ls.result_inverse / sum);
            cumsum[3] = cumsum[2] + (ls.result_swap/ sum);
            return cumsum;
        }
        public int Select_with_Probability(Latin_Hypercube[] LHyper, int pop_no,Random rr)
        {
            double[] cumsum = cumsum_function(LHyper, pop_no);
            double rand=rr.NextDouble();
            int result_index = -1;
            for (int ii = 0; ii < pop_no; ii++)
            {
                if (rand > cumsum[ii]&&rand<cumsum[ii+1])
                {
                    result_index = ii;
                    break;
                }
            }
            if (result_index == -1)
                result_index = pop_no - 1;
            return result_index;
        }
        public int Select_with_Probability_for_local_Searches(loca_searches ls, int ls_method, Random rr)
        {
            double[] cumsum = cumsum_function_for_local_searches(ls, ls_method);
            double rand = rr.NextDouble();
            int result_index = -1;
            for (int ii = 0; ii < ls_method; ii++)
            {
                if (rand > cumsum[ii] && rand < cumsum[ii + 1])
                {
                    result_index = ii;
                    break;
                }
            }
            return result_index;
        }
        public int ranking_selection_for_lc(loca_searches ls, int ls_method, Random rr)
        {
            double[] temp = new double[3];
            int[] rank = new int[3];
            int result=-1;
            temp[0] = ls.result_insert; rank[0] = 0;
            temp[1] = ls.result_inverse; rank[1] = 1;
            temp[2] = ls.result_swap; rank[2] = 2;

            for (int ii = 0; ii < temp.Length - 1; ii++)
                for (int jj = ii + 1; jj < temp.Length; jj++)
                {
                    if (temp[ii] < temp[jj])
                    {
                        double temps = temp[ii];
                        temp[ii] = temp[jj];
                        temp[jj] = temps;
                        int rtemp = rank[ii];
                        rank[ii] = rank[jj];
                        rank[jj] = rtemp;
                    }
                }
            double p = 1;
            for (int ii = 0; ii < rank.Length; ii++)
            {
                temp[ii] = Math.Pow((1 - ((Convert.ToDouble(ii) + 1) / (rank.Length + 1))), p);
            }
            for (int ii = 0; ii < temp.Length; ii++)
                if (temp[ii] > rr.NextDouble())
                {
                    result = rank[ii];
                    break;
                }
            if (result == -1)
                result = rank[rank.Length - 1];
            return result;
        }
        public MOA_Node SA_local_search2(ref MOA_Node Node, int ls_method, int P, int N, Random rr, int iteration,double thresold)
        {
            MOA_Node results = new MOA_Node();
            double z2 = 0;
            double first_point = Node.f;
            for (int ii = 0; ii < iteration; ii++)
            {
                int[,] LH_temp = (int[,])Node.LH.Clone();
                double[,] node_temp = (double[,])Node.x.Clone();
                double z1 = F(LH_temp, N, P);
                int nrand = rr.Next(N);
                int P1 = rr.Next(P);
                int P2 = rr.Next(P);
                while (P1 == P2)
                    P2 = rr.Next(P);
                if (P1 > P2)
                {
                    int help = P1;
                    P1 = P2;
                    P2 = help;
                }
                if (ls_method == 0)
                {
                    z2 = insert2(nrand, P1, P2, ref LH_temp, ref node_temp, N, P);
                }
                else if (ls_method == 1)
                {
                    MOA_Node tempo = inverse2(nrand, P1, P2, LH_temp, node_temp, N, P);
                    z2 = tempo.f;
                    LH_temp = (int[,])tempo.LH.Clone();
                    node_temp = (double[,])tempo.x.Clone();
                }
                else
                {
                    z2 = swap2(nrand, P1, P2, ref LH_temp, ref node_temp, N, P);
                }

                double dz = z2 - z1;
                if (dz <= 0)
                {

                    Node.LH = (int[,])LH_temp.Clone();
                    Node.x = (double[,])node_temp.Clone();
                    Node.f = z2;
                }
                if (Node.f <= thresold)
                {
                    results.index=ii;
                    results.f=0;
                    return results;
                }
            }
            double test = F(convert_search_s_to_solution_s(Node.x, N, P), N, P);
            double last_point = F(Node.LH, N, P);
            double delta_tetha = (first_point - last_point) / iteration;
            results.f = delta_tetha;
            results.index = iteration;
            return results;
        }
        public double SA_local_search(ref MOA_Node Node, int ls_method, int P, int N, Random rr,int iteration)
        {
            double z2 = 0;
            double first_point = Node.f;
            for (int ii = 0; ii < iteration; ii++)
            {
                int[,] LH_temp = (int[,])Node.LH.Clone();
                double[,] node_temp = (double[,])Node.x.Clone();
                double z1 = F(LH_temp, N, P);
                int nrand = rr.Next(N);
                int P1 = rr.Next(P);
                int P2 = rr.Next(P);
                while (P1 == P2)
                    P2 = rr.Next(P);
                if (P1 > P2)
                {
                    int help = P1;
                    P1 = P2;
                    P2 = help;
                }
                
                if (ls_method == 0)
                {
                    z2 = insert2(nrand, P1, P2, ref LH_temp, ref node_temp, N, P);
                }
                else if (ls_method == 1)
                {
                    MOA_Node tempo = inverse2(nrand, P1, P2, LH_temp, node_temp, N, P);
                    z2 = tempo.f;
                    LH_temp = (int[,])tempo.LH.Clone();
                    node_temp = (double[,])tempo.x.Clone();
                }
                else
                {
                    z2 = swap2(nrand, P1, P2, ref LH_temp, ref node_temp, N, P);
                }

                double dz = z2 - z1;
                if (dz <= 0)
                {

                    Node.LH = (int[,])LH_temp.Clone();
                    Node.x = (double[,])node_temp.Clone();
                    Node.f = z2;
                }
            }
            double test = F(convert_search_s_to_solution_s(Node.x, N, P), N, P);
            double last_point = F(Node.LH, N, P);
            double delta_tetha = (first_point - last_point) / iteration;
            return delta_tetha;
        }

        public double SA_local_search_MPLS(ref MOA_Node Node, int P, int N, Random rr, int iteration)
        {
            double z2 = 0;
            double first_point = Node.f;
            for (int ii = 0; ii < iteration; ii++)
            {
                int[,] LH_temp = (int[,])Node.LH.Clone();
                double[,] node_temp = (double[,])Node.x.Clone();
                double z1 = F(LH_temp, N, P);
                int nrand = rr.Next(N);
                int P1 = rr.Next(P);
                int P2 = rr.Next(P);
                while (P1 == P2)
                    P2 = rr.Next(P);
                if (P1 > P2)
                {
                    int help = P1;
                    P1 = P2;
                    P2 = help;
                }
                int ls_method = rr.Next(0, 3);
                if (ls_method == 0)
                {
                    z2 = insert2(nrand, P1, P2, ref LH_temp, ref node_temp, N, P);
                }
                else if (ls_method == 1)
                {
                    MOA_Node tempo = inverse2(nrand, P1, P2, LH_temp, node_temp, N, P);
                    z2 = tempo.f;
                    LH_temp = (int[,])tempo.LH.Clone();
                    node_temp = (double[,])tempo.x.Clone();
                }
                else
                {
                    z2 = swap2(nrand, P1, P2, ref LH_temp, ref node_temp, N, P);
                }

                double dz = z2 - z1;
                if (dz <= 0)
                {

                    Node.LH = (int[,])LH_temp.Clone();
                    Node.x = (double[,])node_temp.Clone();
                    Node.f = z2;
                }
            }
            double test = F(convert_search_s_to_solution_s(Node.x, N, P), N, P);
            double last_point = F(Node.LH, N, P);
            double delta_tetha = (first_point - last_point) / iteration;
            return delta_tetha;
        }
        public double SA_local_search2(ref MOA_Node Node, int ls_method, int P, int N, Random rr, int iteration)
        {
            double z2 = 0;
            double first_point = Node.f;
            for (int ii = 0; ii < iteration; ii++)
            {
                int[,] LH_temp = (int[,])Node.LH.Clone();
                double[,] node_temp = (double[,])Node.x.Clone();
                double z1 = F_Maximin(LH_temp, N, P);
                int nrand = rr.Next(N);
                int P1 = rr.Next(P);
                int P2 = rr.Next(P);
                while (P1 == P2)
                    P2 = rr.Next(P);
                if (P1 > P2)
                {
                    int help = P1;
                    P1 = P2;
                    P2 = help;
                }
                if (ls_method == 0)
                {
                    z2 = insert2(nrand, P1, P2, ref LH_temp, ref node_temp, N, P,1);
                }
                else if (ls_method == 1)
                {
                    MOA_Node tempo = inverse2(nrand, P1, P2, LH_temp, node_temp, N, P,1);
                    z2 = tempo.f;
                    LH_temp = (int[,])tempo.LH.Clone();
                    node_temp = (double[,])tempo.x.Clone();
                }
                else
                {
                    z2 = swap2(nrand, P1, P2, ref LH_temp, ref node_temp, N, P,1);
                }

                double dz = z2 - z1;
                if (dz >= 0)
                {

                    Node.LH = (int[,])LH_temp.Clone();
                    Node.x = (double[,])node_temp.Clone();
                    Node.f = z2;
                }
            }
            double test = F(convert_search_s_to_solution_s(Node.x, N, P), N, P);
            double last_point = F_Maximin(Node.LH, N, P);
            double delta_tetha = (first_point - last_point) / iteration;
            return delta_tetha;
        }
        public children simple_Cross_over(int[,] LH1, int[,] LH2, int N, int P, Random rr)
        {
            children chil=new children();
            int[,] Child1 = new int[N, P];
            int[,] Child2 = new int[N, P];
            ArrayList L1 = new ArrayList();
            ArrayList L2 = new ArrayList();
            for (int ii = 0; ii < N; ii++)
            {
                L1.Clear();
                L2.Clear();
                for (int jj = 0; jj < P; jj++)
                {
                    L1.Add(LH1[ii,jj]);
                    L2.Add(LH2[ii,jj]);
                }

                int rand = rr.Next(1, P);
                for (int jj = 0; jj < rand; jj++)
                {
                    Child1[ii, jj] = LH1[ii, jj];
                    Child2[ii, jj] = LH2[ii, jj];
                    L1.Remove(LH1[ii, jj]);
                    L2.Remove(LH2[ii, jj]);
                }
                int kk = 0;
                for (int jj = rand ; jj < P; jj++)
                {
                    Child1[ii, jj] = (int)L1[kk];
                    Child2[ii, jj] = (int)L2[kk];
                    kk++;
                }

            }
            chil.child1=(int[,])Child1.Clone();
            chil.child2=(int[,])Child2.Clone();
            return chil;
        }
        public children double_Cross_over(int[,] LH1, int[,] LH2, int N, int P, Random rr)
        {
            children chil = new children();
            int[,] Child1 = new int[N, P];
            int[,] Child2 = new int[N, P];
            for(int ii=0;ii<N;ii++)
                for (int jj = 0; jj < P; jj++)
                {
                    Child1[ii, jj] = -1;
                    Child2[ii, jj] = -1;
                }
            ArrayList L1 = new ArrayList();
            ArrayList L2 = new ArrayList();
            for (int ii = 0; ii < N; ii++)
            {
                L1.Clear();
                L2.Clear();
                for (int jj = 0; jj < P; jj++)
                {
                    L1.Add(LH1[ii, jj]);
                    L2.Add(LH2[ii, jj]);
                }

                int rand = rr.Next(1, P);
                for (int jj = 0; jj < rand; jj++)
                {
                    int index = rr.Next(L1.Count);
                    int index2 = rr.Next(L1.Count);
                    Child1[ii, index] = LH1[ii, index];
                    Child2[ii, index2] = LH2[ii, index2];
                    L2.Remove(LH1[ii, index]);
                    L1.Remove(LH2[ii, index2]);
                }
                for (int jj = 0; jj < P; jj++)
                {
                    if (Child1[ii, jj] == -1)
                    {
                        Child1[ii,jj] =  (int)L2[0];
                        L2.RemoveAt(0);
                    }
                    if (Child2[ii, jj] == -1)
                    {
                        Child2[ii,jj] = (int)L1[0];
                        L1.RemoveAt(0);
                    }
                }
               
            }
            chil.child1 = (int[,])Child1.Clone();
            chil.child2 = (int[,])Child2.Clone();
            return chil;
        }
        public int[,] Local_Search(int[,] LH, int N, int P)
        {
            double best_fit = F(LH, N, P);
            int[,] LH_result = new int[N, P];
            for (int kk = 0; kk < N; kk++)
            for(int ii=0;ii<P;ii++)
                for (int ll = 0; ll < P ; ll++)
                {
                    if (ii != ll)
                    {
                        int temp = LH[kk, ii];
                        LH[kk, ii] = LH[kk, ll];
                        LH[kk, ll] = temp;
                        double temp_F = F(LH, N, P);
                        if (temp_F < best_fit)
                        {
                            best_fit = temp_F;
                            LH_result = (int[,])LH.Clone();
                        }

                        temp = LH[kk, ll];
                        LH[kk, ll] = LH[kk, ii];
                        LH[kk, ii] = temp;
                    }
                }
            return LH_result;
        }
        public void Topology_Update2(ref ArrayList[] N, int pop_no, Random rr,int t,int running_update_time)
        {
            int ii=0;
            if ((t % running_update_time) == 0 && t > 0)
            {
                while (ii < pop_no / 2)
                {
                    int particle = rr.Next(pop_no);
                    if (N[particle].Count > 2)
                    {
                        int nei = rr.Next(N[particle].Count);
                        int r = Convert.ToInt32(N[particle][nei]);
                        N[particle].Remove(r);
                        N[r].Remove(particle);
                        ii++;
                    }
                }
            }
        }
        public void Topology_Update(ref ArrayList[] N, int pop_no, int k,ref int estep, int t,Random rr)
        {
            if (t > 0 && t <= k && (t % (k / (pop_no - 3))) == 0)
            {
                for (int ii = 0; ii < (pop_no - (estep + 2)); ii++)
                {
                    int particle = rr.Next(pop_no);
                    if (N[particle].Count > 2)
                    {
                        int nei = rr.Next(N[particle].Count);
                        int r = Convert.ToInt32(N[particle][nei]);
                        N[particle].Remove(r);
                        N[r].Remove(particle);
                    }
                }
                estep++;
            }
        }
        public double[,] Opposition_Learning(double[,] x,int N,int P)
        {
            double[,] Ox = new double[N,P];
            for (int ii = 0; ii < N; ii++)
                for (int jj = 0; jj < P; jj++)
                Ox[ii,jj] = 1-x[ii,jj];
            return Ox;
        }
        public loca_searches Local_Searches(int[,] LH, double[,] x, int N, int P)
        {
            loca_searches ls = new loca_searches();
            double first_fit = F(LH, N, P);
            result_ls best_swap = new result_ls(); result_ls best_insert = new result_ls(); result_ls best_inverse = new result_ls();
            best_insert.f = 10000; best_inverse.f = 10000; best_swap.f = 10000;
            Random rr = new Random();
            //for (int kk = 0; kk < N; kk++)
            //    for (int ii = 0; ii < P - 1; ii++)
            //        for (int ll = ii + 1; ll < P; ll++)
            //        {
            for (int iii = 0; iii < 10; iii++)
            {
                int kk = rr.Next(N);
                int ii = rr.Next(P);
                int ll = rr.Next(P);
                if (ii != ll)
                {
                    int p1 = ii;
                    int p2 = ll;
                    if (ii > ll)
                    {
                        int temp = p1;
                        p1 = p2;
                        p2 = temp;
                    }
                    result_ls temp_swap = swap(kk, p1, p2, LH, x, N, P);
                    result_ls temp_insert = insert(kk, p1, p2, LH, x, N, P);
                    MOA_Node temp_inverse = inverse2(kk, p1, p2, LH, x, N, P);
                    if (best_swap.f > temp_swap.f)
                    {
                        best_swap.f = temp_swap.f;
                        best_swap.LH = (int[,])temp_swap.LH.Clone();
                        best_swap.x = (double[,])temp_swap.x.Clone();
                    }
                    if (best_insert.f > temp_insert.f)
                    {
                        best_insert.f = temp_insert.f;
                        best_insert.LH = (int[,])temp_insert.LH.Clone();
                        best_insert.x = (double[,])temp_inverse.x.Clone();
                    }
                    if (best_inverse.f > temp_inverse.f)
                    {
                        best_inverse.f = temp_inverse.f;
                        best_inverse.LH = (int[,])temp_inverse.LH.Clone();
                        best_inverse.x = (double[,])temp_inverse.x.Clone();
                    }
                }
            }
            //double all = N * P * (P - 1);
            double all = 1000;
            ls.result_insert = (first_fit - best_insert.f) / all;
            ls.result_inverse = (first_fit - best_inverse.f) / all;
            ls.result_swap = (first_fit - best_swap.f) / all;
            if (ls.result_insert > ls.result_inverse)
                if (ls.result_insert > ls.result_swap)
                {
                    ls.LH = (int[,])best_insert.LH.Clone();
                    ls.x = (double[,])best_insert.x.Clone();
                }
                else
                {
                    ls.LH = (int[,])best_swap.LH.Clone();
                    ls.x = (double[,])best_swap.x.Clone();
                }
            else if (ls.result_inverse > ls.result_swap)
            {
                ls.LH = (int[,])best_inverse.LH.Clone();
                ls.x = (double[,])best_inverse.x.Clone();
            }
            else
            {
                ls.LH = (int[,])best_swap.LH.Clone();
                ls.x = (double[,])best_swap.x.Clone();
            }
            return ls;
        }
        public MOA_Node[] cellular_MAMOA(Latin_Hypercube[] LHC, MOA_Node[] Nodes, MOA_Node[] NeiNodes, int pop_no)
        {
            double y = 0.5;
            int L = Convert.ToInt32(Math.Floor(Math.Pow(Convert.ToDouble(pop_no), y)));
            int row = 0; int column = 0;
            int pop_no2 = Convert.ToInt32(Math.Pow(L, 2));
            int[] neighbor = new int[5];
            for (int ii = 0; ii < pop_no; ii++)
            {
                row = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(ii / L)));
                column = ((ii) % L);
                neighbor[0] = ii - 1;
                neighbor[1] = ii + 1;
                neighbor[2] = ii + L;
                neighbor[3] = ii - L;
                if (column == 0)
                    neighbor[0] = ii + L - 1;
                if (column == L - 1)
                    neighbor[1] = ii - L + 1;
                if (row == L - 1 && pop_no == pop_no2)
                    neighbor[2] = ii - (L - 1) * L;
                else if (row == L && pop_no2 != pop_no)
                    neighbor[2] = ii - (L) * L;
                if (row == 0 && pop_no == pop_no2)
                    neighbor[3] = ii + (L - 1) * L;
                else if (row == 0 && pop_no2 != pop_no)
                    neighbor[3] = ii + (L) * L;
                neighbor[4] = ii;
                double min = LHC[neighbor[0]].F;
                int min_index = 0;
                for (int jj = 0; jj < 5; jj++)
                {
                    if (neighbor[jj] > pop_no)
                        neighbor[jj] = ii - 1;
                    if (min > LHC[neighbor[jj]].F)
                    {
                        min = LHC[neighbor[jj]].F;
                        min_index = jj;
                    }
                }
                if (NeiNodes[ii].f > min)
                {
                    NeiNodes[ii].x = (double[,])Nodes[neighbor[min_index]].x;
                    NeiNodes[ii].f = min;
                    NeiNodes[ii].LH = (int[,])LHC[neighbor[min_index]].LH.Clone();
                    NeiNodes[ii].index = neighbor[min_index];
                }
            }
            return NeiNodes;
        }
        public result_ls swap(int n, int pos1, int pos2, int[,] LH, double[,] node, int N, int P)
        {
            result_ls rs = new result_ls();
            int[,] lh_temp = (int[,])LH.Clone();
            int temp = lh_temp[n, pos1];
            lh_temp[n, pos1] = lh_temp[n, pos2];
            lh_temp[n, pos2] = temp;
            double[,] x = (double[,])node.Clone();
            double temp_x = x[n, pos1];
            x[n, pos1] = x[n, pos2];
            x[n, pos2] = temp_x;
            rs.f = F(lh_temp, N, P);
            rs.LH = (int[,])lh_temp.Clone();
            rs.x = (double[,])x.Clone();
            return rs;
        }
        public result_ls insert(int n, int pos1, int pos2, int[,] LH, double[,] node, int N, int P)
        {
            int[,] lh_temp = (int[,])LH.Clone();
            double[,] x = (double[,])node.Clone();
            result_ls rs = new result_ls();
            double position = x[n, pos1];
            for (int ii = pos1; ii < pos2 - 1; ii++)
            {
                lh_temp[n, ii] = lh_temp[n, ii + 1];
                x[n, ii] = x[n, ii + 1];
            }
            x[n, pos2 - 1] = position;
            lh_temp[n, pos2 - 1] = LH[n, pos1];
            rs.f = F(lh_temp, N, P);
            rs.LH = (int[,])lh_temp.Clone();
            rs.x = (double[,])x.Clone();
            return rs;
        }
        public result_ls inverse(int n, int pos1, int pos2, int[,] LH, int N, int P)
        {
            int[,] help = (int[,])LH.Clone();
            result_ls rs = new result_ls();
            int kk = pos1;
            int item = LH[n, kk];
            for (int ii = pos2; ii > pos1; ii--)
                help[n, kk++] = LH[n, ii];
            help[n, pos2] = item;
            rs.f = F(help, N, P);
            rs.LH = (int[,])help.Clone();
            return rs;
        }
        public double swap(int n,int pos1, int pos2, int[,] LH,int N,int P)
        {
            int[,] lh_temp = (int[,])LH.Clone();
            int temp = lh_temp[n, pos1];
            lh_temp[n, pos1] = lh_temp[n, pos2];
            lh_temp[n, pos2] = temp;
            return F(lh_temp, N, P);
        }
        public double insert(int n,int pos1, int pos2, int[,] LH,int N,int P)
        {
            int[,] lh_temp = (int[,])LH.Clone();
            for (int ii = pos1; ii < pos2-1; ii++)
                lh_temp[n, ii] = lh_temp[n, ii + 1];
            lh_temp[n, pos2 - 1] = LH[n, pos1];
            return F(lh_temp, N, P);
        }
        public double inverse2(int n,int pos1, int pos2, int[,] LH,int N,int P)
        {
            int[,] help = (int[,])LH.Clone();
            int kk=pos1;
            int item = LH[n, kk];
            for (int ii = pos2; ii > pos1; ii--)
                help[n, kk++] = LH[n, ii];
            help[n, pos2] = item;
            return F(help, N, P);
        }
        public double swap2(int n, int pos1, int pos2, ref int[,] LH, ref double[,] x, int N, int P)
        {
            int temp = LH[n, pos1];
            LH[n, pos1] = LH[n, pos2];
            LH[n, pos2] = temp;
            double temp_x = x[n, pos1];
            x[n, pos1] = x[n, pos2];
            x[n, pos2] = temp_x;
            return F(LH, N, P);
        }
        public double insert2(int n, int pos1, int pos2, ref int[,] LH, ref double[,] x, int N, int P)
        {
            int item=LH[n, pos1];
            double position=x[n, pos1];
            for (int ii = pos1; ii < pos2 - 1; ii++)
            {
                LH[n, ii] = LH[n, ii + 1];
                x[n, ii] = x[n, ii + 1];
            }
            LH[n, pos2 - 1] = item;
            x[n, pos2 - 1] =position ;
            return F(LH, N, P);
        }
        public MOA_Node inverse2(int n, int pos1, int pos2, int[,] LH, double[,] x, int N, int P)
        {
            MOA_Node help = new MOA_Node();
            help.LH = (int[,])LH.Clone();
            help.x = (double[,])x.Clone();
            int kk = pos1;
            int item = LH[n, kk];
            double item_x = x[n, kk];
            for (int ii = pos2; ii > pos1; ii--)
            {
                help.LH[n, kk] = LH[n, ii];
                help.x[n, kk++] = x[n, ii];
            }
            help.LH[n, pos2] = item;
            help.x[n, pos2] = item_x;
            help.f = F(help.LH, N, P);
            return help;
        }
        public double swap2(int n, int pos1, int pos2, ref int[,] LH, ref double[,] x, int N, int P,int maximin)
        {
            int temp = LH[n, pos1];
            LH[n, pos1] = LH[n, pos2];
            LH[n, pos2] = temp;
            double temp_x = x[n, pos1];
            x[n, pos1] = x[n, pos2];
            x[n, pos2] = temp_x;
            return F_Maximin(LH, N, P);
        }
        public double insert2(int n, int pos1, int pos2, ref int[,] LH, ref double[,] x, int N, int P,int maximin)
        {
            double test = F_Maximin(convert_search_s_to_solution_s(x, N, P), N, P);
            int item = LH[n, pos1];
            double position = x[n, pos1];
            for (int ii = pos1; ii < pos2 - 1; ii++)
            {
                LH[n, ii] = LH[n, ii + 1];
                x[n, ii] = x[n, ii + 1];
            }
            LH[n, pos2 - 1] = item;
            x[n, pos2 - 1] = position;
            test = F_Maximin(convert_search_s_to_solution_s(x, N, P), N, P);
            return F_Maximin(LH, N, P);
        }
        public MOA_Node inverse2(int n, int pos1, int pos2, int[,] LH, double[,] x, int N, int P, int maximin)
        {
            MOA_Node help = new MOA_Node();
            help.LH = (int[,])LH.Clone();
            help.x = (double[,])x.Clone();
            int kk = pos1;
            int item = LH[n, kk];
            double item_x = x[n, kk];
            for (int ii = pos2; ii > pos1; ii--)
            {
                help.LH[n, kk] = LH[n, ii];
                help.x[n, kk++] = x[n, ii];
            }
            help.LH[n, pos2] = item;
            help.x[n, pos2] = item_x;
            help.f = F_Maximin(help.LH, N, P);
            return help;
        }
        public int[,] mutation(int[,] LH, int N, int P, Random rr)
        {
            for (int ii = 0; ii < N; ii++)
            {
                int r1 = rr.Next(P);
                int r2 = rr.Next(P);
                while (r1 == r2)
                    r2 = rr.Next(P);
                int temp = LH[ii, r1];
                LH[ii, r1] = LH[ii, r2];
                LH[ii, r2] = temp;

            }
            return LH;
        }
        public double[,,] construct_plh(int N, int P)
        {
            double[, ,] PLH = new double[N, P, P];
            for (int ii = 0; ii < N; ii++)
                for (int jj = 0; jj < P; jj++)
                    for (int kk = 0; kk < P; kk++)
                        PLH[ii, jj, kk] = 0.5;
            return PLH;
        }
        public double best_for_iter(Latin_Hypercube[] LH, int pop_no)
        {
            double min = 10000;
            for (int ii = 0; ii < pop_no; ii++)
                if (min > LH[ii].F)
                    min = LH[ii].F;
            return min;
        }
        public double diversity(Latin_Hypercube[]olh, int pop_no, int N, int P)
        {
            double[] Ni = new double[pop_no];
            double diver = 0;
            double iter = 0;
            ArrayList differs = new ArrayList();
            double differ = 0;
            for (int ii = 0; ii < pop_no - 1; ii++)
                for (int jj = ii + 1; jj < pop_no; jj++)
                {
                    differ = 0;
                    iter = 0;
                    for (int cc = 0; cc < N; cc++)
                        for (int dd = 0; dd < P; dd++)
                        {
                            if (olh[ii].LH[cc, dd] != olh[jj].LH[cc, dd])
                                differ++;
                            iter++;
                        }

                    differs.Add(differ / iter);
                }
            differ = 0;
            for (int ii = 0; ii < differs.Count; ii++)
                differ += (double)differs[ii];

            diver = differ / (differs.Count - 1);
            return diver;
        }
        public int[,]local_search_SA(int[,]LH,int P,int N,double T,double zp,Random rr ,double cr)
        {

            while (T > zp)
            {
                int[,] LH_temp = (int[,])LH.Clone();
                double z1 = F(LH_temp, N, P);
                int nrand = rr.Next(N);
                int P1 = rr.Next(P);
                int P2 = rr.Next(P);
                while (P1 == P2)
                    P2 = rr.Next(P);
                int temp = LH_temp[nrand, P1];
                LH_temp[nrand, P1] = LH_temp[nrand, P2];
                LH_temp[nrand, P2] = temp;
                double z2 = F(LH_temp, N, P);
                double dz = z2 - z1;
                if (dz <= 0 || Math.Exp(-dz / T) > rr.NextDouble())
                {
                    LH = (int[,])LH_temp.Clone();
                }

                T = T * cr;
            }
            return LH;
        }
        public int[,] local_search_randomness(int[,] LH, int P, int N, double T, double zp, Random rr, double cr)
        {
            int[,] LH_temp = (int[,])LH.Clone();
            int[,] Best = (int[,])LH.Clone();
            double z1 = F(LH_temp, N, P);
            while (T > zp)
            {
                LH_temp = (int[,])LH.Clone();
                int nrand = rr.Next(N);
                int P1 = rr.Next(P);
                int P2 = rr.Next(P);
                while (P1 == P2)
                    P2 = rr.Next(P);
                int temp = LH_temp[nrand, P1];
                LH_temp[nrand, P1] = LH_temp[nrand, P2];
                LH_temp[nrand, P2] = temp;
                double z2 = F(LH_temp, N, P);
                double dz = z2 - z1;
                if (dz <= 0 )
                {
                    z1 = z2;
                    Best = (int[,])LH_temp.Clone();
                }

                T = T * cr;
            }
            return LH;
        }
       public string array_to_string(int[,]LH,int N,int P)
       {
           string result="";
           for (int ii = 0; ii < N; ii++)
               for (int jj = 0; jj < P; jj++)
                   result += LH[ii, jj]+" ";
           return result;
       }
       public double[,] node_constructing(int N, int P, Random rr)
       {
           double[,] x = new double[N, P];
           for (int ii = 0; ii < N; ii++)
               for (int jj = 0; jj < P; jj++)
                   x[ii, jj] = rr.NextDouble();
           return x;
       }
       public int[,] convert_search_s_to_solution_s(double[,] x, int N, int P)
       {
           int[,] LH = new int[N, P];
           LHs[] lhs;
           MergeSort Ms = new MergeSort();
           for (int ii = 0; ii < N; ii++)
           {
               lhs = new LHs[P];
               for (int jj = 0; jj < P; jj++)
               {
                   lhs[jj].position = x[ii, jj];
                   lhs[jj].index = jj;
               }
               LHs[] res=Ms.mergesort(lhs, P);
               for (int jj = 0; jj < P; jj++)
               {
                   LH[ii, res[jj].index] = jj;
               }
           }
           return LH;
       }
       public MOA_Node[] cellular(Latin_Hypercube[] LHC, Latin_Hypercube[] Nei, MOA_Node[] Nodes, MOA_Node[] NeiNodes, int pop_no)
       {
           double y = 0.5;
           int L = Convert.ToInt32(Math.Floor(Math.Pow(Convert.ToDouble(pop_no), y)));
           int row = 0; int column = 0;
           int pop_no2 = Convert.ToInt32(Math.Pow(L, 2));
           int[] neighbor = new int[5];
           for (int ii = 0; ii < pop_no; ii++)
           {
               row = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(ii / L)));
               column = ((ii) % L);
               neighbor[0] = ii - 1;
               neighbor[1] = ii + 1;
               neighbor[2] = ii + L;
               neighbor[3] = ii - L;
               if (column == 0)
                   neighbor[0] = ii + L - 1;
               if (column == L - 1)
                   neighbor[1] = ii - L + 1;
               if (row == L - 1 && pop_no == pop_no2)
                   neighbor[2] = ii - (L - 1) * L;
               else if (row == L && pop_no2 != pop_no)
                   neighbor[2] = ii - (L) * L;
               if (row == 0 && pop_no == pop_no2)
                   neighbor[3] = ii + (L - 1) * L;
               else if (row == 0 && pop_no2 != pop_no)
                   neighbor[3] = ii + (L) * L;
               neighbor[4] = ii;
               double min = LHC[neighbor[0]].F;
               int min_index = 0;
               for (int jj = 0; jj < 5; jj++)
               {
                   if (neighbor[jj] > pop_no)
                       neighbor[jj] = ii - 1;
                   if (min > LHC[neighbor[jj]].F)
                   {
                       min = LHC[neighbor[jj]].F;
                       min_index = jj;
                   }
               }
               if (Nei[ii].F > min)
               {
                   NeiNodes[ii].x = (double[,])Nodes[neighbor[min_index]].x;
                   NeiNodes[ii].f = min;
                   NeiNodes[ii].index = neighbor[min_index];
               }
           }
           return NeiNodes;
       }
       public MOA_Node[] Define_Local_Best(ArrayList[] N, Latin_Hypercube[] LHC, MOA_Node[] Nodes, MOA_Node[] NeiNodes, int pop_no)
       {
           for (int ii = 0; ii < pop_no; ii++)
           {
               double min = 10000;
               int min_index = 0;
               for (int jj = 0; jj < N[ii].Count; jj++)
               {
                   int temp = Convert.ToInt32(N[ii][jj]);
                   if (min > LHC[temp].F)
                   {
                       min = LHC[temp].F;
                       min_index = temp;
                   }
               }

               NeiNodes[ii].x = (double[,])Nodes[min_index].x;
               NeiNodes[ii].f = min;
               NeiNodes[ii].index = min_index;
           }
           return NeiNodes;
       }
       public MOA_Node[] StructureCore(Latin_Hypercube[] LHC,  MOA_Node[] Nodes, MOA_Node[] NeiNodes, int pop_no, string str, Random rr)
       {
           for (int ii = 0; ii < pop_no; ii++)
           {

               int[] neighbor = Structures(ii, pop_no, str,rr);
               double min = 1000;
               int min_index = 0;
               for (int jj = 0; jj < neighbor.Length; jj++)
               {
                   if (neighbor[jj] > pop_no)
                       neighbor[jj] = ii - 1;
                   if (min > LHC[neighbor[jj]].F)
                   {
                       min = LHC[neighbor[jj]].F;
                       min_index = jj;
                   }
               }
               //if (Nei[ii].F > min)
               //{
               if (neighbor.Length > 0)
               {
                   NeiNodes[ii].x = (double[,])Nodes[neighbor[min_index]].x;
                   NeiNodes[ii].f = min;
                   NeiNodes[ii].index = neighbor[min_index];
               }
           }
           return NeiNodes;
       }
       public MOA_Node[] DynamicStructureCore(Latin_Hypercube[] LHC, Latin_Hypercube[] Nei, MOA_Node[] Nodes, MOA_Node[] NeiNodes, int pop_no,int iteration,Random rr,int declination_range,ref int L)
       {
           
           if ((iteration%declination_range)==0 && iteration!=0)
               L--;
           int[] neighbor = new int[2*L];
           for (int ii = 0; ii < pop_no; ii++)
           {
                int kk = 0;
                for (int jj = 1; jj <= L; jj++)
                {
                    neighbor[kk++] = ii - jj;
                    neighbor[kk++] = ii +jj;
                    if (neighbor[kk - 2] < 0)
                        neighbor[kk - 2] = pop_no - Convert.ToInt32(Math.Abs(ii - jj));
                    if (neighbor[kk-1] > pop_no - 1)
                        neighbor[kk-1] = (ii+jj)-pop_no;
                }
               int min_index = 0;
               double min = 1000;
               for (int jj = 0; jj < neighbor.Length; jj++)
               {
                   if (neighbor[jj] > pop_no)
                       neighbor[jj] = ii - 1;
                   if (min > LHC[neighbor[jj]].F)
                   {
                       min = LHC[neighbor[jj]].F;
                       min_index = jj;
                   }
               }
               //if (Nei[ii].F > min)
               //{
                    NeiNodes[ii].x = (double[,])Nodes[neighbor[min_index]].x;
                   NeiNodes[ii].f = min;
                   NeiNodes[ii].index = neighbor[min_index];
               //}
           }
           return NeiNodes;
       }
       public int[] Structure_selection(int ii,int iteration, int pop_no,string state,Random rr)
       {
           int[] neighbor={0,1};
           if (state == "random")
           {
               if (iteration < 100)
                   neighbor = randoms(4, pop_no,rr);
               else if (iteration < 700)
                   neighbor = randoms(2, pop_no, rr);
               //else if (iteration < 700)
               //    neighbor = cellular_structure(ii, pop_no);
               else
                   neighbor = randoms(6, pop_no, rr);
           }
           else
           {
               if (iteration < 100)
                   neighbor = Star_structure(ii, pop_no);
               else if (iteration < 700)
                   neighbor = cellular_structure(ii, pop_no);
               //else if (iteration < 700)
               //    neighbor = cellular_structure(ii, pop_no);
               else
                   neighbor = randoms(2, pop_no, rr);
           }
           return neighbor;
       }
       public MOA_Node[] DynamicStructureCore2(Latin_Hypercube[] LHC, Latin_Hypercube[] Nei, MOA_Node[] Nodes, MOA_Node[] NeiNodes, int pop_no, int iteration, Random rr, int declination_range, ref int L)
       {
           for (int ii = 0; ii < pop_no; ii++)
           {
               string state = "random";
               int[] neighbor = Structure_selection(ii,iteration, pop_no,state,rr);
               double min = 1000;
               int min_index = 0;
               for (int jj = 0; jj < neighbor.Length; jj++)
               {
                   if (neighbor[jj] > pop_no)
                       neighbor[jj] = ii - 1;
                   if (min > LHC[neighbor[jj]].F)
                   {
                       min = LHC[neighbor[jj]].F;
                       min_index = jj;
                   }
               }
               if (NeiNodes[ii].f > 0)
               {
                   NeiNodes[ii].x = (double[,])Nodes[neighbor[min_index]].x;
                   NeiNodes[ii].f = min;
                   NeiNodes[ii].index = neighbor[min_index];
               }
           }
           return NeiNodes;
       }
       public int[] Structure_selection2( int pop_no,int iteration,int portion, Random rr,int ii)
       {
           int[] neighbor = { 0, 1 };
           int defaults =1+ iteration / portion;
           //if (defaults > pop_no / 10)
           ////    defaults = pop_no/10;
           //neighbor = randoms(defaults, pop_no, rr);
           neighbor = Regulated_Dynamic_structure(defaults, pop_no,ii);
           return neighbor;
       }
       public int[] Regulated_Dynamic_structure(int L, int pop_no,int ii)
       {
           int[] neighbor = new int[2 * L];
               int kk = 0;
               for (int jj = 1; jj <= L; jj++)
               {
                   neighbor[kk++] = ii - jj;
                   neighbor[kk++] = ii + jj;
                   if (neighbor[kk - 2] < 0)
                       neighbor[kk - 2] = pop_no - Convert.ToInt32(Math.Abs(ii - jj));
                   if (neighbor[kk - 1] > pop_no - 1)
                       neighbor[kk - 1] = (ii + jj) - pop_no;
               }
               //neighbor[neighbor.Length - 1] = ii;
               
           return neighbor;
       }
       public double Normal_Distribution(Random rand)
       {
           double u1 = rand.NextDouble(); //these are uniform(0,1) random doubles
           double part1 = 1 / (Math.Sqrt(2 * Math.PI));
           double part2 = Math.Exp(-0.5 * Math.Pow(u1, 2));
           return part1*part2;
       }
   
       public MOA_Node[] DynamicStructureCore3(Latin_Hypercube[] LHC, Latin_Hypercube[] Nei, MOA_Node[] Nodes, MOA_Node[] NeiNodes, int portion, int iteration,int pop_no, Random rr)
       {
           for (int ii = 0; ii < pop_no; ii++)
           {
               int[] neighbor = Structure_selection2(pop_no, iteration, portion, rr,ii);
               double min = 1000;
               int min_index = 0;
               for (int jj = 0; jj < neighbor.Length; jj++)
               {
                   if (neighbor[jj] > pop_no)
                       neighbor[jj] = ii - 1;
                   if (min > LHC[neighbor[jj]].F)
                   {
                       min = LHC[neighbor[jj]].F;
                       min_index = jj;
                   }
               }
               if (NeiNodes[ii].f > 0)
               {
                   NeiNodes[ii].x = (double[,])Nodes[neighbor[min_index]].x;
                   NeiNodes[ii].f = min;
                   NeiNodes[ii].index = neighbor[min_index];
               }
           }
           return NeiNodes;
       }
       public MOA_Node[] define_pbest(Latin_Hypercube[] LHC, MOA_Node[] Nodes, MOA_Node[] NeiNodes, int pop_no)
       {
           for (int ii = 0; ii < pop_no; ii++)
           {
               if (NeiNodes[ii].f > LHC[ii].F)
               {
                   NeiNodes[ii].x = (double[,])Nodes[ii].x;
                   NeiNodes[ii].f = LHC[ii].F;
                   NeiNodes[ii].LH = (int[,])LHC[ii].LH.Clone();
               }
           }
           return NeiNodes;
       }
       public MOA_Node[] define_pbest2(MOA_Node[] Nodes, MOA_Node[] NeiNodes, int pop_no)
       {
           for (int ii = 0; ii < pop_no; ii++)
           {
               if (NeiNodes[ii].f > Nodes[ii].f)
               {
                   NeiNodes[ii].x = (double[,])Nodes[ii].x;
                   NeiNodes[ii].f = Nodes[ii].f;
                   NeiNodes[ii].LH = (int[,])Nodes[ii].LH.Clone();
               }
           }
           return NeiNodes;
       }
       public void compute_Snq(ref double[,]Snq, int n, int q,double[]fm,int[,,]Zmnq,int M)
       {
           for (int ii = 0; ii < n; ii++)
               for (int jj = 0; jj < q; jj++)
               {
                   double zsum=0;
                   double fz = 0;
                   for (int kk = 0; kk < M; kk++)
                   {
                       zsum+= Zmnq[kk, ii, jj];
                       fz += fm[kk] * Zmnq[kk, ii, jj];
                   }
                   Snq[ii, jj] = fz / zsum;
               }
       }

       public MOA_Node[] define_pbest2(Latin_Hypercube[] LHC, MOA_Node[] Nodes, MOA_Node[] NeiNodes, int pop_no)
       {
           for (int ii = 0; ii < pop_no; ii++)
           {
               if (NeiNodes[ii].f < LHC[ii].F)
               {
                   NeiNodes[ii].x = (double[,])Nodes[ii].x;
                   NeiNodes[ii].f = LHC[ii].F;
                   NeiNodes[ii].LH = (int[,])LHC[ii].LH.Clone();
               }
           }
           return NeiNodes;
       }
       public int[] sq_rand_gen2(int width, int Max, Random rr)
       {
           int[] sq_rand = new int[width];
           ArrayList squence = new ArrayList();
           for (int ii = 0; ii < Max; ii++)
               squence.Add(ii);
           for (int ii = 0; ii < width; ii++)
           {
               int count = squence.Count;
               int rand = rr.Next(count);
               int _fetch = Convert.ToInt32(squence[rand]);
               squence.Remove(_fetch);
               sq_rand[ii] = _fetch;
           }
           return sq_rand;
       }
       public int[] cellular_structure(int ii,int pop_no)
       {
           double y = 0.5;
           int L = Convert.ToInt32(Math.Floor(Math.Pow(Convert.ToDouble(pop_no), y)));
           int row = 0; int column = 0;
           int pop_no2 = Convert.ToInt32(Math.Pow(L, 2));
           int[] neighbor = new int[4];
               row = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(ii / L)));
               column = ((ii) % L);
               neighbor[0] = ii - 1;
               neighbor[1] = ii + 1;
               neighbor[2] = ii + L;
               neighbor[3] = ii - L;
               if (column == 0)
                   neighbor[0] = ii + L - 1;
               if (column == L - 1)
                   neighbor[1] = ii - L + 1;
               if (row == L - 1 && pop_no == pop_no2)
                   neighbor[2] = ii - (L - 1) * L;
               else if (row == L && pop_no2 != pop_no)
                   neighbor[2] = ii - (L) * L;
               if (row == 0 && pop_no == pop_no2)
                   neighbor[3] = ii + (L - 1) * L;
               else if (row == 0 && pop_no2 != pop_no)
                   neighbor[3] = ii + (L) * L;
               
           return neighbor;
       }
       public int[] grid_structure(int ii, int pop_no)
       {
           double y = 0.5;
           int L = Convert.ToInt32(Math.Floor(Math.Pow(Convert.ToDouble(pop_no), y)));
           int row = 0; int column = 0;
           int pop_no2 = Convert.ToInt32(Math.Pow(L, 2));
           ArrayList neighbour = new ArrayList();
           row = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(ii / L)));
           column = ((ii) % L);
           neighbour.Add(ii - 1);
           neighbour.Add(ii + 1);
           neighbour.Add(ii + L);
           neighbour.Add(ii - L);
           for (int dd = 0; dd < neighbour.Count; dd++)
           {
               int temp=(int)neighbour[dd];
               if ( temp< 0 || temp > pop_no - 1)
                   neighbour.RemoveAt(dd);
           }
           int[] neighbor = (int[])neighbour.ToArray(Type.GetType("System.Int32"));
           return neighbor;
       }
       public double[,] PO_construction(int D,MOA_Node[]Pi,MOA_Node[]Pn,int N,int P,ref int func_eval,int index_pop,ref ArrayList Costs)
       {
           double[,] Snq = new double[D, 2];
           int M = 0;
           int[,] L = OA(D, ref M);
           int[,,] Zmnq = new int[M, D,2];
           for(int ii=0;ii<M;ii++)
               for(int jj=0;jj<D;jj++)
                   for (int kk = 1; kk <= 2; kk++)
                   {
                       if (L[ii, jj] == kk)
                           Zmnq[ii, jj, kk - 1] = 1;
                   }

           int[] indexes = new int[N * P];
           MOA_Node[] X = new MOA_Node[M];
           MOA_Node Xb = new MOA_Node();
           Xb.f = 10000;
           double[] fm = new double[M];
           for (int jj = 0; jj < M; jj++)
           {
               X[jj].x = new double[N, P];
               int index = 0;
               for (int ii = 0; ii < N; ii++)
                   for (int kk = 0; kk < P; kk++)
                   {
                       if (L[jj, index] == 1)
                           X[jj].x[ii, kk] = Pi[index_pop].x[ii, kk];
                       else
                           X[jj].x[ii, kk] = Pn[index_pop].x[ii, kk];
                   }
                       X[jj].LH = convert_search_s_to_solution_s(X[jj].x, N, P);
                       X[jj].f = F(X[jj].LH, N, P);
                       func_eval++;
                       fm[jj] = X[jj].f;
                       if (X[jj].f < Xb.f)
                       {
                           Xb.f = X[jj].f;
                           Xb.x = (double[,])X[jj].x.Clone();
                           Xb.LH = (int[,])X[jj].LH.Clone();
                       }
                       Costs.Add(Xb.f);

           }
           compute_Snq(ref Snq,D, 2, fm, Zmnq, M);
           double[,] Xp = new double[N , P];
           double[,] Xtest = new double[N , P];
           int ind_sol = 0;
           double Fit = 100000;
               ind_sol = 0;
               for (int ii = 0; ii < N; ii++)
                   for (int jj = 0; jj < P; jj++)
                       if (Snq[ind_sol, 0] < Snq[ind_sol, 1])
                       {
                           Xtest[ii, jj] = Pi[index_pop].x[ii, jj];
                       }
                       else
                       {
                           Xtest[ii, jj] = Pn[index_pop].x[ii, jj];
                       }
               int[,] LH = convert_search_s_to_solution_s(Xtest, N, P);
               double ff=F(LH,N,P);
               
               func_eval++;
               if (Fit > ff)
               {
                   Fit = ff;
                   Xp=(double[,])Xtest.Clone();
               }
               Costs.Add(Fit);
           double[,] PO = new double[N, P];
           if (Fit < Xb.f)
           {
               PO = (double[,])Xp.Clone();
           }
           else
           {
               PO = (double[,])Xb.x.Clone();
           }
           return PO;
       }
       public int[] ladder_structure(int ii, int pop_no)
       {
           double pop = Convert.ToDouble(pop_no);
           int L = Convert.ToInt32(Math.Floor(pop/2));
           ArrayList neighbour = new ArrayList();
           neighbour.Add(ii - 1);
           neighbour.Add(ii + 1);
           if (ii < L)
           {
               if (neighbour.Contains(-1))
                   neighbour.Remove(ii - 1);
               if (neighbour.Contains(L))
                   neighbour.Remove(L);
               neighbour.Add(ii + L);
           }
           else
           {
               if (neighbour.Contains(L))
                   neighbour.Remove(L);
               if (neighbour.Contains(pop_no))
                   neighbour.Remove(pop_no);
               neighbour.Add(ii - L);
           }
           int[] neighbor = (int[])neighbour.ToArray(Type.GetType("System.Int32"));
           return neighbor;
       }
       public int[] cross_ladder_structure(int ii, int pop_no)
       {
           double pop = Convert.ToDouble(pop_no);
           int L = Convert.ToInt32(Math.Floor(pop / 2));
           ArrayList neighbour = new ArrayList();
           neighbour.Add(ii - 1);
           neighbour.Add(ii + 1);
           if (ii < L)
           {
               if (neighbour.Contains(-1))
                   neighbour.Remove(-1);
               if (neighbour.Contains(L))
                   neighbour.Remove(L);
               neighbour.Add(ii + L);
               neighbour.Add(ii + L - 1);
               if (neighbour.Contains(L))
                   neighbour.Remove(L);
               neighbour.Add(ii + L + 1);
               if (neighbour.Contains(pop_no))
                   neighbour.Remove(pop_no);
           }
           else
           {
               if (neighbour.Contains(L))
                   neighbour.Remove(L);
               if (neighbour.Contains(pop_no))
                   neighbour.Remove(pop_no);
               neighbour.Add(ii - L);
               neighbour.Add(ii - L - 1);
               if (neighbour.Contains(-1))
                   neighbour.Remove(-1);
               neighbour.Add(ii - L + 1);
               if (neighbour.Contains(L))
                   neighbour.Remove(L);
           }
           int[] neighbor = (int[])neighbour.ToArray(Type.GetType("System.Int32"));
           return neighbor;
       }
       public int[] Btree_structure(int ii, int pop_no)
       {
           ArrayList neighbour = new ArrayList();
           Queue<int> Q = new Queue<int>();
           do
           {
               if ((2 * ii + 1) < pop_no)
               {
                   neighbour.Add(2 * ii + 1);
                   Q.Enqueue(2 * ii + 1);
               }
               if ((2 * ii + 2) < pop_no)
               {
                   neighbour.Add(2 * ii + 2);
                   Q.Enqueue(2 * ii + 2);
               }
               if (Q.Count > 0)
               {
                   ii = Q.Dequeue();
               }
           } while (2*ii+1<pop_no||Q.Count>0);
           int[] neighbor = (int[])neighbour.ToArray(Type.GetType("System.Int32"));
           return neighbor;
       }
       public int[] Star_structure(int ii, int pop_no)
       {
           int[] neighbor = new int[pop_no-1];
           int kk = 0;
           for (int jj = 0; jj < pop_no;jj++)
               if(jj!=ii)
               neighbor[kk++] = jj;

           return neighbor;
       }
    public int[] randoms(int width, int Max, Random rr)
    {
        int []sq_rand = new int[width];
        ArrayList squence = new ArrayList();
        for (int ii = 0; ii < Max; ii++)
            squence.Add(ii);
        for (int ii = 0; ii < width; ii++)
        {
            int count = squence.Count;
            int rand = rr.Next(count);
            int _fetch = Convert.ToInt32(squence[rand]);
            squence.Remove(_fetch);
            sq_rand[ii]=_fetch;
        }
        return sq_rand;
    }
       public void Short_Range_Operation1(ref double[,] x, int dim, int points, int P, Random rr)
       {
           for(int ii=0;ii<dim;ii++)
               for (int jj = 0; jj < points; jj++)
               {
                   int rand = rr.Next(P);
                   x[ii, rand] = rr.NextDouble();
               }
       }
       public void Short_Range_Operation2(ref double[,] x, int N, int P, double CSRR, Random rr)
       {
           for (int ii = 0; ii < N; ii++)
               for (int jj = 0; jj < P; jj++)
               {
                   x[ii, jj] +=2* CSRR * rr.NextDouble()-CSRR;
               }
       }
       public void Short_Range_Operation3(ref double[,] F, int N, int P, double CSRR, Random rr)
       {
           for (int ii = 0; ii < N; ii++)
               for (int jj = 0; jj < P; jj++)
               {
                   F[ii, jj] =40* CSRR * rr.NextDouble()-20*CSRR;
               }
       }
       public int[] Cluster_structure(int ii, int pop_no, int cluster_size)
       {
           ArrayList neighbors = new ArrayList();
           int first_neighbour = (ii / cluster_size) * cluster_size;
           int[] neighbour1 = new int[2];
           int end_neighbour = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(ii+1) / cluster_size)) * cluster_size;
           if ((ii % cluster_size) != 0||ii==0)
           {
               for (int jj = first_neighbour; jj < end_neighbour; jj++)
                   neighbors.Add(jj);
           }
           else if ((ii % 5) == 0 && ii != 0)
           {
               int cluster = ii / (cluster_size);
               neighbour1[0] = (cluster - 1) * 5;
               if (neighbour1[0] <= 0)
                   neighbour1[0] = cluster_size;
               neighbour1[1] = (cluster + 1) * 5;
               if (neighbour1[1] >= pop_no)
                   neighbour1[1] = pop_no-1;
               neighbors.Add(neighbour1[0]); neighbors.Add(neighbour1[1]);
               first_neighbour = ((ii - 1) / cluster_size) * cluster_size + 1;
               end_neighbour = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(ii - 1) / cluster_size)) * cluster_size;
               for (int jj = first_neighbour; jj < end_neighbour; jj++)
                   if (!neighbors.Contains(jj))
                       neighbors.Add(jj);
           }
        int[] neighbor = (int[])neighbors.ToArray(System.Type.GetType("System.Int32"));

           return neighbor;
       }
       public int[] Bipartie_structure(int ii, int pop_no)
       {
           double pop = Convert.ToDouble(pop_no);
           int L = Convert.ToInt32(Math.Floor(pop / 2));
           int[] neighbor = new int[L];
           if (ii < L)
           {
               for (int jj = L, kk=0; jj < pop_no; jj++,kk++)
                   neighbor[kk] = jj;
           }
           else
           {
               for (int jj = 0; jj < L; jj++)
                   neighbor[jj] = jj;
           }
           return neighbor;
       }
       public int[] Ring(int ii, int pop_no)
       {
           int[] neighbor = new int[2];
               neighbor[0] = ii - 1;
               neighbor[1] = ii + 1;
               if (neighbor[0] < 0)
                   neighbor[0] = pop_no - 1;
               if (neighbor[1] > (pop_no - 1))
                   neighbor[1] = 0;
           return neighbor;
       }
       public int[] Structures(int ii, int pop_no, string structure,Random rr)
       {
           int[] neighbours = {0, 1};
           if (structure == "Ring")
               neighbours = Ring(ii, pop_no);
           else if (structure == "Star")
               neighbours = Star_structure(ii, pop_no);
           else if (structure == "Btree")
               neighbours = Btree_structure(ii, pop_no);
           else if (structure == "Bipartie")
               neighbours = Bipartie_structure(ii, pop_no);
           else if (structure == "Cluster")
               neighbours = Cluster_structure(ii, pop_no, 5);
           else if (structure == "Grid")
               neighbours = grid_structure(ii, pop_no);
           else if (structure == "Ladder")
               neighbours = ladder_structure(ii, pop_no);
           else if (structure == "Cross-Ladder")
               neighbours = cross_ladder_structure(ii, pop_no);
           else if (structure == "Cellular")
               neighbours = cellular_structure(ii, pop_no);
           else if (structure == "random2")
               neighbours = randoms(2, pop_no, rr);
           else if (structure == "random5")
               neighbours = randoms(5, pop_no, rr);
           else if (structure == "random20")
               neighbours = randoms(20, pop_no, rr);
               for (int jj = 0; jj < neighbours.Length; jj++)
                   if (neighbours[jj] < 0 || neighbours[jj] >= pop_no)
                       neighbours[jj] = ii;

           return neighbours;
       }
       public MOA_Node[] cellular2(Latin_Hypercube[] LHC, Latin_Hypercube[] Nei, MOA_Node[] Nodes, MOA_Node[] NeiNodes, int pop_no)
       {
           double y = 0.5;
           int L = Convert.ToInt32(Math.Floor(Math.Pow(Convert.ToDouble(pop_no), y)));
           int row = 0; int column = 0;
           int pop_no2 = Convert.ToInt32(Math.Pow(L, 2));
           int[] neighbor = new int[5];
           for (int ii = 0; ii < pop_no; ii++)
           {
               row = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(ii / L)));
               column = ((ii) % L);
               neighbor[0] = ii - 1;
               neighbor[1] = ii + 1;
               neighbor[2] = ii + L;
               neighbor[3] = ii - L;
               if (column == 0)
                   neighbor[0] = ii + L - 1;
               if (column == L - 1)
                   neighbor[1] = ii - L + 1;
               if (row == L - 1 && pop_no == pop_no2)
                   neighbor[2] = ii - (L - 1) * L;
               else if (row == L && pop_no2 != pop_no)
                   neighbor[2] = ii - (L) * L;
               if (row == 0 && pop_no == pop_no2)
                   neighbor[3] = ii + (L - 1) * L;
               else if (row == 0 && pop_no2 != pop_no)
                   neighbor[3] = ii + (L) * L;
               neighbor[4] = ii;
               double min = LHC[neighbor[0]].F;
               int min_index = 0;
               for (int jj = 0; jj < 5; jj++)
               {
                   if (neighbor[jj] > pop_no)
                       neighbor[jj] = ii - 1;
                   if (min > LHC[neighbor[jj]].F)
                   {
                       min = LHC[neighbor[jj]].F;
                       min_index = jj;
                   }
               }
               if (Nei[ii].F > min)
               {
                   NeiNodes[ii].x = (double[,])Nodes[neighbor[min_index]].x;
               }
           }
           return NeiNodes;
       }

       public MOA_Node[] mergesort(MOA_Node[] CV, int n)
       {
           if (n == 1) return CV;
           int k = n / 2;
           MOA_Node[] l2 = new MOA_Node[k];
           if ((n % 2) != 0)
               k++;
           MOA_Node[] l1 = new MOA_Node[k];
           for (int i = 0; i < k; i++)
               l1[i] = CV[i];
           for (int j = k; j < n; j++)
               l2[j - k] = CV[j];
           l1 = mergesort(l1, l1.Length);
           l2 = mergesort(l2, l2.Length);
           return merge(l1, l2);
       }

       private MOA_Node[] merge(MOA_Node[] a, MOA_Node[] b)
       {
           MOA_Node[] c = new MOA_Node[a.Length + b.Length];
           int k = 0; int p = 0; int q = 0;
           while (a.Length > p && b.Length > q)
           {
               if (a[p].f > b[q].f)
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

       public double[] Min_max_all(int n,int pos, MOA_Node[] Pop)
       {
           double[] temp = new double[2];
           double min = 1000;
           double max = -1000;
           for (int ii = 0; ii < Pop.Length; ii++)
           {
               if (max < Pop[ii].x[n,pos])
                   max = Pop[ii].x[n,pos];
               if (min > Pop[ii].x[n,pos])
                   min = Pop[ii].x[n,pos];
           }
           temp[0] = min;
           temp[1] = max;
           return temp;
       }
       public double Cauchy(Random rr, double median, double formFactor)
       {
           double u, v;
           do
           {
               u = 2.0 * rr.NextDouble() - 1.0;
               v = 2.0 * rr.NextDouble() - 1.0;
           }
           while (u * u + v * v > 1.0 || (u == 0.0 && v == 0.0));

           if (u != 0)
               return (median + formFactor * (v / u));
           else
               return (median);
       }
       //public double Normal_Distribution(Random rand, double mean, double stdev)
       //{
       //    double u1 = 0; double u2 = 0; double w = 0;
       //    do
       //    {
       //        u1 = 2 * rand.NextDouble() - 1;
       //        u2 = 2 * rand.NextDouble() - 1;
       //        w = u1 * u1 + u2 * u2;
       //    } while (w >= 1);

       //    w = Math.Sqrt((-2.0 * Math.Log(w)) / w);
       //    return mean + (u2 * w) * stdev;
       //}
       public double[,] Concatenation(double[,] best,int position,int N, int swarm_size, double[,] x)
       {
           double[,] result = (double[,])best.Clone();
           int index = 0;
           for (int ii = position; ii < position + swarm_size; ii++)
           {
               for (int jj = 0; jj < N; jj++)
               result[jj,ii] = x[jj,index];
               index++;
           }
           return result;
       }
       public int[] Ring_withmyself(int ii, int pop_no)
       {
           int[] neighbor = new int[3];
           neighbor[0] = ii - 1;
           neighbor[1] = ii + 1;
           neighbor[2] = ii;
           if (neighbor[0] < 0)
               neighbor[0] = pop_no - 1;
           if (neighbor[1] > (pop_no - 1))
               neighbor[1] = 0;
           return neighbor;
       }
       public double Normal_Distribution(Random rand, double mean, double stdev)
       {
           double u1 = 0; double u2 = 0; double w = 0;
           do
           {
               u1 = 2 * rand.NextDouble() - 1;
               u2 = 2 * rand.NextDouble() - 1;
               w = u1 * u1 + u2 * u2;
           } while (w >= 1);

           w = Math.Sqrt((-2.0 * Math.Log(w)) / w);
           return mean + (u2 * w) * stdev;
       }
       public double Cauchy_mu(Random rr)
       {
           return Math.Tan(Math.PI * (rr.NextDouble() - 0.5));
       }
       public bool similarity(double[,] x1, double[,] x2,double N, double P)
       {
           for (int ii = 0; ii < N; ii++)
               for (int jj = 0; jj < P; jj++)
               if (x1[ii,jj] != x2[ii,jj])
                   return false;
           return true;
       }
       public double mean_simple(ArrayList A)
       {
           double sum = 0; double sum2 = 0;
           for (int ii = 0; ii < A.Count; ii++)
           {
               sum += Convert.ToDouble(A[ii]);
               sum2 += Math.Pow(Convert.ToDouble(A[ii]), 2);
           }
           return sum2 / sum;
       }
       public double mean_Lehmer(ArrayList A)
       {
           double sum = 0;
           for (int ii = 0; ii < A.Count; ii++)
           {
               sum += Convert.ToDouble(A[ii]);
           }
           return sum / A.Count;
       }
       public double get_t_quantile(double alpha, int nb_exp,double[,]t_table,bool next = false)
       {
           int pos = -1;
           for (int i = 0; i < 6; i++)
               if (t_table[0,i] == alpha)
               {
                   pos = i;
                   break;
               }
           if (next) pos++; //(1-alpha/2) quantile
           if (nb_exp > 100) nb_exp = 101;
           return (t_table[nb_exp,pos]);
       }
       //public void clustering(ref double[] orders, int II,ref int index, R[,]Rha)
       //{
       //    double temp = Rha[II, index].Cost;
       //    if (Rha[II, index - 1].Cost == temp)
       //    {
       //        orders[index]++;
       //        index--;
       //        clustering(ref orders, II, ref index, Rha);
       //    }
       //}
       public void Mutation_BGA(ref MOA_Node indi, MOA_Node[] Pop,int N, int P, Random rr)
       {
           double num = 16;
           double pai = 1.0 / num;
           for (int ii=0; ii < N; ii++)
           {
               int pos = rr.Next(P);
               double rangi = 0; double min = 0; double max = 0;
               int i;
               double dif = 0;
               double sum = 0;
               double[] temp = Min_max_all(ii,pos, Pop);
               min = temp[0];
               max = temp[1];
               rangi = 0.1 * (max - min);

               for (i = 0, dif = 1; i < num; i++, dif /= 2)
               {
                   if (rr.NextDouble() < pai)
                   {
                       sum += dif;
                   }

               }

               double value = indi.x[ii,pos];
               if (sum != 0)
               {
                   // Obtain the sign
                   if (rr.NextDouble() < 0.5)
                   {
                       value += rangi * sum;

                       if (value > max)
                       {
                           value = max;
                       }
                   }
                   else
                   {
                       value -= rangi * sum;

                       if (value < min)
                       {
                           value = min;
                       }
                   }
               }

               indi.x[ii,pos] = value;
           }
       }
       public int negative_assortative_mating_strategy(double[,] x,int N,int P, MOA_Node[] Pop, Random rr)
       {
           double max = -1000;
           int index = 0;
           int[] p = new int[3];
           p[0] = rr.Next(Pop.Length);
           p[1] = rr.Next(Pop.Length);
           p[2] = rr.Next(Pop.Length);
           for (int ii = 0; ii < p.Length; ii++)
           {
               double temp = 0;
               for (int jj = 0; jj < N; jj++)
                   for (int kk = 0; kk < P; kk++)
                       temp += Math.Abs(Pop[p[ii]].x[jj, kk] - x[jj, kk]);
               if (max < temp)
               {
                   max = temp;
                   index = ii;
               }
           }
           return index;
       }
       public double[,] BLX_Crossover(int N,int P,double[,] x1, double[,] x2)
       {
           Random rr = new Random();
           double[,] breed = new double[N, P]; 
           for (int ii = 0; ii < N; ii++)
            for (int jj = 0; jj < P; jj++)
           {
               double CMin = Min(x1[ii,jj], x2[ii,jj]);
               double CMax = Max(x1[ii,jj], x2[ii,jj]);
               double I = (CMax - CMin) * 0.5;
               double A1 = CMin - I;
               if (A1 < CMin)
                   A1 = CMin;
               double B1 = CMax + I;
               if (B1 > CMax)
                   B1 = CMax;
               breed[ii,jj] = A1 + rr.NextDouble() * (B1 - A1);
           }

           return breed;
       }
       public double Min(double x1, double x2)
       {
           double min = 1000;
           if (x1 < min)
               min = x1;
           if (x2 < min)
               min = x2;


           return min;
       }
       public double Max(double x1, double x2)
       {
           double min = -1000;

           if (x1 > min)
               min = x1;
           if (x2 > min)
               min = x2;

           return min;
       }
       //public void SolisWets(ref double[,] Sol, ref double fitness_Sol, int N,int P, ref  double[,] bias, ref double rho, int MaxEval, Random rand)
       //{
       //    Form1 form = new Form1();
       //    int numSuccess = 0;
       //    int NumFailed = 0;
       //    double[,] dif = new double[N,P];
       //    double[,] Solprim = new double[N,P];
       //    double[,] Solzegon = new double[N,P];
       //    double fitness_Sol_prim = 0;
       //    double fitness_Sol_zegon = 0;
       //    RNG.Variance = rho;
       //    for (int numEval = 0; numEval < MaxEval; numEval++)
       //    {
       //        for (int ii = 0; ii < N; ii++)
       //            for (int jj = 0; jj < P; jj++)
       //            {
       //                dif[ii,jj] = RNG.NextDouble();
       //                Solprim[ii,jj] = Sol[ii,jj] + bias[ii,jj] + dif[ii,jj];
       //            }
       //        Solprim = form.Node_treatment(Solprim,N,P, rand);
       //        int[,] LH = convert_search_s_to_solution_s(Solprim, N, P);
       //        fitness_Sol_prim = F(LH, N, P);
       //        if (fitness_Sol > fitness_Sol_prim)
       //        {
       //            Sol = (double[,])Solprim.Clone();
       //            fitness_Sol = fitness_Sol_prim;
       //            for (int ii = 0; ii < N; ii++)
       //                for (int jj = 0; jj < P; jj++)
       //                {
       //                    bias[ii,jj] = 0.2 * bias[ii, jj] + 0.4 * (dif[ii, jj] + bias[ii, jj]);
       //                }
       //            numSuccess++;
       //            NumFailed = 0;
       //        }
       //        else
       //        {
       //            for (int ii = 0; ii < N; ii++)
       //                for (int jj = 0; jj < P; jj++)
       //                Solzegon[ii,jj] = Sol[ii,jj] - bias[ii,jj] - dif[ii,jj];
       //            Solzegon = form.Node_treatment(Solzegon, N, P, rand);
       //            LH = convert_search_s_to_solution_s(Solzegon, N, P);
       //            fitness_Sol_zegon = F(LH, N, P);
       //            if (fitness_Sol_zegon < fitness_Sol)
       //            {
       //                Sol = (double[,])Solzegon.Clone();
       //                fitness_Sol = fitness_Sol_zegon;
       //                for (int ii = 0; ii < N; ii++)
       //                    for (int jj = 0; jj < P; jj++)
       //                    {
       //                        bias[ii,jj] = bias[ii,jj] - 0.4 * (dif[ii,jj] + bias[ii,jj]);
       //                    }
       //                numSuccess++;
       //                NumFailed = 0;

       //            }
       //            else
       //            {
       //                NumFailed++;
       //                numSuccess = 0;
       //            }

       //        }

       //        if (numSuccess > 5)
       //        {
       //            rho *= 2;
       //            numSuccess = 0;
       //        }
       //        else if (NumFailed > 3)
       //        {
       //            rho /= 2;
       //            NumFailed = 0;
       //        }
       //    }

       //}
       public LS[] Remove_Unchanged_particle(LS[] LS_S)
       {
           LS[] Result = new LS[LS_S.Length - 1];
           for (int ii = 0; ii < Result.Length; ii++)
               Result[ii] = LS_S[ii + 1];
           return Result;
       }
       public void Perturbation(ref int[,] LH,Random rand,int N,int P)
       {
           int p1 = rand.Next(P);
           int p2 = rand.Next(P);
           if (p2 < p1)
           {
               int temp = p2;
               p2 = p1;
               p1 = temp;
           }
           int l = rand.Next(N);
           int[,] LH_temp = (int[,])LH.Clone();
           for (int ii = p1; ii <= p2; ii++)
           {
               int kk = ii+1;
               if (kk == (p2 + 1))
                   kk = p1;
                   LH_temp[l, ii] = LH[l, kk];

           }
           LH = (int[,])LH_temp.Clone();
       }
       public int[,] OA(int D,ref int M)
       {
           M =Convert.ToInt32(Math.Pow(2,Math.Ceiling(Math.Log(D + 1, 2))));
           int N = M - 1;
           int u = Convert.ToInt32(Math.Log(M, 2));
           int[,] L = new int[M, N];
           for(int a=0;a<M;a++)
               for (int kk = 0; kk < u; kk++)
               {
                   int b=Convert.ToInt32(Math.Pow(2,kk-1));
                   int aa = a + 1;
                   int k = kk + 1;
                   L[a,b]=Convert.ToInt32(Math.Floor((aa-1)/(Math.Pow(2,u-k)))%2);
               }
           for(int a=0;a<M;a++)
               for (int kk = 0; kk < u; kk++)
               {
                   int b = Convert.ToInt32(Math.Pow(2, kk - 1));
                   for (int s = 0; s < b - 1; s++)
                   {
                       L[a, b + s] = (L[a, s] + L[a, b]) % 2;
                   }
               }
           for(int a=0;a<M;a++)
               for (int b = 0; b < N; b++)
               {
                   if (L[a, b] == 0)
                       L[a, b] = 1;
                   else if (L[a, b] == 1)
                       L[a, b] = 2;
               }
           return L;
       }
    }
}
