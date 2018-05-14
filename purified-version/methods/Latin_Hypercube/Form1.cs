using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Collections;
namespace Latin_Hypercube
{
    struct Swarms
    {
        public MOA_Node[] particles;

    }
        struct Collection_of_Set
    {
        public string s;
        public int frequently;
        public double fitness;
        public SortedList<int, int> SL;
        public int size_summit;
    }
        struct R
        {
           public double Cost;
           public int conf;
           public double value;
        }
        struct loca_searches
        {
            public double result_swap;
            public double result_insert;
            public double result_inverse;
            public int[,] LH;
            public double[,] x;
        }
        struct LS
        {
            public double[,] x;
            public double F;
            public double[,] bias;
            public double rho;
            public int visited;
        }
    struct Latin_Hypercube
    {
        public int[,] LH;
        public double Fitness;
        public double F;
    }
    struct MOA_Node
    {
        public double[,] x;
        public int[,] LH;
        public double f;
        public int index;
    }
     struct TT_Queue
    {
        public double Best_cost;
        public int[,] Best_Neighbour;
    }
    public partial class Form1 : Form
    {
        StreamWriter sw;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "MAPSO";
            comboBox3.Text = "Audze-Eglais";
            orgMOA.Checked = false;
            SA.Enabled = false;
            GA.Enabled = false;
            PSO.Enabled = false;
            MOA.Enabled = false;
            Mu1.Text = ".005";
            Mu2.Text = ".005";
            Mu_step.Text = ".005";
            cr1.Text = ".5";
            cr2.Text = ".5";
            cr_step.Text = ".005";
            //button1.Enabled = false;
            TExp_text.Text = ".005";
            Cexp_text.Text = "0.005";
            Exp.Text = "NO";
            CSRR_text.Text = "0.5";
            ISSR_combo.Text = "0";
            SHR.Text = "0.01";
            D.Text = "1";
            cmin.Text = "0.9";
            cmax.Text = "0.9";
            c_step.Text = "0.1";
            cmin21.Text = "0.9";
            cmin22.Text = "0.9";
            c2_step.Text = "0.1";
            Wmin.Text = "0.9";
            Wmax.Text = "0.9";
            W_step.Text = "0.9";
            Ac.Text = "0";
            D.Text = "1";
            Inten.Text = "1";
            Al.Text = ".1";
            Inten2.Text = "1";
            Al2.Text = ".1";
            Inten_step.Text = ".1";
            Al_step.Text = ".1";
            NT.Text = "30";
            NI.Text = "20000";
            NP.Text = "5";
            NPO.Text = "100";
            //NE.Text = "2";
            NPO2.Text = "100";
            //NE2.Text = "2";
            NPO_step.Text = "1";
            NE_step.Text = "1";
            comboBox2.Text = "Cellular";
            N1.Text = "120";
            N2.Text = "120";
            N_s.Text = "20";
            colrate1.Text = ".91";
            colrate2.Text = ".99";
            col_step.Text = "0.02";
            T1.Text = "100";
            T2.Text = "1000";
            T_step.Text = "900";
            LI.Text = "100";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //ArrayList aa = new ArrayList();
            //StreamReader SR2 = new StreamReader("cost_n_5p_200_pop_OrthogonalPSO.txt");
            //string SS=SR2.ReadToEnd();
            //string[] sasa = SS.Split(' ','\n');
            //double[]sas=new double[100000];
            //for (int ii = 0; ii < 100000; ii++)
            //    if (sasa[ii] != " ")
            //        sas[ii] = Convert.ToDouble(sasa[ii]);
            //double xx = 10000;
            //for (int iii = 0; iii < sas.Length; iii++)
            //{
            //    xx = sas[iii]; 
            //    for (int jjj = 0; jjj < iii; jjj++)
            //    {
            //        if (sas[jjj] < xx)
            //        {
            //            xx = sas[jjj];
            //        }
            //    }
            //    sas[iii] = xx;

            //}
            //StreamWriter sass = new StreamWriter("OPSO.txt");
            //for (int uuu = 0; uuu < sas.Length; uuu++)
            //{
            //    sass.Write(sas[uuu]+" ");
            //}
            //sass.Close();
            //StreamReader SR = new StreamReader("t-table.txt");
            //string file = SR.ReadToEnd();
            //string[] FF = file.Split('\n');
            double[,] t_table = new double[102, 7];
            //int kkkk = 0;
            //for (int ii = 0; ii < FF.Length; ii++)
            //{
            //    string[] temp = FF[ii].Split(' ');
            //    for (int jj = 0; jj < temp.Length; jj++)
            //        if (temp[jj] != "")
            //            t_table[ii, kkkk++] = Convert.ToDouble(temp[jj]);
            //    kkkk = 0;
            //}
            #region Initialization
            string Criterion = "";
            int Ntest = Convert.ToInt32(NT.Text);
            int NPop = Convert.ToInt32(NP.Text);
            int Iteration = Convert.ToInt32(NI.Text);
            int NPoint1 = Convert.ToInt32(NPO.Text);
            int NPoint2 = Convert.ToInt32(NPO2.Text);
            int Point_step = Convert.ToInt32(NPO_step.Text);
            int NExperiment1 = Convert.ToInt32(NE.Text);
            int NExperiment2 = Convert.ToInt32(NE2.Text);
            int Experiment_step = Convert.ToInt32(NE_step.Text);
            string dimension = "2 10,3 10,4 10,5 10,6 10,2 14,3 14,4 14,2 18,3 18,2 22,2 26,2 30";
            string[] dimen = dimension.Split(',');
            int[] Ns = new int[dimen.Length];
            int[] Ps = new int[dimen.Length];
            for (int ii = 0; ii < dimen.Length; ii++)
            {
                string[] temps = dimen[ii].Split(' ');
                Ns[ii] = Convert.ToInt32(temps[0]);
                Ps[ii] = Convert.ToInt32(temps[1]);
            }
            string structure = "";
            if (comboBox2.Text == "Ring")
                structure = "Ring";
            else if (comboBox2.Text == "Star")
                structure = "Star";
            else if (comboBox2.Text == "Btree")
                structure = "Btree";
            else if (comboBox2.Text == "Bipartie")
                structure = "Bipartie";
            else if (comboBox2.Text == "Cluster")
                structure = "Cluster";
            else if (comboBox2.Text == "Grid")
                structure = "Grid";
            else if (comboBox2.Text == "Ladder")
                structure = "Ladder";
            else if (comboBox2.Text == "Cross-Ladder")
                structure = "Cross-Ladder";
            else if (comboBox2.Text == "Cellular")
                structure = "Cellular";
            else if (comboBox2.Text == "random2")
                structure = "random2";
            else if (comboBox2.Text == "random5")
                structure = "random5";
            else if (comboBox2.Text == "random20")
                structure = "random20";
            else if (comboBox2.Text == "Dynamic")
                structure = "Dynamic";
            else if (comboBox2.Text == "RDynamic")
                structure = "RDynamic";
            else if (comboBox2.Text == "RRDynamic")
                structure = "RRDynamic";
            else if (comboBox2.Text == "Frankenstein")
                structure = "Frankenstein";
            string method = comboBox1.Text;
            
            if (comboBox3.Text == "Audze-Eglais")
                Criterion = "Audze-Eglais";
            else if (comboBox3.Text == "RLDs")
                Criterion = "RLDs";
            else
                Criterion = "Maximin";
            OLH LH_Class = new OLH();
            #endregion
            #region LatinHypercube
            if (Criterion != "RLDs")
            {
                //int[] Pops = { 5, 10, 20, 25, 50, 100 };
                int[] Pops = {  100 };
                for (int pp = 0; pp < Pops.Length; pp++)
                {
                    NPop = Pops[pp];
                    //int[] Point = { 50, 100, 150, 250, 350 };
                    int[] Point = { 350 };
                    //for (int P = NPoint1; P <= NPoint2; P += Point_step)
                    for (int III = 0; III < Point.Length; III++)
                        for (int N = NExperiment1; N <= NExperiment2; N++)
                        {
                            int P = Point[III];
                            //int N = -1; int P = -1;
                            string ss = "";
                            string ss2 = "";
                            double[] costs = new double[Ntest];
                            Latin_Hypercube[] Nodes_test = new Latin_Hypercube[Ntest];
                            Random rr = new Random();
                            double Fmax = -1; double Fmin = 1000;
                            ////////////////Temporary ////////////////////
                            if (Criterion != "Maximin")
                            {

                                #region MAPSO
                                 if (method == "MAPSO")
                                {
                                    string learning = "Gbest";
                                    double I_str = 1000;
                                    //double[] r_lg_s = { 0.05, 0.15, 0.2, 0.25 };
                                    //double[] r_lg_s = { 0.1, 0.3, 0.5, 0.7, 0.9 };
                                    //double C1 = 0.9; double C2 = 0.9; double W = 0.9;
                                    NPop = 20;
                                    int budget = 100000;
                                    //double C1 = 1.214301; double C2 = 7.931352; double W = 7.316036;
                                    //double alpha = 0.3367201;
                                    //double C1 = 0.9; double C2 = 0.9; double W = 0.9;
                                    double C1 = 4; double C2 = 4; double W = 0.01;
                                    //double alpha = 0.3;
                                    //double[] Cs = { 0.5, 1, 1.5, 2, 2.5 };
                                    //double[] Ws = { 2.5, 5 };
                                    //for (int LL = 0; LL < r_lg_s.Length; LL++)
                                    //{
                                    //for(int WW=0;WW<2;WW++)
                                    //    for (int CC = 0; CC < 5; CC++)
                                    //    {
                                    //C1 = 1; C2 = 1; W = 2.5;
                                    //Iteration = Convert.ToInt32(Math.Ceiling(budget * (1 - alpha) / NPop));
                                    //int Learning = Convert.ToInt32((NPop * alpha) / (1 - alpha));
                                    //double r_lg = r_lg_s[LL];
                                    double r_lg = 0.1;
                                    double n_frec = I_str * ((1 - r_lg) / r_lg);
                                    Iteration = (Convert.ToInt32((n_frec / NPop) * 1.9));
                                    int Learning = Convert.ToInt32(r_lg * I_str);
                                    double[,] Cost = new double[Ntest, Iteration];
                                    ss = "Costs_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_W_" + W.ToString() + "_C1_" + C1.ToString() + "_C2_" + C2.ToString() + method + "r_LcLG" + r_lg.ToString() + "_test_" + Ntest.ToString() + ".txt";
                                    //ss2 = "fit_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_W_" + W.ToString() + "_C1_" + C1.ToString() + "_C2_" + C2.ToString() + method + "r_LcLG" + r_lg.ToString() + "_test_" + Ntest.ToString() + ".txt";
                                    if (!File.Exists(ss2))
                                    {
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            MOA_Node[] Nodes = new MOA_Node[NPop];
                                            MOA_Node[] BNodes = new MOA_Node[NPop];
                                            MOA_Node[] Forces = new MOA_Node[NPop];
                                            MOA_Node[] a = new MOA_Node[NPop];
                                            MOA_Node[] v = new MOA_Node[NPop];
                                            Latin_Hypercube[] LHC = new Latin_Hypercube[NPop];
                                            Latin_Hypercube[] B = new Latin_Hypercube[NPop];
                                            MOA_Node Best_nodes = new MOA_Node();
                                            double[] distances = new double[NPop];
                                            Best_nodes.f = 1000;
                                            for (int ii = 0; ii < NPop; ii++)
                                            {
                                                v[ii].x = new double[N, P];
                                            }
                                            Fmax = 0; Fmin = 1000;
                                            int min_index = 0; int max_index = 0;
                                            for (int ii = 0; ii < NPop; ii++)
                                            {
                                                Nodes[ii].x = LH_Class.node_constructing(N, P, rr);
                                                BNodes[ii].x = (double[,])Nodes[ii].x.Clone();
                                                LHC[ii].LH = LH_Class.convert_search_s_to_solution_s(Nodes[ii].x, N, P);
                                                LHC[ii].F = LH_Class.F(LHC[ii].LH, N, P);
                                                BNodes[ii].f = 10000;
                                                if (Fmax < LHC[ii].F)
                                                {
                                                    Fmax = LHC[ii].F;
                                                    max_index = ii;
                                                }
                                                if (Fmin > LHC[ii].F)
                                                {
                                                    Fmin = LHC[ii].F;
                                                    min_index = ii;
                                                }
                                            }

                                            loca_searches ls_methods = LH_Class.Local_Searches(LHC[min_index].LH, Nodes[min_index].x, N, P);
                                            Best_nodes.LH = (int[,])ls_methods.LH.Clone();
                                            Best_nodes.x = (double[,])ls_methods.x.Clone();
                                            Best_nodes.f = LH_Class.F(Best_nodes.LH, N, P);
                                            for (int it = 0; it < Iteration; it++)
                                            {
                                                Fmax = 0; Fmin = 1000;
                                                min_index = 0; max_index = 0;
                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    LHC[ii].LH = LH_Class.convert_search_s_to_solution_s(Nodes[ii].x, N, P);
                                                    LHC[ii].F = LH_Class.F(LHC[ii].LH, N, P);
                                                }
                                                BNodes = LH_Class.define_pbest(LHC, Nodes, BNodes, NPop);
                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    if (BNodes[ii].f < Best_nodes.f)
                                                    {
                                                        Best_nodes.f = BNodes[ii].f;
                                                        Best_nodes.LH = (int[,])BNodes[ii].LH.Clone();
                                                        Best_nodes.x = (double[,])BNodes[ii].x.Clone();
                                                    }
                                                }
                                                if (learning == "Pbest")
                                                {
                                                    for (int ii = 0; ii < NPop; ii++)
                                                    {
                                                        ///////////////////////Leaning Phase////////////////////////////////
                                                        int ls_chosen = LH_Class.ranking_selection_for_lc(ls_methods, 3, rr);
                                                        double delta_tetha = LH_Class.SA_local_search(ref BNodes[ii], ls_chosen, P, N, rr, Learning);
                                                        switch (ls_chosen)
                                                        {
                                                            case 0: ls_methods.result_insert += delta_tetha; break;
                                                            case 1: ls_methods.result_inverse += delta_tetha; break;
                                                            case 2: ls_methods.result_swap += delta_tetha; break;
                                                        }
                                                        ////////////////////////////////////////////////////////////////////


                                                    }
                                                }
                                                else if (learning == "Gbest")
                                                {
                                                    int ls_chosen = LH_Class.ranking_selection_for_lc(ls_methods, 3, rr);
                                                    double delta_tetha = LH_Class.SA_local_search(ref Best_nodes, ls_chosen, P, N, rr, Learning);
                                                    switch (ls_chosen)
                                                    {
                                                        case 0: ls_methods.result_insert += delta_tetha; break;
                                                        case 1: ls_methods.result_inverse += delta_tetha; break;
                                                        case 2: ls_methods.result_swap += delta_tetha; break;
                                                    }
                                                    ////////////////////////////////////////////////////////////////////
                                                }
                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    for (int n = 0; n < N; n++)
                                                        for (int p = 0; p < P; p++)
                                                        {
                                                            v[ii].x[n, p] = W * v[ii].x[n, p] + C1 * rr.NextDouble() * (BNodes[ii].x[n, p] - Nodes[ii].x[n, p]) + C2 * rr.NextDouble() * (Best_nodes.x[n, p] - Nodes[ii].x[n, p]);
                                                            Nodes[ii].x[n, p] = Nodes[ii].x[n, p] + v[ii].x[n, p];
                                                        }

                                                    Nodes[ii].x = Node_treatment(Nodes[ii].x, N, P, rr);
                                                }
                                                Cost[tt, it] = Best_nodes.f;
                                            }

                                            costs[tt] = Best_nodes.f;
                                            //Nodes_test[tt].LH = (int[,])Best_nodes.LH.Clone();

                                        }
                                        //for (int tt = 0; tt < Ntest; tt++)
                                        //{
                                        //    for (int ii = 0; ii < N; ii++)
                                        //    {
                                        //        for (int jj = 0; jj < P; jj++)
                                        //        {
                                        //            sw.Write(Nodes_test[tt].LH[ii, jj].ToString() + " ");
                                        //        }
                                        //        sw.WriteLine();
                                        //    }
                                        //}
                                        //sw.Close();
                                        //sw = new StreamWriter(ss2);
                                        //for (int tt = 0; tt < Ntest; tt++)
                                        //{
                                        //    sw.Write(costs[tt].ToString() + " ");
                                        //}
                                        //sw.Close();
                                        sw = new StreamWriter(ss);
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            for (int it = 0; it < Iteration; it++)
                                            {
                                                sw.Write(Cost[tt, it].ToString() + " ");

                                            }
                                        }
                                        sw.Close();
                                    }
                                    //}
                                }

                                #endregion
 

                        }
                    }

                                #endregion
                    Application.Exit();
                }
            }

            #region RLDs
            else if (Criterion == "RLDs")
            {
                for (int P = NPoint1; P <= NPoint2; P += Point_step)
                    for (int N = NExperiment1; N <= NExperiment2; N++)
                    {

                        int[] iter = { 10, 100, 1000, 10000 };
                        //10-10 0.255 0.25 0.2460
                        double[] thresolds = { 0.255, 0.25, 0.2460 };
                        string ss = "";
                        string ss2 = "";
                        double[] costs = new double[Ntest];
                        Latin_Hypercube[] Nodes_test = new Latin_Hypercube[Ntest];
                        Random rr = new Random();
                        for (int IT = 0; IT < iter.Length; IT++)
                            for (int Tr = 0; Tr < thresolds.Length; Tr++)
                            {
                                int[] Fail_Accept = new int[Ntest];
                                int[] iteration_out = new int[Ntest];
                                Iteration = iter[IT];
                                double thresold = thresolds[Tr];
                                #region PSO
                                if (method == "PSO")
                                {
                                    double C1 = 0.9;
                                    double C2 = C1;
                                    double W = 0.9;
                                    ss = "Fail_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_W_" + W.ToString() + "_C1_" + C1.ToString() + "_C2_" + C2.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + "tres" + thresold.ToString() + ".txt";
                                    ss2 = "fit_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_W_" + W.ToString() + "_C1_" + C1.ToString() + "_C2_" + C2.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + "tres" + thresold.ToString() + ".txt";
                                    string ss3 = "iter_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_W_" + W.ToString() + "_C1_" + C1.ToString() + "_C2_" + C2.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + "tres" + thresold.ToString() + ".txt";
                                    int FA = -1; int Iter = 0;
                                    if (!File.Exists(ss))
                                    {
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            Iter = 0;
                                            FA = -1;
                                            MOA_Node[] Nodes = new MOA_Node[NPop];
                                            MOA_Node[] BNodes = new MOA_Node[NPop];
                                            MOA_Node[] Forces = new MOA_Node[NPop];
                                            MOA_Node[] a = new MOA_Node[NPop];
                                            MOA_Node[] v = new MOA_Node[NPop];
                                            Latin_Hypercube[] LHC = new Latin_Hypercube[NPop];
                                            Latin_Hypercube[] B = new Latin_Hypercube[NPop];
                                            Latin_Hypercube Best_indi = new Latin_Hypercube();
                                            MOA_Node Best_nodes = new MOA_Node();
                                            double[] distances = new double[NPop];
                                            Best_indi.F = 1000;
                                            for (int ii = 0; ii < NPop; ii++)
                                            {
                                                v[ii].x = new double[N, P];
                                            }
                                            for (int ii = 0; ii < NPop; ii++)
                                            {
                                                Nodes[ii].x = LH_Class.node_constructing(N, P, rr);
                                                BNodes[ii].x = (double[,])Nodes[ii].x.Clone();
                                                LHC[ii].LH = LH_Class.convert_search_s_to_solution_s(Nodes[ii].x, N, P);
                                                LHC[ii].F = LH_Class.F(LHC[ii].LH, N, P);
                                                BNodes[ii].f = LHC[ii].F;
                                            }
                                            for (int it = 0; it < Iteration && Best_indi.F >= thresold; it++)
                                            {
                                                double Fmax = 0; double Fmin = 1000;
                                                int min_index = 0; int max_index = 0;
                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    LHC[ii].LH = LH_Class.convert_search_s_to_solution_s(Nodes[ii].x, N, P);
                                                    LHC[ii].F = LH_Class.F(LHC[ii].LH, N, P);
                                                    if (Fmax < LHC[ii].F)
                                                    {
                                                        Fmax = LHC[ii].F;
                                                        max_index = ii;
                                                    }
                                                    if (Fmin > LHC[ii].F)
                                                    {
                                                        Fmin = LHC[ii].F;
                                                        min_index = ii;
                                                    }
                                                }
                                                if (Best_indi.F > Fmin)
                                                {
                                                    Best_indi.F = Fmin;
                                                    Best_indi.LH = (int[,])LHC[min_index].LH.Clone();
                                                    Best_nodes.x = (double[,])Nodes[min_index].x.Clone();

                                                }
                                                BNodes = LH_Class.define_pbest(LHC, Nodes, BNodes, NPop);
                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    for (int n = 0; n < N; n++)
                                                        for (int p = 0; p < P; p++)
                                                        {
                                                            v[ii].x[n, p] = W * v[ii].x[n, p] + C1 * rr.NextDouble() * (BNodes[ii].x[n, p] - Nodes[ii].x[n, p]) + C2 * rr.NextDouble() * (Best_nodes.x[n, p] - Nodes[ii].x[n, p]);
                                                            Nodes[ii].x[n, p] = Nodes[ii].x[n, p] + v[ii].x[n, p];
                                                        }

                                                    Nodes[ii].x = Node_treatment(Nodes[ii].x, N, P, rr);
                                                }
                                                if (Best_indi.F <= thresold)
                                                    FA = 1;
                                                Iter = it;
                                            }
                                            costs[tt] = Best_indi.F;
                                            Fail_Accept[tt] = FA;
                                            iteration_out[tt] = Iter * NPop;

                                        }

                                        sw = new StreamWriter(ss);
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            sw.Write(Fail_Accept[tt].ToString() + " ");
                                        }
                                        sw.Close();
                                        sw = new StreamWriter(ss2);
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            sw.Write(costs[tt].ToString() + " ");
                                        }
                                        sw.Close();
                                        sw = new StreamWriter(ss3);
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            sw.Write(iteration_out[tt].ToString() + " ");
                                        }
                                        sw.Close();
                                    }
                                }
                                #endregion
                                #region DE
                                else if (method == "DE")
                                {
                                    double Cr = 0.01;
                                    double F = 0.4;
                                    ss = "Fail_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_F_" + F.ToString() + "_Cr_" + Cr.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + "tres" + thresold.ToString() + ".txt";
                                    ss2 = "fit_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_F_" + F.ToString() + "_Cr_" + Cr.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + "tres" + thresold.ToString() + ".txt";
                                    string ss3 = "iter_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_F_" + F.ToString() + "_Cr_" + Cr.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + "tres" + thresold.ToString() + ".txt";
                                    int FA = -1; int Iter = 0;
                                    if (!File.Exists(ss))
                                    {
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            MOA_Node[] Pop = new MOA_Node[NPop];
                                            MOA_Node[] Pprim = new MOA_Node[NPop];
                                            Latin_Hypercube[] LHC = new Latin_Hypercube[NPop];
                                            Latin_Hypercube Best_indi = new Latin_Hypercube();
                                            MOA_Node V = new MOA_Node(); MOA_Node U = new MOA_Node();
                                            MOA_Node Best_nodes = new MOA_Node();
                                            double[] distances = new double[NPop];
                                            Best_indi.F = 1000;

                                            for (int ii = 0; ii < NPop; ii++)
                                            {
                                                Pop[ii].x = LH_Class.node_constructing(N, P, rr);
                                                LHC[ii].LH = LH_Class.convert_search_s_to_solution_s(Pop[ii].x, N, P);
                                                LHC[ii].F = LH_Class.F(LHC[ii].LH, N, P);
                                            }
                                            for (int it = 0; it < Iteration; it++)
                                            {
                                                double Fmin = 1000;
                                                int min_index = 0;
                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    int[] Parents = LH_Class.sq_rand_gen2(3, NPop, rr);
                                                    V.x = new double[N, P];
                                                    U.x = new double[N, P];
                                                    for (int N_i = 0; N_i < N; N_i++)
                                                        for (int P_i = 0; P_i < P; P_i++)
                                                        {
                                                            V.x[N_i, P_i] = Pop[Parents[0]].x[N_i, P_i] + F * (Pop[Parents[1]].x[N_i, P_i] - Pop[Parents[2]].x[N_i, P_i]);
                                                            if (rr.NextDouble() < Cr)
                                                                U.x[N_i, P_i] = V.x[N_i, P_i];
                                                            else
                                                                U.x[N_i, P_i] = Pop[ii].x[N_i, P_i];
                                                        }
                                                    U.LH = LH_Class.convert_search_s_to_solution_s(U.x, N, P);
                                                    U.f = LH_Class.F(U.LH, N, P);
                                                    LHC[ii].LH = LH_Class.convert_search_s_to_solution_s(Pop[ii].x, N, P);
                                                    LHC[ii].F = LH_Class.F(LHC[ii].LH, N, P);
                                                    if (Fmin > LHC[ii].F)
                                                    {
                                                        Fmin = LHC[ii].F;
                                                        min_index = ii;
                                                    }
                                                    if (U.f <= LHC[ii].F)
                                                    {
                                                        Pprim[ii].x = (double[,])U.x.Clone();
                                                        Pprim[ii].f = U.f;
                                                        Pprim[ii].LH = (int[,])U.LH.Clone();
                                                    }
                                                    else
                                                    {
                                                        Pprim[ii].x = (double[,])Pop[ii].x.Clone();
                                                        Pprim[ii].f = LHC[ii].F;
                                                        Pprim[ii].LH = (int[,])LHC[ii].LH.Clone();
                                                    }
                                                }
                                                if (Best_indi.F > Fmin)
                                                {
                                                    Best_indi.F = Fmin;
                                                    Best_indi.LH = (int[,])LHC[min_index].LH.Clone();
                                                    Best_nodes.x = (double[,])Pop[min_index].x.Clone();

                                                }
                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    Pop[ii].x = (double[,])Pprim[ii].x.Clone();
                                                    LHC[ii].F = Pprim[ii].f;
                                                    LHC[ii].LH = (int[,])LHC[ii].LH.Clone();
                                                }
                                                if (Best_indi.F <= thresold)
                                                {
                                                    FA = 1;
                                                    break;
                                                }
                                                Iter = it;
                                            }
                                            costs[tt] = Best_indi.F;
                                            Fail_Accept[tt] = FA;
                                            iteration_out[tt] = Iter * NPop;

                                        }

                                        sw = new StreamWriter(ss);
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            sw.Write(Fail_Accept[tt].ToString() + " ");
                                        }
                                        sw.Close();
                                        sw = new StreamWriter(ss2);
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            sw.Write(costs[tt].ToString() + " ");
                                        }
                                        sw.Close();
                                        sw = new StreamWriter(ss3);
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            sw.Write(iteration_out[tt].ToString() + " ");
                                        }
                                        sw.Close();

                                    }
                                }

                                #endregion
                                #region ES
                                else if (method == "ES")
                                {
                                    double[] Lambda_s = { 0.2, 0.4, 0.6, 0.8, 1 };
                                    int breeds_number = 1 * NPop;
                                    double SC = 0.8;
                                    ss = "Fault_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_Lambda_" + Lambda_s[4].ToString() + "_Sigma_Fac_" + SC.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + "tres" + thresold.ToString() + ".txt";
                                    ss2 = "fit_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_Lambda_" + Lambda_s[4].ToString() + "_Sigma_Fac_" + SC.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + "tres" + thresold.ToString() + ".txt";
                                    string ss3 = "iter_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_Lambda_" + Lambda_s[4].ToString() + "_Sigma_Fac_" + SC.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + "tres" + thresold.ToString() + ".txt";
                                    int FA = -1; int Iter = 0;
                                    if (!File.Exists(ss2))
                                    {
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            MOA_Node[] Pop = new MOA_Node[NPop];
                                            MOA_Node Best_nodes = new MOA_Node();
                                            Best_nodes.f = 10000;
                                            MOA_Node[] Breeds = new MOA_Node[breeds_number];
                                            double[] distances = new double[NPop];
                                            int phi_count = 0;
                                            double sigma = 1;
                                            for (int ii = 0; ii < NPop; ii++)
                                            {
                                                Pop[ii].x = LH_Class.node_constructing(N, P, rr);
                                                Pop[ii].LH = LH_Class.convert_search_s_to_solution_s(Pop[ii].x, N, P);
                                                Pop[ii].f = LH_Class.F(Pop[ii].LH, N, P);
                                            }

                                            for (int it = 0; it < Iteration; it++)
                                            {
                                                MOA_Node[] All = new MOA_Node[NPop + breeds_number];
                                                for (int ii = 0; ii < breeds_number; ii++)
                                                {
                                                    Breeds[ii].x = new double[N, P];
                                                    int parent1 = rr.Next(NPop);
                                                    int parent2 = rr.Next(NPop);
                                                    for (int n = 0; n < N; n++)
                                                        for (int p = 0; p < P; p++)
                                                        {
                                                            double rand = rr.NextDouble();
                                                            if (rand < 0.5)
                                                            {
                                                                Breeds[ii].x[n, p] = Pop[parent1].x[n, p];
                                                            }
                                                            else
                                                            {
                                                                Breeds[ii].x[n, p] = Pop[parent2].x[n, p];
                                                            }
                                                        }

                                                }
                                                for (int ii = 0; ii < breeds_number; ii++)
                                                {
                                                    for (int n = 0; n < N; n++)
                                                        for (int p = 0; p < P; p++)
                                                        {
                                                            Breeds[ii].x[n, p] = Breeds[ii].x[n, p] + sigma * LH_Class.Normal_Distribution(rr);
                                                        }
                                                    Breeds[ii].LH = LH_Class.convert_search_s_to_solution_s(Breeds[ii].x, N, P);
                                                    Breeds[ii].f = LH_Class.F(Breeds[ii].LH, N, P);
                                                    All[ii].x = (double[,])Breeds[ii].x.Clone();
                                                    All[ii].LH = (int[,])Breeds[ii].LH.Clone();
                                                    All[ii].f = Breeds[ii].f;

                                                }

                                                double[] OldCost = new double[NPop];
                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    int[,] LH = LH_Class.convert_search_s_to_solution_s(Pop[ii].x, N, P);
                                                    OldCost[ii] = LH_Class.F(LH, N, P);
                                                    for (int n = 0; n < N; n++)
                                                        for (int p = 0; p < P; p++)
                                                        {
                                                            Pop[ii].x[n, p] = Pop[ii].x[n, p] + sigma * LH_Class.Normal_Distribution(rr);
                                                        }
                                                    Pop[ii].LH = LH_Class.convert_search_s_to_solution_s(Pop[ii].x, N, P);
                                                    Pop[ii].f = LH_Class.F(Pop[ii].LH, N, P);

                                                    // putting all pop into a temporary combinator
                                                    All[ii + breeds_number].x = (double[,])Pop[ii].x.Clone();
                                                    All[ii + breeds_number].LH = (int[,])Pop[ii].LH.Clone();
                                                    All[ii + breeds_number].f = Pop[ii].f;

                                                    if (Pop[ii].f < OldCost[ii])
                                                        phi_count++;
                                                }
                                                int mutation_count = (it + 1) * NPop;
                                                if (phi_count < (mutation_count / 5))
                                                    sigma = sigma / SC;
                                                else if (phi_count > (mutation_count / 5))
                                                    sigma = sigma * SC;
                                                // Sort all POP+Breed
                                                All = LH_Class.mergesort(All, All.Length);

                                                //storing the best node into best node container
                                                if (Best_nodes.f >= All[0].f)
                                                {
                                                    Best_nodes.x = (double[,])All[0].x.Clone();
                                                    Best_nodes.LH = (int[,])All[0].LH.Clone();
                                                    Best_nodes.f = All[0].f;
                                                }

                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    Pop[ii].x = (double[,])All[ii].x.Clone();
                                                    Pop[ii].LH = (int[,])All[ii].LH.Clone();
                                                    Pop[ii].f = All[ii].f;
                                                }
                                                if (Best_nodes.f <= thresold)
                                                {
                                                    FA = 1;
                                                    break;
                                                }
                                                Iter = it;
                                            }
                                            costs[tt] = Best_nodes.f;
                                            Fail_Accept[tt] = FA;
                                            iteration_out[tt] = Iter * NPop;

                                        }

                                        sw = new StreamWriter(ss);
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            sw.Write(Fail_Accept[tt].ToString() + " ");
                                        }
                                        sw.Close();
                                        sw = new StreamWriter(ss2);
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            sw.Write(costs[tt].ToString() + " ");
                                        }
                                        sw.Close();
                                        sw = new StreamWriter(ss3);
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            sw.Write(iteration_out[tt].ToString() + " ");
                                        }
                                        sw.Close();
                                    }
                                    //}
                                }
                                #endregion
                                #region ESE
                                else if (method == "ESE")
                                {

                                    int n1 = Convert.ToInt32(N1.Text);
                                    int n2 = Convert.ToInt32(N2.Text);
                                    int n_s = Convert.ToInt32(N_s.Text);
                                    double t1 = Convert.ToDouble(T1.Text);
                                    double alpha1 = 0.8;
                                    double alpha2 = 0.9;
                                    double alpha3 = 0.7;
                                    double small_per = 0.1;
                                    int it = 0;
                                    double Th = 0.01;
                                    int M = 10;
                                    int J = 1;
                                    ss = "Fault_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + "tres" + thresold.ToString() + ".txt";
                                    ss2 = "fit_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + "tres" + thresold.ToString() + ".txt";
                                    string ss3 = "iter_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + "tres" + thresold.ToString() + ".txt";
                                    int FA = -1; int Iter = 0;
                                    if (!File.Exists(ss2))
                                    {
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            FA = -1;
                                            Th = 0.01;
                                            bool flagimp = false;
                                            int SumIterPop = Iteration * NPop;
                                            it = 0;
                                            int[,] LH = LH_Class.constructing_Latin_hypercube(N, P, rr);
                                            double Z = LH_Class.F(LH, N, P);
                                            Th = Th * Z;
                                            int[,] X_best = (int[,])LH.Clone();
                                            //Outer Loop
                                            while (it < SumIterPop)
                                            {
                                                int[,] X_oldBest = (int[,])X_best.Clone();
                                                // inner Loop
                                                int N_imp = 0; int N_acp = 0;
                                                for (int ii = 0; ii < M && it < SumIterPop; ii++)
                                                {
                                                    //picking procedure
                                                    int[,] LH_Best_Row = (int[,])LH.Clone();
                                                    double ZR = 1000;
                                                    int jj = 0;
                                                    while (jj < J && it < SumIterPop)
                                                    {
                                                        int[,] LH_temp = (int[,])LH_Best_Row.Clone();
                                                        int nrand = rr.Next(N);
                                                        int P1 = rr.Next(P);
                                                        int P2 = rr.Next(P);
                                                        int temp = LH_temp[nrand, P1];
                                                        LH_temp[nrand, P1] = LH_temp[nrand, P2];
                                                        LH_temp[nrand, P2] = temp;
                                                        double z2 = LH_Class.F(LH_temp, N, P);
                                                        double dz = z2 - ZR;
                                                        if (dz < 0)
                                                        {
                                                            LH_Best_Row = (int[,])LH_temp.Clone();
                                                            ZR = z2;
                                                        }
                                                        jj++;
                                                        it++;
                                                    }
                                                    double delta_h = ZR - Z;
                                                    if (Th * rr.NextDouble() >= delta_h)
                                                    {
                                                        LH = (int[,])LH_Best_Row.Clone();
                                                        N_acp++;
                                                        if (ZR < Z)
                                                        {
                                                            X_best = (int[,])LH.Clone();
                                                            N_imp++;
                                                            Z = ZR;
                                                        }
                                                    }

                                                    ////////////////////


                                                    //Inner Loop End ///////////////////////
                                                }
                                                double F_B = LH_Class.F(X_oldBest, N, P) - LH_Class.F(X_best, N, P);
                                                if (F_B > 0)
                                                    flagimp = true;
                                                else
                                                    flagimp = false;


                                                ///////////////////////////Update T_h /////////////////////////////
                                                double Acc_ratio = Convert.ToDouble(N_acp) / M;
                                                double Impro_ratio = Convert.ToDouble(N_imp) / M;
                                                //////////Improving procedure
                                                if (flagimp == true)
                                                {
                                                    if (Acc_ratio > small_per && Impro_ratio < Acc_ratio)
                                                        Th = alpha1 * Th;
                                                    else if (Acc_ratio > small_per && Impro_ratio == Acc_ratio)
                                                    {
                                                        //nothing
                                                    }
                                                    else
                                                        Th = Th / alpha1;
                                                    ///////////////////////////////////////////////
                                                }
                                                else if (flagimp == false)
                                                {    /////////////Exploration Process/////////////
                                                    if (Acc_ratio < small_per)
                                                        Th = Th / alpha2;
                                                    else
                                                        Th = Th * alpha3;
                                                }
                                                if (Z <= thresold)
                                                {
                                                    FA = 1;
                                                    break;
                                                }
                                                Iter = it;
                                            }
                                            costs[tt] = Z;
                                            Fail_Accept[tt] = FA;
                                            iteration_out[tt] = Iter;

                                        }

                                        sw = new StreamWriter(ss);
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            sw.Write(Fail_Accept[tt].ToString() + " ");
                                        }
                                        sw.Close();
                                        sw = new StreamWriter(ss2);
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            sw.Write(costs[tt].ToString() + " ");
                                        }
                                        sw.Close();
                                        sw = new StreamWriter(ss3);
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            sw.Write(iteration_out[tt].ToString() + " ");
                                        }
                                        sw.Close();
                                    }
                                    //}

                                }
                                #endregion
                                #region ILS
                                else if (method == "ILS")
                                {
                                    int it = 0;
                                    ss = "Fault_N_" + N.ToString() + "P_" + P.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + "tres" + thresold.ToString() + ".txt";
                                    ss2 = "fit_N_" + N.ToString() + "P_" + P.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + "tres" + thresold.ToString() + ".txt";
                                    string ss3 = "iter_N_" + N.ToString() + "P_" + P.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + "tres" + thresold.ToString() + ".txt";
                                    int FA = -1; int Iter = 0;
                                    if (!File.Exists(ss2))
                                    {
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            it = 0;
                                            FA = -1;
                                            int[,] LH = LH_Class.constructing_Latin_hypercube(N, P, rr);
                                            double z1 = 0;
                                            int MaxIter = Iteration * NPop;
                                            bool change = false;
                                            while (it < MaxIter)
                                            {

                                                int[,] LH_temp = (int[,])LH.Clone();
                                                z1 = LH_Class.F(LH_temp, N, P);
                                                //local search
                                                do
                                                {
                                                    change = false;
                                                    for (int ii = 0; ii < N && it < MaxIter; ii++)
                                                        for (int jj = 0; jj < P && it < MaxIter; jj++)
                                                            for (int kk = 0; kk < P && it < MaxIter; kk++)
                                                            {
                                                                if (jj != kk)
                                                                {
                                                                    LH_temp = (int[,])LH.Clone();
                                                                    int temp = LH_temp[ii, jj];
                                                                    LH_temp[ii, jj] = LH_temp[ii, kk];
                                                                    LH_temp[ii, kk] = temp;
                                                                    double z2 = LH_Class.F(LH_temp, N, P);
                                                                    double dz = z2 - z1;
                                                                    if (dz < 0)
                                                                    {
                                                                        LH = (int[,])LH_temp.Clone();
                                                                        z1 = z2;
                                                                        change = true;
                                                                    }
                                                                }
                                                                if (z1 <= thresold)
                                                                {
                                                                    FA = 1;
                                                                    goto End;
                                                                }
                                                                Iter = it;
                                                                it++;
                                                            }
                                                }
                                                while (change && it < MaxIter);
                                                LH_Class.Perturbation(ref LH, rr, N, P);

                                            }
                                        End:
                                            costs[tt] = z1;
                                            Fail_Accept[tt] = FA;
                                            iteration_out[tt] = Iter;

                                        }

                                        sw = new StreamWriter(ss);
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            sw.Write(Fail_Accept[tt].ToString() + " ");
                                        }
                                        sw.Close();
                                        sw = new StreamWriter(ss2);
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            sw.Write(costs[tt].ToString() + " ");
                                        }
                                        sw.Close();
                                        sw = new StreamWriter(ss3);
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            sw.Write(iteration_out[tt].ToString() + " ");
                                        }
                                        sw.Close();
                                    }

                                }
                                #endregion
                                #region GA
                                if (method == "Genetic")
                                {
                                    int min_index = 0;
                                    double mu_rate = 0.005;
                                    double cr_rate = 1;
                                    ss = "Fail_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + "tres" + thresold.ToString() + ".txt";
                                    ss2 = "fit_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + "tres" + thresold.ToString() + ".txt";
                                    string ss3 = "iter_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + "tres" + thresold.ToString() + ".txt";
                                    int FA = -1; int Iter = 0;
                                    if (!File.Exists(ss))
                                    {
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            FA = -1;
                                            double Fmax = -1; double Fmin = 1000;
                                            Latin_Hypercube[] LH = new Latin_Hypercube[NPop];
                                            Latin_Hypercube Best_indi = new Latin_Hypercube();
                                            Best_indi.F = 1000;
                                            for (int ii = 0; ii < NPop; ii++)
                                            {

                                                LH[ii].LH = LH_Class.constructing_Latin_hypercube(N, P, rr);
                                                LH[ii].F = LH_Class.F(LH[ii].LH, N, P);
                                                if (Fmax < LH[ii].F)
                                                    Fmax = LH[ii].F;
                                                if (Fmin > LH[ii].F)
                                                {
                                                    Fmin = LH[ii].F;
                                                    min_index = ii;
                                                }
                                            }
                                            for (int it = 0; it < Iteration; it++)
                                            {

                                                Fmax = -1; Fmin = 1000;
                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    LH[ii].F = LH_Class.F(LH[ii].LH, N, P);
                                                    if (Fmax < LH[ii].F)
                                                        Fmax = LH[ii].F;
                                                    if (Fmin > LH[ii].F)
                                                    {
                                                        Fmin = LH[ii].F;
                                                        min_index = ii;
                                                    }
                                                }
                                                if (Fmin < Best_indi.F)
                                                {
                                                    Best_indi.F = Fmin;
                                                    Best_indi.LH = (int[,])LH[min_index].LH.Clone();
                                                }
                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    LH[ii].Fitness = LH_Class.fitness(Fmax, Fmin, LH[ii].F);
                                                }

                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    if (cr_rate > rr.NextDouble())
                                                    {
                                                        int index = LH_Class.Select_with_Probability(LH, NPop, rr);
                                                        int index2 = LH_Class.Select_with_Probability(LH, NPop, rr);
                                                        while (index == index2)
                                                            index2 = LH_Class.Select_with_Probability(LH, NPop, rr);
                                                        children childs = LH_Class.double_Cross_over(LH[index].LH, LH[index2].LH, N, P, rr);
                                                        double F1 = LH_Class.F(childs.child1, N, P); double F2 = LH_Class.F(childs.child2, N, P);
                                                        if (F1 < F2)
                                                            LH[ii].LH = (int[,])childs.child1.Clone();
                                                        else
                                                            LH[ii].LH = (int[,])childs.child2.Clone();
                                                    }
                                                    if (mu_rate > rr.NextDouble())
                                                        LH[ii].LH = LH_Class.mutation(LH[ii].LH, N, P, rr);
                                                }
                                                if (Best_indi.F <= thresold)
                                                {
                                                    FA = 1;
                                                    break;
                                                }
                                                Iter = it;
                                            }

                                            costs[tt] = Best_indi.F;
                                            Fail_Accept[tt] = FA;
                                            iteration_out[tt] = Iter * NPop;

                                        }

                                        sw = new StreamWriter(ss);
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            sw.Write(Fail_Accept[tt].ToString() + " ");
                                        }
                                        sw.Close();
                                        sw = new StreamWriter(ss2);
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            sw.Write(costs[tt].ToString() + " ");
                                        }
                                        sw.Close();
                                        sw = new StreamWriter(ss3);
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            sw.Write(iteration_out[tt].ToString() + " ");
                                        }
                                        sw.Close();
                                    }
                                }
                                #endregion
                                #region SA
                                else if (method == "SA")
                                {
                                    int it = 0;
                                    double T = 0.01;
                                    double cr = 0.80;
                                    double M = P * (P - 1) * N;
                                    ss = "Fault_N_" + N.ToString() + "P_" + P.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + "tres" + thresold.ToString() + ".txt";
                                    ss2 = "fit_N_" + N.ToString() + "P_" + P.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + "tres" + thresold.ToString() + ".txt";
                                    string ss3 = "iter_N_" + N.ToString() + "P_" + P.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + "tres" + thresold.ToString() + ".txt";
                                    int FA = -1; int Iter = 0;
                                    if (!File.Exists(ss))
                                    {
                                        double T_help = T;
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            T = T_help;
                                            it = 0;
                                            int[,] LH = LH_Class.constructing_Latin_hypercube(N, P, rr);
                                            int[,] LH_temp = (int[,])LH.Clone();
                                            double z1 = 0;
                                            double dz = 0;
                                            double Z_best = 10000;
                                            //if (Criterion == "Maximin")
                                            //    z1 = LH_Class.F_Maximin(LH, N, P);
                                            //else
                                            z1 = LH_Class.F(LH, N, P);
                                            while (it < Iteration * NPop)
                                            {
                                                int I = 0;

                                                while (I < M && it < Iteration * NPop)
                                                {
                                                    int nrand = rr.Next(N);
                                                    int P1 = rr.Next(P);
                                                    int P2 = rr.Next(P);
                                                    LH_temp = (int[,])LH.Clone();
                                                    int temp = LH_temp[nrand, P1];
                                                    LH_temp[nrand, P1] = LH_temp[nrand, P2];
                                                    LH_temp[nrand, P2] = temp;
                                                    double z2 = 10000;
                                                    #region MM
                                                    //if (Criterion == "Maximin")
                                                    //{
                                                    //    z2 = LH_Class.F_Maximin(LH_temp, N, P);
                                                    //}
                                                    #endregion
                                                    //else
                                                    //{
                                                    z2 = LH_Class.F(LH_temp, N, P);
                                                    //}
                                                    //#region Maxmin
                                                    //if (Criterion == "Maximin")
                                                    //{
                                                    //    dz = z1 - z2;
                                                    //    if (z2 < z1 || Math.Exp(-dz / T) > rr.NextDouble())
                                                    //    {
                                                    //        LH = (int[,])LH_temp.Clone();
                                                    //        z2 = z1;
                                                    //    }
                                                    //    if (dz > 0)
                                                    //        I++;
                                                    //}
                                                    //#endregion
                                                    //else
                                                    //{
                                                    dz = z2 - z1;
                                                    double Boltzman = Math.Exp(-dz / T);

                                                    if (dz < 0 || Boltzman > rr.NextDouble())
                                                    {
                                                        LH = (int[,])LH_temp.Clone();
                                                        z1 = z2;
                                                    }
                                                    if (z2 < Z_best)
                                                    {
                                                        I = 0;
                                                        Z_best = z2;
                                                    }
                                                    else
                                                        I++;
                                                    //}
                                                    if (z1 <= thresold)
                                                    {
                                                        FA = 1;
                                                        goto End;
                                                    }
                                                    Iter = it;
                                                    it++;
                                                }
                                                T = T * cr;
                                            }
                                        End:
                                            costs[tt] = z1;
                                            Fail_Accept[tt] = FA;
                                            iteration_out[tt] = Iter;

                                        }

                                        sw = new StreamWriter(ss);
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            sw.Write(Fail_Accept[tt].ToString() + " ");
                                        }
                                        sw.Close();
                                        sw = new StreamWriter(ss2);
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            sw.Write(costs[tt].ToString() + " ");
                                        }
                                        sw.Close();
                                        sw = new StreamWriter(ss3);
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            sw.Write(iteration_out[tt].ToString() + " ");
                                        }
                                        sw.Close();
                                    }


                                }
                                #endregion
                                #region CP
                                else if (method == "CP")
                                {
                                    int it = 0;
                                    ss = "Fault_N_" + N.ToString() + "P_" + P.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + "tres" + thresold.ToString() + ".txt";
                                    ss2 = "fit_N_" + N.ToString() + "P_" + P.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + "tres" + thresold.ToString() + ".txt";
                                    string ss3 = "iter_N_" + N.ToString() + "P_" + P.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + "tres" + thresold.ToString() + ".txt";
                                    int FA = -1; int Iter = 0;
                                    double z1 = 0;
                                    if (!File.Exists(ss))
                                    {
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            FA = -1;
                                            it = 0;
                                            int[,] LH = LH_Class.constructing_Latin_hypercube(N, P, rr);
                                            double Z = 0;
                                            int MaxIter = Iteration * NPop;
                                            while (it < MaxIter)
                                            {

                                                int[,] LH_temp = (int[,])LH.Clone();
                                                z1 = LH_Class.F(LH_temp, N, P);
                                                for (int ii = 0; ii < N && it < MaxIter; ii++)
                                                {
                                                    for (int jj = 0; jj < P && it < MaxIter; jj++)
                                                        for (int kk = 0; kk < P && it < MaxIter; kk++)
                                                        {
                                                            if (jj != kk)
                                                            {
                                                                LH_temp = (int[,])LH.Clone();
                                                                int temp = LH_temp[ii, jj];
                                                                LH_temp[ii, jj] = LH_temp[ii, kk];
                                                                LH_temp[ii, kk] = temp;
                                                                double z2 = LH_Class.F(LH_temp, N, P);
                                                                double dz = z2 - z1;
                                                                if (dz < 0)
                                                                {
                                                                    LH = (int[,])LH_temp.Clone();
                                                                    z1 = z2;
                                                                }
                                                            }
                                                            if (z1 <= thresold)
                                                            {
                                                                FA = 1;
                                                                goto End;
                                                            }
                                                            Iter = it;
                                                            it++;
                                                        }
                                                }
                                            }
                                        End:
                                            costs[tt] = z1;
                                            Fail_Accept[tt] = FA;
                                            iteration_out[tt] = Iter;

                                        }

                                        sw = new StreamWriter(ss);
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            sw.Write(Fail_Accept[tt].ToString() + " ");
                                        }
                                        sw.Close();
                                        sw = new StreamWriter(ss2);
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            sw.Write(costs[tt].ToString() + " ");
                                        }
                                        sw.Close();
                                        sw = new StreamWriter(ss3);
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            sw.Write(iteration_out[tt].ToString() + " ");
                                        }
                                        sw.Close();
                                    }
                                }
                                #endregion
                                #region MAPSO
                                else if (method == "MAPSO")
                                {
                                    string learning = "Gbest";
                                    double I_str = 1000;
                                    int O = Iteration * 100;
                                    double[] r_lg_s = { 0.1, 0.3, 0.5, 0.7, 0.9 };
                                    double C1 = 1.0; double C2 = 1.0; double W = 1.5;
                                    NPop = 20;
                                    ss = "Fail_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + "tres" + thresold.ToString() + ".txt";
                                    ss2 = "fit_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + "tres" + thresold.ToString() + ".txt";
                                    string ss3 = "iter_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + "tres" + thresold.ToString() + ".txt";
                                    int FA = -1; int Iter = 0;
                                    double r_lg = r_lg_s[0];
                                    double n_frec = I_str * ((1 - r_lg) / r_lg);
                                    int Learning = Convert.ToInt32(r_lg * I_str);
                                    //Iteration = (Convert.ToInt32((n_frec / NPop) * 1.9));
                                    double aggregation = (NPop + Learning);
                                    Iteration = Convert.ToInt32(Math.Ceiling(O / aggregation));
                                    if (!File.Exists(ss))
                                    {
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            FA = -1;
                                            int L = 0;
                                            double Fmax = 0; double Fmin = 1000;
                                            MOA_Node[] Nodes = new MOA_Node[NPop];
                                            MOA_Node[] BNodes = new MOA_Node[NPop];
                                            MOA_Node[] Forces = new MOA_Node[NPop];
                                            MOA_Node[] a = new MOA_Node[NPop];
                                            MOA_Node[] v = new MOA_Node[NPop];
                                            Latin_Hypercube[] LHC = new Latin_Hypercube[NPop];
                                            Latin_Hypercube[] B = new Latin_Hypercube[NPop];
                                            MOA_Node Best_nodes = new MOA_Node();
                                            double[] distances = new double[NPop];
                                            Best_nodes.f = 1000;
                                            for (int ii = 0; ii < NPop; ii++)
                                            {
                                                v[ii].x = new double[N, P];
                                            }
                                            Fmax = 0; Fmin = 1000;
                                            int min_index = 0; int max_index = 0;
                                            for (int ii = 0; ii < NPop; ii++)
                                            {
                                                Nodes[ii].x = LH_Class.node_constructing(N, P, rr);
                                                BNodes[ii].x = (double[,])Nodes[ii].x.Clone();
                                                LHC[ii].LH = LH_Class.convert_search_s_to_solution_s(Nodes[ii].x, N, P);
                                                LHC[ii].F = LH_Class.F(LHC[ii].LH, N, P);
                                                BNodes[ii].f = 10000;
                                                if (Fmax < LHC[ii].F)
                                                {
                                                    Fmax = LHC[ii].F;
                                                    max_index = ii;
                                                }
                                                if (Fmin > LHC[ii].F)
                                                {
                                                    Fmin = LHC[ii].F;
                                                    min_index = ii;
                                                }
                                            }

                                            loca_searches ls_methods = LH_Class.Local_Searches(LHC[min_index].LH, Nodes[min_index].x, N, P);
                                            Best_nodes.LH = (int[,])ls_methods.LH.Clone();
                                            Best_nodes.x = (double[,])ls_methods.x.Clone();
                                            Best_nodes.f = LH_Class.F(Best_nodes.LH, N, P);
                                            for (int it = 0; it < Iteration; it++)
                                            {
                                                Fmax = 0; Fmin = 1000;
                                                min_index = 0; max_index = 0;
                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    LHC[ii].LH = LH_Class.convert_search_s_to_solution_s(Nodes[ii].x, N, P);
                                                    LHC[ii].F = LH_Class.F(LHC[ii].LH, N, P);
                                                }
                                                BNodes = LH_Class.define_pbest(LHC, Nodes, BNodes, NPop);
                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    if (BNodes[ii].f < Best_nodes.f)
                                                    {
                                                        Best_nodes.f = BNodes[ii].f;
                                                        Best_nodes.LH = (int[,])BNodes[ii].LH.Clone();
                                                        Best_nodes.x = (double[,])BNodes[ii].x.Clone();
                                                    }
                                                }
                                                if (learning == "Pbest")
                                                {
                                                    for (int ii = 0; ii < NPop; ii++)
                                                    {
                                                        ///////////////////////Leaning Phase////////////////////////////////
                                                        int ls_chosen = LH_Class.ranking_selection_for_lc(ls_methods, 3, rr);
                                                        double delta_tetha = LH_Class.SA_local_search(ref BNodes[ii], ls_chosen, P, N, rr, Learning);
                                                        switch (ls_chosen)
                                                        {
                                                            case 0: ls_methods.result_insert += delta_tetha; break;
                                                            case 1: ls_methods.result_inverse += delta_tetha; break;
                                                            case 2: ls_methods.result_swap += delta_tetha; break;
                                                        }
                                                        ////////////////////////////////////////////////////////////////////


                                                    }
                                                }
                                                else if (learning == "Gbest")
                                                {
                                                    int ls_chosen = LH_Class.ranking_selection_for_lc(ls_methods, 3, rr);
                                                    MOA_Node Temp = LH_Class.SA_local_search2(ref Best_nodes, ls_chosen, P, N, rr, Learning, thresold);
                                                    double delta_tetha = Temp.f;//it's a delta_tetha but because we require some parametric variable we use moa_node
                                                    L = Temp.index;
                                                    switch (ls_chosen)
                                                    {
                                                        case 0: ls_methods.result_insert += delta_tetha; break;
                                                        case 1: ls_methods.result_inverse += delta_tetha; break;
                                                        case 2: ls_methods.result_swap += delta_tetha; break;
                                                    }
                                                    ////////////////////////////////////////////////////////////////////
                                                }
                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    for (int n = 0; n < N; n++)
                                                        for (int p = 0; p < P; p++)
                                                        {
                                                            v[ii].x[n, p] = W * v[ii].x[n, p] + C1 * rr.NextDouble() * (BNodes[ii].x[n, p] - Nodes[ii].x[n, p]) + C2 * rr.NextDouble() * (Best_nodes.x[n, p] - Nodes[ii].x[n, p]);
                                                            Nodes[ii].x[n, p] = Nodes[ii].x[n, p] + v[ii].x[n, p];
                                                        }

                                                    Nodes[ii].x = Node_treatment(Nodes[ii].x, N, P, rr);
                                                }
                                                if (Best_nodes.f <= thresold)
                                                {
                                                    FA = 1;
                                                    break;
                                                }
                                                Iter = it;
                                            }

                                            costs[tt] = Best_nodes.f;
                                            Fail_Accept[tt] = FA;
                                            iteration_out[tt] = Iter * (NPop + Learning) + L;

                                        }

                                        sw = new StreamWriter(ss);
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            sw.Write(Fail_Accept[tt].ToString() + " ");
                                        }
                                        sw.Close();
                                        sw = new StreamWriter(ss2);
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            sw.Write(costs[tt].ToString() + " ");
                                        }
                                        sw.Close();
                                        sw = new StreamWriter(ss3);
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            sw.Write(iteration_out[tt].ToString() + " ");
                                        }
                                        sw.Close();
                                    }
                                }

                                #endregion

                            }
                    }

            }
            #endregion
        }
        public double distance1(double[,] x1, double[,] x2, int N, int P)
        {
            double result = 0;
            for(int ii=0;ii<N;ii++)
                for (int jj = 0; jj < P; jj++)
                {
                    result += Math.Abs(x1[ii, jj] - x2[ii, jj]);
                }
            return result;
        }
        public double distance2(double[,] x1, double[,] x2, int N, int P)
        {
            double result = 0;
            for (int ii = 0; ii < N; ii++)
                for (int jj = 0; jj < P; jj++)
                {
                    result += Math.Pow(Math.Abs(x1[ii, jj] - x2[ii, jj]),2);
                }
            return Math.Sqrt(result);
        }
        public double distance3(double[,] x1, double[,] x2, int N, int P)
        {
            double result = 0;
            for (int ii = 0; ii < N; ii++)
                for (int jj = 0; jj < P; jj++)
                {
                    result =  Math.Max(x1[ii, jj] - x2[ii, jj],result);
                }
            return result;
        }
        private void button2_Click(object sender, EventArgs e)
        {

            int Ntest = Convert.ToInt32(NT.Text);
            int NPop = Convert.ToInt32(NP.Text);
            int Iteration = Convert.ToInt32(NI.Text);
            int NPoint1 = Convert.ToInt32(NPO.Text);
            int NPoint2 = Convert.ToInt32(NPO2.Text);
            int Point_step = Convert.ToInt32(NPO_step.Text);
            int NExperiment1 = Convert.ToInt32(NE.Text);
            int NExperiment2 = Convert.ToInt32(NE2.Text);
            Collection_of_Set[] CS = new Collection_of_Set[Iteration];
            int iter = 0;
            int iter1 = 0;
            int[] steps = new int[Iteration];
            int[] edges = new int[Iteration];
            double[] differentials = new double[Iteration];
            Random rr = new Random(0);
            int Experiment_step = Convert.ToInt32(NE_step.Text);
            SortedList<string, int> SET_of_LO = new SortedList<string, int>();
            Queue<TT_Queue> Master_Of_Queue = new Queue<TT_Queue>();
            OLH LH_class = new OLH();
            int isnull = 0;
            for (int P = NPoint1; P <= NPoint2; P += Point_step)
                for (int N = NExperiment1; N <= NExperiment2; N++)
                {
                    double z = 0;
                    TT_Queue localarea = new TT_Queue();
                    string ss = "Timetabling_N_" + N.ToString() + "_Point_" + P.ToString() + "_Iterations_" + Iteration.ToString() + ".txt";
                    string ss2 = "Time_to_Local_Optima_" + N.ToString() + "_Point_" + P.ToString() + "_Iterations_" + Iteration.ToString() + ".txt";
                    for (int it = 0; it < Iteration; it++)
                    {
                        Master_Of_Queue.Clear();
                        SET_of_LO.Clear();
                        int[,] LH = LH_class.constructing_Latin_hypercube(N, P, rr);
                        int[,] LH_first = (int[,])LH.Clone();
                        string LH_string = LH_class.array_to_string(LH, N, P);
                        SET_of_LO.Add(LH_string, 0);
                        int step = 0;
                        int edge = 0;
                        double first = LH_class.F(LH, N, P);
                        double Best_fitness = 1000;
                        ////////////////////////////////////////////////////////////////////////////////////////
                        do
                        {
                            z = LH_class.F(LH, N, P);
                            Best_fitness = z;
                            int[,] temp = (int[,])LH.Clone();
                            double temper = 0;
                            for (int kk = 0; kk < N; kk++)
                                for (int ii = 0; ii < P; ii++)
                                    for (int ll = 0; ll < P; ll++)
                                    {
                                        if (ii != ll)
                                        {
                                            int temps = temp[kk, ii];
                                            temp[kk, ii] = temp[kk, ll];
                                            temp[kk, ll] = temps;
                                            temper = LH_class.F(temp, N, P);
                                            if (Best_fitness > temper)
                                            {
                                                Master_Of_Queue.Clear();
                                                SET_of_LO.Clear();
                                                Best_fitness = temper;
                                            }
                                            if (Best_fitness == temper)
                                            {
                                                string str = LH_class.array_to_string(temp, N, P);
                                                localarea.Best_cost = Best_fitness;
                                                localarea.Best_Neighbour = (int[,])temp.Clone();
                                                if (!SET_of_LO.ContainsKey(str))
                                                {
                                                    SET_of_LO.Add(str, 0);
                                                    Master_Of_Queue.Enqueue(localarea);
                                                }
                                            }
                                            temps = temp[kk, ll];
                                            temp[kk, ll] = temp[kk, ii];
                                            temp[kk, ii] = temps;
                                        }
                                    }

                            isnull = Master_Of_Queue.Count;
                            if (localarea.Best_cost < z)
                                edge++;
                            step++;
                            if (isnull > 0)
                            {
                                localarea = Master_Of_Queue.Dequeue();
                                LH = (int[,])localarea.Best_Neighbour.Clone();
                            }
                        } while (localarea.Best_cost <= z && isnull > 0);
                        int temperoray = 0;
                        steps[iter1] = step;
                        differentials[iter1] = first - localarea.Best_cost;
                        edges[iter1++] = edge;
                        string str_best_x = SET_of_LO.Keys[0];
                        int[,]vertex=string_to_array(str_best_x,N,P);
                        bool a = false;
                        for (int ii = iter - 1; ii >= 0; ii--)
                            if (CS[ii].s.Equals(str_best_x))
                            {
                                temperoray = distance4(LH_first, vertex, N, P);
                                if (CS[ii].SL.ContainsKey(temperoray))
                                {
                                    int temmp = CS[ii].SL.IndexOfKey(temperoray);
                                    temmp = CS[ii].SL.Values[temmp] + 1;
                                    CS[ii].SL.Remove(temperoray);
                                    CS[ii].SL.Add(temperoray, temmp);
                                }
                                else
                                    CS[ii].SL.Add(temperoray, 1);
                                CS[ii].frequently++;
                                a = true;
                                break;
                            }
                        if (!a)
                        {
                            CS[iter] = new Collection_of_Set();
                            CS[iter].SL = new SortedList<int, int>();
                            temperoray = distance4(LH_first, vertex, N, P);
                            CS[iter].SL.Add(temperoray, 1);
                            CS[iter].s = str_best_x;
                            CS[iter].fitness = Best_fitness;
                            CS[iter].size_summit = SET_of_LO.Count;
                            CS[iter].frequently++;
                            iter++;
                        }
                    }



                    #region Creating File
                    //............................... create file Time

                    bubble_sort(ref CS, iter);
                    int ma = 1;
                    int max = 0;
                    for (int max_in = 0; max_in < iter; max_in++)
                    {
                        if (max < CS[max_in].SL.Keys[CS[max_in].SL.Count - 1])
                            max = CS[max_in].SL.Keys[CS[max_in].SL.Count - 1];
                    }

                    sw = new StreamWriter(ss);
                    for (int i = 0; i < iter; i++)
                    {
                        ma = 1;
                        if (CS[i].size_summit == 0)
                            break;
                        for (int k = 0; k < CS[i].s.Length; k++)
                        {
                            sw.Write(CS[i].s[k] + " ");
                        }
                        sw.Write(" " + CS[i].fitness.ToString());
                        sw.Write(" " + CS[i].size_summit.ToString());
                        sw.Write(" " + CS[i].frequently.ToString());
                        for (int j = 0; j < CS[i].SL.Count; j++)
                        {
                            int helping = CS[i].SL.Keys[j];
                            while (ma < helping)
                            {
                                sw.Write(" " + "0");
                                ma++;
                            }
                            sw.Write(" " + CS[i].SL.Values[j].ToString());
                            ma++;
                        }

                        while (ma <= max)
                        {
                            sw.Write(" " + "0");
                            ma++;
                        }
                        sw.WriteLine();
                    }
                    sw.Close();
                    sw = new StreamWriter(ss2);
                    //**************************************************Time To sw2
                    for (int kk = 0; kk < iter1; kk++)
                    {
                        sw.Write(steps[kk].ToString());
                        sw.Write(" " + differentials[kk].ToString());
                        sw.Write(" " + edges[kk].ToString());
                        sw.WriteLine();
                    }
                    sw.Close();
                }
            #endregion
        }
        private void bubble_sort(ref Collection_of_Set[] CS, int count)
        {
            Collection_of_Set temp = new Collection_of_Set();
            for (int i = 0; i < count - 1; i++)
                for (int j = i + 1; j < count; j++)
                    if (CS[i].fitness > CS[j].fitness)
                    {
                        temp = CS[i];
                        CS[i] = CS[j];
                        CS[j] = temp;
                    }
        }
        public double[,] Node_treatment(double[,] Node,int N,int P,Random rr)
        {
            double min = 0;
            double max = 1;
            for (int ii = 0; ii < N; ii++)
                for (int jj = 0; jj < P; jj++)
                {
                    if (Node[ii, jj] > max)
                        Node[ii, jj] = rr.NextDouble();
                    if (Node[ii, jj] < min)
                        Node[ii, jj] = rr.NextDouble();
                }
            return Node;
        }
        public int distance4(int[,] LH1, int[,] LH2, int N, int P)
        {
            int dist=0;
            for (int ii = 0; ii < N; ii++)
                for (int jj = 0; jj < P; jj++)
                    if (LH1[ii, jj] != LH2[ii, jj])
                        dist++;
            return dist / (P * N);
        }
        public int[,] string_to_array(string ss,int N,int P)
        {
            string[] all = ss.Split(' ');
            int[,]LH=new int[N,P];
            int kk = 0;
            for (int ii = 0; ii < N; ii++)
                for (int jj = 0; jj < P; jj++)
                    LH[ii, jj] = Convert.ToInt32(all[kk++]);
            return LH;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "DE" || comboBox1.Text == "ES"||comboBox1.Text=="ILS"||comboBox1.Text=="MASW")
                button1.Enabled = true;
            if (comboBox1.Text == "ESE")
            {
                SA.Enabled = true;
                button1.Enabled = true;
                SA.Text = "ESE";
                label27.Text = "J:";
                label28.Text = "M:";
                GA.Enabled = false;
                PSO.Enabled = false;
                MOA.Enabled = false;
            }
            else
            {
                label27.Text = "Cooling_rate";
                label28.Text = "N:";
            }
            if (comboBox1.Text == "MOA" || comboBox1.Text == "MAMOA" || comboBox1.Text == "MOA2" || comboBox1.Text == "MOA+OBL" || comboBox1.Text == "MOAC")
            {
                MOA.Enabled = true;
                button1.Enabled = true;
                SA.Enabled = false;
                GA.Enabled = false;
                PSO.Enabled = false;
            }
            else if (comboBox1.Text == "CP")
            {
                button1.Enabled = true;
            }
            else if (comboBox1.Text == "Genetic")
            {
                GA.Enabled = true;
                button1.Enabled = true;
                SA.Enabled = false;
                PSO.Enabled = false;
                MOA.Enabled = false;
            }
            else if (comboBox1.Text == "SA")
            {
                SA.Enabled = true;
                button1.Enabled = true;
                GA.Enabled = false;
                PSO.Enabled = false;
                MOA.Enabled = false;
            }
            else if (comboBox1.Text == "PSO" || comboBox1.Text == "MAPSO")
            {

                PSO.Enabled = true;
                button1.Enabled = true;
                SA.Enabled = false;
                GA.Enabled = false;
                MOA.Enabled = false;
            }

        }



    }

}
