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
            comboBox1.Text = "DMOA";
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
            NT.Text = "4";
            //NI.Text = "1000";
            NP.Text = "25";
            //NPO.Text = "50";
            //NE.Text = "2";
            //NPO2.Text = "200";
            //NE2.Text = "2";
            //NPO_step.Text = "50";
            //NE_step.Text = "5";
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
                //int[] Pops = {  100 };
                //for (int pp = 0; pp < Pops.Length; pp++)
                //{
                //    NPop = Pops[pp];
                //    //int[] Point = { 50, 100, 150, 250, 350 };
                //    int[] Point = { 350 };
                for (int P = NPoint1; P <= NPoint2; P += Point_step)
                    //for (int III = 0; III < Point.Length; III++)
                    for (int N = NExperiment1; N <= NExperiment2; N++)
                    {
                        //int P = Point[III];
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
                            #region audze_Eiglas;
                            #region GA
                            if (method == "Genetic")
                            {
                                int min_index = 0;
                                //double mu1 = Convert.ToDouble(Mu1.Text);
                                //double mu2 = Convert.ToDouble(Mu2.Text);
                                //double mu_step = Convert.ToDouble(Mu_step.Text);
                                //double cro1 = Convert.ToDouble(cr1.Text);
                                //double cro2 = Convert.ToDouble(cr2.Text);
                                //double cro_step = Convert.ToDouble(cr_step.Text);
                                //double[] MU_s = { 0.0001, 0.001, 0.005, 0.01, 0.1 };
                                //double[] CR_s = { 0.2, 0.4, 0.6, 0.8, 1 };
                                //for (int iii = 0; iii < 5; iii++)
                                //    for (int jjj = 0; jjj < 5; jjj++)
                                //    {
                                int FCs = 100000;
                                Iteration = FCs / NPop;
                                double mu_rate = 0.4214758;
                                double cr_rate = 0.9423646;
                                double[,] Cost = new double[Ntest, Iteration];
                                //ss = "Cost_N_" + N.ToString() + "P_" + P.ToString() + "pop_" + NPop.ToString() + method + "_cr_" + cr_rate.ToString() + "_mu_rate_" + mu_rate.ToString() + "_test_" + Ntest.ToString() + ".txt";
                                ss2 = "fit_N_" + N.ToString() + "P_" + P.ToString() + "pop_" + NPop.ToString() + method + "_cr_" + cr_rate.ToString() + "_mu_rate_" + mu_rate.ToString() + "_test_" + Ntest.ToString() + ".txt";
                                #region file_existency
                                if (!File.Exists(ss2))
                                {
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
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
                                            //Cost[tt, it] = Best_indi.F;
                                        }
                                        costs[tt] = Best_indi.F;
                                        //Nodes_test[tt].LH = (int[,])Best_indi.LH.Clone();
                                    }


                                    //sw = new StreamWriter(ss);
                                    //for (int tt = 0; tt < Ntest; tt++)
                                    //{
                                    //    for (int it = 0; it < Iteration; it++)
                                    //    {
                                    //        sw.Write(Cost[tt, it].ToString() + " ");

                                    //    }
                                    //}
                                    //sw.Close();
                                    sw = new StreamWriter(ss2);
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        sw.Write(costs[tt].ToString() + " ");
                                    }
                                    sw.Close();
                                    #endregion
                                }

                            }
                            #endregion
                            #region SA
                            else if (method == "SA")
                            {
                                int it = 0;
                                double T = 68.1384;
                                double cr = 0.8513743;
                                int FCs = 100000;
                                NPop = 1;
                                Iteration = FCs / NPop;
                                double[,] Cost = new double[Ntest, Iteration];
                                double M = P * (P - 1) * N;
                                //ss = "Result_N_" + N.ToString() + "P_" + P.ToString() + method + ".txt";
                                ss2 = "fit_N_" + N.ToString() + "P_" + P.ToString() + method + ".txt";
                                //string ss3 = "Cost_N_" + N.ToString() + "P_" + P.ToString() + method + ".txt";
                                if (!File.Exists(ss))
                                {
                                    //int Iter = 0;
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
                                                //if ((it % 100) == 0)
                                                //    Cost[tt, Iter++] = Z_best;
                                                it++;
                                            }
                                            T = T * cr;
                                        }
                                        costs[tt] = Z_best;
                                        //Nodes_test[tt].LH = (int[,])LH.Clone();
                                    }


                                    //sw = new StreamWriter(ss);
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
                                    sw = new StreamWriter(ss2);
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        sw.Write(costs[tt].ToString() + " ");
                                    }
                                    sw.Close();
                                    //sw = new StreamWriter(ss3);
                                    //for (int tt = 0; tt < Ntest; tt++)
                                    //    for (int jj = 0; jj < 1000; jj++)
                                    //    {
                                    //        sw.Write(Cost[tt, jj].ToString() + " ");
                                    //    }
                                    //sw.Close();
                                    //}
                                }

                            }
                            #endregion
                            #region CP
                            else if (method == "CP")
                            {
                                int it = 0;
                                double[,] Cost = new double[Ntest, Iteration];
                                //ss = "Result_N_" + N.ToString() + "P_" + P.ToString() + method + ".txt";
                                ss2 = "fit_N_" + N.ToString() + "P_" + P.ToString() + method + "test" + Ntest.ToString() + ".txt";
                                //string ss3 = "Cost_N_" + N.ToString() + "P_" + P.ToString() + method + ".txt";
                                if (!File.Exists(ss))
                                {
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        //int Iter = 0;
                                        it = 0;
                                        int[,] LH = LH_Class.constructing_Latin_hypercube(N, P, rr);
                                        double Z = 0;
                                        int MaxIter = Iteration * NPop;
                                        while (it < MaxIter)
                                        {

                                            int[,] LH_temp = (int[,])LH.Clone();
                                            double z1 = LH_Class.F(LH_temp, N, P);
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
                                                        //if ((it % 100) == 0)
                                                        //    Cost[tt, Iter++] = z1;
                                                        it++;
                                                    }
                                            }
                                            Z = z1;
                                        }
                                        costs[tt] = Z;
                                        //Nodes_test[tt].LH = (int[,])LH.Clone();
                                    }


                                    //sw = new StreamWriter(ss);
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
                                    sw = new StreamWriter(ss2);
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        sw.Write(costs[tt].ToString() + " ");
                                    }
                                    sw.Close();
                                    //sw = new StreamWriter(ss3);
                                    //for (int tt = 0; tt < Ntest; tt++)
                                    //    for (int jj = 0; jj < 1000; jj++)
                                    //    {
                                    //        sw.Write(Cost[tt, jj].ToString() + " ");
                                    //    }
                                    //sw.Close();
                                }

                            }
                            #endregion
                            #region MOA
                            else if (method == "MOAOriginal")
                            {
                                double short_range = 0.01;
                                int acceleration = Convert.ToInt32(Ac.Text);
                                int Distance = Convert.ToInt32(D.Text);
                                double[] Magnet = new double[NPop];
                                double[] Mass = new double[NPop];
                                double al1 = Convert.ToDouble(Al.Text);
                                double al2 = Convert.ToDouble(Al2.Text);
                                double al_step = Convert.ToDouble(Al_step.Text);
                                double in1 = Convert.ToDouble(Inten.Text);
                                double in2 = Convert.ToDouble(Inten2.Text);
                                double in_step = Convert.ToDouble(Inten_step.Text);
                                for (double alpha = al1; alpha < al2; alpha += al_step)
                                    for (double intensity = in1; intensity < al2; intensity += in_step)
                                    {
                                        ss = "Result_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_intensity" + intensity.ToString() + "_alpha_" + alpha.ToString() + "_Dis_" + method + Distance.ToString() + "_Acc_" + Ac.Text + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + "_struct_" + structure + ".txt";
                                        ss2 = "fit_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_intensity" + intensity.ToString() + "alpha_" + alpha.ToString() + "_Dis_" + method + Distance.ToString() + "_Acc_" + Ac.Text + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + "_struct_" + structure + ".txt";
                                        if (!File.Exists(ss))
                                        {
                                            for (int tt = 0; tt < Ntest; tt++)
                                            {
                                                MOA_Node[] Nodes = new MOA_Node[NPop];
                                                MOA_Node[] Forces = new MOA_Node[NPop];
                                                MOA_Node[] a = new MOA_Node[NPop];
                                                MOA_Node[] v = new MOA_Node[NPop];
                                                Latin_Hypercube[] LHC = new Latin_Hypercube[NPop];
                                                Latin_Hypercube Best_indi = new Latin_Hypercube();
                                                double[] distances = new double[NPop];
                                                Best_indi.F = 1000;

                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    Forces[ii].x = new double[N, P];
                                                    a[ii].x = new double[N, P];
                                                    v[ii].x = new double[N, P];
                                                }
                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    Nodes[ii].x = LH_Class.node_constructing(N, P, rr);
                                                }
                                                for (int it = 0; it < Iteration; it++)
                                                {
                                                    Fmax = 0; Fmin = 1000;
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
                                                    }
                                                    double range = Fmax - Fmin;
                                                    for (int ii = 0; ii < NPop; ii++)
                                                    {
                                                        Magnet[ii] = (Fmax - LHC[ii].F) / (range);
                                                        Mass[ii] = Magnet[ii] * intensity + alpha;
                                                    }

                                                    for (int ii = 0; ii < NPop; ii++)
                                                    {
                                                        Forces[ii].x = new double[N, P];
                                                    }
                                                    for (int ii = 0; ii < NPop; ii++)
                                                    {
                                                        int[] Neigbour = LH_Class.Structures(ii, NPop, structure, rr);
                                                        for (int jj = 0; jj < Neigbour.Length; jj++)
                                                        {
                                                            if (ii != Neigbour[jj])
                                                            {
                                                                if (D.Text == "1")
                                                                    distances[ii] = distance1(Nodes[ii].x, Nodes[Neigbour[jj]].x, N, P);
                                                                else
                                                                    distances[ii] = distance4(LHC[ii].LH, LHC[Neigbour[jj]].LH, N, P);
                                                                if (distances[ii] > short_range)
                                                                {
                                                                    for (int n = 0; n < N; n++)
                                                                        for (int p = 0; p < P; p++)
                                                                            Forces[ii].x[n, p] = Forces[ii].x[n, p] + (Nodes[Neigbour[jj]].x[n, p] - Nodes[ii].x[n, p]) * Magnet[Neigbour[jj]] / distances[ii];

                                                                }

                                                                else
                                                                {
                                                                    for (int n = 0; n < N; n++)
                                                                        for (int p = 0; p < P; p++)
                                                                        {
                                                                            Forces[ii].x[n, p] = rr.NextDouble();
                                                                        }
                                                                    Nodes[ii].x = LH_Class.node_constructing(N, P, rr);
                                                                }
                                                            }
                                                        }
                                                        //for (int n = 0; n < N; n++)
                                                        //    for (int p = 0; p < P; p++)
                                                        //    {
                                                        //        Forces[ii].x[n, p] = Forces[ii].x[n, p] / (NPop - 1);
                                                        //        //Forces[ii].x[n, p] = Forces[ii].x[n, p] * rr.NextDouble();
                                                        //    }

                                                    }
                                                    if (acceleration == 0)
                                                    {
                                                        for (int ii = 0; ii < NPop; ii++)
                                                        {
                                                            for (int n = 0; n < N; n++)
                                                                for (int p = 0; p < P; p++)
                                                                {
                                                                    v[ii].x[n, p] = (Forces[ii].x[n, p] / Mass[ii]);
                                                                    Nodes[ii].x[n, p] = Nodes[ii].x[n, p] + v[ii].x[n, p];
                                                                }

                                                            Nodes[ii].x = Node_treatment(Nodes[ii].x, N, P, rr);
                                                        }
                                                    }
                                                    else if (acceleration == 1)
                                                    {
                                                        for (int ii = 0; ii < NPop; ii++)
                                                        {
                                                            for (int n = 0; n < N; n++)
                                                                for (int p = 0; p < P; p++)
                                                                {
                                                                    a[ii].x[n, p] = (Forces[ii].x[n, p] / Mass[ii]);
                                                                    v[ii].x[n, p] = v[ii].x[n, p] * rr.NextDouble() + a[ii].x[n, p];
                                                                    Nodes[ii].x[n, p] = Nodes[ii].x[n, p] + v[ii].x[n, p];
                                                                }

                                                            Nodes[ii].x = Node_treatment(Nodes[ii].x, N, P, rr);
                                                        }
                                                    }


                                                }
                                                costs[tt] = Best_indi.F;
                                                Nodes_test[tt].LH = (int[,])Best_indi.LH.Clone();
                                            }
                                            sw = new StreamWriter(ss);
                                            for (int tt = 0; tt < Ntest; tt++)
                                            {
                                                for (int ii = 0; ii < N; ii++)
                                                {
                                                    for (int jj = 0; jj < P; jj++)
                                                    {
                                                        sw.Write(Nodes_test[tt].LH[ii, jj].ToString() + " ");
                                                    }
                                                    sw.WriteLine();
                                                }
                                            }
                                            sw.Close();
                                            sw = new StreamWriter(ss2);
                                            for (int tt = 0; tt < Ntest; tt++)
                                            {
                                                sw.Write(costs[tt].ToString() + " ");
                                            }
                                            sw.Close();
                                        }
                                    }
                            }
                            #endregion
                            #region MOA2
                            else if (method == "MOA2")
                            {
                                //StreamReader SR2 = new StreamReader("parameter.txt");
                                //string[] SS = SR2.ReadToEnd().Split('\n', '\r');
                                //string[] inten_ar = SS[0].Split('=', ',');
                                //string[] al_ar = SS[2].Split('=', ',');
                                //double[] int_ar = new double[al_ar.Length - 1];
                                //double[] alp_ar = new double[inten_ar.Length - 1];
                                //for (int ii = 0; ii < inten_ar.Length - 1; ii++)
                                //    int_ar[ii] = Convert.ToDouble(inten_ar[ii + 1]);
                                //for (int ii = 0; ii < al_ar.Length - 1; ii++)
                                //    alp_ar[ii] = Convert.ToDouble(al_ar[ii + 1]);
                                //double[,] divers = new double[Ntest, Iteration];
                                //double[,] fitnesses = new double[Ntest, Iteration];
                                double short_range = Convert.ToDouble(SHR.Text);
                                int acceleration = Convert.ToInt32(Ac.Text);
                                int Distance = Convert.ToInt32(D.Text);
                                double[] Magnet = new double[NPop];
                                double[] Mass = new double[NPop];
                                double al1 = Convert.ToDouble(Al.Text);
                                double al2 = Convert.ToDouble(Al2.Text);
                                double al_step = Convert.ToDouble(Al_step.Text);
                                double in1 = Convert.ToDouble(Inten.Text);
                                double in2 = Convert.ToDouble(Inten2.Text);
                                double in_step = Convert.ToDouble(Inten_step.Text);
                                //for (double alpha = al1; alpha <= al2; alpha += al_step)
                                //    for (double intensity = in1; intensity <= in2; intensity += in_step)
                                //    {
                                //for (int ai = 0; ai < alp_ar.Length; ai++)
                                //    for (int iij = 0; iij < int_ar.Length; iij++)
                                //    {
                                //double alpha = alp_ar[ai];
                                //double intensity = int_ar[iij];
                                double alpha = 0.0001;
                                double intensity = 1;
                                //ss = "Result_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_intensity" + intensity.ToString() + "_alpha_" + alpha.ToString() + "_Dis_" + method + Distance.ToString() + "_Acc_" + Ac.Text + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + ".txt";
                                //ss2 = "Result\\fit_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_intensity" + intensity.ToString() + "alpha_" + alpha.ToString() + "_Dis_" + method + Distance.ToString() + "_Acc_" + Ac.Text + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + ".txt";
                                ss2 = "Result\\fit_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_intensity" + intensity.ToString() + "alpha_" + alpha.ToString() + "_Dis_" + method + Distance.ToString() + "_Acc_" + Ac.Text + "_Iteration_" + Iteration.ToString() + ".txt";
                                        //string ss3 = "Fiter_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_intensity" + intensity.ToString() + "alpha_" + alpha.ToString() + "_Dis_" + method + Distance.ToString() + "_Acc_" + Ac.Text + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + ".txt";
                                        //string ss4 = "Diver_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_intensity" + intensity.ToString() + "alpha_" + alpha.ToString() + "_Dis_" + method + Distance.ToString() + "_Acc_" + Ac.Text + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + ".txt";
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
                                                Latin_Hypercube Best_indi = new Latin_Hypercube();
                                                double[] distances = new double[NPop];
                                                Best_indi.F = 1000;

                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    Forces[ii].x = new double[N, P];
                                                    a[ii].x = new double[N, P];
                                                    v[ii].x = new double[N, P];
                                                }
                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    Nodes[ii].x = LH_Class.node_constructing(N, P, rr);
                                                    BNodes[ii].x = (double[,])Nodes[ii].x.Clone();
                                                }
                                                for (int it = 0; it < Iteration; it++)
                                                {
                                                    Fmax = 0; Fmin = 1000;
                                                    int min_index = 0; int max_index = 0;
                                                    for (int ii = 0; ii < NPop; ii++)
                                                    {
                                                        LHC[ii].LH = LH_Class.convert_search_s_to_solution_s(Nodes[ii].x, N, P);
                                                        LHC[ii].F = LH_Class.F(LHC[ii].LH, N, P);
                                                        B[ii].F = LHC[ii].F;
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
                                                    }
                                                    double range = Fmax - Fmin;
                                                    for (int ii = 0; ii < NPop; ii++)
                                                    {
                                                        Magnet[ii] = (Fmax - LHC[ii].F) / (range);
                                                        Mass[ii] = Magnet[ii] * intensity + alpha;
                                                    }
                                                    BNodes = LH_Class.cellular(LHC, B, Nodes, BNodes, NPop);
                                                    for (int ii = 0; ii < NPop; ii++)
                                                    {
                                                        Forces[ii].x = new double[N, P];
                                                    }
                                                    for (int ii = 0; ii < NPop; ii++)
                                                    {
                                                        distances[ii] = distance1(Nodes[ii].x, BNodes[ii].x, N, P);
                                                        //if (distances[ii] > short_range)
                                                        //{
                                                        for (int n = 0; n < N; n++)
                                                            for (int p = 0; p < P; p++)
                                                                Forces[ii].x[n, p] = Forces[ii].x[n, p] + (BNodes[ii].x[n, p] - Nodes[ii].x[n, p]) * Magnet[BNodes[ii].index] / distances[ii];

                                                        //}
                                                        //else
                                                        //{
                                                        //for (int n = 0; n < N; n++)
                                                        //    for (int p = 0; p < P; p++)
                                                        //    {
                                                        //        Forces[ii].x[n, p] = rr.NextDouble();
                                                        //    }
                                                        //Nodes[ii].x = LH_Class.node_constructing(N, P, rr);
                                                        //}

                                                        //for (int n = 0; n < N; n++)
                                                        //    for (int p = 0; p < P; p++)
                                                        //    {
                                                        //        //Forces[ii].x[n, p] =  Forces[ii].x[n, p] /(NPop-1);
                                                        //        Forces[ii].x[n, p] = Forces[ii].x[n, p] * rr.NextDouble();
                                                        //    }
                                                    }
                                                    if (acceleration == 0)
                                                    {
                                                        for (int ii = 0; ii < NPop; ii++)
                                                        {
                                                            for (int n = 0; n < N; n++)
                                                                for (int p = 0; p < P; p++)
                                                                {
                                                                    v[ii].x[n, p] = (Forces[ii].x[n, p] / Mass[ii]) * rr.NextDouble();
                                                                    Nodes[ii].x[n, p] = Nodes[ii].x[n, p] + v[ii].x[n, p];
                                                                }

                                                            Nodes[ii].x = Node_treatment(Nodes[ii].x, N, P, rr);
                                                        }
                                                    }
                                                    else if (acceleration == 1)
                                                    {
                                                        for (int ii = 0; ii < NPop; ii++)
                                                        {
                                                            for (int n = 0; n < N; n++)
                                                                for (int p = 0; p < P; p++)
                                                                {
                                                                    a[ii].x[n, p] = (Forces[ii].x[n, p] / Mass[ii]);
                                                                    v[ii].x[n, p] = v[ii].x[n, p] * rr.NextDouble() + a[ii].x[n, p];
                                                                    Nodes[ii].x[n, p] = Nodes[ii].x[n, p] + v[ii].x[n, p];
                                                                }

                                                            Nodes[ii].x = Node_treatment(Nodes[ii].x, N, P, rr);
                                                        }
                                                    }

                                                    //divers[tt, it] = LH_Class.diversity(LHC, NPop, N, P);
                                                    //fitnesses[tt, it] = LH_Class.best_for_iter(LHC, NPop);

                                                }
                                                costs[tt] = Best_indi.F;
                                                Nodes_test[tt].LH = (int[,])Best_indi.LH.Clone();
                                            }
                                            //sw = new StreamWriter(ss);
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
                                            sw = new StreamWriter(ss2);
                                            ss = "Result\\fit_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_intensity" + intensity.ToString() + "alpha_" + alpha.ToString() + "_Dis_" + method + Distance.ToString() + "_Acc_" + Ac.Text + "_Iteration_1000_test_10.txt";
                                            if (File.Exists(ss))
                                            {
                                                StreamReader sr = new StreamReader(ss);
                                                sw.Write(sr.ReadToEnd());
                                                sr.Close();
                                            }
                                            for (int tt = 0; tt < Ntest; tt++)
                                            {
                                                sw.Write(costs[tt].ToString() + " ");
                                            }
                                            sw.Close();

                                            //sw = new StreamWriter(ss3);
                                            //for (int ii = 0; ii < Ntest; ii++)
                                            //{
                                            //    for (int jj = 0; jj < Iteration; jj++)
                                            //        sw.Write(fitnesses[ii, jj].ToString() + "  ");
                                            //    sw.WriteLine();
                                            //}
                                            //sw.Close();
                                            //sw = new StreamWriter(ss4);
                                            //for (int ii = 0; ii < Ntest; ii++)
                                            //{
                                            //    for (int jj = 0; jj < Iteration; jj++)
                                            //        sw.Write(divers[ii, jj].ToString() + "  ");
                                            //    sw.WriteLine();
                                            //}
                                            //sw.Close();
                                        //}
                                    }
                            }
                            #endregion
                            #region MOA3
                            else if (method == "TMOA")
                            {
                                // Frankenstein MOA parameters
                                //int estep = 0;
                                //int k = NPop * 2;
                                double T = 0.1;
                                ////////////////////////////////////
                                ArrayList[] Neighbors = new ArrayList[NPop];
                                for (int ii = 0; ii < NPop; ii++)
                                {
                                    Neighbors[ii] = new ArrayList();
                                    for (int jj = 0; jj < NPop; jj++)
                                        if (ii != jj)
                                            Neighbors[ii].Add(jj);
                                }
                                double[,] divers = new double[Ntest, Iteration];
                                double[,] fitnesses = new double[Ntest, Iteration];
                                double CExp = Convert.ToDouble(Cexp_text.Text);
                                double TExp = Convert.ToDouble(TExp_text.Text);
                                int ISSR = Convert.ToInt32(ISSR_combo.Text);
                                double CSRR = Convert.ToDouble(CSRR_text.Text);
                                //double core_effect = Convert.ToDouble(CE.Text);
                                double core_effect = 0.5;
                                double opposed_core_effect = 1 - core_effect;
                                //int zetta = 2;
                                //int portion = (Iteration / NPop)*zetta;
                                //if (orgMOA.Checked)
                                //    opposed_core_effect = 1;
                                //else
                                //    method = "MOA_opt";
                                double short_range = Convert.ToDouble(SHR.Text);
                                int acceleration = Convert.ToInt32(Ac.Text);
                                int Distance = Convert.ToInt32(D.Text);
                                double[] Magnet = new double[NPop];
                                double[] Mass = new double[NPop];
                                double intensity = 1;
                                double alpha = 0.1;
                                ss = "Res_N_" + N.ToString() + "P_" + P.ToString() + "T_" + T.ToString() + "_Tcc" + TC.Text.ToString() + "_ce_" + core_effect.ToString() + "_Pop_" + NPop.ToString() + "_int" + intensity.ToString() + "_al_" + alpha.ToString() + "_Dis_" + method + Distance.ToString() + "_Acc_" + Ac.Text + "_It_" + Iteration.ToString() + "_t_" + Ntest.ToString() + "_str_" + structure + ".txt";
                                ss2 = "fit_N_" + N.ToString() + "P_" + P.ToString() + "T_" + T.ToString() + "_Tcc" + TC.Text.ToString() + "_ce_" + core_effect.ToString() + "_Pop_" + NPop.ToString() + "_int" + intensity.ToString() + "al_" + alpha.ToString() + "_Dis_" + method + Distance.ToString() + "_Acc_" + Ac.Text + "_It_" + Iteration.ToString() + "_t_" + Ntest.ToString() + "_str_" + structure + ".txt";
                                string ss3 = "Fiter_N_" + N.ToString() + "P_" + P.ToString() + "T_" + T.ToString() + "_Tcc" + TC.Text.ToString() + "_ce_" + core_effect.ToString() + "_Pop_" + NPop.ToString() + "_int" + intensity.ToString() + "_al_" + alpha.ToString() + "_Dis_" + method + Distance.ToString() + "_Acc_" + Ac.Text + "_It_" + Iteration.ToString() + "_t_" + Ntest.ToString() + "_str_" + structure + ".txt";
                                string ss4 = "Diver_N_" + N.ToString() + "P_" + P.ToString() + "_Tcc" + TC.Text.ToString() + "_ce_" + core_effect.ToString() + "_Pop_" + NPop.ToString() + "_int" + intensity.ToString() + "al_" + alpha.ToString() + "_Dis_" + method + Distance.ToString() + "_Acc_" + Ac.Text + "_It_" + Iteration.ToString() + "_t_" + Ntest.ToString() + "_str_" + structure + ".txt";
                                if (!File.Exists(ss))
                                {
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        //core_effect = Convert.ToDouble(CE.Text);
                                        //T = 0.1;
                                        core_effect = 0.5;
                                        MOA_Node[] Nodes = new MOA_Node[NPop];
                                        MOA_Node[] BNodes = new MOA_Node[NPop];
                                        MOA_Node Best_node = new MOA_Node();
                                        MOA_Node[] Forces = new MOA_Node[NPop];
                                        MOA_Node[] a = new MOA_Node[NPop];
                                        MOA_Node[] v = new MOA_Node[NPop];
                                        Latin_Hypercube[] LHC = new Latin_Hypercube[NPop];
                                        Latin_Hypercube[] B = new Latin_Hypercube[NPop];
                                        Latin_Hypercube Best_indi = new Latin_Hypercube();
                                        double[] distances = new double[NPop];
                                        Best_indi.F = 1000;
                                        int running_update_time = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(Iteration / (NPop - 3))));
                                        int declination_range = (2 * Iteration) / NPop;
                                        int L = NPop / 2;
                                        for (int ii = 0; ii < NPop; ii++)
                                        {
                                            Forces[ii].x = new double[N, P];
                                            a[ii].x = new double[N, P];
                                            v[ii].x = new double[N, P];
                                        }
                                        for (int ii = 0; ii < NPop; ii++)
                                        {
                                            Nodes[ii].x = LH_Class.node_constructing(N, P, rr);
                                            BNodes[ii].x = (double[,])Nodes[ii].x.Clone();
                                            BNodes[ii].f = 10000;
                                        }
                                        for (int it = 0; it < Iteration; it++)
                                        {
                                            Fmax = 0; Fmin = 1000;
                                            int min_index = 0; int max_index = 0;
                                            for (int ii = 0; ii < NPop; ii++)
                                            {
                                                LHC[ii].LH = LH_Class.convert_search_s_to_solution_s(Nodes[ii].x, N, P);
                                                LHC[ii].F = LH_Class.F(LHC[ii].LH, N, P);
                                                B[ii].F = LHC[ii].F;
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
                                                Best_node.x = (double[,])Nodes[min_index].x.Clone();
                                            }
                                            if (Exp.Text == "YES")
                                            {
                                                double div = LH_Class.diversity(LHC, NPop, N, P);
                                                if (div < TExp)
                                                {
                                                    for (int ii = 0; ii < NPop; ii++)
                                                        for (int jj = 0; jj < N; jj++)
                                                            for (int kk = 0; kk < P; kk++)
                                                            {
                                                                Nodes[ii].x[jj, kk] += 2 * CExp * rr.NextDouble() - CExp;
                                                            }
                                                }
                                            }
                                            double range = Fmax - Fmin;
                                            for (int ii = 0; ii < NPop; ii++)
                                            {
                                                Magnet[ii] = (Fmax - LHC[ii].F) / (range);
                                                Mass[ii] = Magnet[ii] * intensity + alpha;
                                            }
                                            //if (structure == "Frankenstein")
                                            //{
                                            //    LH_Class.Topology_Update2(ref Neighbors,NPop,rr,it,running_update_time);
                                            //    BNodes=LH_Class.Define_Local_Best(Neighbors,LHC,Nodes,BNodes,NPop);
                                            //}
                                            if (structure != "Dynamic" && structure != "RDynamic" && structure != "RRDynamic")
                                                BNodes = LH_Class.StructureCore(LHC, Nodes, BNodes, NPop, structure, rr);
                                            //else if(structure !="Frankenstein")
                                            //    BNodes = LH_Class.DynamicStructureCore3(LHC, B, Nodes, BNodes,portion, it, NPop,rr);
                                            for (int ii = 0; ii < NPop; ii++)
                                            {
                                                Forces[ii].x = new double[N, P];
                                            }
                                            for (int ii = 0; ii < NPop; ii++)
                                            {
                                                #region reaching to core
                                                if (D.Text == "1")
                                                    distances[ii] = distance1(Nodes[ii].x, BNodes[ii].x, N, P);
                                                else if (D.Text == "2")
                                                    distances[ii] = distance2(Nodes[ii].x, BNodes[ii].x, N, P);
                                                else if (D.Text == "3")
                                                    distances[ii] = distance3(Nodes[ii].x, BNodes[ii].x, N, P);
                                                else if (D.Text == "4")
                                                    distances[ii] = distance4(LHC[ii].LH, LHC[BNodes[ii].index].LH, N, P);

                                                // reducing core effect
                                                opposed_core_effect = 1 - core_effect;
                                                //
                                                //if (distances[ii] > short_range)
                                                //{
                                                for (int n = 0; n < N; n++)
                                                    for (int p = 0; p < P; p++)
                                                        Forces[ii].x[n, p] = Forces[ii].x[n, p] + (BNodes[ii].x[n, p] - Nodes[ii].x[n, p]) * Magnet[BNodes[ii].index] * core_effect / distances[ii];

                                                //}
                                                //else
                                                //{

                                                //    if (ISSR == 1)
                                                //    {
                                                //        int dim = Convert.ToInt32(Math.Ceiling(CSRR * N));
                                                //        int Points = Convert.ToInt32(Math.Ceiling(CSRR * P));
                                                //        LH_Class.Short_Range_Operation1(ref Nodes[ii].x, dim, Points, P, rr);
                                                //    }
                                                //    else if (ISSR == 2)
                                                //    {
                                                //        LH_Class.Short_Range_Operation2(ref Nodes[ii].x, N, P, CSRR, rr);
                                                //    }
                                                //    else if (ISSR == 3)
                                                //    {
                                                //        LH_Class.Short_Range_Operation3(ref Forces[ii].x, N, P, CSRR, rr);
                                                //    }
                                                //    else
                                                //    {
                                                //        //Do nothing when the selected option is the basic MOA
                                                //    }
                                                //}
                                                #endregion
                                                #region particles effect
                                                if (opposed_core_effect > 0)
                                                {
                                                    int[] Neigbour = LH_Class.Structures(ii, NPop, structure, rr);
                                                    for (int jj = 0; jj < Neigbour.Length; jj++)
                                                    {
                                                        if (ii != Neigbour[jj] && Nodes[ii].index != jj)
                                                        {
                                                            if (D.Text == "1")
                                                                distances[ii] = distance1(Nodes[ii].x, Nodes[Neigbour[jj]].x, N, P);
                                                            else if (D.Text == "2")
                                                                distances[ii] = distance2(Nodes[ii].x, Nodes[Neigbour[jj]].x, N, P);
                                                            else if (D.Text == "3")
                                                                distances[ii] = distance3(Nodes[ii].x, Nodes[Neigbour[jj]].x, N, P);
                                                            else
                                                                distances[ii] = distance4(LHC[ii].LH, LHC[Neigbour[jj]].LH, N, P);
                                                            if (distances[ii] > short_range)
                                                            {
                                                                for (int n = 0; n < N; n++)
                                                                    for (int p = 0; p < P; p++)
                                                                        Forces[ii].x[n, p] += (Nodes[Neigbour[jj]].x[n, p] - Nodes[ii].x[n, p]) * Magnet[Neigbour[jj]] * opposed_core_effect / distances[ii];

                                                            }


                                                            else
                                                            {
                                                                if (ISSR == 1)
                                                                {
                                                                    int dim = Convert.ToInt32(Math.Ceiling(CSRR * N));
                                                                    int Points = Convert.ToInt32(Math.Ceiling(CSRR * P));
                                                                    LH_Class.Short_Range_Operation1(ref Nodes[ii].x, dim, Points, P, rr);
                                                                }
                                                                else if (ISSR == 2)
                                                                {
                                                                    LH_Class.Short_Range_Operation2(ref Nodes[ii].x, N, P, CSRR, rr);
                                                                }
                                                                else if (ISSR == 3)
                                                                {
                                                                    LH_Class.Short_Range_Operation3(ref Forces[ii].x, N, P, CSRR, rr);
                                                                }
                                                                else
                                                                {
                                                                    //Do nothing when the selected option is the basic MOA
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                #endregion

                                            }
                                            if (acceleration == 0)
                                            {
                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    for (int n = 0; n < N; n++)
                                                        for (int p = 0; p < P; p++)
                                                        {
                                                            v[ii].x[n, p] = (Forces[ii].x[n, p] / Mass[ii]) * rr.NextDouble();
                                                            Nodes[ii].x[n, p] = Nodes[ii].x[n, p] + v[ii].x[n, p];
                                                            //Nodes[ii].x[n, p] = Nodes[ii].x[n, p] + v[ii].x[n, p] + (Best_node.x[n, p]-Nodes[ii].x[n, p])*T*rr.NextDouble() ;
                                                        }

                                                    Nodes[ii].x = Node_treatment(Nodes[ii].x, N, P, rr);
                                                }
                                            }
                                            else if (acceleration == 1)
                                            {
                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    for (int n = 0; n < N; n++)
                                                        for (int p = 0; p < P; p++)
                                                        {
                                                            a[ii].x[n, p] = (Forces[ii].x[n, p] / Mass[ii]);
                                                            v[ii].x[n, p] = v[ii].x[n, p] * rr.NextDouble() + a[ii].x[n, p];
                                                            Nodes[ii].x[n, p] = Nodes[ii].x[n, p] + v[ii].x[n, p];
                                                        }

                                                    Nodes[ii].x = Node_treatment(Nodes[ii].x, N, P, rr);
                                                }
                                            }
                                            divers[tt, it] = LH_Class.diversity(LHC, NPop, N, P);
                                            fitnesses[tt, it] = LH_Class.best_for_iter(LHC, NPop);
                                        }
                                        costs[tt] = Best_indi.F;
                                        Nodes_test[tt].LH = (int[,])Best_indi.LH.Clone();
                                    }
                                    sw = new StreamWriter(ss);
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        for (int ii = 0; ii < N; ii++)
                                        {
                                            for (int jj = 0; jj < P; jj++)
                                            {
                                                sw.Write(Nodes_test[tt].LH[ii, jj].ToString() + " ");
                                            }
                                            sw.WriteLine();
                                        }
                                    }
                                    sw.Close();
                                    sw = new StreamWriter(ss2);
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        sw.Write(costs[tt].ToString() + " ");
                                    }
                                    sw.Close();
                                    sw = new StreamWriter(ss3);
                                    for (int ii = 0; ii < Ntest; ii++)
                                    {
                                        for (int jj = 0; jj < Iteration; jj++)
                                            sw.Write(fitnesses[ii, jj].ToString() + "  ");
                                        sw.WriteLine();
                                    }
                                    sw.Close();
                                    sw = new StreamWriter(ss4);
                                    for (int ii = 0; ii < Ntest; ii++)
                                    {
                                        for (int jj = 0; jj < Iteration; jj++)
                                            sw.Write(divers[ii, jj].ToString() + "  ");
                                        sw.WriteLine();
                                    }
                                    sw.Close();
                                }

                            }
                            #endregion
                            #region MOAC
                            else if (method == "MOAC")
                            {
                                int acceleration = 0;
                                int Distance = 1;
                                double[] betta = { 0, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1 };
                                double gamma = 0.99;
                                //int O = N * P * 1000000;
                                Int64 max = Iteration * NPop;
                                Int64 max2 = (N * (P - 1) * P) / 2;
                                Int64 O = (max * max2);
                                double intensity = 0.1;
                                //int Individual_Learning = 0;
                                double alpha = 1;
                                for (int jjj = 1; jjj < betta.Length; jjj++)
                                {
                                    Iteration = (Convert.ToInt32(2 * (O * (1 - betta[jjj])) / (NPop * N * P * (P - 1)))) + 1;
                                    int Individual_Learning = Convert.ToInt32((betta[jjj] * O) / (2 * N * P * Iteration));
                                    double[] Magnet = new double[NPop];
                                    double[] Mass = new double[NPop];
                                    double[,] divers = new double[Ntest, Iteration];
                                    double[,] fitnesses = new double[Ntest, Iteration];
                                    double core_effect = 0.5;
                                    double opposed_core_effect = 1 - core_effect;
                                    ss = "Res_N_" + N.ToString() + "P_" + P.ToString() + "gamma_" + gamma.ToString() + "_Pop_" + NPop.ToString() + "IL" + Individual_Learning.ToString() + "_int" + intensity.ToString() + "_al_" + alpha.ToString() + "_Dis_" + method + Distance.ToString() + "_Acc_" + Ac.Text + "_It_" + Iteration.ToString() + "_t_" + Ntest.ToString() + "_str_" + structure + ".txt";
                                    ss2 = "fit_N_" + N.ToString() + "P_" + P.ToString() + "gamma_" + gamma.ToString() + "_Pop_" + NPop.ToString() + "IL" + Individual_Learning.ToString() + "_int" + intensity.ToString() + "al_" + alpha.ToString() + "_Dis_" + method + Distance.ToString() + "_Acc_" + Ac.Text + "_It_" + Iteration.ToString() + "_t_" + Ntest.ToString() + "_str_" + structure + ".txt";
                                    //string ss3 = "Fiter_N_" + N.ToString() + "P_" + P.ToString() + "T_" + T_text.Text.ToString() +"_Pop_" + NPop.ToString() + "_int" + intensity.ToString() + "_al_" + alpha.ToString() + "_Dis_" + method + Distance.ToString() + "_Acc_" + Ac.Text + "_It_" + Iteration.ToString() + "_t_" + Ntest.ToString() + "_str_" + structure + ".txt";
                                    //string ss4 = "Diver_N_" + N.ToString() + "P_" + P.ToString() + "T_" + T_text.Text.ToString() + "_Pop_" + NPop.ToString() + "_int" + intensity.ToString() + "al_" + alpha.ToString() + "_Dis_" + method + Distance.ToString() + "_Acc_" + Ac.Text + "_It_" + Iteration.ToString() + "_t_" + Ntest.ToString() + "_str_" + structure + ".txt";
                                    if (!File.Exists(ss))
                                    {
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            core_effect = 0.5;
                                            MOA_Node[] Nodes = new MOA_Node[NPop];
                                            MOA_Node[] BNodes = new MOA_Node[NPop];
                                            MOA_Node Best_node = new MOA_Node();
                                            MOA_Node[] Forces = new MOA_Node[NPop];
                                            MOA_Node[] a = new MOA_Node[NPop];
                                            MOA_Node[] v = new MOA_Node[NPop];
                                            Latin_Hypercube[] LHC = new Latin_Hypercube[NPop];
                                            Latin_Hypercube[] B = new Latin_Hypercube[NPop];
                                            Latin_Hypercube Best_indi = new Latin_Hypercube();
                                            double[] distances = new double[NPop];
                                            Best_indi.F = 1000;
                                            for (int ii = 0; ii < NPop; ii++)
                                            {
                                                Forces[ii].x = new double[N, P];
                                                a[ii].x = new double[N, P];
                                                v[ii].x = new double[N, P];
                                            }
                                            for (int ii = 0; ii < NPop; ii++)
                                            {
                                                Nodes[ii].x = LH_Class.node_constructing(N, P, rr);
                                                BNodes[ii].x = (double[,])Nodes[ii].x.Clone();
                                                BNodes[ii].f = 10000;
                                            }
                                            for (int it = 0; it < Iteration; it++)
                                            {
                                                Fmax = 0; Fmin = 1000;
                                                int min_index = 0; int max_index = 0;
                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    LHC[ii].LH = LH_Class.convert_search_s_to_solution_s(Nodes[ii].x, N, P);
                                                    LHC[ii].F = LH_Class.F(LHC[ii].LH, N, P);
                                                    B[ii].F = LHC[ii].F;
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
                                                    Best_node.x = (double[,])Nodes[min_index].x.Clone();
                                                }
                                                double range = Fmax - Fmin;
                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    Magnet[ii] = (Fmax - LHC[ii].F) / (range);
                                                    Mass[ii] = Magnet[ii] * intensity + alpha;
                                                }
                                                //if (structure != "Dynamic" && structure != "RDynamic" && structure != "RRDynamic")
                                                BNodes = LH_Class.StructureCore(LHC, Nodes, BNodes, NPop, structure, rr);
                                                //else if (structure != "Frankenstein")
                                                //    BNodes = LH_Class.DynamicStructureCore3(LHC, B, Nodes, BNodes, portion, it, NPop, rr);
                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    Forces[ii].x = new double[N, P];
                                                }
                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    #region reaching to core
                                                    if (D.Text == "1")
                                                        distances[ii] = distance1(Nodes[ii].x, BNodes[ii].x, N, P);
                                                    else if (D.Text == "2")
                                                        distances[ii] = distance2(Nodes[ii].x, BNodes[ii].x, N, P);
                                                    else if (D.Text == "3")
                                                        distances[ii] = distance3(Nodes[ii].x, BNodes[ii].x, N, P);
                                                    else if (D.Text == "4")
                                                        distances[ii] = distance4(LHC[ii].LH, LHC[BNodes[ii].index].LH, N, P);

                                                    // reducing core effect
                                                    core_effect = 1 - opposed_core_effect;
                                                    //
                                                    //if (distances[ii] > short_range)
                                                    //{
                                                    for (int n = 0; n < N; n++)
                                                        for (int p = 0; p < P; p++)
                                                            Forces[ii].x[n, p] = Forces[ii].x[n, p] + (BNodes[ii].x[n, p] - Nodes[ii].x[n, p]) * Magnet[BNodes[ii].index] * core_effect / distances[ii] + (Best_node.x[n, p] - Nodes[ii].x[n, p]) * rr.NextDouble();


                                                    #endregion
                                                    #region particles effect
                                                    if (opposed_core_effect > 0)
                                                    {
                                                        int[] Neigbour = LH_Class.Structures(ii, NPop, structure, rr);
                                                        for (int jj = 0; jj < Neigbour.Length; jj++)
                                                        {
                                                            if (ii != Neigbour[jj] && Nodes[ii].index != jj)
                                                            {
                                                                if (D.Text == "1")
                                                                    distances[ii] = distance1(Nodes[ii].x, Nodes[Neigbour[jj]].x, N, P);
                                                                else if (D.Text == "2")
                                                                    distances[ii] = distance2(Nodes[ii].x, Nodes[Neigbour[jj]].x, N, P);
                                                                else if (D.Text == "3")
                                                                    distances[ii] = distance3(Nodes[ii].x, Nodes[Neigbour[jj]].x, N, P);
                                                                else
                                                                    distances[ii] = distance4(LHC[ii].LH, LHC[Neigbour[jj]].LH, N, P);
                                                                //if (distances[ii] > short_range)
                                                                //{
                                                                for (int n = 0; n < N; n++)
                                                                    for (int p = 0; p < P; p++)
                                                                        Forces[ii].x[n, p] += (Nodes[Neigbour[jj]].x[n, p] - Nodes[ii].x[n, p]) * Magnet[Neigbour[jj]] * opposed_core_effect / distances[ii];

                                                                //}

                                                            }
                                                        }
                                                    }
                                                    #endregion

                                                }
                                                // Individual Learning
                                                int IL = 0;
                                                while (IL < Individual_Learning)
                                                {

                                                    int[,] LH_temp = (int[,])Best_indi.LH.Clone();
                                                    double[,] x = (double[,])Best_node.x.Clone();
                                                    int nrand = rr.Next(N);
                                                    int P1 = rr.Next(P);
                                                    int P2 = rr.Next(P);
                                                    int temp = LH_temp[nrand, P1];
                                                    LH_temp[nrand, P1] = LH_temp[nrand, P2];
                                                    LH_temp[nrand, P2] = temp;
                                                    double x_temp = x[nrand, P1];
                                                    x[nrand, P1] = x[nrand, P2];
                                                    x[nrand, P2] = x_temp;
                                                    double z2 = LH_Class.F(LH_temp, N, P);
                                                    if ((z2 - Best_indi.F) < 0)
                                                    {
                                                        Best_indi.LH = (int[,])LH_temp.Clone();
                                                        Best_node.x = (double[,])x.Clone();
                                                        Best_indi.F = z2;
                                                    }
                                                    IL++;

                                                }
                                                Best_indi.F = LH_Class.F(Best_indi.LH, N, P);
                                                //////////////////////////////////////////

                                                #region noacceleration
                                                if (acceleration == 0)
                                                {
                                                    for (int ii = 0; ii < NPop; ii++)
                                                    {
                                                        for (int n = 0; n < N; n++)
                                                            for (int p = 0; p < P; p++)
                                                            {
                                                                v[ii].x[n, p] = (Forces[ii].x[n, p] / Mass[ii]) * rr.NextDouble();
                                                                Nodes[ii].x[n, p] = Nodes[ii].x[n, p] + v[ii].x[n, p];
                                                            }

                                                        Nodes[ii].x = Node_treatment(Nodes[ii].x, N, P, rr);
                                                    }
                                                }
                                                #endregion
                                                #region acceleration
                                                else if (acceleration == 1)
                                                {
                                                    for (int ii = 0; ii < NPop; ii++)
                                                    {
                                                        for (int n = 0; n < N; n++)
                                                            for (int p = 0; p < P; p++)
                                                            {
                                                                a[ii].x[n, p] = (Forces[ii].x[n, p] / Mass[ii]);
                                                                v[ii].x[n, p] = v[ii].x[n, p] * rr.NextDouble() + a[ii].x[n, p];
                                                                Nodes[ii].x[n, p] = Nodes[ii].x[n, p] + v[ii].x[n, p];
                                                            }

                                                        Nodes[ii].x = Node_treatment(Nodes[ii].x, N, P, rr);
                                                    }
                                                }
                                                #endregion
                                                opposed_core_effect = opposed_core_effect * gamma;
                                                //divers[tt, it] = LH_Class.diversity(LHC, NPop, N, P);
                                                //fitnesses[tt, it] = LH_Class.best_for_iter(LHC, NPop);
                                            }
                                            costs[tt] = Best_indi.F;
                                            Nodes_test[tt].LH = (int[,])Best_indi.LH.Clone();
                                        }
                                        sw = new StreamWriter(ss);
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            for (int ii = 0; ii < N; ii++)
                                            {
                                                for (int jj = 0; jj < P; jj++)
                                                {
                                                    sw.Write(Nodes_test[tt].LH[ii, jj].ToString() + " ");
                                                }
                                                sw.WriteLine();
                                            }
                                        }
                                        sw.Close();
                                        sw = new StreamWriter(ss2);
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            sw.Write(costs[tt]);
                                            sw.Write(" ");
                                        }
                                        sw.Close();
                                        //sw = new StreamWriter(ss3);
                                        //for (int ii = 0; ii < Ntest; ii++)
                                        //{
                                        //    for (int jj = 0; jj < Iteration; jj++)
                                        //        sw.Write(fitnesses[ii, jj].ToString() + "  ");
                                        //    sw.WriteLine();
                                        //}
                                        //sw.Close();
                                        //sw = new StreamWriter(ss4);
                                        //for (int ii = 0; ii < Ntest; ii++)
                                        //{
                                        //    for (int jj = 0; jj < Iteration; jj++)
                                        //        sw.Write(divers[ii, jj].ToString() + "  ");
                                        //    sw.WriteLine();
                                        //}
                                        //sw.Close();
                                    }

                                }
                            }
                            #endregion
                            #region MOAL
                            else if (method == "MOAL")
                            {
                                int acceleration = 0;
                                int Distance = 1;
                                //double[] betta = { 0, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1 };
                                StreamReader SR2 = new StreamReader("parameterls.txt");
                                string[] tempstring = SR2.ReadLine().Split('=', ',');
                                SR2 = new StreamReader("parameterfi.txt");
                                string[] tempstring2 = SR2.ReadLine().Split('=', ',');
                                //if(initial_rho.Text==""||final_rho.Text=="")
                                //{
                                //    MessageBox.Show("لطفا بازه را وارد کنید");
                                //    return;
                                //}
                                //string[]tempstring=initial_rho.Text.Split(',');
                                double[] betta = new double[tempstring.Length - 1];
                                double[] intensity_arfinal = new double[tempstring2.Length];
                                for (int ii = 1; ii < tempstring.Length; ii++)
                                {
                                    betta[ii - 1] = Convert.ToDouble(tempstring[ii]);
                                }
                                for (int ii = 1; ii < tempstring2.Length; ii++)
                                {
                                    intensity_arfinal[ii - 1] = Convert.ToDouble(tempstring2[ii]);
                                }
                                //    intensity_arinitial[ii] = Convert.ToDouble(tempstring[ii]);
                                //string[] tempstring = final_rho.Text.Split(',');
                                //double[] intensity_arfinal = new double[tempstring.Length - 1];
                                //for (int ii = 1; ii < tempstring.Length; ii++)
                                //    intensity_arfinal[ii-1] = Convert.ToDouble(tempstring[ii]);
                                //double[] gamma_array = { 0.99, 0.995, 0.999, 0.9995, 0.9999 };
                                //double[] intensity_array = { 0.1, 0.3, 0.5, 0.6, 0.8 };
                                //double[]intensity_arinitial = { 0.1, 0.3, 0.5, 0.7, 0.9 };
                                //double[] intensity_arinitial = { 0.01,0.05 };
                                //double[] intensity_arfinal = {1,2,4,6, 8 };
                                //double[] intensity_array = {0.1, 0.3,0.5,0.6,0.8 };
                                //int[] stop_it = { 1, 2, 3, 5,8 };
                                //double gamma = 0.999;
                                //int O = N * P * 1000000;
                                Int64 max = Iteration * NPop;
                                Int64 max2 = (N * (P - 1) * P) / 2;
                                Int64 O = (max * max2);
                                double intensity = 0.1;
                                //int Individual_Learning = 0;
                                //for (int jjj = 0; jjj < betta.Length; jjj++)
                                //{
                                for (int jjk = 0; jjk < intensity_arfinal.Length; jjk++)
                                    for (int jjc = 0; jjc < betta.Length; jjc++)
                                    {
                                        //intensity = intensity_arinitial[jjk];
                                        //we first set the intensity to zero because we believe that its initial value does not have any effect on the result.
                                        intensity = 0;
                                        Iteration = (Convert.ToInt32(2 * (O * (1 - betta[jjc])) / (NPop * N * P * (P - 1)))) + 1;
                                        int Individual_Learning = Convert.ToInt32((betta[jjc] * O) / (2 * N * P * Iteration));
                                        double delta = (intensity_arfinal[jjk]) / Iteration;
                                        //double delta = (1.2) / Iteration;
                                        double[] Magnet = new double[NPop];
                                        double[] Mass = new double[NPop];
                                        double[,] divers = new double[Ntest, Iteration];
                                        double[,] fitnesses = new double[Ntest, Iteration];
                                        //  double core_effect = 0.5;
                                        // double opposed_core_effect = 1 - core_effect;
                                        //ss = "Res_N_" + N.ToString() + "P_" + P.ToString() + "gamma_" + gamma.ToString() + "_Pop_" + NPop.ToString() + "IL" + Individual_Learning.ToString() + "_int" + intensity.ToString()  + "_Dis_" + method +stop.ToString()+".txt";
                                        ss2 = "Result\\fit_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "intenfinal" + intensity_arfinal[jjk].ToString() + "_betta" + intensity.ToString() + betta[jjc].ToString() + "_Dis_" + method + ".txt";
                                        //string ss3 = "Fiter_N_" + N.ToString() + "P_" + P.ToString() + "T_" + T_text.Text.ToString() +"_Pop_" + NPop.ToString() + "_int" + intensity.ToString() + "_al_" + alpha.ToString() + "_Dis_" + method + Distance.ToString() + "_Acc_" + Ac.Text + "_It_" + Iteration.ToString() + "_t_" + Ntest.ToString() + "_str_" + structure + ".txt";
                                        //string ss4 = "Diver_N_" + N.ToString() + "P_" + P.ToString() + "T_" + T_text.Text.ToString() + "_Pop_" + NPop.ToString() + "_int" + intensity.ToString() + "al_" + alpha.ToString() + "_Dis_" + method + Distance.ToString() + "_Acc_" + Ac.Text + "_It_" + Iteration.ToString() + "_t_" + Ntest.ToString() + "_str_" + structure + ".txt";
                                        if (!File.Exists(ss2))
                                        {
                                            for (int tt = 0; tt < Ntest; tt++)
                                            {
                                                //intensity = intensity_arinitial[jjk];
                                                intensity = 0;
                                                MOA_Node[] Nodes = new MOA_Node[NPop];
                                                MOA_Node[] BNodes = new MOA_Node[NPop];
                                                MOA_Node Best_node = new MOA_Node();
                                                MOA_Node[] Forces = new MOA_Node[NPop];
                                                MOA_Node[] a = new MOA_Node[NPop];
                                                MOA_Node[] v = new MOA_Node[NPop];
                                                Latin_Hypercube[] LHC = new Latin_Hypercube[NPop];
                                                Latin_Hypercube[] B = new Latin_Hypercube[NPop];
                                                Latin_Hypercube Best_indi = new Latin_Hypercube();
                                                double[] distances = new double[NPop];
                                                Best_indi.F = 1000;
                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    Forces[ii].x = new double[N, P];
                                                    a[ii].x = new double[N, P];
                                                    v[ii].x = new double[N, P];
                                                }
                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    Nodes[ii].x = LH_Class.node_constructing(N, P, rr);
                                                    BNodes[ii].x = (double[,])Nodes[ii].x.Clone();
                                                    BNodes[ii].f = 10000;
                                                }
                                                for (int it = 0; it < Iteration; it++)
                                                {
                                                    Fmax = 0; Fmin = 1000;
                                                    int min_index = 0; int max_index = 0;
                                                    for (int ii = 0; ii < NPop; ii++)
                                                    {
                                                        LHC[ii].LH = LH_Class.convert_search_s_to_solution_s(Nodes[ii].x, N, P);
                                                        LHC[ii].F = LH_Class.F(LHC[ii].LH, N, P);
                                                        B[ii].F = LHC[ii].F;
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
                                                        Best_node.x = (double[,])Nodes[min_index].x.Clone();
                                                    }
                                                    double range = Fmax - Fmin;
                                                    for (int ii = 0; ii < NPop; ii++)
                                                    {
                                                        Magnet[ii] = (Fmax - LHC[ii].F) / (range);
                                                        //Mass[ii] = Magnet[ii] * intensity + alpha;
                                                        Mass[ii] = Magnet[ii] * intensity;
                                                    }
                                                    //if (structure != "Dynamic" && structure != "RDynamic" && structure != "RRDynamic")
                                                    BNodes = LH_Class.StructureCore(LHC, Nodes, BNodes, NPop, structure, rr);
                                                    //else if (structure != "Frankenstein")
                                                    //    BNodes = LH_Class.DynamicStructureCore3(LHC, B, Nodes, BNodes, portion, it, NPop, rr);
                                                    for (int ii = 0; ii < NPop; ii++)
                                                    {
                                                        Forces[ii].x = new double[N, P];
                                                    }
                                                    for (int ii = 0; ii < NPop; ii++)
                                                    {
                                                        #region reaching to core
                                                        if (D.Text == "1")
                                                            distances[ii] = distance1(Nodes[ii].x, BNodes[ii].x, N, P);
                                                        else if (D.Text == "2")
                                                            distances[ii] = distance2(Nodes[ii].x, BNodes[ii].x, N, P);
                                                        else if (D.Text == "3")
                                                            distances[ii] = distance3(Nodes[ii].x, BNodes[ii].x, N, P);
                                                        else if (D.Text == "4")
                                                            distances[ii] = distance4(LHC[ii].LH, LHC[BNodes[ii].index].LH, N, P);

                                                        // reducing core effect
                                                        //core_effect = 1 - opposed_core_effect;
                                                        //
                                                        //if (distances[ii] > short_range)
                                                        //{
                                                        //for (int n = 0; n < N; n++)
                                                        //    for (int p = 0; p < P; p++)
                                                        //        Forces[ii].x[n, p] = Forces[ii].x[n, p] + (BNodes[ii].x[n, p] - Nodes[ii].x[n, p]) * Magnet[BNodes[ii].index] * core_effect / distances[ii] + (Best_node.x[n, p] - Nodes[ii].x[n, p]) * rr.NextDouble();

                                                        for (int n = 0; n < N; n++)
                                                            for (int p = 0; p < P; p++)
                                                                Forces[ii].x[n, p] = Forces[ii].x[n, p] + (BNodes[ii].x[n, p] - Nodes[ii].x[n, p]) * Magnet[BNodes[ii].index] / distances[ii];


                                                        #endregion

                                                    }
                                                    // Individual Learning
                                                    int IL = 0;
                                                    while (IL < Individual_Learning)
                                                    {

                                                        int[,] LH_temp = (int[,])Best_indi.LH.Clone();
                                                        double[,] x = (double[,])Best_node.x.Clone();
                                                        int nrand = rr.Next(N);
                                                        int P1 = rr.Next(P);
                                                        int P2 = rr.Next(P);
                                                        int temp = LH_temp[nrand, P1];
                                                        LH_temp[nrand, P1] = LH_temp[nrand, P2];
                                                        LH_temp[nrand, P2] = temp;
                                                        double x_temp = x[nrand, P1];
                                                        x[nrand, P1] = x[nrand, P2];
                                                        x[nrand, P2] = x_temp;
                                                        double z2 = LH_Class.F(LH_temp, N, P);
                                                        if ((z2 - Best_indi.F) < 0)
                                                        {
                                                            Best_indi.LH = (int[,])LH_temp.Clone();
                                                            Best_node.x = (double[,])x.Clone();
                                                            Best_indi.F = z2;
                                                        }
                                                        IL++;

                                                    }
                                                    Best_indi.F = LH_Class.F(Best_indi.LH, N, P);
                                                    //////////////////////////////////////////

                                                    #region noacceleration
                                                    if (acceleration == 0)
                                                    {
                                                        for (int ii = 0; ii < NPop; ii++)
                                                        {
                                                            for (int n = 0; n < N; n++)
                                                                for (int p = 0; p < P; p++)
                                                                {
                                                                    v[ii].x[n, p] = (Forces[ii].x[n, p] / Mass[ii]) * rr.NextDouble();
                                                                    Nodes[ii].x[n, p] = Nodes[ii].x[n, p] + v[ii].x[n, p];
                                                                }

                                                            Nodes[ii].x = Node_treatment(Nodes[ii].x, N, P, rr);
                                                        }
                                                    }
                                                    #endregion
                                                    intensity += delta;
                                                    divers[tt, it] = LH_Class.diversity(LHC, NPop, N, P);
                                                    fitnesses[tt, it] = LH_Class.best_for_iter(LHC, NPop);
                                                }
                                                costs[tt] = Best_indi.F;
                                                Nodes_test[tt].LH = (int[,])Best_indi.LH.Clone();
                                            }
                                            //sw = new StreamWriter(ss);
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
                                            sw = new StreamWriter(ss2);
                                            for (int tt = 0; tt < Ntest; tt++)
                                            {
                                                sw.Write(costs[tt]);
                                                sw.Write(" ");
                                            }
                                            sw.Close();
                                            //sw = new StreamWriter(ss3);
                                            //for (int ii = 0; ii < Ntest; ii++)
                                            //{
                                            //    for (int jj = 0; jj < Iteration; jj++)
                                            //        sw.Write(fitnesses[ii, jj].ToString() + "  ");
                                            //    sw.WriteLine();
                                            //}
                                            //sw.Close();
                                            //sw = new StreamWriter(ss4);
                                            //for (int ii = 0; ii < Ntest; ii++)
                                            //{
                                            //    for (int jj = 0; jj < Iteration; jj++)
                                            //        sw.Write(divers[ii, jj].ToString() + "  ");
                                            //    sw.WriteLine();
                                            //}
                                            //sw.Close();
                                        }

                                    }
                            }
                            #endregion
                            #region PSO
                            else if (method == "PSO")
                            {
                                //double W1 = Convert.ToDouble(Wmin.Text);
                                //double W2 = Convert.ToDouble(Wmax.Text);
                                //double w_step = Convert.ToDouble(W_step.Text);
                                //double C11 = Convert.ToDouble(cmin.Text);
                                //double C12 = Convert.ToDouble(cmax.Text);
                                //double C11_step = Convert.ToDouble(c_step.Text);
                                //double C21 = Convert.ToDouble(cmin21.Text);
                                //double C22 = Convert.ToDouble(cmin22.Text);
                                //double C22_step = Convert.ToDouble(c2_step.Text);
                                //for (double W = W1; W <= W2; W += w_step)
                                //    for (double C1 = C11; C1 <= C12; C1 += C11_step)
                                //        for (double C2 = C21; C2 <= C12; C2 += C22_step)
                                //        {

                                //double[] W_s = { 0.1, 0.5, 0.75, 1, 1.5 };
                                //double[] W_s = { 0.1, 0.5, 0.75, 1, 1.5 };
                                //double[] W_s = { 0.001, 0.005, 0.01, 0.1, 0.5 };
                                //double[] C_s = { 2, 3, 4, 5, 8 };
                                //for (int cc = 0; cc < C_s.Length; cc++)
                                //    for (int ww = 0; ww < W_s.Length; ww++)
                                //    {
                                //double C1 = 2.1542;
                                //double C2 = 4.631684;
                                //double W = 0.04065714;
                                //double C1 = C_s[cc]; double C2 = C_s[cc]; double W = W_s[ww];
                                double C1 = 4; double C2 = 4; double W = 0.01;
                                double[,] Cost = new double[Ntest, Iteration];
                                //ss = "Cost_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_W_" + W.ToString() + "_C1_" + C1.ToString() + "_C2_" + C2.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + ".txt";
                                ss2 = "fit_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_W_" + W.ToString() + "_C1_" + C1.ToString() + "_C2_" + C2.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + ".txt";
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
                                        for (int it = 0; it < Iteration; it++)
                                        {
                                            Fmax = 0; Fmin = 1000;
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
                                            Cost[tt, it] = Best_indi.F;
                                        }

                                        costs[tt] = Best_indi.F;
                                        //Nodes_test[tt].LH = (int[,])Best_indi.LH.Clone();

                                    }

                                    //sw = new StreamWriter(ss);
                                    //for (int tt = 0; tt < Ntest; tt++)
                                    //{
                                    //    for (int it = 0; it < Iteration; it++)
                                    //    {
                                    //        sw.Write(Cost[tt, it].ToString() + " ");

                                    //    }
                                    //}
                                    //sw.Close();
                                    sw = new StreamWriter(ss2);
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        sw.Write(costs[tt].ToString() + " ");
                                    }
                                    sw.Close();
                                    //}
                                }
                            }

                            #endregion
                            #region DE
                            else if (method == "DE")
                            {

                                //double[] Cr_s = { 0.001, 0.005, 0.01, 0.05, 0.1 };
                                //double[] F_s = { 0.01, 0.1, 0.2, 0.3, 0.4 };
                                //for (int cc = 0; cc < 5; cc++)
                                //    for (int ww = 0; ww < 5; ww++)
                                //    {
                                //double Cr = Cr_s[cc];
                                //double F = F_s[ww];
                                double Cr = 0.02240;
                                double F = 0.37404;
                                double[,] Cost = new double[Ntest, Iteration];
                                ss = "Cost_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_F_" + F.ToString() + "_Cr_" + Cr.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + ".txt";
                                ss2 = "fit_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_F_" + F.ToString() + "_Cr_" + Cr.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + ".txt";
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
                                            Fmin = 1000;
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
                                            Cost[tt, it] = Best_indi.F;
                                        }

                                        costs[tt] = Best_indi.F;
                                        Nodes_test[tt].LH = (int[,])Best_indi.LH.Clone();

                                    }

                                    sw = new StreamWriter(ss);
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        for (int it = 0; it < Iteration; it++)
                                        {
                                            sw.Write(Cost[tt, it].ToString() + " ");

                                        }
                                    }
                                    sw.Close();
                                    sw = new StreamWriter(ss2);
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        sw.Write(costs[tt].ToString() + " ");
                                    }
                                    sw.Close();
                                }
                                //}

                            }

                            #endregion
                            #region ES
                            else if (method == "ES")
                            {

                                double[] Lambda_s = { 0.2, 0.4, 0.6, 0.8, 1 };
                                // sigma constant which is the constant factor to be multiplied to sigma
                                //double[] SC_s = { 0.2, 0.4, 0.6, 0.8, 1,1.2,1.5 };
                                //for (int cc = 0; cc < 5; cc++)
                                //    for (int ww = 0; ww < 7; ww++)
                                //    {
                                //int breeds_number = Convert.ToInt32(Lambda_s[cc] * NPop);
                                int breeds_number = Convert.ToInt32(0.7969 * NPop);
                                double SC = 0.9444;
                                double[,] Cost = new double[Ntest, Iteration];
                                ss = "Cost_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_Lambda_" + Lambda_s[4].ToString() + "_Sigma_Fac_" + SC.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + ".txt";
                                ss2 = "fit_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_Lambda_" + Lambda_s[4].ToString() + "_Sigma_Fac_" + SC.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + ".txt";
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
                                            Cost[tt, it] = Best_nodes.f;
                                        }

                                        costs[tt] = Best_nodes.f;
                                        Nodes_test[tt].LH = (int[,])Best_nodes.LH.Clone();

                                    }

                                    sw = new StreamWriter(ss);
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        for (int it = 0; it < Iteration; it++)
                                        {
                                            sw.Write(Cost[tt, it].ToString() + " ");

                                        }
                                    }
                                    sw.Close();
                                    sw = new StreamWriter(ss2);
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        sw.Write(costs[tt].ToString() + " ");
                                    }
                                    sw.Close();
                                }
                                //}
                            }

                            #endregion
                            #region MAPSO
                            else if (method == "MAPSO")
                            {
                                string learning = "Gbest";
                                double I_str = 1000;
                                //double[] r_lg_s = { 0.05, 0.15, 0.2, 0.25 };
                                //double[] r_lg_s = { 0.1, 0.3, 0.5, 0.7, 0.9 };
                                //double C1 = 0.9; double C2 = 0.9; double W = 0.9;
                                NPop = 20;
                                int FCs = 100000;
                                Iteration = FCs / NPop;
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
                                Iteration = (Convert.ToInt32((n_frec / NPop) * 1.85));
                                int Learning = Convert.ToInt32(r_lg * I_str);
                                //double[,] Cost = new double[Ntest, Iteration];
                                //ss = "Costs_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_W_" + W.ToString() + "_C1_" + C1.ToString() + "_C2_" + C2.ToString() + method + "r_LcLG" + r_lg.ToString() + "_test_" + Ntest.ToString() + ".txt";
                                ss2 = "result\\fit_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_W_" + W.ToString() + "_C1_" + C1.ToString() + "_C2_" + C2.ToString() + method + "r_LcLG" + r_lg.ToString() + "_test_" + Ntest.ToString() + ".txt";
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
                                            //Cost[tt, it] = Best_nodes.f;
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
                                    sw = new StreamWriter(ss2);
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        sw.Write(costs[tt].ToString() + " ");
                                    }
                                    sw.Close();
                                    //sw = new StreamWriter(ss);
                                    //for (int tt = 0; tt < Ntest; tt++)
                                    //{
                                    //    for (int it = 0; it < Iteration; it++)
                                    //    {
                                    //        sw.Write(Cost[tt, it].ToString() + " ");

                                    //    }
                                    //}
                                    //sw.Close();
                                }
                                //}
                            }

                            #endregion
                            #region JADE
                            else if (method == "JADE")
                            {
                                double[] Cr_A = new double[NPop];
                                double[] F_A = new double[NPop];
                                double Cr = 0.5;
                                double F = 0.5;
                                Random RR = new Random();
                                double c = 0.1; double p = 0.05;
                                double[,] Cost = new double[Ntest, Iteration];
                                ss2 = "fit_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + method + "_test_" + Ntest.ToString() + ".txt";
                                ss = "Costs_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + method + "_test_" + Ntest.ToString() + ".txt";
                                if (!File.Exists(ss2))
                                {
                                    int p_group = Convert.ToInt32(100 * p % NPop);
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        Cr_A = new double[NPop];
                                        F_A = new double[NPop];
                                        Cr = 0.5;
                                        F = 0.5;
                                        MOA_Node[] Pop = new MOA_Node[NPop];
                                        MOA_Node[] V = new MOA_Node[NPop];
                                        MOA_Node[] U = new MOA_Node[NPop];
                                        MOA_Node[] Best = new MOA_Node[NPop];
                                        ArrayList SF = new ArrayList();
                                        ArrayList Scr = new ArrayList();
                                        ArrayList A_x = new ArrayList();
                                        ArrayList A_y = new ArrayList();
                                        ArrayList A_f = new ArrayList();
                                        MOA_Node Best_nodes = new MOA_Node();
                                        double[] distances = new double[NPop];
                                        Best_nodes.f = 1E250;
                                        for (int ii = 0; ii < NPop; ii++)
                                        {
                                            Pop[ii].x = LH_Class.node_constructing(N, P, rr);
                                            Pop[ii].LH = LH_Class.convert_search_s_to_solution_s(Pop[ii].x, N, P);
                                            Pop[ii].f = LH_Class.F(Pop[ii].LH, N, P);
                                            A_x.Add(Pop[ii].x.Clone());
                                            A_f.Add(Pop[ii].f);
                                            /////////init V
                                            V[ii].x = new double[N, P];
                                            U[ii].x = new double[N, P];
                                        }
                                        ///////////////////////////////////////////////////////////////////////////////////////
                                        for (int it = 0; it < Iteration; it++)
                                        {
                                            SF = new ArrayList();
                                            Scr = new ArrayList();
                                            Best = LH_Class.mergesort(Pop, NPop);
                                            for (int ii = 0; ii < NPop; ii++)
                                            {
                                                F_A[ii] = LH_Class.Cauchy(rr, F, 0.1);
                                                Cr_A[ii] = LH_Class.Normal_Distribution(rr, Cr, 0.1);
                                                int best_index = rr.Next(p_group);
                                                MOA_Node X_best = Best[best_index];
                                                int index_r1 = rr.Next(NPop);
                                                if (X_best.f == Pop[index_r1].f)
                                                {
                                                    while (LH_Class.similarity(X_best.x, Pop[index_r1].x, N, P))
                                                        index_r1 = rr.Next(NPop);
                                                }
                                                int index_r2 = rr.Next(A_f.Count);
                                                double Fit_A = Convert.ToDouble(A_f[index_r2]);
                                                if (X_best.f == Fit_A || Fit_A == Pop[index_r1].f)
                                                {
                                                    double[,] X = (double[,])A_x[index_r2];
                                                    while (LH_Class.similarity(X_best.x, X, N, P))
                                                    {
                                                        index_r2 = rr.Next(NPop);
                                                        X = (double[,])A_x[index_r2];
                                                    }
                                                }
                                                int J_rand = rr.Next(P);
                                                for (int jj = 0; jj < N; jj++)
                                                    for (int kk = 0; kk < P; kk++)
                                                    {
                                                        double[,] x = (double[,])A_x[index_r2];
                                                        V[ii].x[jj, kk] = Pop[ii].x[jj, kk] + F_A[ii] * (X_best.x[jj, kk] - Pop[ii].x[jj, kk]) + F_A[ii] * (Pop[index_r1].x[jj, kk] - x[jj, kk]);
                                                        if ((jj == J_rand) || (rr.NextDouble() < Cr_A[ii]))
                                                        {
                                                            U[ii].x[jj, kk] = V[ii].x[jj, kk];
                                                        }
                                                        else
                                                        {
                                                            U[ii].x[jj, kk] = Pop[ii].x[jj, kk];
                                                        }
                                                    }
                                                U[ii].x = Node_treatment(U[ii].x, N, P, rr);
                                                U[ii].LH = LH_Class.convert_search_s_to_solution_s(U[ii].x, N, P);
                                                U[ii].f = LH_Class.F(U[ii].LH, N, P);
                                                if (U[ii].f <= Pop[ii].f)
                                                {
                                                    int rand = rr.Next(NPop);
                                                    A_x.Add((double[,])Pop[ii].x.Clone());
                                                    A_f.Add(Pop[ii].f);
                                                    Pop[ii].x = (double[,])U[ii].x.Clone();
                                                    Pop[ii].LH = (int[,])U[ii].LH.Clone();
                                                    Pop[ii].f = U[ii].f;
                                                    SF.Add(F_A[ii]);
                                                    Scr.Add(Cr_A[ii]);
                                                }
                                                if (Best_nodes.f > Pop[ii].f)
                                                {
                                                    Best_nodes.f = Pop[ii].f;
                                                    Best_nodes.x = (double[,])Pop[ii].x.Clone();
                                                    Best_nodes.LH = (int[,])Pop[ii].LH.Clone();

                                                }
                                            }

                                            int Overhead = A_x.Count - NPop;
                                            for (int ii = 0; ii < Overhead; ii++)
                                            {
                                                int rand = rr.Next(A_x.Count);
                                                A_x.RemoveAt(rand);
                                                A_f.RemoveAt(rand);
                                            }

                                            if (Scr.Count > 0)
                                                Cr = (1 - c) * Cr + c * LH_Class.mean_simple(Scr);
                                            if (SF.Count > 0)
                                                F = (1 - c) * F + c * LH_Class.mean_Lehmer(SF);
                                            Cost[tt, it] = Best_nodes.f;
                                        }
                                        costs[tt] = Best_nodes.f;
                                        Nodes_test[tt].LH = (int[,])Best_nodes.LH.Clone();
                                    }
                                    //sw = new StreamWriter(ss2);
                                    //for (int tt = 0; tt < Ntest; tt++)
                                    //{
                                    //    sw.Write(costs[tt].ToString() + " ");
                                    //}
                                    //sw.Close();
                                    sw = new StreamWriter(ss);
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        for (int ii = 0; ii < N; ii++)
                                        {
                                            for (int jj = 0; jj < P; jj++)
                                            {
                                                sw.Write(Nodes_test[tt].LH[ii, jj].ToString() + " ");
                                            }
                                            sw.WriteLine();
                                        }
                                    }
                                    sw.Close();
                                    sw = new StreamWriter(ss2);
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        for (int it = 0; it < Iteration; it++)
                                        {
                                            sw.Write(Cost[tt, it].ToString() + " ");

                                        }
                                    }
                                    sw.Close();
                                }
                            }
                            #endregion
                            #region ESE
                            else if (method == "ESE")
                            {
                                int n1 = Convert.ToInt32(N1.Text);
                                int n2 = Convert.ToInt32(N2.Text);
                                int n_s = Convert.ToInt32(N_s.Text);
                                double t1 = Convert.ToDouble(T1.Text);
                                double alpha1 = 0.3151553;
                                double alpha2 = 0.9770274;
                                double alpha3 = 0.6886896;
                                double small_per = 0.203023;
                                int it = 0;
                                int FCs = 100000;
                                NPop = 1;
                                Iteration = FCs / NPop;
                                //int[] Ms = { 1, 10, 50, 100, 500 };
                                //int[] Js = { 1, 10, 30, 50, 100 };
                                //double[] Ths = { 0.0001, 0.001, 0.01, 0.1 };
                                double[,] Cost = new double[Ntest, Iteration];
                                //for (int Thi = 0; Thi < 4; Thi++)
                                //    for (int Ji = 0; Ji < 5; Ji++)
                                //        for (int Mi = 0; Mi < 5; Mi++)
                                //        {
                                double Th = 0.6397121;
                                int M = 57;
                                int J = 7;
                                //ss = "Result_N_" + N.ToString() + "P_" + P.ToString() + method + ".txt";
                                ss2 = "fit_N_" + N.ToString() + "P_" + P.ToString() + method + ".txt";
                                //string ss3 = "fit_N_" + N.ToString() + "P_" + P.ToString() + method + ".txt";
                                if (!File.Exists(ss2))
                                {
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        int Iter = 0;
                                        Th = 0.6397121;
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

                                                    //if ((it % 100) == 0)
                                                    //    Cost[tt, Iter++] = ZR;
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
                                        }
                                        costs[tt] = Z;
                                        //Nodes_test[tt].LH = (int[,])LH.Clone();
                                    }


                                    //sw = new StreamWriter(ss);
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
                                    sw = new StreamWriter(ss2);
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        sw.Write(costs[tt].ToString() + " ");
                                    }
                                    sw.Close();
                                    //    sw = new StreamWriter(ss3);
                                    //    for (int tt = 0; tt < Ntest; tt++)
                                    //        for (int jj = 0; jj < 1000; jj++)
                                    //        {
                                    //            sw.Write(Cost[tt, jj].ToString() + " ");
                                    //        }
                                    //    sw.Close();
                                    //}
                                }

                            }
                            #endregion
                            #region ILS
                            else if (method == "ILS")
                            {
                                int it = 0;
                                ss = "Result_N_" + N.ToString() + "P_" + P.ToString() + method + "_test" + Ntest.ToString() + ".txt";
                                ss2 = "fit_N_" + N.ToString() + "P_" + P.ToString() + method + "_test" + Ntest.ToString() + ".txt";
                                string ss3 = "Cost" + N.ToString() + "P_" + P.ToString() + method + "_test" + Ntest.ToString() + ".txt";
                                double[,] Cost = new double[Ntest, Iteration];
                                if (!File.Exists(ss2))
                                {
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        it = 0;
                                        int[,] LH = LH_Class.constructing_Latin_hypercube(N, P, rr);
                                        double z1 = 0;
                                        int MaxIter = Iteration * NPop;
                                        bool change = false;
                                        int Iter = 0;
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
                                                            if ((it % 100) == 0)
                                                                Cost[tt, Iter++] = z1;
                                                            it++;
                                                        }
                                            }
                                            while (change && it < MaxIter);
                                            LH_Class.Perturbation(ref LH, rr, N, P);
                                        }
                                        costs[tt] = z1;
                                        Nodes_test[tt].LH = (int[,])LH.Clone();
                                    }


                                    sw = new StreamWriter(ss);
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        for (int ii = 0; ii < N; ii++)
                                        {
                                            for (int jj = 0; jj < P; jj++)
                                            {
                                                sw.Write(Nodes_test[tt].LH[ii, jj].ToString() + " ");
                                            }
                                            sw.WriteLine();
                                        }
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
                                        for (int jj = 0; jj < 1000; jj++)
                                        {
                                            sw.Write(Cost[tt, jj].ToString() + " ");
                                        }
                                    sw.Close();
                                    //}
                                }

                            }
                            #endregion
                            #region SREA
                            else if (method == "MASW")
                            {
                                int O = NPop * Convert.ToInt32(NI.Text);
                                double[] N_LS_GL = { 0.1, 0.3, 0.5, 0.7, 0.9 };
                                double[] Mu_rate_s = { 0.001, 0.005, 0.01, 0.05, 0.1 };

                                for (int Portion_index = 0; Portion_index < 5; Portion_index++)
                                    for (int M_index = 0; M_index < 5; M_index++)
                                    {
                                        //double[] N_LS_GL = {0.5,0.5,0.9,0.3,0.5,0.5,0.1,0.5,0.3,0.9,0.9,0.3,0.5,0,0.3,0.5,0.5,0.5,0.1,0.9,0.3,0.5};
                                        //double[] Mu_rate_s = { 0.005,0.005,0.005,0.05,0.05,0.05,0.05, 0.005,0.005,0.05,0.05,0.05,0.01,0,0.05,0.005,0.01,0.005,0.05,0.01,0.05,0.05 };
                                        double LS_LG = N_LS_GL[Portion_index];
                                        double Mu_rate = Mu_rate_s[M_index];
                                        Iteration = Convert.ToInt32((O * (1 - LS_LG)) / NPop) + 1;
                                        int I_str = Convert.ToInt32(O * LS_LG / Iteration);

                                        ss2 = "fit_N_" + N.ToString() + "_Mr_" + Mu_rate.ToString() + "LSLG" + LS_LG.ToString() + "_Pop_" + NPop.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + ".txt";
                                        if (!File.Exists(ss2))
                                        {
                                            for (int tt = 0; tt < Ntest; tt++)
                                            {
                                                MOA_Node[] Pop = new MOA_Node[NPop];
                                                MOA_Node Best_nodes = new MOA_Node();
                                                MOA_Node[] Breed = new MOA_Node[NPop];
                                                Best_nodes.f = 1E250;
                                                LS[] LS_S = new LS[NPop];
                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    Pop[ii].x = LH_Class.node_constructing(N, P, rr);
                                                    Pop[ii].LH = LH_Class.convert_search_s_to_solution_s(Pop[ii].x, N, P);
                                                    Pop[ii].f = LH_Class.F(Pop[ii].LH, N, P);

                                                }
                                                Pop = LH_Class.mergesort(Pop, NPop);
                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    LS_S[ii].x = (double[,])Pop[ii].x.Clone();
                                                    LS_S[ii].F = Pop[ii].f;
                                                }
                                                for (int it = 0; it < Iteration; it++)
                                                {
                                                    //perform Steady State GA
                                                    #region generate Breeds
                                                    for (int ii = 0; ii < NPop; ii++)
                                                    {
                                                        if (Mu_rate > rr.NextDouble())
                                                            LH_Class.Mutation_BGA(ref Pop[ii], Pop, N, P, rr);
                                                        Pop[ii].LH = LH_Class.convert_search_s_to_solution_s(Pop[ii].x, N, P);
                                                        Pop[ii].f = LH_Class.F(Pop[ii].LH, N, P);
                                                    }
                                                    for (int ii = 0; ii < NPop; ii++)
                                                    {
                                                        int parent1 = rr.Next(NPop);
                                                        Breed[ii].x = new double[N, P];
                                                        int parent2 = LH_Class.negative_assortative_mating_strategy(Pop[parent1].x, N, P, Pop, rr);
                                                        Breed[ii].x = LH_Class.BLX_Crossover(N, P, Pop[parent1].x, Pop[parent2].x);
                                                        Node_treatment(Breed[ii].x, N, P, rr);
                                                        Breed[ii].LH = LH_Class.convert_search_s_to_solution_s(Breed[ii].x, N, P);
                                                        Breed[ii].f = LH_Class.F(Breed[ii].LH, N, P);
                                                    }
                                                    #endregion
                                                    // Replacement Strategy
                                                    if (it == 0)
                                                        Pop = LH_Class.mergesort(Pop, NPop);
                                                    Breed = LH_Class.mergesort(Breed, NPop);
                                                    if (Breed[0].f < Pop[NPop - 1].f)
                                                    {
                                                        Pop[NPop - 1].x = (double[,])Breed[0].x.Clone();
                                                        Pop[NPop - 1].f = Breed[0].f;
                                                    }
                                                    //
                                                    //Pick the best individual of Population
                                                    if (LS_S.Length == 0)
                                                    {
                                                        LS_S = new LS[NPop - 1];
                                                        for (int ii = 1; ii < NPop; ii++)
                                                        {
                                                            Pop[ii].x = LH_Class.node_constructing(N, P, rr);
                                                            Pop[ii].LH = LH_Class.convert_search_s_to_solution_s(Pop[ii].x, N, P);
                                                            Pop[ii].f = LH_Class.F(Pop[ii].LH, N, P);
                                                            LS_S[ii - 1].x = (double[,])Pop[ii].x.Clone();
                                                            LS_S[ii - 1].F = Pop[ii].f;
                                                        }

                                                    }
                                                    LS Best_Indi_BLS = new LS();
                                                    Best_Indi_BLS.F = LS_S[0].F;
                                                    Best_Indi_BLS.x = (double[,])LS_S[0].x.Clone();
                                                    Best_Indi_BLS.visited = LS_S[0].visited;
                                                    // Initialize Bias and Rho
                                                    if (Best_Indi_BLS.visited == 0)
                                                    {
                                                        Best_Indi_BLS.bias = new double[N, P];
                                                        Best_Indi_BLS.rho = 0.01;
                                                    }
                                                    else
                                                    {
                                                        Best_Indi_BLS.bias = (double[,])LS_S[0].bias.Clone();
                                                        Best_Indi_BLS.rho = LS_S[0].rho;
                                                    }
                                                    // Local Search Operator
                                                    LS Best_Indi_ALS = new LS();
                                                    Best_Indi_ALS.x = (double[,])Best_Indi_BLS.x.Clone();
                                                    Best_Indi_ALS.F = Best_Indi_BLS.F;
                                                    Best_Indi_ALS.rho = Best_Indi_BLS.rho;
                                                    Best_Indi_ALS.visited = Best_Indi_BLS.visited;
                                                    Best_Indi_ALS.bias = (double[,])Best_Indi_BLS.bias.Clone();
                                                    //LH_Class.SolisWets(ref Best_Indi_ALS.x, ref Best_Indi_ALS.F, N, P, ref Best_Indi_ALS.bias, ref Best_Indi_ALS.rho, I_str, rr);

                                                    // Remove Unchanged particle from population
                                                    if (Best_Indi_BLS.F - Best_Indi_ALS.F == 0)
                                                    {
                                                        LS_S = LH_Class.Remove_Unchanged_particle(LS_S);
                                                    }
                                                    else
                                                    {
                                                        LS_S[0].x = (double[,])Best_Indi_ALS.x.Clone();
                                                        LS_S[0].visited = 1;
                                                        LS_S[0].F = Best_Indi_ALS.F;
                                                        LS_S[0].rho = Best_Indi_ALS.rho;
                                                        LS_S[0].bias = (double[,])Best_Indi_ALS.bias.Clone();
                                                    }

                                                    Pop[NPop - 1].x = (double[,])Best_Indi_ALS.x.Clone();
                                                    Pop[NPop - 1].f = Best_Indi_ALS.F;
                                                    Pop = LH_Class.mergesort(Pop, NPop);
                                                    if (Best_nodes.f > Pop[0].f)
                                                    {
                                                        Best_nodes.f = Pop[0].f;
                                                        Best_nodes.x = (double[,])Pop[0].x.Clone();
                                                    }
                                                    /////////////////////

                                                }
                                                costs[tt] = Best_nodes.f;

                                            }


                                            sw = new StreamWriter(ss2);
                                            for (int tt = 0; tt < Ntest; tt++)
                                            {
                                                sw.Write(costs[tt].ToString() + " ");
                                            }
                                            sw.Close();
                                        }
                                    }

                            }

                            #endregion
                            #region MOAwithoutLS
                            else if (method == "DMOA")
                            {
                                int acceleration = 0;
                                //int Distance = 1;
                                //double[] betta = { 0, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1 };
                                //StreamReader SR2 = new StreamReader("parameterls.txt");
                                //string[] tempstring = SR2.ReadLine().Split('=', ',');
                                //StreamReader SR2 = new StreamReader("parameterfi.txt");
                                //string[] tempstring2 = SR2.ReadLine().Split('=', ',');
                                //double[] intensity_arfinal = new double[tempstring2.Length];
                                //for (int ii = 1; ii < tempstring2.Length; ii++)
                                //{
                                //    intensity_arfinal[ii - 1] = Convert.ToDouble(tempstring2[ii]);
                                //}
                                //SR2.Close();
                                //SR2 = new StreamReader("parameterini.txt");
                                //tempstring2 = SR2.ReadLine().Split('=', ',');
                                //double[] intensity_arinitial = new double[tempstring2.Length];
                                //for (int ii = 1; ii < tempstring2.Length; ii++)
                                //{
                                //    intensity_arinitial[ii - 1] = Convert.ToDouble(tempstring2[ii]);
                                //}
                                //SR2.Close();
                                //    intensity_arinitial[ii] = Convert.ToDouble(tempstring[ii]);
                                //string[] tempstring = final_rho.Text.Split(',');
                                //double[] intensity_arfinal = new double[tempstring.Length - 1];
                                //for (int ii = 1; ii < tempstring.Length; ii++)
                                //    intensity_arfinal[ii-1] = Convert.ToDouble(tempstring[ii]);
                                //double[] gamma_array = { 0.99, 0.995, 0.999, 0.9995, 0.9999 };
                                //double[] intensity_array = { 0.1, 0.3, 0.5, 0.6, 0.8 };
                                //double[]intensity_arinitial = { 0.1, 0.3, 0.5, 0.7, 0.9 };
                                //double[] intensity_arinitial = { 0.01,0.05 };
                                double[] intensity_arfinal = { 1.6 };
                                //double[] intensity_array = {0.1, 0.3,0.5,0.6,0.8 };
                                //int[] stop_it = { 1, 2, 3, 5,8 };
                                //double gamma = 0.999;
                                //int O = N * P * 1000000;
                                //Int64 max = Iteration * NPop;
                                //Int64 max2 = (N * (P - 1) * P) / 2;
                                //Int64 O = (max * max2);
                                //int Individual_Learning = 0;
                                double intensity = 0;
                                //for (int jjj = 0; jjj < intensity_arinitial.Length; jjj++)
                                //for (int jjk = 0; jjk < intensity_arfinal.Length; jjk++)
                                //for (int jjc = 0; jjc < betta.Length; jjc++)
                                //{
                                //intensity = intensity_arinitial[jjj];
                                //we first set the intensity to zero because we believe that its initial value does not have any effect on the result.
                                //Iteration = (Convert.ToInt32(2 * (O * (1 - betta[jjc])) / (NPop * N * P * (P - 1)))) + 1;
                                //int Individual_Learning = Convert.ToInt32((betta[jjc] * O) / (2 * N * P * Iteration));

                                int FCs = 100000;
                                Iteration = FCs / NPop;
                                double delta = (intensity_arfinal[0] - intensity) / Iteration;
                                if (delta < 0)
                                    continue;
                                //double delta = (1.2) / Iteration;

                                double[] Magnet = new double[NPop];
                                double[] Mass = new double[NPop];
                                double[,] divers = new double[Ntest, Iteration];
                                double[,] fitnesses = new double[Ntest, Iteration];
                                //  double core_effect = 0.5;
                                // double opposed_core_effect = 1 - core_effect;
                                //ss = "Res_N_" + N.ToString() + "P_" + P.ToString() + "gamma_" + gamma.ToString() + "_Pop_" + NPop.ToString() + "IL" + Individual_Learning.ToString() + "_int" + intensity.ToString()  + "_Dis_" + method +stop.ToString()+".txt";
                                ss2 = "result\\fit_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "intenfinal" + intensity_arfinal[0].ToString() + "_Dis_" + method + ".txt";
                                //string ss3 = "Fiter_N_" + N.ToString() + "P_" + P.ToString() + "T_" + T_text.Text.ToString() +"_Pop_" + NPop.ToString() + "_int" + intensity.ToString() + "_al_" + alpha.ToString() + "_Dis_" + method + Distance.ToString() + "_Acc_" + Ac.Text + "_It_" + Iteration.ToString() + "_t_" + Ntest.ToString() + "_str_" + structure + ".txt";
                                //string ss4 = "Diver_N_" + N.ToString() + "P_" + P.ToString() + "T_" + T_text.Text.ToString() + "_Pop_" + NPop.ToString() + "_int" + intensity.ToString() + "al_" + alpha.ToString() + "_Dis_" + method + Distance.ToString() + "_Acc_" + Ac.Text + "_It_" + Iteration.ToString() + "_t_" + Ntest.ToString() + "_str_" + structure + ".txt";
                                int count = 0;
                                if (File.Exists(ss2))
                                {
                                    StreamReader reader = new StreamReader(ss2);
                                    string[] results = reader.ReadToEnd().Split(' ','\n');
                                    count = results.Length - 1;
                                    reader.Close();
                                    
                                }
                                for (int tt = count; tt < Ntest; tt++)
                                {
                                    //ss2 = "Result\\fit_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "intenfinal" + intensity_arfinal[0].ToString() + "_Dis_" + method + "TN" + tt.ToString() + ".txt";
                                    //if (!File.Exists(ss2))
                                    //{
                                        //intensity = intensity_arinitial[jjk];
                                        intensity = 0;
                                        MOA_Node[] Nodes = new MOA_Node[NPop];
                                        MOA_Node[] BNodes = new MOA_Node[NPop];
                                        MOA_Node Best_node = new MOA_Node();
                                        MOA_Node[] Forces = new MOA_Node[NPop];
                                        MOA_Node[] a = new MOA_Node[NPop];
                                        MOA_Node[] v = new MOA_Node[NPop];
                                        Latin_Hypercube[] LHC = new Latin_Hypercube[NPop];
                                        Latin_Hypercube[] B = new Latin_Hypercube[NPop];
                                        Latin_Hypercube Best_indi = new Latin_Hypercube();
                                        double[] distances = new double[NPop];
                                        Best_indi.F = 1000;
                                        for (int ii = 0; ii < NPop; ii++)
                                        {
                                            Forces[ii].x = new double[N, P];
                                            a[ii].x = new double[N, P];
                                            v[ii].x = new double[N, P];
                                        }
                                        for (int ii = 0; ii < NPop; ii++)
                                        {
                                            Nodes[ii].x = LH_Class.node_constructing(N, P, rr);
                                            BNodes[ii].x = (double[,])Nodes[ii].x.Clone();
                                            BNodes[ii].f = 10000;
                                        }
                                        for (int it = 0; it < Iteration; it++)
                                        {
                                            Fmax = 0; Fmin = 1000;
                                            int min_index = 0; int max_index = 0;
                                            for (int ii = 0; ii < NPop; ii++)
                                            {
                                                LHC[ii].LH = LH_Class.convert_search_s_to_solution_s(Nodes[ii].x, N, P);
                                                LHC[ii].F = LH_Class.F(LHC[ii].LH, N, P);
                                                B[ii].F = LHC[ii].F;
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
                                                Best_node.x = (double[,])Nodes[min_index].x.Clone();
                                            }
                                            double range = Fmax - Fmin;
                                            for (int ii = 0; ii < NPop; ii++)
                                            {
                                                Magnet[ii] = (Fmax - LHC[ii].F) / (range);
                                                //Mass[ii] = Magnet[ii] * intensity + alpha;
                                                Mass[ii] = Magnet[ii] * intensity;
                                            }
                                            //if (structure != "Dynamic" && structure != "RDynamic" && structure != "RRDynamic")
                                            BNodes = LH_Class.StructureCore(LHC, Nodes, BNodes, NPop, structure, rr);
                                            //else if (structure != "Frankenstein")
                                            //    BNodes = LH_Class.DynamicStructureCore3(LHC, B, Nodes, BNodes, portion, it, NPop, rr);
                                            for (int ii = 0; ii < NPop; ii++)
                                            {
                                                Forces[ii].x = new double[N, P];
                                            }
                                            for (int ii = 0; ii < NPop; ii++)
                                            {
                                                #region reaching to core
                                                if (D.Text == "1")
                                                    distances[ii] = distance1(Nodes[ii].x, BNodes[ii].x, N, P);
                                                else if (D.Text == "2")
                                                    distances[ii] = distance2(Nodes[ii].x, BNodes[ii].x, N, P);
                                                else if (D.Text == "3")
                                                    distances[ii] = distance3(Nodes[ii].x, BNodes[ii].x, N, P);
                                                else if (D.Text == "4")
                                                    distances[ii] = distance4(LHC[ii].LH, LHC[BNodes[ii].index].LH, N, P);

                                                // reducing core effect
                                                //core_effect = 1 - opposed_core_effect;
                                                //
                                                //if (distances[ii] > short_range)
                                                //{
                                                //for (int n = 0; n < N; n++)
                                                //    for (int p = 0; p < P; p++)
                                                //        Forces[ii].x[n, p] = Forces[ii].x[n, p] + (BNodes[ii].x[n, p] - Nodes[ii].x[n, p]) * Magnet[BNodes[ii].index] * core_effect / distances[ii] + (Best_node.x[n, p] - Nodes[ii].x[n, p]) * rr.NextDouble();

                                                for (int n = 0; n < N; n++)
                                                    for (int p = 0; p < P; p++)
                                                        Forces[ii].x[n, p] = Forces[ii].x[n, p] + (BNodes[ii].x[n, p] - Nodes[ii].x[n, p]) * Magnet[BNodes[ii].index] / distances[ii];


                                                #endregion

                                            }
                                            // Individual Learning
                                            int IL = 0;
                                            //while (IL < Individual_Learning)
                                            //{

                                            //    int[,] LH_temp = (int[,])Best_indi.LH.Clone();
                                            //    double[,] x = (double[,])Best_node.x.Clone();
                                            //    int nrand = rr.Next(N);
                                            //    int P1 = rr.Next(P);
                                            //    int P2 = rr.Next(P);
                                            //    int temp = LH_temp[nrand, P1];
                                            //    LH_temp[nrand, P1] = LH_temp[nrand, P2];
                                            //    LH_temp[nrand, P2] = temp;
                                            //    double x_temp = x[nrand, P1];
                                            //    x[nrand, P1] = x[nrand, P2];
                                            //    x[nrand, P2] = x_temp;
                                            //    double z2 = LH_Class.F(LH_temp, N, P);
                                            //    if ((z2 - Best_indi.F) < 0)
                                            //    {
                                            //        Best_indi.LH = (int[,])LH_temp.Clone();
                                            //        Best_node.x = (double[,])x.Clone();
                                            //        Best_indi.F = z2;
                                            //    }
                                            //    IL++;

                                            //}
                                            //Best_indi.F = LH_Class.F(Best_indi.LH, N, P);
                                            //////////////////////////////////////////

                                            #region noacceleration
                                            if (acceleration == 0)
                                            {
                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    for (int n = 0; n < N; n++)
                                                        for (int p = 0; p < P; p++)
                                                        {
                                                            v[ii].x[n, p] = (Forces[ii].x[n, p] / Mass[ii]) * rr.NextDouble();
                                                            Nodes[ii].x[n, p] = Nodes[ii].x[n, p] + v[ii].x[n, p];
                                                        }

                                                    Nodes[ii].x = Node_treatment(Nodes[ii].x, N, P, rr);
                                                }
                                            }
                                            #endregion
                                            intensity += delta;
                                            //divers[tt, it] = LH_Class.diversity(LHC, NPop, N, P);
                                            //fitnesses[tt, it] = LH_Class.best_for_iter(LHC, NPop);
                                            //}
                                            costs[tt] = Best_indi.F;
                                            //Nodes_test[tt].LH = (int[,])Best_indi.LH.Clone();
                                        }
                                        string prev_result = "";
                                        if (File.Exists(ss2))
                                        {
                                            StreamReader reader = new StreamReader(ss2);
                                            prev_result = reader.ReadToEnd();
                                            reader.Close();
                                        }
                                        sw = new StreamWriter(ss2);
                                        sw.Write(prev_result  + Best_indi.F + " ");
                                        sw.Close();
                                        //sw = new StreamWriter(ss);
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
                                        //    sw.Write(costs[tt]);
                                        //    sw.Write(" ");
                                        //}
                                        //sw.Close();
                                        //sw = new StreamWriter(ss3);
                                        //for (int ii = 0; ii < Ntest; ii++)
                                        //{
                                        //    for (int jj = 0; jj < Iteration; jj++)
                                        //        sw.Write(fitnesses[ii, jj].ToString() + "  ");
                                        //    sw.WriteLine();
                                        //}
                                        //sw.Close();
                                        //sw = new StreamWriter(ss4);
                                        //for (int ii = 0; ii < Ntest; ii++)
                                        //{
                                        //    for (int jj = 0; jj < Iteration; jj++)
                                        //        sw.Write(divers[ii, jj].ToString() + "  ");
                                        //    sw.WriteLine();
                                        //}
                                        //sw.Close();
                                    //}

                                }
                            }
                            #endregion
                            #region CCPSO2
                            else if (method == "CCPSO2")
                            {
                                int[] S = { 10, 20, 30, 50, 100 };
                                double[,] S1_A = { { 2, 5, 10, 50, 100 }, { 2, 4, 8, 16, 32 }, { 2, 5, 10, 15, 25 }, { 2, 5, 20, 50, 100 }, { 4, 9, 27, 36, 64 } };
                                double[] ps = { 0, 0.1, 0.2, 0.3, 0.5 };
                                Random RR = new Random();
                                for (int index2 = 0; index2 < ps.Length; index2++)
                                    for (int index = 0; index < S.Length; index++)
                                    {
                                        //int index_cost = 0;
                                        //        int index = 0;
                                        //        int index2=0;
                                        //double[] cost = new double[(NPop * Iteration) / 3 + 1];
                                        //ArrayList cost = new ArrayList();
                                        //int index_indicator = 0;
                                        ss2 = "fit_N" + N.ToString() + "P_" + P.ToString() + method + "_p" + ps[index2] + "_Pattern_" + index + ".txt";
                                        ss = "cost_N" + N.ToString() + "P_" + P.ToString() + method + "Pattern_" + index + ".txt";
                                        if (!File.Exists(ss2))
                                        {
                                            for (int ii = 0; ii < S.Length; ii++)
                                                S[ii] = Convert.ToInt32(S1_A[index, ii]);
                                            for (int ii = 0; ii < S.Length; ii++)
                                                S[ii] = Convert.ToInt32(Math.Ceiling((Convert.ToDouble(S[ii]) / 100) * P));
                                            MOA_Node[] Pop = new MOA_Node[NPop];
                                            int[] Indexes = new int[P];

                                            double p = ps[index2];// it has a chance to be a choice as a parameter
                                            for (int tt = 0; tt < Ntest; tt++)
                                            {
                                                int ind = rr.Next(S.Length);
                                                int s = S[ind];
                                                int K = P / s;
                                                Swarms[] SWs = new Swarms[K];
                                                Swarms[] LocalBest = new Swarms[K];
                                                Swarms[] PersonalBest = new Swarms[K];
                                                MOA_Node[] PersonBest = new MOA_Node[NPop];
                                                MOA_Node Ybest = new MOA_Node();
                                                Ybest.f = 1E290;
                                                Swarms[] PYbest = new Swarms[K];
                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    Pop[ii].x = LH_Class.node_constructing(N, P, rr);
                                                    PersonBest[ii].x = (double[,])Pop[ii].x.Clone();
                                                    Pop[ii].LH = LH_Class.convert_search_s_to_solution_s(Pop[ii].x, N, P);
                                                    Pop[ii].f = LH_Class.F(Pop[ii].LH, N, P);
                                                    if (Ybest.f > Pop[ii].f)
                                                    {
                                                        Ybest.x = (double[,])Pop[ii].x.Clone();
                                                        Ybest.LH = (int[,])Pop[ii].LH.Clone();
                                                        Ybest.f = Pop[ii].f;
                                                    }
                                                    PersonBest[ii].f = Pop[ii].f;
                                                }
                                                double p_yfirst = Ybest.f;
                                                for (int it = 0; it < NPop * Iteration;)
                                                {
                                                    if (p_yfirst <= Ybest.f && it != 0)
                                                    {
                                                        ind = rr.Next(S.Length);
                                                        s = S[ind];
                                                        K = P / s;
                                                        SWs = new Swarms[K];
                                                        LocalBest = new Swarms[K];
                                                        PersonalBest = new Swarms[K];
                                                        PYbest = new Swarms[K];
                                                    }
                                                    p_yfirst = Ybest.f;
                                                    Indexes = LH_Class.sq_rand_gen2(P, P, rr);
                                                    int ll = 0;
                                                    for (int kk = 0; kk < K; kk++)
                                                    {
                                                        SWs[kk].particles = new MOA_Node[NPop];
                                                        LocalBest[kk].particles = new MOA_Node[NPop];
                                                        PersonalBest[kk].particles = new MOA_Node[NPop];
                                                        PYbest[kk].particles = new MOA_Node[1];
                                                        for (int jj = 0; jj < NPop; jj++)
                                                        {
                                                            SWs[kk].particles[jj].x = new double[N, P];
                                                            LocalBest[kk].particles[jj].x = new double[N, P];
                                                            PersonalBest[kk].particles[jj].x = new double[N, P];
                                                            PYbest[kk].particles[0].x = new double[N, P];
                                                            for (int kkk = 0; kkk < s; kkk++)
                                                            {
                                                                for (int ii = 0; ii < N; ii++)
                                                                {
                                                                    SWs[kk].particles[jj].x[ii, kkk] = Pop[jj].x[ii, Indexes[kk * s + kkk]];
                                                                    PersonalBest[kk].particles[jj].x[ii, kkk] = PersonBest[jj].x[ii, Indexes[kk * s + kkk]];
                                                                }
                                                            }
                                                        }

                                                        for (int ii = 0; ii < s; ii++)
                                                        {
                                                            for (int jj = 0; jj < N; jj++)
                                                                PYbest[kk].particles[0].x[jj, ii] = Ybest.x[jj, ll];
                                                            ll++;
                                                        }
                                                        PYbest[kk].particles[0].LH = LH_Class.convert_search_s_to_solution_s(PYbest[kk].particles[0].x, N, P);
                                                        PYbest[kk].particles[0].f = LH_Class.F(PYbest[kk].particles[0].LH, N, P);
                                                        it++;
                                                    }
                                                    for (int sss = 0; sss < K; sss++)
                                                    {
                                                        for (int jj = 0; jj < NPop; jj++)
                                                        {
                                                            double[,] constructing = LH_Class.Concatenation(Ybest.x, sss * s, N, s, SWs[sss].particles[jj].x);
                                                            double[,] personal_best = LH_Class.Concatenation(Ybest.x, sss * s, N, s, PersonalBest[sss].particles[jj].x);
                                                            double[,] y_best = LH_Class.Concatenation(Ybest.x, sss * s, N, s, PYbest[sss].particles[0].x);
                                                            int[,] subs_constructing = LH_Class.convert_search_s_to_solution_s(constructing, N, P);
                                                            SWs[sss].particles[jj].f = LH_Class.F(subs_constructing, N, P);
                                                            it++;
                                                            int[,] subs_personal_best = LH_Class.convert_search_s_to_solution_s(personal_best, N, P);
                                                            PersonalBest[sss].particles[jj].f = LH_Class.F(subs_personal_best, N, P);
                                                            it++;
                                                            if (PersonalBest[sss].particles[jj].f > SWs[sss].particles[jj].f)
                                                            {
                                                                PersonalBest[sss].particles[jj].f = SWs[sss].particles[jj].f;
                                                                PersonalBest[sss].particles[jj].x = (double[,])SWs[sss].particles[jj].x.Clone();
                                                            }
                                                            int[,] subs_y_best = LH_Class.convert_search_s_to_solution_s(y_best, N, P);
                                                            PYbest[sss].particles[0].f = LH_Class.F(subs_y_best, N, P);
                                                            it++;
                                                            if (PersonalBest[sss].particles[jj].f < PYbest[sss].particles[0].f)
                                                            {
                                                                PYbest[sss].particles[0].f = PersonalBest[sss].particles[jj].f;
                                                                PYbest[sss].particles[0].x = (double[,])PersonalBest[sss].particles[jj].x.Clone();
                                                            }
                                                            //cost.Add(Ybest.f);
                                                        }
                                                        /////////////////////////////////////////////////
                                                        for (int jj = 0; jj < NPop; jj++)
                                                        {
                                                            int[] Nei = LH_Class.Ring_withmyself(jj, NPop);
                                                            double min = 1E250;
                                                            for (int ii = 0; ii < Nei.Length; ii++)
                                                            {
                                                                if (PersonalBest[sss].particles[Nei[ii]].f < min)
                                                                {
                                                                    LocalBest[sss].particles[jj].f = PersonalBest[sss].particles[Nei[ii]].f;
                                                                    LocalBest[sss].particles[jj].x = (double[,])PersonalBest[sss].particles[Nei[ii]].x.Clone();
                                                                    min = PersonalBest[sss].particles[Nei[ii]].f;
                                                                }
                                                            }
                                                        }
                                                        if (PYbest[sss].particles[0].f < Ybest.f)
                                                        {
                                                            Ybest.f = PYbest[sss].particles[0].f;
                                                            int mm = 0;
                                                            for (int ii = sss * s; ii < sss * s + s; ii++)
                                                            {
                                                                for (int nn = 0; nn < N; nn++)
                                                                    Ybest.x[nn, ii] = PYbest[sss].particles[0].x[nn, mm];
                                                                mm++;
                                                            }
                                                        }
                                                    }
                                                    for (int sss = 0; sss < K; sss++)
                                                    {
                                                        for (int jj = 0; jj < NPop; jj++)
                                                        {
                                                            for (int nn = 0; nn < N; nn++)
                                                                for (int kk = 0; kk < s; kk++)
                                                                {
                                                                    if (RR.NextDouble() <= p)
                                                                        SWs[sss].particles[jj].x[nn, kk] = PersonalBest[sss].particles[jj].x[nn, kk] + LH_Class.Cauchy_mu(RR) * (PersonalBest[sss].particles[jj].x[nn, kk] - LocalBest[sss].particles[jj].x[nn, kk]);
                                                                    else
                                                                        SWs[sss].particles[jj].x[nn, kk] = LocalBest[sss].particles[jj].x[nn, kk] + LH_Class.Normal_Distribution(RR, 0, 1) * (PersonalBest[sss].particles[jj].x[nn, kk] - LocalBest[sss].particles[jj].x[nn, kk]);
                                                                    Pop[jj].x[nn, sss * s + kk] = SWs[sss].particles[jj].x[nn, kk];
                                                                    PersonBest[jj].x[nn, sss * s + kk] = PersonalBest[sss].particles[jj].x[nn, kk];
                                                                }

                                                        }
                                                    }
                                                    for (int jj = 0; jj < NPop; jj++)
                                                    {
                                                        Node_treatment(Pop[jj].x, N, P, RR);
                                                    }

                                                }
                                                costs[tt] = Ybest.f;
                                                Nodes_test[tt].LH = (int[,])Ybest.LH.Clone();
                                            }
                                            sw = new StreamWriter(ss2);
                                            for (int tt = 0; tt < Ntest; tt++)
                                            {
                                                sw.Write(costs[tt].ToString() + " ");
                                            }
                                            sw.Close();
                                            //sw = new StreamWriter(ss);
                                            //for (int ii = 0; ii < cost.Count; ii++)
                                            //{
                                            //    sw.Write(cost[ii].ToString() + " ");
                                            //}
                                            //sw.Close();
                                            //sw = new StreamWriter(ss);
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
                                        }
                                    }
                            }
                            #endregion
                            #region METHODS
                            else if (method == "METHODS")
                            {
                                string learning = "Gbest";
                                double C1 = 1; double C2 = 1; double W = 1.5;
                                double[] Cs = { 0.5, 1, 1.5, 2, 2.5 };
                                double[] Ws = { 2.5, 5 };
                                //for (int LL = 0; LL < r_lg_s.Length; LL++)
                                //{
                                //C1 = 1; C2 = 1; W = 2.5;
                                double r_lg = 1;
                                Iteration = 1;
                                NPop = 1;
                                double[,] Cost = new double[Ntest, Iteration];
                                int Learning = 100000;
                                // ss = "Costs_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_W_" + W.ToString() + "_C1_" + C1.ToString() + "_C2_" + C2.ToString() + method + "r_LcLG" + r_lg.ToString() + "_test_" + Ntest.ToString() + ".txt";
                                ss2 = "fit_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_W_" + W.ToString() + "_C1_" + C1.ToString() + "_C2_" + C2.ToString() + "MLS" + "r_LcLG" + r_lg.ToString() + "_test_" + Ntest.ToString() + ".txt";
                                if (!File.Exists(ss))
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

                                        //loca_searches ls_methods = LH_Class.Local_Searches(LHC[min_index].LH, Nodes[min_index].x, N, P);
                                        //Best_nodes.LH = (int[,])ls_methods.LH.Clone();
                                        //Best_nodes.x = (double[,])ls_methods.x.Clone();
                                        //Best_nodes.f = LH_Class.F(Best_nodes.LH, N, P);
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
                                            if (learning == "Gbest")
                                            {
                                                double delta_tetha = LH_Class.SA_local_search_MPLS(ref Best_nodes, P, N, rr, Learning);
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
                                            //Cost[tt, it] = Best_nodes.f;
                                        }

                                        costs[tt] = Best_nodes.f;
                                        Nodes_test[tt].LH = (int[,])Best_nodes.LH.Clone();

                                    }
                                    sw = new StreamWriter(ss2);
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        sw.Write(costs[tt].ToString() + " ");
                                    }
                                    sw.Close();
                                    //sw = new StreamWriter(ss);
                                    //for (int tt = 0; tt < Ntest; tt++)
                                    //{
                                    //    for (int it = 0; it < Iteration; it++)
                                    //    {
                                    //        sw.Write(Cost[tt, it].ToString() + " ");

                                    //    }
                                    //}
                                    //sw.Close();
                                }
                                //}
                            }
                            #endregion
                            #region F-RaceMAPSO
                            else if (method == "FRMAPSO")
                            {
                                int budget = NPop * Iteration;
                                double Mean = 0;
                                /////////////Initialization Process//////////////////////
                                int instance = dimen.Length;
                                int Nconf = 0;
                                int Npar = 4;
                                int Bwhole = Convert.ToInt32(Bud.Text);
                                int Bused = 0;
                                int Niter = Convert.ToInt32(Math.Floor(2 + Math.Log(Npar)));
                                int[] Bj = new int[Niter];
                                Bj[0] = Bwhole / Niter;
                                Nconf = Bj[0] / 5;
                                Random RR = new Random();
                                float[,] Configuration = new float[Nconf, Npar];
                                double[] Cost = new double[Nconf];
                                R[,] Rha = new R[instance, Nconf];

                                for (int jj = 0; jj < Nconf; jj++)
                                {
                                    for (int kk = 0; kk < Npar - 1; kk++)
                                    {
                                        Configuration[jj, kk] = Convert.ToSingle(10 * RR.NextDouble());
                                    }
                                    for (int kk = Npar - 1; kk < Npar; kk++)
                                    {
                                        Configuration[jj, kk] = Convert.ToSingle(RR.NextDouble());
                                    }
                                }
                                ///////////////////////////////////////////////////////
                                bool[] dis = new bool[Nconf]; // The ones have been discarded...
                                int dis_conf = 0;
                                int best_cand = -1;
                                int ins_count = 0;
                                int Learning = 0;
                                ss = Directory.GetCurrentDirectory() + "\\FRMAPSO.txt";
                                if (!File.Exists(ss))
                                {
                                    for (int IT = 0; IT < Niter; IT++)
                                    {
                                        Rha = new R[instance, Nconf];
                                        dis = new bool[Nconf];
                                        double[] orders = new double[Nconf];
                                        for (int II = 0; II < instance && dis_conf <= Nconf - 1; II++)
                                        {
                                            N = Ns[II];
                                            P = Ps[II];
                                            for (int jj = 0; jj < Nconf; jj++)
                                            {
                                                if (!dis[jj])
                                                {
                                                    double C1 = Configuration[jj, 0]; double C2 = Configuration[jj, 1]; double W = Configuration[jj, 2];
                                                    Mean = 0;
                                                    double alpha = Configuration[jj, 3];
                                                    Iteration = Convert.ToInt32(Math.Ceiling(budget * (1 - alpha) / NPop));
                                                    Learning = Convert.ToInt32((NPop * alpha) / (1 - alpha));
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

                                                            int ls_chosen = LH_Class.ranking_selection_for_lc(ls_methods, 3, rr);
                                                            double delta_tetha = LH_Class.SA_local_search(ref Best_nodes, ls_chosen, P, N, rr, Learning);
                                                            switch (ls_chosen)
                                                            {
                                                                case 0: ls_methods.result_insert += delta_tetha; break;
                                                                case 1: ls_methods.result_inverse += delta_tetha; break;
                                                                case 2: ls_methods.result_swap += delta_tetha; break;
                                                            }
                                                            ////////////////////////////////////////////////////////////////////
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
                                                        }

                                                        costs[tt] = Best_nodes.f;
                                                        Mean += Best_nodes.f;
                                                    }
                                                    //Cost[jj] = Mean / Ntest;
                                                    Rha[II, jj].Cost = Mean / Ntest;
                                                    Rha[II, jj].conf = jj;
                                                }
                                            }

                                            for (int hh = II; hh < II + 1; hh++)
                                            {
                                                for (int hh2 = 0; hh2 < Nconf - 1; hh2++)
                                                {
                                                    if (!dis[hh2])
                                                        for (int hh3 = hh2 + 1; hh3 < Nconf; hh3++)
                                                        {
                                                            if (!dis[hh3])
                                                                if (Rha[hh, hh2].Cost < Rha[hh, hh3].Cost)
                                                                {
                                                                    R temp = Rha[hh, hh2];
                                                                    Rha[hh, hh2] = Rha[hh, hh3];
                                                                    Rha[hh, hh3] = temp;
                                                                }
                                                        }
                                                }
                                            }
                                            for (int hh = II; hh < II + 1; hh++)
                                            {
                                                for (int ii = Nconf - 1; ii > 0; ii--)
                                                {
                                                    if (!dis[ii])
                                                    {
                                                        Rha[hh, ii].value++;
                                                        for (int jj = ii - 1; jj >= 0; jj--)
                                                        {
                                                            if (Rha[hh, ii].Cost == Rha[hh, jj].Cost)
                                                            {
                                                                Rha[hh, ii].value++;
                                                            }
                                                            else
                                                            {
                                                                ii = jj + 1;
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            if (Rha[II, 1].value <= 1 && !dis[0])
                                            {
                                                Rha[II, 0].value = 1;
                                            }
                                            int Nc = 0;
                                            for (int ii = 0; ii < Nconf; ii++)
                                            {
                                                if (!dis[ii])
                                                {

                                                    if (Rha[II, ii].value > 2)
                                                    {
                                                        int temp = Convert.ToInt32(Rha[II, ii].value);
                                                        int ind = 0;
                                                        for (int jj = ii - temp + 1; jj <= ii; jj++)
                                                        {
                                                            ind += jj + 1;
                                                        }
                                                        for (int jj = ii - temp + 1; jj <= ii; jj++)
                                                        {
                                                            Rha[II, jj].value = ind / temp;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Rha[II, ii].value = ii + 1 - Nc;
                                                    }
                                                }
                                                else
                                                    Nc++;

                                            }
                                            for (int jj = II; jj < II + 1; jj++)
                                                for (int ii = 0; ii < orders.Length; ii++)
                                                {
                                                    if (!dis[ii])
                                                    {
                                                        orders[Rha[jj, ii].conf] += Rha[II, ii].value;
                                                    }
                                                }
                                            ////////////////////T computation
                                            double T = 0;
                                            double sorat = 0;
                                            for (int hh2 = 0; hh2 < Nconf; hh2++)
                                            {
                                                if (!dis[hh2])
                                                {
                                                    sorat += Math.Pow(orders[hh2] - (((II + 1) * Nconf + 1) / 2), 2);
                                                }
                                            }
                                            sorat = sorat * (Nconf - 1);
                                            double makhraj = 0;
                                            for (int hh = 0; hh < II + 1; hh++)
                                            {
                                                for (int hh2 = 0; hh2 < Nconf; hh2++)
                                                {
                                                    if (!dis[hh2])
                                                    {
                                                        makhraj += Math.Pow(Rha[hh, hh2].conf, 2);
                                                    }
                                                }
                                            }

                                            makhraj = makhraj - ((II * Nconf * Math.Pow((Nconf + 1), 2)) / 4);
                                            T = sorat / makhraj;
                                            ////////////////
                                            double alpha2 = 0.05;
                                            double quantile1 = LH_Class.get_t_quantile(alpha2, II + 1, t_table); //getStudentT(alpha, rows);
                                            if (T <= quantile1)
                                            {

                                            }
                                            else
                                            {
                                                //calculating T2 (pair-wise test), when needed
                                                double T2, quantile2 = LH_Class.get_t_quantile(alpha2, II + 1, t_table, true);
                                                double best_score = -1;
                                                for (int j = 0; j < Nconf; j++)
                                                {

                                                    if (orders[j] > best_score || best_score == -1)
                                                    {
                                                        best_score = orders[j];
                                                        best_cand = j;
                                                    }
                                                }
                                                makhraj *= Math.Abs((2 * (II + 1)) * (1 - (T / ((II + 1) * (Nconf - 1)))));
                                                makhraj /= ((II + 1) * (Nconf - 1));
                                                for (int j = 0; j < Nconf; j++)
                                                    if (!dis[j])
                                                    {
                                                        if (j != best_cand)
                                                        {
                                                            double diff = orders[best_cand] - orders[j];
                                                            if (diff < 0) diff *= (-1);
                                                            T2 = diff / Math.Sqrt(makhraj);
                                                            if (diff / Math.Sqrt(makhraj) > quantile2)
                                                            {
                                                                dis[j] = true;
                                                                dis_conf++;
                                                                orders[j] = 0;
                                                            }
                                                        }
                                                    }
                                            }
                                            ////////////////////
                                            ins_count = II;
                                        }
                                        //////////////////////////////////////////Select The best///////////////////////////////////
                                        int remainder = Nconf - dis_conf;
                                        int[] rz = new int[Nconf];
                                        int kk = 0;
                                        for (int ii = 0; ii < rz.Length; ii++)
                                        {
                                            if (!dis[ii])
                                            {
                                                rz[Rha[ins_count, ii].conf] = kk + 1;
                                                kk++;
                                            }
                                        }
                                        double[] Pz = new double[remainder];
                                        double rands = RR.NextDouble();
                                        kk = 0;
                                        for (int ii = 0; ii < Nconf; ii++)
                                        {
                                            if (!dis[ii])
                                            {
                                                if (kk == 0)
                                                    Pz[kk] = Convert.ToDouble(remainder - orders[ii] + 1) / (remainder * (remainder + 1) / 2);
                                                else
                                                    Pz[kk] = Convert.ToDouble(remainder - orders[ii] + 1) / (remainder * (remainder + 1) / 2) + Pz[kk - 1];
                                                if (Pz[kk] > rands)
                                                {
                                                    best_cand = Rha[ins_count, ii].conf;
                                                    break;
                                                }
                                                kk++;
                                            }
                                        }
                                        ///////////////////////////////////////////////////////////////////////////////////////////


                                        Bused += Bj[IT];
                                        double lboundCW = 0;
                                        double uboundCW = 10;
                                        double l_lg = 0;
                                        double u_lg = 1;
                                        int Mue = 5 + IT + 1;
                                        double deltad_menfi_yekCW = (uboundCW - lboundCW) / 2;
                                        double deltad_menfi_yek_lg = (u_lg - l_lg) / 2;
                                        int symbol = 0;
                                        Bj[IT + 1] = (Bwhole - Bused) / (Niter - IT + 1);
                                        int Nconf_perv = Nconf;
                                        Nconf = Convert.ToInt32(Bj[IT + 1] / (Mue + Math.Min(5, IT + 1))) - remainder;// (Nconf-dis_conf) is equal the remainder of perv_conf
                                        if (Nconf < 1)
                                        {
                                            break;
                                        }
                                        double deltad_CW = deltad_menfi_yekCW * Math.Pow((1.0 / Nconf), ((double)IT) / Npar);
                                        double delta_lg = deltad_menfi_yek_lg * Math.Pow((1.0 / Nconf), ((double)IT) / Npar);
                                        float[,] PervConf = (float[,])Configuration.Clone();
                                        Configuration = new float[Nconf + remainder, Npar];
                                        ///////C1 , C2 , W, r_lg
                                        for (int jj = 0; jj < Nconf; jj++)
                                        {
                                            for (kk = 0; kk < Npar - 1; kk++)
                                            {
                                                symbol = RR.Next(0, 2);
                                                if (symbol == 0)
                                                    Configuration[jj, kk] = Convert.ToSingle(PervConf[best_cand, kk] + deltad_CW * RR.NextDouble());
                                                else
                                                    Configuration[jj, kk] = Convert.ToSingle(PervConf[best_cand, kk] - deltad_CW * RR.NextDouble());
                                            }
                                            symbol = RR.Next(0, 2);
                                            if (symbol == 0)
                                                Configuration[jj, Npar - 1] = Convert.ToSingle(PervConf[best_cand, Npar - 1] + delta_lg * RR.NextDouble());
                                            else
                                                Configuration[jj, Npar - 1] = Convert.ToSingle(PervConf[best_cand, Npar - 1] - delta_lg * RR.NextDouble());
                                        }
                                        int iii = Nconf;
                                        for (int jj = 0; jj < Nconf_perv; jj++)
                                        {
                                            if (!dis[jj])
                                            {
                                                for (kk = 0; kk < Npar; kk++)
                                                {
                                                    Configuration[iii, kk] = PervConf[jj, kk];
                                                }
                                                iii++;
                                            }
                                        }
                                        Nconf = Nconf + remainder;// the set of perv_conf+ curr_conf
                                        dis_conf = 0;
                                    }
                                    sw = new StreamWriter(ss);
                                    for (int ii = 0; ii < Npar; ii++)
                                    {
                                        sw.WriteLine(Configuration[best_cand, ii]);
                                    }
                                    sw.Close();
                                }
                            }
                            #endregion
                            #region F-RaceESE
                            else if (method == "FRESE")
                            {
                                double Mean = 0;
                                /////////////Initialization Process//////////////////////
                                int instance = dimen.Length;
                                int Nconf = 0;
                                int Npar = 7;
                                int Bwhole = Convert.ToInt32(Bud.Text);
                                int Bused = 0;
                                int Niter = Convert.ToInt32(Math.Floor(2 + Math.Log(Npar)));
                                int[] Bj = new int[Niter];
                                Bj[0] = Bwhole / Niter;
                                Nconf = Bj[0] / 5;
                                Random RR = new Random();
                                float[,] Configuration = new float[Nconf, Npar];
                                double[] Cost = new double[Nconf];
                                R[,] Rha = new R[instance, Nconf];
                                for (int jj = 0; jj < Nconf; jj++)
                                {
                                    for (int kk = 0; kk < Npar - 2; kk++)
                                    {
                                        Configuration[jj, kk] = Convert.ToSingle(RR.NextDouble());
                                    }
                                    for (int kk = Npar - 2; kk < Npar - 1; kk++)
                                    {
                                        Configuration[jj, kk] = RR.Next(1, 100);
                                    }
                                    for (int kk = Npar - 1; kk < Npar; kk++)
                                    {
                                        Configuration[jj, kk] = RR.Next(1, 10);
                                    }
                                }
                                double it = 0;
                                ///////////////////////////////////////////////////////
                                bool[] dis = new bool[Nconf]; // The ones have been discarded...
                                int dis_conf = 0;
                                int best_cand = -1;
                                int ins_count = 0;
                                ss = Directory.GetCurrentDirectory() + "\\FRESE.txt";
                                if (!File.Exists(ss))
                                {
                                    for (int IT = 0; IT < Niter; IT++)
                                    {
                                        Rha = new R[instance, Nconf];
                                        dis = new bool[Nconf];
                                        double[] orders = new double[Nconf];
                                        for (int II = 0; II < instance && dis_conf <= Nconf - 1; II++)
                                        {
                                            N = Ns[II];
                                            P = Ps[II];
                                            for (int jjj = 0; jjj < Nconf; jjj++)
                                            {
                                                double alpha1 = Configuration[jjj, 0];
                                                double alpha2 = Configuration[jjj, 1];
                                                double alpha3 = Configuration[jjj, 2];
                                                double small_per = Configuration[jjj, 3];
                                                double Th = Configuration[jjj, 4];
                                                int M = Convert.ToInt32(Configuration[jjj, 5]);
                                                int J = Convert.ToInt32(Configuration[jjj, 6]);
                                                Mean = 0;
                                                for (int tt = 0; tt < Ntest; tt++)
                                                {
                                                    Th = Configuration[jjj, 4];
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
                                                    }
                                                    costs[tt] = Z;
                                                    Mean += Z;
                                                }

                                                Rha[II, jjj].Cost = Mean / Ntest;
                                                Rha[II, jjj].conf = jjj;
                                            }

                                            for (int hh = II; hh < II + 1; hh++)
                                            {
                                                for (int hh2 = 0; hh2 < Nconf - 1; hh2++)
                                                {
                                                    if (!dis[hh2])
                                                        for (int hh3 = hh2 + 1; hh3 < Nconf; hh3++)
                                                        {
                                                            if (!dis[hh3])
                                                                if (Rha[hh, hh2].Cost < Rha[hh, hh3].Cost)
                                                                {
                                                                    R temp = Rha[hh, hh2];
                                                                    Rha[hh, hh2] = Rha[hh, hh3];
                                                                    Rha[hh, hh3] = temp;
                                                                }
                                                        }
                                                }
                                            }
                                            for (int hh = II; hh < II + 1; hh++)
                                            {
                                                for (int ii = Nconf - 1; ii > 0; ii--)
                                                {
                                                    if (!dis[ii])
                                                    {
                                                        Rha[hh, ii].value++;
                                                        for (int jj = ii - 1; jj >= 0; jj--)
                                                        {
                                                            if (Rha[hh, ii].Cost == Rha[hh, jj].Cost)
                                                            {
                                                                Rha[hh, ii].value++;
                                                            }
                                                            else
                                                            {
                                                                ii = jj + 1;
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            if (Rha[II, 1].value <= 1 && !dis[0])
                                            {
                                                Rha[II, 0].value = 1;
                                            }
                                            int Nc = 0;
                                            for (int ii = 0; ii < Nconf; ii++)
                                            {
                                                if (!dis[ii])
                                                {

                                                    if (Rha[II, ii].value > 2)
                                                    {
                                                        int temp = Convert.ToInt32(Rha[II, ii].value);
                                                        int ind = 0;
                                                        for (int jj = ii - temp + 1; jj <= ii; jj++)
                                                        {
                                                            ind += jj + 1;
                                                        }
                                                        for (int jj = ii - temp + 1; jj <= ii; jj++)
                                                        {
                                                            Rha[II, jj].value = ind / temp;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Rha[II, ii].value = ii + 1 - Nc;
                                                    }
                                                }
                                                else
                                                    Nc++;

                                            }
                                            for (int jj = II; jj < II + 1; jj++)
                                                for (int ii = 0; ii < orders.Length; ii++)
                                                {
                                                    if (!dis[ii])
                                                    {
                                                        orders[Rha[jj, ii].conf] += Rha[II, ii].value;
                                                    }
                                                }
                                            ////////////////////T computation
                                            double T = 0;
                                            double sorat = 0;
                                            for (int hh2 = 0; hh2 < Nconf; hh2++)
                                            {
                                                if (!dis[hh2])
                                                {
                                                    sorat += Math.Pow(orders[hh2] - (((II + 1) * Nconf + 1) / 2), 2);
                                                }
                                            }
                                            sorat = sorat * (Nconf - 1);
                                            double makhraj = 0;
                                            for (int hh = 0; hh < II + 1; hh++)
                                            {
                                                for (int hh2 = 0; hh2 < Nconf; hh2++)
                                                {
                                                    if (!dis[hh2])
                                                    {
                                                        makhraj += Math.Pow(Rha[hh, hh2].conf, 2);
                                                    }
                                                }
                                            }

                                            makhraj = makhraj - ((II * Nconf * Math.Pow((Nconf + 1), 2)) / 4);
                                            T = sorat / makhraj;
                                            ////////////////
                                            double alpha = 0.05;
                                            double quantile1 = LH_Class.get_t_quantile(alpha, II + 1, t_table); //getStudentT(alpha, rows);
                                            if (T <= quantile1)
                                            {

                                            }
                                            else
                                            {
                                                //calculating T2 (pair-wise test), when needed
                                                double T2, quantile2 = LH_Class.get_t_quantile(alpha, II + 1, t_table, true);
                                                double best_score = -1;
                                                for (int j = 0; j < Nconf; j++)
                                                {

                                                    if (orders[j] > best_score || best_score == -1)
                                                    {
                                                        best_score = orders[j];
                                                        best_cand = j;
                                                    }
                                                }
                                                makhraj *= Math.Abs((2 * (II + 1)) * (1 - (T / ((II + 1) * (Nconf - 1)))));
                                                makhraj /= ((II + 1) * (Nconf - 1));
                                                for (int j = 0; j < Nconf; j++)
                                                    if (!dis[j])
                                                    {
                                                        if (j != best_cand)
                                                        {
                                                            double diff = orders[best_cand] - orders[j];
                                                            if (diff < 0) diff *= (-1);
                                                            T2 = diff / Math.Sqrt(makhraj);
                                                            if (diff / Math.Sqrt(makhraj) > quantile2)
                                                            {
                                                                dis[j] = true;
                                                                dis_conf++;
                                                                orders[j] = 0;
                                                            }
                                                        }
                                                    }
                                            }
                                            ////////////////////
                                            ins_count = II;
                                        }
                                        //////////////////////////////////////////Select The best///////////////////////////////////
                                        int remainder = Nconf - dis_conf;
                                        int[] rz = new int[Nconf];
                                        int kk = 0;
                                        for (int ii = 0; ii < rz.Length; ii++)
                                        {
                                            if (!dis[ii])
                                            {
                                                rz[Rha[ins_count, ii].conf] = kk + 1;
                                                kk++;
                                            }
                                        }
                                        double[] Pz = new double[remainder];
                                        double rands = RR.NextDouble();
                                        kk = 0;
                                        for (int ii = 0; ii < Nconf; ii++)
                                        {
                                            if (!dis[ii])
                                            {
                                                if (kk == 0)
                                                    Pz[kk] = Convert.ToDouble(remainder - orders[ii] + 1) / (remainder * (remainder + 1) / 2);
                                                else
                                                    Pz[kk] = Convert.ToDouble(remainder - orders[ii] + 1) / (remainder * (remainder + 1) / 2) + Pz[kk - 1];
                                                if (Pz[kk] > rands)
                                                {
                                                    best_cand = Rha[ins_count, ii].conf;
                                                    break;
                                                }
                                                kk++;
                                            }
                                        }
                                        ///////////////////////////////////////////////////////////////////////////////////////////


                                        Bused += Bj[IT];
                                        double lboundCW = 0;
                                        double uboundCW = 10;
                                        double l_lg = 0;
                                        double u_lg = 1;
                                        int Mue = 5 + IT + 1;
                                        double deltad_menfi_yekCW = (uboundCW - lboundCW) / 2;
                                        double deltad_menfi_yek_lg = (u_lg - l_lg) / 2;
                                        int symbol = 0;
                                        Bj[IT + 1] = (Bwhole - Bused) / (Niter - IT + 1);
                                        int Nconf_perv = Nconf;
                                        Nconf = Convert.ToInt32(Bj[IT + 1] / (Mue + Math.Min(5, IT + 1))) - remainder;// (Nconf-dis_conf) is equal the remainder of perv_conf
                                        if (Nconf < 1)
                                        {
                                            break;
                                        }
                                        double deltad_CW = deltad_menfi_yekCW * Math.Pow((1.0 / Nconf), ((double)IT) / Npar);
                                        double delta_lg = deltad_menfi_yek_lg * Math.Pow((1.0 / Nconf), ((double)IT) / Npar);
                                        float[,] PervConf = (float[,])Configuration.Clone();
                                        Configuration = new float[Nconf + remainder, Npar];
                                        ///////C1 , C2 , W, r_lg
                                        for (int jj = 0; jj < Nconf; jj++)
                                        {
                                            for (kk = 0; kk < Npar - 1; kk++)
                                            {
                                                symbol = RR.Next(0, 2);
                                                if (symbol == 0)
                                                    Configuration[jj, kk] = Convert.ToSingle(PervConf[best_cand, kk] + deltad_CW * RR.NextDouble());
                                                else
                                                    Configuration[jj, kk] = Convert.ToSingle(PervConf[best_cand, kk] - deltad_CW * RR.NextDouble());
                                            }
                                            symbol = RR.Next(0, 2);
                                            if (symbol == 0)
                                                Configuration[jj, Npar - 1] = Convert.ToSingle(PervConf[best_cand, Npar - 1] + delta_lg * RR.NextDouble());
                                            else
                                                Configuration[jj, Npar - 1] = Convert.ToSingle(PervConf[best_cand, Npar - 1] - delta_lg * RR.NextDouble());
                                        }
                                        int iii = Nconf;
                                        for (int jj = 0; jj < Nconf_perv; jj++)
                                        {
                                            if (!dis[jj])
                                            {
                                                for (kk = 0; kk < Npar; kk++)
                                                {
                                                    Configuration[iii, kk] = PervConf[jj, kk];
                                                }
                                                iii++;
                                            }
                                        }
                                        Nconf = Nconf + remainder;// the set of perv_conf+ curr_conf
                                        dis_conf = 0;
                                    }
                                    sw = new StreamWriter(ss);
                                    for (int ii = 0; ii < Npar; ii++)
                                    {
                                        sw.WriteLine(Configuration[best_cand, ii]);
                                    }
                                    sw.Close();
                                }
                            }
                            #endregion
                            #region F-RaceSA
                            else if (method == "FRSA")
                            {
                                int budget = NPop * Iteration;
                                double Mean = 0;
                                /////////////Initialization Process//////////////////////
                                int instance = dimen.Length;
                                int Nconf = 0;
                                int Npar = 2;
                                int Bwhole = Convert.ToInt32(Bud.Text);
                                int Bused = 0;
                                int Niter = Convert.ToInt32(Math.Floor(2 + Math.Log(Npar)));
                                int[] Bj = new int[Niter];
                                Bj[0] = Bwhole / Niter;
                                Nconf = Bj[0] / 5;
                                Random RR = new Random();
                                float[,] Configuration = new float[Nconf, Npar];
                                double[] Cost = new double[Nconf];
                                R[,] Rha = new R[instance, Nconf];
                                for (int jj = 0; jj < Nconf; jj++)
                                {
                                    Configuration[jj, 0] = Convert.ToSingle(100 * RR.NextDouble());// T
                                    Configuration[jj, 1] = Convert.ToSingle(0.8 + 0.2 * RR.NextDouble());// Cooling rate
                                }
                                ///////////////////////////////////////////////////////
                                bool[] dis = new bool[Nconf]; // The ones have been discarded...
                                int dis_conf = 0;
                                int best_cand = -1;
                                int ins_count = 0;
                                int Learning = 0;
                                ss = Directory.GetCurrentDirectory() + "\\FRSA.txt";
                                if (!File.Exists(ss))
                                {
                                    for (int IT = 0; IT < Niter; IT++)
                                    {
                                        Rha = new R[instance, Nconf];
                                        dis = new bool[Nconf];
                                        double[] orders = new double[Nconf];
                                        for (int II = 0; II < instance && dis_conf <= Nconf - 1; II++)
                                        {
                                            N = Ns[II];
                                            P = Ps[II];
                                            double M = P * (P - 1) * N;
                                            for (int jjj = 0; jjj < Nconf; jjj++)
                                            {
                                                double T_help = Configuration[jjj, 0];
                                                double cr = Configuration[jjj, 1];
                                                Mean = 0;
                                                int Iter = 0;
                                                for (int tt = 0; tt < Ntest; tt++)
                                                {
                                                    double T = T_help;
                                                    int it = 0;
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
                                                            z2 = LH_Class.F(LH_temp, N, P);
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
                                                            it++;
                                                        }
                                                        T = T * cr;
                                                    }
                                                    costs[tt] = z1;
                                                    Mean += z1;
                                                }

                                                Rha[II, jjj].Cost = Mean / Ntest;
                                                Rha[II, jjj].conf = jjj;
                                            }
                                            for (int hh = II; hh < II + 1; hh++)
                                            {
                                                for (int hh2 = 0; hh2 < Nconf - 1; hh2++)
                                                {
                                                    if (!dis[hh2])
                                                        for (int hh3 = hh2 + 1; hh3 < Nconf; hh3++)
                                                        {
                                                            if (!dis[hh3])
                                                                if (Rha[hh, hh2].Cost < Rha[hh, hh3].Cost)
                                                                {
                                                                    R temp = Rha[hh, hh2];
                                                                    Rha[hh, hh2] = Rha[hh, hh3];
                                                                    Rha[hh, hh3] = temp;
                                                                }
                                                        }
                                                }
                                            }
                                            for (int hh = II; hh < II + 1; hh++)
                                            {
                                                for (int ii = Nconf - 1; ii > 0; ii--)
                                                {
                                                    if (!dis[ii])
                                                    {
                                                        Rha[hh, ii].value++;
                                                        for (int jj = ii - 1; jj >= 0; jj--)
                                                        {
                                                            if (Rha[hh, ii].Cost == Rha[hh, jj].Cost)
                                                            {
                                                                Rha[hh, ii].value++;
                                                            }
                                                            else
                                                            {
                                                                ii = jj + 1;
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            if (Rha[II, 1].value <= 1 && !dis[0])
                                            {
                                                Rha[II, 0].value = 1;
                                            }
                                            int Nc = 0;
                                            for (int ii = 0; ii < Nconf; ii++)
                                            {
                                                if (!dis[ii])
                                                {

                                                    if (Rha[II, ii].value > 2)
                                                    {
                                                        int temp = Convert.ToInt32(Rha[II, ii].value);
                                                        int ind = 0;
                                                        for (int jj = ii - temp + 1; jj <= ii; jj++)
                                                        {
                                                            ind += jj + 1;
                                                        }
                                                        for (int jj = ii - temp + 1; jj <= ii; jj++)
                                                        {
                                                            Rha[II, jj].value = ind / temp;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Rha[II, ii].value = ii + 1 - Nc;
                                                    }
                                                }
                                                else
                                                    Nc++;

                                            }
                                            for (int jj = II; jj < II + 1; jj++)
                                                for (int ii = 0; ii < orders.Length; ii++)
                                                {
                                                    if (!dis[ii])
                                                    {
                                                        orders[Rha[jj, ii].conf] += Rha[II, ii].value;
                                                    }
                                                }
                                            ////////////////////T computation
                                            double TC = 0;
                                            double sorat = 0;
                                            for (int hh2 = 0; hh2 < Nconf; hh2++)
                                            {
                                                if (!dis[hh2])
                                                {
                                                    sorat += Math.Pow(orders[hh2] - (((II + 1) * Nconf + 1) / 2), 2);
                                                }
                                            }
                                            sorat = sorat * (Nconf - 1);
                                            double makhraj = 0;
                                            for (int hh = 0; hh < II + 1; hh++)
                                            {
                                                for (int hh2 = 0; hh2 < Nconf; hh2++)
                                                {
                                                    if (!dis[hh2])
                                                    {
                                                        makhraj += Math.Pow(Rha[hh, hh2].conf, 2);
                                                    }
                                                }
                                            }

                                            makhraj = makhraj - ((II * Nconf * Math.Pow((Nconf + 1), 2)) / 4);
                                            TC = sorat / makhraj;
                                            ////////////////
                                            double alpha2 = 0.05;
                                            double quantile1 = LH_Class.get_t_quantile(alpha2, II + 1, t_table); //getStudentT(alpha, rows);
                                            if (TC <= quantile1)
                                            {

                                            }
                                            else
                                            {
                                                //calculating T2 (pair-wise test), when needed
                                                double T2, quantile2 = LH_Class.get_t_quantile(alpha2, II + 1, t_table, true);
                                                double best_score = -1;
                                                for (int j = 0; j < Nconf; j++)
                                                {

                                                    if (orders[j] > best_score || best_score == -1)
                                                    {
                                                        best_score = orders[j];
                                                        best_cand = j;
                                                    }
                                                }
                                                makhraj *= Math.Abs((2 * (II + 1)) * (1 - (TC / ((II + 1) * (Nconf - 1)))));
                                                makhraj /= ((II + 1) * (Nconf - 1));
                                                for (int j = 0; j < Nconf; j++)
                                                    if (!dis[j])
                                                    {
                                                        if (j != best_cand)
                                                        {
                                                            double diff = orders[best_cand] - orders[j];
                                                            if (diff < 0) diff *= (-1);
                                                            T2 = diff / Math.Sqrt(makhraj);
                                                            if (diff / Math.Sqrt(makhraj) > quantile2)
                                                            {
                                                                dis[j] = true;
                                                                dis_conf++;
                                                                orders[j] = 0;
                                                            }
                                                        }
                                                    }
                                            }
                                            ////////////////////
                                            ins_count = II;
                                        }
                                        //////////////////////////////////////////Select The best///////////////////////////////////
                                        int remainder = Nconf - dis_conf;
                                        int[] rz = new int[Nconf];
                                        int kk = 0;
                                        for (int ii = 0; ii < rz.Length; ii++)
                                        {
                                            if (!dis[ii])
                                            {
                                                rz[Rha[ins_count, ii].conf] = kk + 1;
                                                kk++;
                                            }
                                        }
                                        double[] Pz = new double[remainder];
                                        double rands = RR.NextDouble();
                                        kk = 0;
                                        for (int ii = 0; ii < Nconf; ii++)
                                        {
                                            if (!dis[ii])
                                            {
                                                if (kk == 0)
                                                    Pz[kk] = Convert.ToDouble(remainder - orders[ii] + 1) / (remainder * (remainder + 1) / 2);
                                                else
                                                    Pz[kk] = Convert.ToDouble(remainder - orders[ii] + 1) / (remainder * (remainder + 1) / 2) + Pz[kk - 1];
                                                if (Pz[kk] > rands)
                                                {
                                                    best_cand = Rha[ins_count, ii].conf;
                                                    break;
                                                }
                                                kk++;
                                            }
                                        }
                                        ///////////////////////////////////////////////////////////////////////////////////////////


                                        Bused += Bj[IT];
                                        double lboundCW = 0;
                                        double uboundCW = 10;
                                        double l_lg = 0;
                                        double u_lg = 1;
                                        int Mue = 5 + IT + 1;
                                        double deltad_menfi_yekCW = (uboundCW - lboundCW) / 2;
                                        double deltad_menfi_yek_lg = (u_lg - l_lg) / 2;
                                        int symbol = 0;
                                        Bj[IT + 1] = (Bwhole - Bused) / (Niter - IT + 1);
                                        int Nconf_perv = Nconf;
                                        Nconf = Convert.ToInt32(Bj[IT + 1] / (Mue + Math.Min(5, IT + 1))) - remainder;// (Nconf-dis_conf) is equal the remainder of perv_conf
                                        if (Nconf < 1)
                                        {
                                            break;
                                        }
                                        double deltad_CW = deltad_menfi_yekCW * Math.Pow((1.0 / Nconf), ((double)IT) / Npar);
                                        double delta_lg = deltad_menfi_yek_lg * Math.Pow((1.0 / Nconf), ((double)IT) / Npar);
                                        float[,] PervConf = (float[,])Configuration.Clone();
                                        Configuration = new float[Nconf + remainder, Npar];
                                        ///////C1 , C2 , W, r_lg
                                        for (int jj = 0; jj < Nconf; jj++)
                                        {
                                            for (kk = 0; kk < Npar - 1; kk++)
                                            {
                                                symbol = RR.Next(0, 2);
                                                if (symbol == 0)
                                                    Configuration[jj, kk] = Convert.ToSingle(PervConf[best_cand, kk] + deltad_CW * RR.NextDouble());
                                                else
                                                    Configuration[jj, kk] = Convert.ToSingle(PervConf[best_cand, kk] - deltad_CW * RR.NextDouble());
                                            }
                                            symbol = RR.Next(0, 2);
                                            if (symbol == 0)
                                                Configuration[jj, Npar - 1] = Convert.ToSingle(PervConf[best_cand, Npar - 1] + delta_lg * RR.NextDouble());
                                            else
                                                Configuration[jj, Npar - 1] = Convert.ToSingle(PervConf[best_cand, Npar - 1] - delta_lg * RR.NextDouble());
                                        }
                                        int iii = Nconf;
                                        for (int jj = 0; jj < Nconf_perv; jj++)
                                        {
                                            if (!dis[jj])
                                            {
                                                for (kk = 0; kk < Npar; kk++)
                                                {
                                                    Configuration[iii, kk] = PervConf[jj, kk];
                                                }
                                                iii++;
                                            }
                                        }
                                        Nconf = Nconf + remainder;// the set of perv_conf+ curr_conf
                                        dis_conf = 0;
                                    }
                                    sw = new StreamWriter(ss);
                                    for (int ii = 0; ii < Npar; ii++)
                                    {
                                        sw.WriteLine(Configuration[best_cand, ii]);
                                    }
                                    sw.Close();
                                }
                            }
                            #endregion
                            #region F-RaceGA
                            else if (method == "FRGA")
                            {
                                double Mean = 0;
                                /////////////Initialization Process//////////////////////
                                int instance = dimen.Length;
                                int Nconf = 0;
                                int Npar = 2;
                                int Bwhole = Convert.ToInt32(Bud.Text);
                                int Bused = 0;
                                int Niter = Convert.ToInt32(Math.Floor(2 + Math.Log(Npar)));
                                int[] Bj = new int[Niter];
                                Bj[0] = Bwhole / Niter;
                                Nconf = Bj[0] / 5;
                                Random RR = new Random();
                                float[,] Configuration = new float[Nconf, Npar];
                                double[] Cost = new double[Nconf];
                                R[,] Rha = new R[instance, Nconf];
                                for (int jj = 0; jj < Nconf; jj++)
                                {
                                    Configuration[jj, 0] = Convert.ToSingle(RR.NextDouble());// mu_rate
                                    Configuration[jj, 1] = Convert.ToSingle(RR.NextDouble());// cross_rate
                                }
                                ///////////////////////////////////////////////////////
                                bool[] dis = new bool[Nconf]; // The ones have been discarded...
                                int dis_conf = 0;
                                int best_cand = -1;
                                int ins_count = 0;
                                ss = Directory.GetCurrentDirectory() + "\\FRGA.txt";
                                int min_index = 0;
                                if (!File.Exists(ss))
                                {
                                    for (int IT = 0; IT < Niter; IT++)
                                    {
                                        Rha = new R[instance, Nconf];
                                        dis = new bool[Nconf];
                                        double[] orders = new double[Nconf];
                                        for (int II = 0; II < instance && dis_conf <= Nconf - 1; II++)
                                        {
                                            N = Ns[II];
                                            P = Ps[II];
                                            for (int jjj = 0; jjj < Nconf; jjj++)
                                            {
                                                double mu_rate = Configuration[jjj, 0];
                                                double cr_rate = Configuration[jjj, 1];
                                                Mean = 0;
                                                for (int tt = 0; tt < Ntest; tt++)
                                                {
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
                                                    }
                                                    costs[tt] = Best_indi.F;
                                                    Mean += Best_indi.F;
                                                }

                                                Rha[II, jjj].Cost = Mean / Ntest;
                                                Rha[II, jjj].conf = jjj;
                                            }

                                            for (int hh = II; hh < II + 1; hh++)
                                            {
                                                for (int hh2 = 0; hh2 < Nconf - 1; hh2++)
                                                {
                                                    if (!dis[hh2])
                                                        for (int hh3 = hh2 + 1; hh3 < Nconf; hh3++)
                                                        {
                                                            if (!dis[hh3])
                                                                if (Rha[hh, hh2].Cost < Rha[hh, hh3].Cost)
                                                                {
                                                                    R temp = Rha[hh, hh2];
                                                                    Rha[hh, hh2] = Rha[hh, hh3];
                                                                    Rha[hh, hh3] = temp;
                                                                }
                                                        }
                                                }
                                            }
                                            for (int hh = II; hh < II + 1; hh++)
                                            {
                                                for (int ii = Nconf - 1; ii > 0; ii--)
                                                {
                                                    if (!dis[ii])
                                                    {
                                                        Rha[hh, ii].value++;
                                                        for (int jj = ii - 1; jj >= 0; jj--)
                                                        {
                                                            if (Rha[hh, ii].Cost == Rha[hh, jj].Cost)
                                                            {
                                                                Rha[hh, ii].value++;
                                                            }
                                                            else
                                                            {
                                                                ii = jj + 1;
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            if (Rha[II, 1].value <= 1 && !dis[0])
                                            {
                                                Rha[II, 0].value = 1;
                                            }
                                            int Nc = 0;
                                            for (int ii = 0; ii < Nconf; ii++)
                                            {
                                                if (!dis[ii])
                                                {

                                                    if (Rha[II, ii].value > 2)
                                                    {
                                                        int temp = Convert.ToInt32(Rha[II, ii].value);
                                                        int ind = 0;
                                                        for (int jj = ii - temp + 1; jj <= ii; jj++)
                                                        {
                                                            ind += jj + 1;
                                                        }
                                                        for (int jj = ii - temp + 1; jj <= ii; jj++)
                                                        {
                                                            Rha[II, jj].value = ind / temp;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Rha[II, ii].value = ii + 1 - Nc;
                                                    }
                                                }
                                                else
                                                    Nc++;

                                            }
                                            for (int jj = II; jj < II + 1; jj++)
                                                for (int ii = 0; ii < orders.Length; ii++)
                                                {
                                                    if (!dis[ii])
                                                    {
                                                        orders[Rha[jj, ii].conf] += Rha[II, ii].value;
                                                    }
                                                }
                                            ////////////////////T computation
                                            double T = 0;
                                            double sorat = 0;
                                            for (int hh2 = 0; hh2 < Nconf; hh2++)
                                            {
                                                if (!dis[hh2])
                                                {
                                                    sorat += Math.Pow(orders[hh2] - (((II + 1) * Nconf + 1) / 2), 2);
                                                }
                                            }
                                            sorat = sorat * (Nconf - 1);
                                            double makhraj = 0;
                                            for (int hh = 0; hh < II + 1; hh++)
                                            {
                                                for (int hh2 = 0; hh2 < Nconf; hh2++)
                                                {
                                                    if (!dis[hh2])
                                                    {
                                                        makhraj += Math.Pow(Rha[hh, hh2].conf, 2);
                                                    }
                                                }
                                            }

                                            makhraj = makhraj - ((II * Nconf * Math.Pow((Nconf + 1), 2)) / 4);
                                            T = sorat / makhraj;
                                            ////////////////
                                            double alpha2 = 0.05;
                                            double quantile1 = LH_Class.get_t_quantile(alpha2, II + 1, t_table); //getStudentT(alpha, rows);
                                            if (T <= quantile1)
                                            {

                                            }
                                            else
                                            {
                                                //calculating T2 (pair-wise test), when needed
                                                double T2, quantile2 = LH_Class.get_t_quantile(alpha2, II + 1, t_table, true);
                                                double best_score = -1;
                                                for (int j = 0; j < Nconf; j++)
                                                {

                                                    if (orders[j] > best_score || best_score == -1)
                                                    {
                                                        best_score = orders[j];
                                                        best_cand = j;
                                                    }
                                                }
                                                makhraj *= Math.Abs((2 * (II + 1)) * (1 - (T / ((II + 1) * (Nconf - 1)))));
                                                makhraj /= ((II + 1) * (Nconf - 1));
                                                for (int j = 0; j < Nconf; j++)
                                                    if (!dis[j])
                                                    {
                                                        if (j != best_cand)
                                                        {
                                                            double diff = orders[best_cand] - orders[j];
                                                            if (diff < 0) diff *= (-1);
                                                            T2 = diff / Math.Sqrt(makhraj);
                                                            if (diff / Math.Sqrt(makhraj) > quantile2)
                                                            {
                                                                dis[j] = true;
                                                                dis_conf++;
                                                                orders[j] = 0;
                                                            }
                                                        }
                                                    }
                                            }
                                            ////////////////////
                                            ins_count = II;
                                        }
                                        //////////////////////////////////////////Select The best///////////////////////////////////
                                        int remainder = Nconf - dis_conf;
                                        int[] rz = new int[Nconf];
                                        int kk = 0;
                                        for (int ii = 0; ii < rz.Length; ii++)
                                        {
                                            if (!dis[ii])
                                            {
                                                rz[Rha[ins_count, ii].conf] = kk + 1;
                                                kk++;
                                            }
                                        }
                                        double[] Pz = new double[remainder];
                                        double rands = RR.NextDouble();
                                        kk = 0;
                                        for (int ii = 0; ii < Nconf; ii++)
                                        {
                                            if (!dis[ii])
                                            {
                                                if (kk == 0)
                                                    Pz[kk] = Convert.ToDouble(remainder - orders[ii] + 1) / (remainder * (remainder + 1) / 2);
                                                else
                                                    Pz[kk] = Convert.ToDouble(remainder - orders[ii] + 1) / (remainder * (remainder + 1) / 2) + Pz[kk - 1];
                                                if (Pz[kk] > rands)
                                                {
                                                    best_cand = Rha[ins_count, ii].conf;
                                                    break;
                                                }
                                                kk++;
                                            }
                                        }
                                        ///////////////////////////////////////////////////////////////////////////////////////////


                                        Bused += Bj[IT];
                                        double lboundCW = 0;
                                        double uboundCW = 10;
                                        double l_lg = 0;
                                        double u_lg = 1;
                                        int Mue = 5 + IT + 1;
                                        double deltad_menfi_yekCW = (uboundCW - lboundCW) / 2;
                                        double deltad_menfi_yek_lg = (u_lg - l_lg) / 2;
                                        int symbol = 0;
                                        Bj[IT + 1] = (Bwhole - Bused) / (Niter - IT + 1);
                                        int Nconf_perv = Nconf;
                                        Nconf = Convert.ToInt32(Bj[IT + 1] / (Mue + Math.Min(5, IT + 1))) - remainder;// (Nconf-dis_conf) is equal the remainder of perv_conf
                                        if (Nconf < 1)
                                        {
                                            break;
                                        }
                                        double deltad_CW = deltad_menfi_yekCW * Math.Pow((1.0 / Nconf), ((double)IT) / Npar);
                                        double delta_lg = deltad_menfi_yek_lg * Math.Pow((1.0 / Nconf), ((double)IT) / Npar);
                                        float[,] PervConf = (float[,])Configuration.Clone();
                                        Configuration = new float[Nconf + remainder, Npar];
                                        ///////C1 , C2 , W, r_lg
                                        for (int jj = 0; jj < Nconf; jj++)
                                        {
                                            for (kk = 0; kk < Npar - 1; kk++)
                                            {
                                                symbol = RR.Next(0, 2);
                                                if (symbol == 0)
                                                    Configuration[jj, kk] = Convert.ToSingle(PervConf[best_cand, kk] + deltad_CW * RR.NextDouble());
                                                else
                                                    Configuration[jj, kk] = Convert.ToSingle(PervConf[best_cand, kk] - deltad_CW * RR.NextDouble());
                                            }
                                            symbol = RR.Next(0, 2);
                                            if (symbol == 0)
                                                Configuration[jj, Npar - 1] = Convert.ToSingle(PervConf[best_cand, Npar - 1] + delta_lg * RR.NextDouble());
                                            else
                                                Configuration[jj, Npar - 1] = Convert.ToSingle(PervConf[best_cand, Npar - 1] - delta_lg * RR.NextDouble());
                                        }
                                        int iii = Nconf;
                                        for (int jj = 0; jj < Nconf_perv; jj++)
                                        {
                                            if (!dis[jj])
                                            {
                                                for (kk = 0; kk < Npar; kk++)
                                                {
                                                    Configuration[iii, kk] = PervConf[jj, kk];
                                                }
                                                iii++;
                                            }
                                        }
                                        Nconf = Nconf + remainder;// the set of perv_conf+ curr_conf
                                        dis_conf = 0;
                                    }
                                    sw = new StreamWriter(ss);
                                    for (int ii = 0; ii < Npar; ii++)
                                    {
                                        sw.WriteLine(Configuration[best_cand, ii]);
                                    }
                                    sw.Close();
                                }
                            }
                            #endregion
                            #region F-RacePSO
                            else if (method == "FRPSO")
                            {
                                int budget = NPop * Iteration;
                                double Mean = 0;
                                /////////////Initialization Process//////////////////////
                                int instance = dimen.Length;
                                int Nconf = 0;
                                int Npar = 3;
                                int Bwhole = Convert.ToInt32(Bud.Text);
                                int Bused = 0;
                                int Niter = Convert.ToInt32(Math.Floor(2 + Math.Log(Npar)));
                                int[] Bj = new int[Niter];
                                Bj[0] = Bwhole / Niter;
                                Nconf = Bj[0] / 5;
                                Random RR = new Random();
                                float[,] Configuration = new float[Nconf, Npar];
                                double[] Cost = new double[Nconf];
                                R[,] Rha = new R[instance, Nconf];

                                for (int jj = 0; jj < Nconf; jj++)
                                {
                                    for (int kk = 0; kk < Npar - 1; kk++)
                                    {
                                        Configuration[jj, kk] = Convert.ToSingle(10 * RR.NextDouble());
                                    }
                                    for (int kk = Npar - 1; kk < Npar; kk++)
                                    {
                                        Configuration[jj, kk] = Convert.ToSingle(RR.NextDouble());
                                    }
                                }

                                ///////////////////////////////////////////////////////
                                bool[] dis = new bool[Nconf]; // The ones have been discarded...
                                int dis_conf = 0;
                                int best_cand = -1;
                                int ins_count = 0;
                                ss = Directory.GetCurrentDirectory() + "\\FRPSO.txt";
                                if (!File.Exists(ss))
                                {
                                    for (int IT = 0; IT < Niter; IT++)
                                    {
                                        Rha = new R[instance, Nconf];
                                        dis = new bool[Nconf];
                                        double[] orders = new double[Nconf];
                                        for (int II = 0; II < instance && dis_conf <= Nconf - 1; II++)
                                        {
                                            N = Ns[II];
                                            P = Ps[II];
                                            for (int jj = 0; jj < Nconf; jj++)
                                            {
                                                if (!dis[jj])
                                                {
                                                    double C1 = Configuration[jj, 0]; double C2 = Configuration[jj, 1]; double W = Configuration[jj, 2];
                                                    Mean = 0;

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
                                                            ////////////////////////////////////////////////////////////////////
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
                                                        }

                                                        costs[tt] = Best_nodes.f;
                                                        Mean += Best_nodes.f;
                                                    }
                                                    //Cost[jj] = Mean / Ntest;
                                                    Rha[II, jj].Cost = Mean / Ntest;
                                                    Rha[II, jj].conf = jj;
                                                }
                                            }

                                            for (int hh = II; hh < II + 1; hh++)
                                            {
                                                for (int hh2 = 0; hh2 < Nconf - 1; hh2++)
                                                {
                                                    if (!dis[hh2])
                                                        for (int hh3 = hh2 + 1; hh3 < Nconf; hh3++)
                                                        {
                                                            if (!dis[hh3])
                                                                if (Rha[hh, hh2].Cost < Rha[hh, hh3].Cost)
                                                                {
                                                                    R temp = Rha[hh, hh2];
                                                                    Rha[hh, hh2] = Rha[hh, hh3];
                                                                    Rha[hh, hh3] = temp;
                                                                }
                                                        }
                                                }
                                            }
                                            for (int hh = II; hh < II + 1; hh++)
                                            {
                                                for (int ii = Nconf - 1; ii > 0; ii--)
                                                {
                                                    if (!dis[ii])
                                                    {
                                                        Rha[hh, ii].value++;
                                                        for (int jj = ii - 1; jj >= 0; jj--)
                                                        {
                                                            if (Rha[hh, ii].Cost == Rha[hh, jj].Cost)
                                                            {
                                                                Rha[hh, ii].value++;
                                                            }
                                                            else
                                                            {
                                                                ii = jj + 1;
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            if (Rha[II, 1].value <= 1 && !dis[0])
                                            {
                                                Rha[II, 0].value = 1;
                                            }
                                            int Nc = 0;
                                            for (int ii = 0; ii < Nconf; ii++)
                                            {
                                                if (!dis[ii])
                                                {

                                                    if (Rha[II, ii].value > 2)
                                                    {
                                                        int temp = Convert.ToInt32(Rha[II, ii].value);
                                                        int ind = 0;
                                                        for (int jj = ii - temp + 1; jj <= ii; jj++)
                                                        {
                                                            ind += jj + 1;
                                                        }
                                                        for (int jj = ii - temp + 1; jj <= ii; jj++)
                                                        {
                                                            Rha[II, jj].value = ind / temp;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Rha[II, ii].value = ii + 1 - Nc;
                                                    }
                                                }
                                                else
                                                    Nc++;

                                            }
                                            for (int jj = II; jj < II + 1; jj++)
                                                for (int ii = 0; ii < orders.Length; ii++)
                                                {
                                                    if (!dis[ii])
                                                    {
                                                        orders[Rha[jj, ii].conf] += Rha[II, ii].value;
                                                    }
                                                }
                                            ////////////////////T computation
                                            double T = 0;
                                            double sorat = 0;
                                            for (int hh2 = 0; hh2 < Nconf; hh2++)
                                            {
                                                if (!dis[hh2])
                                                {
                                                    sorat += Math.Pow(orders[hh2] - (((II + 1) * Nconf + 1) / 2), 2);
                                                }
                                            }
                                            sorat = sorat * (Nconf - 1);
                                            double makhraj = 0;
                                            for (int hh = 0; hh < II + 1; hh++)
                                            {
                                                for (int hh2 = 0; hh2 < Nconf; hh2++)
                                                {
                                                    if (!dis[hh2])
                                                    {
                                                        makhraj += Math.Pow(Rha[hh, hh2].conf, 2);
                                                    }
                                                }
                                            }

                                            makhraj = makhraj - ((II * Nconf * Math.Pow((Nconf + 1), 2)) / 4);
                                            T = sorat / makhraj;
                                            ////////////////
                                            double alpha2 = 0.05;
                                            double quantile1 = LH_Class.get_t_quantile(alpha2, II + 1, t_table); //getStudentT(alpha, rows);
                                            if (T <= quantile1)
                                            {

                                            }
                                            else
                                            {
                                                //calculating T2 (pair-wise test), when needed
                                                double T2, quantile2 = LH_Class.get_t_quantile(alpha2, II + 1, t_table, true);
                                                double best_score = -1;
                                                for (int j = 0; j < Nconf; j++)
                                                {

                                                    if (orders[j] > best_score || best_score == -1)
                                                    {
                                                        best_score = orders[j];
                                                        best_cand = j;
                                                    }
                                                }
                                                makhraj *= Math.Abs((2 * (II + 1)) * (1 - (T / ((II + 1) * (Nconf - 1)))));
                                                makhraj /= ((II + 1) * (Nconf - 1));
                                                for (int j = 0; j < Nconf; j++)
                                                    if (!dis[j])
                                                    {
                                                        if (j != best_cand)
                                                        {
                                                            double diff = orders[best_cand] - orders[j];
                                                            if (diff < 0) diff *= (-1);
                                                            T2 = diff / Math.Sqrt(makhraj);
                                                            if (diff / Math.Sqrt(makhraj) > quantile2)
                                                            {
                                                                dis[j] = true;
                                                                dis_conf++;
                                                                orders[j] = 0;
                                                            }
                                                        }
                                                    }
                                            }
                                            ////////////////////
                                            ins_count = II;
                                        }
                                        //////////////////////////////////////////Select The best///////////////////////////////////
                                        int remainder = Nconf - dis_conf;
                                        int[] rz = new int[Nconf];
                                        int kk = 0;
                                        for (int ii = 0; ii < rz.Length; ii++)
                                        {
                                            if (!dis[ii])
                                            {
                                                rz[Rha[ins_count, ii].conf] = kk + 1;
                                                kk++;
                                            }
                                        }
                                        double[] Pz = new double[remainder];
                                        double rands = RR.NextDouble();
                                        kk = 0;
                                        for (int ii = 0; ii < Nconf; ii++)
                                        {
                                            if (!dis[ii])
                                            {
                                                if (kk == 0)
                                                    Pz[kk] = Convert.ToDouble(remainder - orders[ii] + 1) / (remainder * (remainder + 1) / 2);
                                                else
                                                    Pz[kk] = Convert.ToDouble(remainder - orders[ii] + 1) / (remainder * (remainder + 1) / 2) + Pz[kk - 1];
                                                if (Pz[kk] > rands)
                                                {
                                                    best_cand = Rha[ins_count, ii].conf;
                                                    break;
                                                }
                                                kk++;
                                            }
                                        }
                                        ///////////////////////////////////////////////////////////////////////////////////////////


                                        Bused += Bj[IT];
                                        double lboundCW = 0;
                                        double uboundCW = 10;
                                        double l_lg = 0;
                                        double u_lg = 1;
                                        int Mue = 5 + IT + 1;
                                        double deltad_menfi_yekCW = (uboundCW - lboundCW) / 2;
                                        double deltad_menfi_yek_lg = (u_lg - l_lg) / 2;
                                        int symbol = 0;
                                        Bj[IT + 1] = (Bwhole - Bused) / (Niter - IT + 1);
                                        int Nconf_perv = Nconf;
                                        Nconf = Convert.ToInt32(Bj[IT + 1] / (Mue + Math.Min(5, IT + 1))) - remainder;// (Nconf-dis_conf) is equal the remainder of perv_conf
                                        if (Nconf < 1)
                                        {
                                            break;
                                        }
                                        double deltad_CW = deltad_menfi_yekCW * Math.Pow((1.0 / Nconf), ((double)IT) / Npar);
                                        double delta_lg = deltad_menfi_yek_lg * Math.Pow((1.0 / Nconf), ((double)IT) / Npar);
                                        float[,] PervConf = (float[,])Configuration.Clone();
                                        Configuration = new float[Nconf + remainder, Npar];
                                        ///////C1 , C2 , W, r_lg
                                        for (int jj = 0; jj < Nconf; jj++)
                                        {
                                            for (kk = 0; kk < Npar - 1; kk++)
                                            {
                                                symbol = RR.Next(0, 2);
                                                if (symbol == 0)
                                                    Configuration[jj, kk] = Convert.ToSingle(PervConf[best_cand, kk] + deltad_CW * RR.NextDouble());
                                                else
                                                    Configuration[jj, kk] = Convert.ToSingle(PervConf[best_cand, kk] - deltad_CW * RR.NextDouble());
                                            }
                                            symbol = RR.Next(0, 2);
                                            if (symbol == 0)
                                                Configuration[jj, Npar - 1] = Convert.ToSingle(PervConf[best_cand, Npar - 1] + delta_lg * RR.NextDouble());
                                            else
                                                Configuration[jj, Npar - 1] = Convert.ToSingle(PervConf[best_cand, Npar - 1] - delta_lg * RR.NextDouble());
                                        }
                                        int iii = Nconf;
                                        for (int jj = 0; jj < Nconf_perv; jj++)
                                        {
                                            if (!dis[jj])
                                            {
                                                for (kk = 0; kk < Npar; kk++)
                                                {
                                                    Configuration[iii, kk] = PervConf[jj, kk];
                                                }
                                                iii++;
                                            }
                                        }
                                        Nconf = Nconf + remainder;// the set of perv_conf+ curr_conf
                                        dis_conf = 0;
                                    }
                                    sw = new StreamWriter(ss);
                                    for (int ii = 0; ii < Npar; ii++)
                                    {
                                        sw.WriteLine(Configuration[best_cand, ii]);
                                    }
                                    sw.Close();
                                }
                            }
                            #endregion
                            #region F-RaceJADE
                            else if (method == "FRJADE")
                            {
                                double[] Cr_A = new double[NPop];
                                double[] F_A = new double[NPop];
                                double Cr = 0.5;
                                double F = 0.5;
                                double Mean = 0;
                                /////////////Initialization Process//////////////////////
                                int instance = dimen.Length;
                                int Nconf = 0;
                                int Npar = 2;
                                int Bwhole = Convert.ToInt32(Bud.Text);
                                int Bused = 0;
                                int Niter = Convert.ToInt32(Math.Floor(2 + Math.Log(Npar)));
                                int[] Bj = new int[Niter];
                                Bj[0] = Bwhole / Niter;
                                Nconf = Bj[0] / 5;
                                Random RR = new Random();
                                float[,] Configuration = new float[Nconf, Npar];
                                double[] Cost = new double[Nconf];
                                R[,] Rha = new R[instance, Nconf];
                                for (int jj = 0; jj < Nconf; jj++)
                                {
                                    for (int kk = 0; kk < Npar; kk++)
                                    {
                                        Configuration[jj, kk] = Convert.ToSingle(RR.NextDouble());
                                    }
                                }
                                ///////////////////////////////////////////////////////
                                bool[] dis = new bool[Nconf]; // The ones have been discarded...
                                int dis_conf = 0;
                                int best_cand = -1;
                                int ins_count = 0;
                                ss = Directory.GetCurrentDirectory() + "\\FRJADE.txt";
                                if (!File.Exists(ss))
                                {
                                    for (int IT = 0; IT < Niter; IT++)
                                    {
                                        Rha = new R[instance, Nconf];
                                        dis = new bool[Nconf];
                                        double[] orders = new double[Nconf];
                                        for (int II = 0; II < instance && dis_conf <= Nconf - 1; II++)
                                        {
                                            N = Ns[II];
                                            P = Ps[II];
                                            for (int jjj = 0; jjj < Nconf; jjj++)
                                            {
                                                if (!dis[jjj])
                                                {
                                                    Mean = 0;
                                                    double c = Configuration[jjj, 0]; double p = Configuration[jjj, 1];
                                                    int p_group = Convert.ToInt32(100 * p % NPop);
                                                    for (int tt = 0; tt < Ntest; tt++)
                                                    {
                                                        Cr_A = new double[NPop];
                                                        F_A = new double[NPop];
                                                        Cr = 0.5;
                                                        F = 0.5;
                                                        MOA_Node[] Pop = new MOA_Node[NPop];
                                                        MOA_Node[] V = new MOA_Node[NPop];
                                                        MOA_Node[] U = new MOA_Node[NPop];
                                                        MOA_Node[] Best = new MOA_Node[NPop];
                                                        ArrayList SF = new ArrayList();
                                                        ArrayList Scr = new ArrayList();
                                                        ArrayList A_x = new ArrayList();
                                                        ArrayList A_y = new ArrayList();
                                                        ArrayList A_f = new ArrayList();
                                                        MOA_Node Best_nodes = new MOA_Node();
                                                        double[] distances = new double[NPop];
                                                        Best_nodes.f = 1E250;
                                                        for (int ii = 0; ii < NPop; ii++)
                                                        {
                                                            Pop[ii].x = LH_Class.node_constructing(N, P, rr);
                                                            Pop[ii].LH = LH_Class.convert_search_s_to_solution_s(Pop[ii].x, N, P);
                                                            Pop[ii].f = LH_Class.F(Pop[ii].LH, N, P);
                                                            A_x.Add(Pop[ii].x.Clone());
                                                            A_f.Add(Pop[ii].f);
                                                            /////////init V
                                                            V[ii].x = new double[N, P];
                                                            U[ii].x = new double[N, P];
                                                        }
                                                        ///////////////////////////////////////////////////////////////////////////////////////
                                                        for (int it = 0; it < Iteration; it++)
                                                        {
                                                            SF = new ArrayList();
                                                            Scr = new ArrayList();
                                                            Best = LH_Class.mergesort(Pop, NPop);
                                                            for (int ii = 0; ii < NPop; ii++)
                                                            {
                                                                F_A[ii] = LH_Class.Cauchy(rr, F, 0.1);
                                                                Cr_A[ii] = LH_Class.Normal_Distribution(rr, Cr, 0.1);
                                                                int best_index = rr.Next(p_group);
                                                                MOA_Node X_best = Best[best_index];
                                                                int index_r1 = rr.Next(NPop);
                                                                if (X_best.f == Pop[index_r1].f)
                                                                {
                                                                    while (LH_Class.similarity(X_best.x, Pop[index_r1].x, N, P))
                                                                        index_r1 = rr.Next(NPop);
                                                                }
                                                                int index_r2 = rr.Next(A_f.Count);
                                                                double Fit_A = Convert.ToDouble(A_f[index_r2]);
                                                                if (X_best.f == Fit_A || Fit_A == Pop[index_r1].f)
                                                                {
                                                                    double[,] X = (double[,])A_x[index_r2];
                                                                    while (LH_Class.similarity(X_best.x, X, N, P))
                                                                    {
                                                                        index_r2 = rr.Next(NPop);
                                                                        X = (double[,])A_x[index_r2];
                                                                    }
                                                                }
                                                                int J_rand = rr.Next(P);
                                                                for (int jj = 0; jj < N; jj++)
                                                                    for (int kk = 0; kk < P; kk++)
                                                                    {
                                                                        double[,] x = (double[,])A_x[index_r2];
                                                                        V[ii].x[jj, kk] = Pop[ii].x[jj, kk] + F_A[ii] * (X_best.x[jj, kk] - Pop[ii].x[jj, kk]) + F_A[ii] * (Pop[index_r1].x[jj, kk] - x[jj, kk]);
                                                                        if ((jj == J_rand) || (rr.NextDouble() < Cr_A[ii]))
                                                                        {
                                                                            U[ii].x[jj, kk] = V[ii].x[jj, kk];
                                                                        }
                                                                        else
                                                                        {
                                                                            U[ii].x[jj, kk] = Pop[ii].x[jj, kk];
                                                                        }
                                                                    }
                                                                U[ii].x = Node_treatment(U[ii].x, N, P, rr);
                                                                U[ii].LH = LH_Class.convert_search_s_to_solution_s(U[ii].x, N, P);
                                                                U[ii].f = LH_Class.F(U[ii].LH, N, P);
                                                                if (U[ii].f <= Pop[ii].f)
                                                                {
                                                                    int rand = rr.Next(NPop);
                                                                    A_x.Add((double[,])Pop[ii].x.Clone());
                                                                    A_f.Add(Pop[ii].f);
                                                                    Pop[ii].x = (double[,])U[ii].x.Clone();
                                                                    Pop[ii].LH = (int[,])U[ii].LH.Clone();
                                                                    Pop[ii].f = U[ii].f;
                                                                    SF.Add(F_A[ii]);
                                                                    Scr.Add(Cr_A[ii]);
                                                                }
                                                                if (Best_nodes.f > Pop[ii].f)
                                                                {
                                                                    Best_nodes.f = Pop[ii].f;
                                                                    Best_nodes.x = (double[,])Pop[ii].x.Clone();
                                                                    Best_nodes.LH = (int[,])Pop[ii].LH.Clone();

                                                                }
                                                            }

                                                            int Overhead = A_x.Count - NPop;
                                                            for (int ii = 0; ii < Overhead; ii++)
                                                            {
                                                                int rand = rr.Next(A_x.Count);
                                                                A_x.RemoveAt(rand);
                                                                A_f.RemoveAt(rand);
                                                            }

                                                            if (Scr.Count > 0)
                                                                Cr = (1 - c) * Cr + c * LH_Class.mean_simple(Scr);
                                                            if (SF.Count > 0)
                                                                F = (1 - c) * F + c * LH_Class.mean_Lehmer(SF);
                                                        }

                                                        costs[tt] = Best_nodes.f;
                                                        Mean += Best_nodes.f;
                                                    }
                                                    Rha[II, jjj].Cost = Mean / Ntest;
                                                    Rha[II, jjj].conf = jjj;
                                                }
                                            }
                                            for (int hh = II; hh < II + 1; hh++)
                                            {
                                                for (int hh2 = 0; hh2 < Nconf - 1; hh2++)
                                                {
                                                    if (!dis[hh2])
                                                        for (int hh3 = hh2 + 1; hh3 < Nconf; hh3++)
                                                        {
                                                            if (!dis[hh3])
                                                                if (Rha[hh, hh2].Cost < Rha[hh, hh3].Cost)
                                                                {
                                                                    R temp = Rha[hh, hh2];
                                                                    Rha[hh, hh2] = Rha[hh, hh3];
                                                                    Rha[hh, hh3] = temp;
                                                                }
                                                        }
                                                }
                                            }
                                            for (int hh = II; hh < II + 1; hh++)
                                            {
                                                for (int ii = Nconf - 1; ii > 0; ii--)
                                                {
                                                    if (!dis[ii])
                                                    {
                                                        Rha[hh, ii].value++;
                                                        for (int jj = ii - 1; jj >= 0; jj--)
                                                        {
                                                            if (Rha[hh, ii].Cost == Rha[hh, jj].Cost)
                                                            {
                                                                Rha[hh, ii].value++;
                                                            }
                                                            else
                                                            {
                                                                ii = jj + 1;
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            if (Rha[II, 1].value <= 1 && !dis[0])
                                            {
                                                Rha[II, 0].value = 1;
                                            }
                                            int Nc = 0;
                                            for (int ii = 0; ii < Nconf; ii++)
                                            {
                                                if (!dis[ii])
                                                {

                                                    if (Rha[II, ii].value > 2)
                                                    {
                                                        int temp = Convert.ToInt32(Rha[II, ii].value);
                                                        int ind = 0;
                                                        for (int jj = ii - temp + 1; jj <= ii; jj++)
                                                        {
                                                            ind += jj + 1;
                                                        }
                                                        for (int jj = ii - temp + 1; jj <= ii; jj++)
                                                        {
                                                            Rha[II, jj].value = ind / temp;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Rha[II, ii].value = ii + 1 - Nc;
                                                    }
                                                }
                                                else
                                                    Nc++;

                                            }
                                            for (int jj = II; jj < II + 1; jj++)
                                                for (int ii = 0; ii < orders.Length; ii++)
                                                {
                                                    if (!dis[ii])
                                                    {
                                                        orders[Rha[jj, ii].conf] += Rha[II, ii].value;
                                                    }
                                                }
                                            ////////////////////T computation
                                            double T = 0;
                                            double sorat = 0;
                                            for (int hh2 = 0; hh2 < Nconf; hh2++)
                                            {
                                                if (!dis[hh2])
                                                {
                                                    sorat += Math.Pow(orders[hh2] - (((II + 1) * Nconf + 1) / 2), 2);
                                                }
                                            }
                                            sorat = sorat * (Nconf - 1);
                                            double makhraj = 0;
                                            for (int hh = 0; hh < II + 1; hh++)
                                            {
                                                for (int hh2 = 0; hh2 < Nconf; hh2++)
                                                {
                                                    if (!dis[hh2])
                                                    {
                                                        makhraj += Math.Pow(Rha[hh, hh2].conf, 2);
                                                    }
                                                }
                                            }

                                            makhraj = makhraj - ((II * Nconf * Math.Pow((Nconf + 1), 2)) / 4);
                                            T = sorat / makhraj;
                                            ////////////////
                                            double alpha2 = 0.05;
                                            double quantile1 = LH_Class.get_t_quantile(alpha2, II + 1, t_table); //getStudentT(alpha, rows);
                                            if (T <= quantile1)
                                            {

                                            }
                                            else
                                            {
                                                //calculating T2 (pair-wise test), when needed
                                                double T2, quantile2 = LH_Class.get_t_quantile(alpha2, II + 1, t_table, true);
                                                double best_score = -1;
                                                for (int j = 0; j < Nconf; j++)
                                                {

                                                    if (orders[j] > best_score || best_score == -1)
                                                    {
                                                        best_score = orders[j];
                                                        best_cand = j;
                                                    }
                                                }
                                                makhraj *= Math.Abs((2 * (II + 1)) * (1 - (T / ((II + 1) * (Nconf - 1)))));
                                                makhraj /= ((II + 1) * (Nconf - 1));
                                                for (int j = 0; j < Nconf; j++)
                                                    if (!dis[j])
                                                    {
                                                        if (j != best_cand)
                                                        {
                                                            double diff = orders[best_cand] - orders[j];
                                                            if (diff < 0) diff *= (-1);
                                                            T2 = diff / Math.Sqrt(makhraj);
                                                            if (diff / Math.Sqrt(makhraj) > quantile2)
                                                            {
                                                                dis[j] = true;
                                                                dis_conf++;
                                                                orders[j] = 0;
                                                            }
                                                        }
                                                    }
                                            }
                                            ////////////////////
                                            ins_count = II;
                                        }
                                        //////////////////////////////////////////Select The best///////////////////////////////////
                                        int remainder = Nconf - dis_conf;
                                        int[] rz = new int[Nconf];
                                        int kk2 = 0;
                                        for (int ii = 0; ii < rz.Length; ii++)
                                        {
                                            if (!dis[ii])
                                            {
                                                rz[Rha[ins_count, ii].conf] = kk2 + 1;
                                                kk2++;
                                            }
                                        }
                                        double[] Pz = new double[remainder];
                                        double rands = RR.NextDouble();
                                        kk2 = 0;
                                        for (int ii = 0; ii < Nconf; ii++)
                                        {
                                            if (!dis[ii])
                                            {
                                                if (kk2 == 0)
                                                    Pz[kk2] = Convert.ToDouble(remainder - orders[ii] + 1) / (remainder * (remainder + 1) / 2);
                                                else
                                                    Pz[kk2] = Convert.ToDouble(remainder - orders[ii] + 1) / (remainder * (remainder + 1) / 2) + Pz[kk2 - 1];
                                                if (Pz[kk2] > rands)
                                                {
                                                    best_cand = Rha[ins_count, ii].conf;
                                                    break;
                                                }
                                                kk2++;
                                            }
                                        }
                                        ///////////////////////////////////////////////////////////////////////////////////////////


                                        Bused += Bj[IT];
                                        double lboundCW = 0;
                                        double uboundCW = 10;
                                        double l_lg = 0;
                                        double u_lg = 1;
                                        int Mue = 5 + IT + 1;
                                        double deltad_menfi_yekCW = (uboundCW - lboundCW) / 2;
                                        double deltad_menfi_yek_lg = (u_lg - l_lg) / 2;
                                        int symbol = 0;
                                        Bj[IT + 1] = (Bwhole - Bused) / (Niter - IT + 1);
                                        int Nconf_perv = Nconf;
                                        Nconf = Convert.ToInt32(Bj[IT + 1] / (Mue + Math.Min(5, IT + 1))) - remainder;// (Nconf-dis_conf) is equal the remainder of perv_conf
                                        if (Nconf < 1)
                                        {
                                            break;
                                        }
                                        double deltad_CW = deltad_menfi_yekCW * Math.Pow((1.0 / Nconf), ((double)IT) / Npar);
                                        double delta_lg = deltad_menfi_yek_lg * Math.Pow((1.0 / Nconf), ((double)IT) / Npar);
                                        float[,] PervConf = (float[,])Configuration.Clone();
                                        Configuration = new float[Nconf + remainder, Npar];
                                        ///////C1 , C2 , W, r_lg
                                        for (int jj = 0; jj < Nconf; jj++)
                                        {
                                            for (kk2 = 0; kk2 < Npar - 1; kk2++)
                                            {
                                                symbol = RR.Next(0, 2);
                                                if (symbol == 0)
                                                    Configuration[jj, kk2] = Convert.ToSingle(PervConf[best_cand, kk2] + deltad_CW * RR.NextDouble());
                                                else
                                                    Configuration[jj, kk2] = Convert.ToSingle(PervConf[best_cand, kk2] - deltad_CW * RR.NextDouble());
                                            }
                                            symbol = RR.Next(0, 2);
                                            if (symbol == 0)
                                                Configuration[jj, Npar - 1] = Convert.ToSingle(PervConf[best_cand, Npar - 1] + delta_lg * RR.NextDouble());
                                            else
                                                Configuration[jj, Npar - 1] = Convert.ToSingle(PervConf[best_cand, Npar - 1] - delta_lg * RR.NextDouble());
                                        }
                                        int iii = Nconf;
                                        for (int jj = 0; jj < Nconf_perv; jj++)
                                        {
                                            if (!dis[jj])
                                            {
                                                for (kk2 = 0; kk2 < Npar; kk2++)
                                                {
                                                    Configuration[iii, kk2] = PervConf[jj, kk2];
                                                }
                                                iii++;
                                            }
                                        }
                                        Nconf = Nconf + remainder;// the set of perv_conf+ curr_conf
                                        dis_conf = 0;
                                    }
                                    sw = new StreamWriter(ss);
                                    for (int ii = 0; ii < Npar; ii++)
                                    {
                                        sw.WriteLine(Configuration[best_cand, ii]);
                                    }
                                    sw.Close();
                                }
                            }
                            #endregion
                            #region F-RaceCCPSO2
                            else if (method == "FRCCPSO2")
                            {
                                int[] S = { 10, 20, 30, 50, 100 };
                                double Mean = 0;
                                /////////////Initialization Process//////////////////////
                                int instance = dimen.Length;
                                int Nconf = 0;
                                int Npar = 1;
                                int Bwhole = Convert.ToInt32(Bud.Text);
                                int Bused = 0;
                                int Niter = Convert.ToInt32(Math.Floor(2 + Math.Log(Npar)));
                                int[] Bj = new int[Niter];
                                Bj[0] = Bwhole / Niter;
                                Nconf = Bj[0] / 5;
                                Random RR = new Random();
                                float[,] Configuration = new float[Nconf, Npar];
                                double[] Cost = new double[Nconf];
                                R[,] Rha = new R[instance, Nconf];

                                for (int jj = 0; jj < Nconf; jj++)
                                {
                                    for (int kk = 0; kk < Npar - 1; kk++)
                                    {
                                        Configuration[jj, kk] = Convert.ToSingle(10 * RR.NextDouble());
                                    }
                                    for (int kk = Npar - 1; kk < Npar; kk++)
                                    {
                                        Configuration[jj, kk] = Convert.ToSingle(RR.NextDouble());
                                    }
                                }
                                ///////////////////////////////////////////////////////
                                bool[] dis = new bool[Nconf]; // The ones have been discarded...
                                int dis_conf = 0;
                                int best_cand = -1;
                                int ins_count = 0;
                                ss = Directory.GetCurrentDirectory() + "\\FRCCPSO2.txt";
                                if (!File.Exists(ss))
                                {
                                    for (int IT = 0; IT < Niter; IT++)
                                    {
                                        Rha = new R[instance, Nconf];
                                        dis = new bool[Nconf];
                                        double[] orders = new double[Nconf];
                                        for (int II = 0; II < instance && dis_conf <= Nconf - 1; II++)
                                        {
                                            N = Ns[II];
                                            P = Ps[II];
                                            for (int ii = 0; ii < S.Length; ii++)
                                                S[ii] = Convert.ToInt32(Math.Ceiling((Convert.ToDouble(S[ii]) / 100) * P));
                                            MOA_Node[] Pop = new MOA_Node[NPop];
                                            int[] Indexes = new int[P];
                                            for (int jjj = 0; jjj < Nconf; jjj++)
                                            {
                                                if (!dis[jjj])
                                                {
                                                    Mean = 0;
                                                    double p = Configuration[jjj, 0];// it has a chance to be a choice as a parameter
                                                    for (int tt = 0; tt < Ntest; tt++)
                                                    {
                                                        int ind = rr.Next(S.Length);
                                                        int s = S[ind];
                                                        int K = P / s;
                                                        Swarms[] SWs = new Swarms[K];
                                                        Swarms[] LocalBest = new Swarms[K];
                                                        Swarms[] PersonalBest = new Swarms[K];
                                                        MOA_Node[] PersonBest = new MOA_Node[NPop];
                                                        MOA_Node Ybest = new MOA_Node();
                                                        Ybest.f = 1E290;
                                                        Swarms[] PYbest = new Swarms[K];
                                                        for (int ii = 0; ii < NPop; ii++)
                                                        {
                                                            Pop[ii].x = LH_Class.node_constructing(N, P, rr);
                                                            PersonBest[ii].x = (double[,])Pop[ii].x.Clone();
                                                            Pop[ii].LH = LH_Class.convert_search_s_to_solution_s(Pop[ii].x, N, P);
                                                            Pop[ii].f = LH_Class.F(Pop[ii].LH, N, P);
                                                            if (Ybest.f > Pop[ii].f)
                                                            {
                                                                Ybest.x = (double[,])Pop[ii].x.Clone();
                                                                Ybest.LH = (int[,])Pop[ii].LH.Clone();
                                                                Ybest.f = Pop[ii].f;
                                                            }
                                                            PersonBest[ii].f = Pop[ii].f;
                                                        }
                                                        double p_yfirst = Ybest.f;
                                                        for (int it = 0; it < NPop * Iteration;)
                                                        {
                                                            if (p_yfirst <= Ybest.f && it != 0)
                                                            {
                                                                ind = rr.Next(S.Length);
                                                                s = S[ind];
                                                                K = P / s;
                                                                SWs = new Swarms[K];
                                                                LocalBest = new Swarms[K];
                                                                PersonalBest = new Swarms[K];
                                                                PYbest = new Swarms[K];
                                                            }
                                                            p_yfirst = Ybest.f;
                                                            Indexes = LH_Class.sq_rand_gen2(P, P, rr);
                                                            int ll = 0;
                                                            for (int kk = 0; kk < K; kk++)
                                                            {
                                                                SWs[kk].particles = new MOA_Node[NPop];
                                                                LocalBest[kk].particles = new MOA_Node[NPop];
                                                                PersonalBest[kk].particles = new MOA_Node[NPop];
                                                                PYbest[kk].particles = new MOA_Node[1];
                                                                for (int jj = 0; jj < NPop; jj++)
                                                                {
                                                                    SWs[kk].particles[jj].x = new double[N, P];
                                                                    LocalBest[kk].particles[jj].x = new double[N, P];
                                                                    PersonalBest[kk].particles[jj].x = new double[N, P];
                                                                    PYbest[kk].particles[0].x = new double[N, P];
                                                                    for (int kkk = 0; kkk < s; kkk++)
                                                                    {
                                                                        for (int ii = 0; ii < N; ii++)
                                                                        {
                                                                            SWs[kk].particles[jj].x[ii, kkk] = Pop[jj].x[ii, Indexes[kk * s + kkk]];
                                                                            PersonalBest[kk].particles[jj].x[ii, kkk] = PersonBest[jj].x[ii, Indexes[kk * s + kkk]];
                                                                        }
                                                                    }
                                                                }

                                                                for (int ii = 0; ii < s; ii++)
                                                                {
                                                                    for (int jj = 0; jj < N; jj++)
                                                                        PYbest[kk].particles[0].x[jj, ii] = Ybest.x[jj, ll];
                                                                    ll++;
                                                                }
                                                                PYbest[kk].particles[0].LH = LH_Class.convert_search_s_to_solution_s(PYbest[kk].particles[0].x, N, P);
                                                                PYbest[kk].particles[0].f = LH_Class.F(PYbest[kk].particles[0].LH, N, P);
                                                            }
                                                            for (int sss = 0; sss < K; sss++)
                                                            {
                                                                for (int jj = 0; jj < NPop; jj++)
                                                                {
                                                                    double[,] constructing = LH_Class.Concatenation(Ybest.x, sss * s, N, s, SWs[sss].particles[jj].x);
                                                                    double[,] personal_best = LH_Class.Concatenation(Ybest.x, sss * s, N, s, PersonalBest[sss].particles[jj].x);
                                                                    double[,] y_best = LH_Class.Concatenation(Ybest.x, sss * s, N, s, PYbest[sss].particles[0].x);
                                                                    int[,] subs_constructing = LH_Class.convert_search_s_to_solution_s(constructing, N, P);
                                                                    SWs[sss].particles[jj].f = LH_Class.F(subs_constructing, N, P);
                                                                    int[,] subs_personal_best = LH_Class.convert_search_s_to_solution_s(personal_best, N, P);
                                                                    PersonalBest[sss].particles[jj].f = LH_Class.F(subs_personal_best, N, P);
                                                                    if (PersonalBest[sss].particles[jj].f > SWs[sss].particles[jj].f)
                                                                    {
                                                                        PersonalBest[sss].particles[jj].f = SWs[sss].particles[jj].f;
                                                                        PersonalBest[sss].particles[jj].x = (double[,])SWs[sss].particles[jj].x.Clone();
                                                                    }
                                                                    int[,] subs_y_best = LH_Class.convert_search_s_to_solution_s(y_best, N, P);
                                                                    PYbest[sss].particles[0].f = LH_Class.F(subs_y_best, N, P);
                                                                    if (PersonalBest[sss].particles[jj].f < PYbest[sss].particles[0].f)
                                                                    {
                                                                        PYbest[sss].particles[0].f = PersonalBest[sss].particles[jj].f;
                                                                        PYbest[sss].particles[0].x = (double[,])PersonalBest[sss].particles[jj].x.Clone();
                                                                    }
                                                                    it = it + 3;
                                                                }
                                                                /////////////////////////////////////////////////
                                                                for (int jj = 0; jj < NPop; jj++)
                                                                {
                                                                    int[] Nei = LH_Class.Ring_withmyself(jj, NPop);
                                                                    double min = 1E250;
                                                                    for (int ii = 0; ii < Nei.Length; ii++)
                                                                    {
                                                                        if (PersonalBest[sss].particles[Nei[ii]].f < min)
                                                                        {
                                                                            LocalBest[sss].particles[jj].f = PersonalBest[sss].particles[Nei[ii]].f;
                                                                            LocalBest[sss].particles[jj].x = (double[,])PersonalBest[sss].particles[Nei[ii]].x.Clone();
                                                                            min = PersonalBest[sss].particles[Nei[ii]].f;
                                                                        }
                                                                    }
                                                                }
                                                                if (PYbest[sss].particles[0].f < Ybest.f)
                                                                {
                                                                    Ybest.f = PYbest[sss].particles[0].f;
                                                                    int mm = 0;
                                                                    for (int ii = sss * s; ii < sss * s + s; ii++)
                                                                    {
                                                                        for (int nn = 0; nn < N; nn++)
                                                                            Ybest.x[nn, ii] = PYbest[sss].particles[0].x[nn, mm];
                                                                        mm++;
                                                                    }
                                                                }
                                                            }
                                                            for (int sss = 0; sss < K; sss++)
                                                            {
                                                                for (int jj = 0; jj < NPop; jj++)
                                                                {
                                                                    for (int nn = 0; nn < N; nn++)
                                                                        for (int kk = 0; kk < s; kk++)
                                                                        {
                                                                            if (RR.NextDouble() <= p)
                                                                                SWs[sss].particles[jj].x[nn, kk] = PersonalBest[sss].particles[jj].x[nn, kk] + LH_Class.Cauchy_mu(RR) * (PersonalBest[sss].particles[jj].x[nn, kk] - LocalBest[sss].particles[jj].x[nn, kk]);
                                                                            else
                                                                                SWs[sss].particles[jj].x[nn, kk] = LocalBest[sss].particles[jj].x[nn, kk] + LH_Class.Normal_Distribution(RR, 0, 1) * (PersonalBest[sss].particles[jj].x[nn, kk] - LocalBest[sss].particles[jj].x[nn, kk]);
                                                                            Pop[jj].x[nn, sss * s + kk] = SWs[sss].particles[jj].x[nn, kk];
                                                                            PersonBest[jj].x[nn, sss * s + kk] = PersonalBest[sss].particles[jj].x[nn, kk];
                                                                        }
                                                                }
                                                            }
                                                            for (int jj = 0; jj < NPop; jj++)
                                                            {
                                                                Node_treatment(Pop[jj].x, N, P, RR);
                                                            }

                                                        }
                                                        costs[tt] = Ybest.f;
                                                        Mean += costs[tt];
                                                    }
                                                    Rha[II, jjj].Cost = Mean / Ntest;
                                                    Rha[II, jjj].conf = jjj;
                                                }
                                            }
                                            for (int hh = II; hh < II + 1; hh++)
                                            {
                                                for (int hh2 = 0; hh2 < Nconf - 1; hh2++)
                                                {
                                                    if (!dis[hh2])
                                                        for (int hh3 = hh2 + 1; hh3 < Nconf; hh3++)
                                                        {
                                                            if (!dis[hh3])
                                                                if (Rha[hh, hh2].Cost < Rha[hh, hh3].Cost)
                                                                {
                                                                    R temp = Rha[hh, hh2];
                                                                    Rha[hh, hh2] = Rha[hh, hh3];
                                                                    Rha[hh, hh3] = temp;
                                                                }
                                                        }
                                                }
                                            }
                                            for (int hh = II; hh < II + 1; hh++)
                                            {
                                                for (int ii = Nconf - 1; ii > 0; ii--)
                                                {
                                                    if (!dis[ii])
                                                    {
                                                        Rha[hh, ii].value++;
                                                        for (int jj = ii - 1; jj >= 0; jj--)
                                                        {
                                                            if (Rha[hh, ii].Cost == Rha[hh, jj].Cost)
                                                            {
                                                                Rha[hh, ii].value++;
                                                            }
                                                            else
                                                            {
                                                                ii = jj + 1;
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            if (Rha[II, 1].value <= 1 && !dis[0])
                                            {
                                                Rha[II, 0].value = 1;
                                            }
                                            int Nc = 0;
                                            for (int ii = 0; ii < Nconf; ii++)
                                            {
                                                if (!dis[ii])
                                                {

                                                    if (Rha[II, ii].value > 2)
                                                    {
                                                        int temp = Convert.ToInt32(Rha[II, ii].value);
                                                        int ind = 0;
                                                        for (int jj = ii - temp + 1; jj <= ii; jj++)
                                                        {
                                                            ind += jj + 1;
                                                        }
                                                        for (int jj = ii - temp + 1; jj <= ii; jj++)
                                                        {
                                                            Rha[II, jj].value = ind / temp;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Rha[II, ii].value = ii + 1 - Nc;
                                                    }
                                                }
                                                else
                                                    Nc++;

                                            }
                                            for (int jj = II; jj < II + 1; jj++)
                                                for (int ii = 0; ii < orders.Length; ii++)
                                                {
                                                    if (!dis[ii])
                                                    {
                                                        orders[Rha[jj, ii].conf] += Rha[II, ii].value;
                                                    }
                                                }
                                            ////////////////////T computation
                                            double T = 0;
                                            double sorat = 0;
                                            for (int hh2 = 0; hh2 < Nconf; hh2++)
                                            {
                                                if (!dis[hh2])
                                                {
                                                    sorat += Math.Pow(orders[hh2] - (((II + 1) * Nconf + 1) / 2), 2);
                                                }
                                            }
                                            sorat = sorat * (Nconf - 1);
                                            double makhraj = 0;
                                            for (int hh = 0; hh < II + 1; hh++)
                                            {
                                                for (int hh2 = 0; hh2 < Nconf; hh2++)
                                                {
                                                    if (!dis[hh2])
                                                    {
                                                        makhraj += Math.Pow(Rha[hh, hh2].conf, 2);
                                                    }
                                                }
                                            }

                                            makhraj = makhraj - ((II * Nconf * Math.Pow((Nconf + 1), 2)) / 4);
                                            T = sorat / makhraj;
                                            ////////////////
                                            double alpha2 = 0.05;
                                            double quantile1 = LH_Class.get_t_quantile(alpha2, II + 1, t_table); //getStudentT(alpha, rows);
                                            if (T <= quantile1)
                                            {

                                            }
                                            else
                                            {
                                                //calculating T2 (pair-wise test), when needed
                                                double T2, quantile2 = LH_Class.get_t_quantile(alpha2, II + 1, t_table, true);
                                                double best_score = -1;
                                                for (int j = 0; j < Nconf; j++)
                                                {

                                                    if (orders[j] > best_score || best_score == -1)
                                                    {
                                                        best_score = orders[j];
                                                        best_cand = j;
                                                    }
                                                }
                                                makhraj *= Math.Abs((2 * (II + 1)) * (1 - (T / ((II + 1) * (Nconf - 1)))));
                                                makhraj /= ((II + 1) * (Nconf - 1));
                                                for (int j = 0; j < Nconf; j++)
                                                    if (!dis[j])
                                                    {
                                                        if (j != best_cand)
                                                        {
                                                            double diff = orders[best_cand] - orders[j];
                                                            if (diff < 0) diff *= (-1);
                                                            T2 = diff / Math.Sqrt(makhraj);
                                                            if (diff / Math.Sqrt(makhraj) > quantile2)
                                                            {
                                                                dis[j] = true;
                                                                dis_conf++;
                                                                orders[j] = 0;
                                                            }
                                                        }
                                                    }
                                            }
                                            ////////////////////
                                            ins_count = II;
                                        }
                                        //////////////////////////////////////////Select The best///////////////////////////////////
                                        int remainder = Nconf - dis_conf;
                                        int[] rz = new int[Nconf];
                                        int kk2 = 0;
                                        for (int ii = 0; ii < rz.Length; ii++)
                                        {
                                            if (!dis[ii])
                                            {
                                                rz[Rha[ins_count, ii].conf] = kk2 + 1;
                                                kk2++;
                                            }
                                        }
                                        double[] Pz = new double[remainder];
                                        double rands = RR.NextDouble();
                                        kk2 = 0;
                                        for (int ii = 0; ii < Nconf; ii++)
                                        {
                                            if (!dis[ii])
                                            {
                                                if (kk2 == 0)
                                                    Pz[kk2] = Convert.ToDouble(remainder - orders[ii] + 1) / (remainder * (remainder + 1) / 2);
                                                else
                                                    Pz[kk2] = Convert.ToDouble(remainder - orders[ii] + 1) / (remainder * (remainder + 1) / 2) + Pz[kk2 - 1];
                                                if (Pz[kk2] > rands)
                                                {
                                                    best_cand = Rha[ins_count, ii].conf;
                                                    break;
                                                }
                                                kk2++;
                                            }
                                        }
                                        ///////////////////////////////////////////////////////////////////////////////////////////


                                        Bused += Bj[IT];
                                        double lboundCW = 0;
                                        double uboundCW = 10;
                                        double l_lg = 0;
                                        double u_lg = 1;
                                        int Mue = 5 + IT + 1;
                                        double deltad_menfi_yekCW = (uboundCW - lboundCW) / 2;
                                        double deltad_menfi_yek_lg = (u_lg - l_lg) / 2;
                                        int symbol = 0;
                                        Bj[IT + 1] = (Bwhole - Bused) / (Niter - IT + 1);
                                        int Nconf_perv = Nconf;
                                        Nconf = Convert.ToInt32(Bj[IT + 1] / (Mue + Math.Min(5, IT + 1))) - remainder;// (Nconf-dis_conf) is equal the remainder of perv_conf
                                        if (Nconf < 1)
                                        {
                                            break;
                                        }
                                        double deltad_CW = deltad_menfi_yekCW * Math.Pow((1.0 / Nconf), ((double)IT) / Npar);
                                        double delta_lg = deltad_menfi_yek_lg * Math.Pow((1.0 / Nconf), ((double)IT) / Npar);
                                        float[,] PervConf = (float[,])Configuration.Clone();
                                        Configuration = new float[Nconf + remainder, Npar];
                                        ///////C1 , C2 , W, r_lg
                                        for (int jj = 0; jj < Nconf; jj++)
                                        {
                                            for (kk2 = 0; kk2 < Npar - 1; kk2++)
                                            {
                                                symbol = RR.Next(0, 2);
                                                if (symbol == 0)
                                                    Configuration[jj, kk2] = Convert.ToSingle(PervConf[best_cand, kk2] + deltad_CW * RR.NextDouble());
                                                else
                                                    Configuration[jj, kk2] = Convert.ToSingle(PervConf[best_cand, kk2] - deltad_CW * RR.NextDouble());
                                            }
                                            symbol = RR.Next(0, 2);
                                            if (symbol == 0)
                                                Configuration[jj, Npar - 1] = Convert.ToSingle(PervConf[best_cand, Npar - 1] + delta_lg * RR.NextDouble());
                                            else
                                                Configuration[jj, Npar - 1] = Convert.ToSingle(PervConf[best_cand, Npar - 1] - delta_lg * RR.NextDouble());
                                        }
                                        int iii = Nconf;
                                        for (int jj = 0; jj < Nconf_perv; jj++)
                                        {
                                            if (!dis[jj])
                                            {
                                                for (kk2 = 0; kk2 < Npar; kk2++)
                                                {
                                                    Configuration[iii, kk2] = PervConf[jj, kk2];
                                                }
                                                iii++;
                                            }
                                        }
                                        Nconf = Nconf + remainder;// the set of perv_conf+ curr_conf
                                        dis_conf = 0;
                                    }
                                    sw = new StreamWriter(ss);
                                    for (int ii = 0; ii < Npar; ii++)
                                    {
                                        sw.WriteLine(Configuration[best_cand, ii]);
                                    }
                                    sw.Close();
                                }
                            }
                            #endregion
                            #region OrthogonalPSO
                            else if (method == "OrthogonalPSO")
                            {
                                int func_eval = 0;
                                int max_func_eval = NPop * Iteration;
                                int G = 5;
                                ArrayList Cost = new ArrayList();
                                double[] c_s = { 0.5, 1, 2, 3, 5 };
                                double[] w_s = { 0.1, 0.5, 0.8, 1, 1.5 };
                                //for (int cc = 0; cc < c_s.Length; cc++)
                                //    for (int ww = 0; ww < w_s.Length; ww++)
                                //    {
                                //double c = 1.0; double wmax = 0.5; the best configuration found
                                double c = c_s[1]; double wmax = w_s[1];
                                double wmin = wmax - 0.4;
                                if (wmin < 0)
                                    wmin = 0;
                                double[,] cost = new double[Ntest, Iteration];
                                ss = "cost_n_" + N.ToString() + "p_" + P.ToString() + "_pop_" + method + ".txt";
                                ss2 = "fit_n_" + N.ToString() + "p_" + P.ToString() + "_pop_" + NPop.ToString() + "_w_" + wmax.ToString() + "_c_" + c.ToString() + method + "_iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + ".txt";
                                if (!File.Exists(ss))
                                {
                                    structure = "Ring";
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        func_eval = 0;
                                        MOA_Node[] x = new MOA_Node[NPop];
                                        MOA_Node[] pn = new MOA_Node[NPop];
                                        MOA_Node[] pi = new MOA_Node[NPop];
                                        MOA_Node[] v = new MOA_Node[NPop];
                                        MOA_Node[] PO = new MOA_Node[NPop];
                                        MOA_Node best_nodes = new MOA_Node();
                                        int[] stagnated = new int[NPop];
                                        best_nodes.f = 1000;
                                        for (int ii = 0; ii < NPop; ii++)
                                        {
                                            v[ii].x = new double[N, P];
                                            PO[ii].x = new double[N, P];
                                        }
                                        for (int ii = 0; ii < NPop; ii++)
                                        {
                                            x[ii].x = LH_Class.node_constructing(N, P, rr);
                                            pi[ii].x = (double[,])x[ii].x.Clone();
                                            x[ii].LH = LH_Class.convert_search_s_to_solution_s(x[ii].x, N, P);
                                            x[ii].f = LH_Class.F(x[ii].LH, N, P);
                                            pi[ii].f = x[ii].f;
                                            pn[ii].f = 1000;
                                        }
                                        for (int ii = 0; ii < NPop; ii++)
                                        {

                                            int[] struc = LH_Class.Structures(ii, NPop, structure, rr);
                                            for (int jj = 0; jj < struc.Length; jj++)
                                            {
                                                if (x[struc[jj]].f < pn[ii].f)
                                                {
                                                    pn[ii].f = x[struc[jj]].f;
                                                    pn[ii].x = (double[,])x[struc[jj]].x.Clone();
                                                }
                                            }
                                            PO[ii].x = LH_Class.PO_construction(N * P, pi, pn, N, P, ref func_eval, ii, ref Cost);
                                        }

                                        for (int it = 0; it < Iteration && func_eval <= max_func_eval; it++)
                                        {
                                            Fmax = 0; Fmin = 1000;
                                            double gen = Convert.ToInt32(it);
                                            double w = wmax - wmin * gen / Iteration;
                                            for (int ii = 0; ii < NPop; ii++)
                                            {
                                                for (int n = 0; n < N; n++)
                                                    for (int p = 0; p < P; p++)
                                                    {
                                                        v[ii].x[n, p] = w * v[ii].x[n, p] + c * rr.NextDouble() * (PO[ii].x[n, p] - x[ii].x[n, p]);
                                                        x[ii].x[n, p] = x[ii].x[n, p] + v[ii].x[n, p];
                                                    }

                                                x[ii].x = Node_treatment(x[ii].x, N, P, rr);
                                            }
                                            int min_index = 0; int max_index = 0;
                                            for (int ii = 0; ii < NPop; ii++)
                                            {
                                                x[ii].LH = LH_Class.convert_search_s_to_solution_s(x[ii].x, N, P);
                                                x[ii].f = LH_Class.F(x[ii].LH, N, P);
                                                func_eval++;
                                                if (Fmax < x[ii].f)
                                                {
                                                    Fmax = x[ii].f;
                                                    max_index = ii;
                                                }
                                                Cost.Add(Fmax);
                                                if (Fmin > x[ii].f)
                                                {
                                                    Fmin = x[ii].f;
                                                    min_index = ii;
                                                }
                                                if (x[ii].f < pi[ii].f)
                                                {
                                                    pi[ii].f = x[ii].f;
                                                    pi[ii].x = (double[,])x[ii].x.Clone();
                                                    stagnated[ii] = 0;
                                                }
                                                else
                                                {
                                                    stagnated[ii]++;
                                                }
                                                if (stagnated[ii] > G)
                                                {
                                                    PO[ii].x = LH_Class.PO_construction(N * P, pi, pn, N, P, ref func_eval, ii, ref Cost);
                                                    stagnated[ii] = 0;
                                                }
                                                int[] nei = LH_Class.Structures(ii, NPop, structure, rr);
                                                for (int jj = 0; jj < nei.Length; jj++)
                                                {
                                                    if (x[nei[jj]].f > pn[ii].f)
                                                    {
                                                        pn[ii].f = x[nei[jj]].f;
                                                        pn[ii].x = (double[,])x[nei[jj]].x.Clone();
                                                    }
                                                }
                                                if (pi[ii].f < pn[ii].f)
                                                {
                                                    pn[ii].f = pi[ii].f;
                                                    pn[ii].x = (double[,])pi[ii].x.Clone();
                                                }
                                            }
                                            if (best_nodes.f > Fmin)
                                            {
                                                best_nodes.f = Fmin;
                                                best_nodes.LH = (int[,])x[min_index].LH.Clone();
                                                best_nodes.x = (double[,])x[min_index].x.Clone();

                                            }
                                            pn = LH_Class.define_pbest2(x, pn, NPop);

                                            Cost.Add(best_nodes.f);
                                        }

                                        costs[tt] = best_nodes.f;
                                        Nodes_test[tt].LH = (int[,])best_nodes.LH.Clone();

                                    }

                                    sw = new StreamWriter(ss);
                                    //for (int tt = 0; tt < Ntest; tt++)
                                    //{
                                    for (int it = 0; it < Cost.Count; it++)
                                    {
                                        sw.Write(Cost[it].ToString() + " ");

                                    }
                                    //}
                                    sw.Close();
                                    sw = new StreamWriter(ss2);
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        sw.Write(costs[tt].ToString() + " ");
                                    }
                                    sw.Close();
                                    //sw = new StreamWriter(ss);
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
                                    //}
                                }
                            }

                            #endregion
                            #region FROPSO
                            else if (method == "FROPSO")
                            {
                                int func_eval = 0;
                                int max_func_eval = NPop * Iteration;
                                int G = 5;
                                //double[] c_s = { 0.5, 1, 2, 3, 5 };
                                //double[] w_s = { 0.1, 0.5, 0.8, 1, 1.5 };
                                double Mean = 0;
                                /////////////Initialization Process//////////////////////
                                int instance = dimen.Length;
                                int Nconf = 0;
                                int Npar = 2;
                                int Bwhole = Convert.ToInt32(Bud.Text);
                                int Bused = 0;
                                int Niter = Convert.ToInt32(Math.Floor(2 + Math.Log(Npar)));
                                int[] Bj = new int[Niter];
                                Bj[0] = Bwhole / Niter;
                                Nconf = Bj[0] / 5;
                                Random RR = new Random();
                                float[,] Configuration = new float[Nconf, Npar];
                                double[] Cost = new double[Nconf];
                                R[,] Rha = new R[instance, Nconf];

                                for (int jj = 0; jj < Nconf; jj++)
                                {
                                    for (int kk = 0; kk < Npar - 1; kk++)
                                    {
                                        Configuration[jj, kk] = Convert.ToSingle(0.5 + 4.5 * RR.NextDouble());
                                    }
                                    for (int kk = Npar - 1; kk < Npar; kk++)
                                    {
                                        Configuration[jj, kk] = Convert.ToSingle(0.1 + 1.4 * RR.NextDouble());
                                    }
                                }
                                ///////////////////////////////////////////////////////
                                bool[] dis = new bool[Nconf]; // The ones have been discarded...
                                int dis_conf = 0;
                                int best_cand = -1;
                                int ins_count = 0;
                                ss = Directory.GetCurrentDirectory() + "\\FROPSO.txt";
                                if (!File.Exists(ss))
                                {
                                    for (int IT = 0; IT < Niter; IT++)
                                    {
                                        Rha = new R[instance, Nconf];
                                        dis = new bool[Nconf];
                                        double[] orders = new double[Nconf];
                                        for (int II = 0; II < instance && dis_conf <= Nconf - 1; II++)
                                        {
                                            N = Ns[II];
                                            P = Ps[II];
                                            MOA_Node[] Pop = new MOA_Node[NPop];
                                            int[] Indexes = new int[P];
                                            for (int jjj = 0; jjj < Nconf; jjj++)
                                            {
                                                if (!dis[jjj])
                                                {
                                                    Mean = 0;
                                                    double c = Configuration[jjj, 0]; double wmax = Configuration[jjj, 1];
                                                    double wmin = wmax - 0.4;
                                                    if (wmin < 0)
                                                        wmin = 0;
                                                    for (int tt = 0; tt < Ntest; tt++)
                                                    {
                                                        func_eval = 0;
                                                        MOA_Node[] x = new MOA_Node[NPop];
                                                        MOA_Node[] pn = new MOA_Node[NPop];
                                                        MOA_Node[] pi = new MOA_Node[NPop];
                                                        MOA_Node[] v = new MOA_Node[NPop];
                                                        MOA_Node[] PO = new MOA_Node[NPop];
                                                        MOA_Node best_nodes = new MOA_Node();
                                                        int[] stagnated = new int[NPop];
                                                        best_nodes.f = 1000;
                                                        for (int ii = 0; ii < NPop; ii++)
                                                        {
                                                            v[ii].x = new double[N, P];
                                                            PO[ii].x = new double[N, P];
                                                        }
                                                        for (int ii = 0; ii < NPop; ii++)
                                                        {
                                                            x[ii].x = LH_Class.node_constructing(N, P, rr);
                                                            pi[ii].x = (double[,])x[ii].x.Clone();
                                                            x[ii].LH = LH_Class.convert_search_s_to_solution_s(x[ii].x, N, P);
                                                            x[ii].f = LH_Class.F(x[ii].LH, N, P);
                                                            pi[ii].f = x[ii].f;
                                                            pn[ii].f = 1000;
                                                        }
                                                        for (int ii = 0; ii < NPop; ii++)
                                                        {

                                                            int[] struc = LH_Class.Structures(ii, NPop, structure, rr);
                                                            for (int jj = 0; jj < struc.Length; jj++)
                                                            {
                                                                if (x[struc[jj]].f < pn[ii].f)
                                                                {
                                                                    pn[ii].f = x[struc[jj]].f;
                                                                    pn[ii].x = (double[,])x[struc[jj]].x.Clone();
                                                                }
                                                            }
                                                            //PO[ii].x = LH_Class.PO_construction(N * P, pi, pn, N, P, ref func_eval, ii);
                                                        }

                                                        for (int it = 0; it < Iteration && func_eval <= max_func_eval; it++)
                                                        {
                                                            Fmax = 0; Fmin = 1000;
                                                            double gen = Convert.ToInt32(it);
                                                            double w = wmax - wmin * gen / Iteration;
                                                            for (int ii = 0; ii < NPop; ii++)
                                                            {
                                                                for (int n = 0; n < N; n++)
                                                                    for (int p = 0; p < P; p++)
                                                                    {
                                                                        v[ii].x[n, p] = w * v[ii].x[n, p] + c * rr.NextDouble() * (PO[ii].x[n, p] - x[ii].x[n, p]);
                                                                        x[ii].x[n, p] = x[ii].x[n, p] + v[ii].x[n, p];
                                                                    }

                                                                x[ii].x = Node_treatment(x[ii].x, N, P, rr);
                                                            }
                                                            int min_index = 0; int max_index = 0;
                                                            for (int ii = 0; ii < NPop; ii++)
                                                            {
                                                                x[ii].LH = LH_Class.convert_search_s_to_solution_s(x[ii].x, N, P);
                                                                x[ii].f = LH_Class.F(x[ii].LH, N, P);
                                                                func_eval++;
                                                                if (Fmax < x[ii].f)
                                                                {
                                                                    Fmax = x[ii].f;
                                                                    max_index = ii;
                                                                }
                                                                if (Fmin > x[ii].f)
                                                                {
                                                                    Fmin = x[ii].f;
                                                                    min_index = ii;
                                                                }
                                                                if (x[ii].f < pi[ii].f)
                                                                {
                                                                    pi[ii].f = x[ii].f;
                                                                    pi[ii].x = (double[,])x[ii].x.Clone();
                                                                    stagnated[ii] = 0;
                                                                }
                                                                else
                                                                {
                                                                    stagnated[ii]++;
                                                                }
                                                                if (stagnated[ii] > G)
                                                                {
                                                                    //PO[ii].x = LH_Class.PO_construction(N * P, pi, pn, N, P, ref func_eval, ii);
                                                                    stagnated[ii] = 0;
                                                                }
                                                                int[] nei = LH_Class.Structures(ii, NPop, structure, rr);
                                                                for (int jj = 0; jj < nei.Length; jj++)
                                                                {
                                                                    if (x[nei[jj]].f > pn[ii].f)
                                                                    {
                                                                        pn[ii].f = x[nei[jj]].f;
                                                                        pn[ii].x = (double[,])x[nei[jj]].x.Clone();
                                                                    }
                                                                }
                                                                if (pi[ii].f < pn[ii].f)
                                                                {
                                                                    pn[ii].f = pi[ii].f;
                                                                    pn[ii].x = (double[,])pi[ii].x.Clone();
                                                                }
                                                            }
                                                            if (best_nodes.f > Fmin)
                                                            {
                                                                best_nodes.f = Fmin;
                                                                best_nodes.LH = (int[,])x[min_index].LH.Clone();
                                                                best_nodes.x = (double[,])x[min_index].x.Clone();

                                                            }
                                                            pn = LH_Class.define_pbest2(x, pn, NPop);
                                                        }
                                                        costs[tt] = best_nodes.f;
                                                        Mean += costs[tt];
                                                    }
                                                    Rha[II, jjj].Cost = Mean / Ntest;
                                                    Rha[II, jjj].conf = jjj;
                                                }
                                            }
                                            for (int hh = II; hh < II + 1; hh++)
                                            {
                                                for (int hh2 = 0; hh2 < Nconf - 1; hh2++)
                                                {
                                                    if (!dis[hh2])
                                                        for (int hh3 = hh2 + 1; hh3 < Nconf; hh3++)
                                                        {
                                                            if (!dis[hh3])
                                                                if (Rha[hh, hh2].Cost < Rha[hh, hh3].Cost)
                                                                {
                                                                    R temp = Rha[hh, hh2];
                                                                    Rha[hh, hh2] = Rha[hh, hh3];
                                                                    Rha[hh, hh3] = temp;
                                                                }
                                                        }
                                                }
                                            }
                                            for (int hh = II; hh < II + 1; hh++)
                                            {
                                                for (int ii = Nconf - 1; ii > 0; ii--)
                                                {
                                                    if (!dis[ii])
                                                    {
                                                        Rha[hh, ii].value++;
                                                        for (int jj = ii - 1; jj >= 0; jj--)
                                                        {
                                                            if (Rha[hh, ii].Cost == Rha[hh, jj].Cost)
                                                            {
                                                                Rha[hh, ii].value++;
                                                            }
                                                            else
                                                            {
                                                                ii = jj + 1;
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            if (Rha[II, 1].value <= 1 && !dis[0])
                                            {
                                                Rha[II, 0].value = 1;
                                            }
                                            int Nc = 0;
                                            for (int ii = 0; ii < Nconf; ii++)
                                            {
                                                if (!dis[ii])
                                                {

                                                    if (Rha[II, ii].value > 2)
                                                    {
                                                        int temp = Convert.ToInt32(Rha[II, ii].value);
                                                        int ind = 0;
                                                        for (int jj = ii - temp + 1; jj <= ii; jj++)
                                                        {
                                                            ind += jj + 1;
                                                        }
                                                        for (int jj = ii - temp + 1; jj <= ii; jj++)
                                                        {
                                                            Rha[II, jj].value = ind / temp;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Rha[II, ii].value = ii + 1 - Nc;
                                                    }
                                                }
                                                else
                                                    Nc++;

                                            }
                                            for (int jj = II; jj < II + 1; jj++)
                                                for (int ii = 0; ii < orders.Length; ii++)
                                                {
                                                    if (!dis[ii])
                                                    {
                                                        orders[Rha[jj, ii].conf] += Rha[II, ii].value;
                                                    }
                                                }
                                            ////////////////////T computation
                                            double T = 0;
                                            double sorat = 0;
                                            for (int hh2 = 0; hh2 < Nconf; hh2++)
                                            {
                                                if (!dis[hh2])
                                                {
                                                    sorat += Math.Pow(orders[hh2] - (((II + 1) * Nconf + 1) / 2), 2);
                                                }
                                            }
                                            sorat = sorat * (Nconf - 1);
                                            double makhraj = 0;
                                            for (int hh = 0; hh < II + 1; hh++)
                                            {
                                                for (int hh2 = 0; hh2 < Nconf; hh2++)
                                                {
                                                    if (!dis[hh2])
                                                    {
                                                        makhraj += Math.Pow(Rha[hh, hh2].conf, 2);
                                                    }
                                                }
                                            }

                                            makhraj = makhraj - ((II * Nconf * Math.Pow((Nconf + 1), 2)) / 4);
                                            T = sorat / makhraj;
                                            ////////////////
                                            double alpha2 = 0.05;
                                            double quantile1 = LH_Class.get_t_quantile(alpha2, II + 1, t_table); //getStudentT(alpha, rows);
                                            if (T <= quantile1)
                                            {

                                            }
                                            else
                                            {
                                                //calculating T2 (pair-wise test), when needed
                                                double T2, quantile2 = LH_Class.get_t_quantile(alpha2, II + 1, t_table, true);
                                                double best_score = -1;
                                                for (int j = 0; j < Nconf; j++)
                                                {

                                                    if (orders[j] > best_score || best_score == -1)
                                                    {
                                                        best_score = orders[j];
                                                        best_cand = j;
                                                    }
                                                }
                                                makhraj *= Math.Abs((2 * (II + 1)) * (1 - (T / ((II + 1) * (Nconf - 1)))));
                                                makhraj /= ((II + 1) * (Nconf - 1));
                                                for (int j = 0; j < Nconf; j++)
                                                    if (!dis[j])
                                                    {
                                                        if (j != best_cand)
                                                        {
                                                            double diff = orders[best_cand] - orders[j];
                                                            if (diff < 0) diff *= (-1);
                                                            T2 = diff / Math.Sqrt(makhraj);
                                                            if (diff / Math.Sqrt(makhraj) > quantile2)
                                                            {
                                                                dis[j] = true;
                                                                dis_conf++;
                                                                orders[j] = 0;
                                                            }
                                                        }
                                                    }
                                            }
                                            ////////////////////
                                            ins_count = II;
                                        }
                                        //////////////////////////////////////////Select The best///////////////////////////////////
                                        int remainder = Nconf - dis_conf;
                                        int[] rz = new int[Nconf];
                                        int kk2 = 0;
                                        for (int ii = 0; ii < rz.Length; ii++)
                                        {
                                            if (!dis[ii])
                                            {
                                                rz[Rha[ins_count, ii].conf] = kk2 + 1;
                                                kk2++;
                                            }
                                        }
                                        double[] Pz = new double[remainder];
                                        double rands = RR.NextDouble();
                                        kk2 = 0;
                                        for (int ii = 0; ii < Nconf; ii++)
                                        {
                                            if (!dis[ii])
                                            {
                                                if (kk2 == 0)
                                                    Pz[kk2] = Convert.ToDouble(remainder - orders[ii] + 1) / (remainder * (remainder + 1) / 2);
                                                else
                                                    Pz[kk2] = Convert.ToDouble(remainder - orders[ii] + 1) / (remainder * (remainder + 1) / 2) + Pz[kk2 - 1];
                                                if (Pz[kk2] > rands)
                                                {
                                                    best_cand = Rha[ins_count, ii].conf;
                                                    break;
                                                }
                                                kk2++;
                                            }
                                        }
                                        ///////////////////////////////////////////////////////////////////////////////////////////


                                        Bused += Bj[IT];
                                        double lboundCW = 0;
                                        double uboundCW = 10;
                                        double l_lg = 0;
                                        double u_lg = 1;
                                        int Mue = 5 + IT + 1;
                                        double deltad_menfi_yekCW = (uboundCW - lboundCW) / 2;
                                        double deltad_menfi_yek_lg = (u_lg - l_lg) / 2;
                                        int symbol = 0;
                                        Bj[IT + 1] = (Bwhole - Bused) / (Niter - IT + 1);
                                        int Nconf_perv = Nconf;
                                        Nconf = Convert.ToInt32(Bj[IT + 1] / (Mue + Math.Min(5, IT + 1))) - remainder;// (Nconf-dis_conf) is equal the remainder of perv_conf
                                        if (Nconf < 1)
                                        {
                                            break;
                                        }
                                        double deltad_CW = deltad_menfi_yekCW * Math.Pow((1.0 / Nconf), ((double)IT) / Npar);
                                        double delta_lg = deltad_menfi_yek_lg * Math.Pow((1.0 / Nconf), ((double)IT) / Npar);
                                        float[,] PervConf = (float[,])Configuration.Clone();
                                        Configuration = new float[Nconf + remainder, Npar];
                                        ///////C1 , C2 , W, r_lg
                                        for (int jj = 0; jj < Nconf; jj++)
                                        {
                                            for (kk2 = 0; kk2 < Npar - 1; kk2++)
                                            {
                                                symbol = RR.Next(0, 2);
                                                if (symbol == 0)
                                                    Configuration[jj, kk2] = Convert.ToSingle(PervConf[best_cand, kk2] + deltad_CW * RR.NextDouble());
                                                else
                                                    Configuration[jj, kk2] = Convert.ToSingle(PervConf[best_cand, kk2] - deltad_CW * RR.NextDouble());
                                            }
                                            symbol = RR.Next(0, 2);
                                            if (symbol == 0)
                                                Configuration[jj, Npar - 1] = Convert.ToSingle(PervConf[best_cand, Npar - 1] + delta_lg * RR.NextDouble());
                                            else
                                                Configuration[jj, Npar - 1] = Convert.ToSingle(PervConf[best_cand, Npar - 1] - delta_lg * RR.NextDouble());
                                        }
                                        int iii = Nconf;
                                        for (int jj = 0; jj < Nconf_perv; jj++)
                                        {
                                            if (!dis[jj])
                                            {
                                                for (kk2 = 0; kk2 < Npar; kk2++)
                                                {
                                                    Configuration[iii, kk2] = PervConf[jj, kk2];
                                                }
                                                iii++;
                                            }
                                        }
                                        Nconf = Nconf + remainder;// the set of perv_conf+ curr_conf
                                        dis_conf = 0;
                                    }
                                    sw = new StreamWriter(ss);
                                    for (int ii = 0; ii < Npar; ii++)
                                    {
                                        sw.WriteLine(Configuration[best_cand, ii]);
                                    }
                                    sw.Close();
                                }
                            }

                            #endregion
                            #region FRDE
                            else if (method == "FRDE")
                            {
                                int func_eval = 0;
                                int max_func_eval = NPop * Iteration;
                                int G = 5;
                                //double[] c_s = { 0.5, 1, 2, 3, 5 };
                                //double[] w_s = { 0.1, 0.5, 0.8, 1, 1.5 };
                                double Mean = 0;
                                /////////////Initialization Process//////////////////////
                                int instance = dimen.Length;
                                int Nconf = 0;
                                int Npar = 2;
                                int Bwhole = Convert.ToInt32(Bud.Text);
                                int Bused = 0;
                                int Niter = Convert.ToInt32(Math.Floor(2 + Math.Log(Npar))) + 1;
                                int[] Bj = new int[Niter];
                                Bj[0] = Bwhole / Niter;
                                Nconf = Bj[0] / 5;
                                Random RR = new Random();
                                float[,] Configuration = new float[Nconf, Npar];
                                double[] Cost = new double[Nconf];
                                R[,] Rha = new R[instance, Nconf];

                                for (int jj = 0; jj < Nconf; jj++)
                                {
                                    for (int kk = 0; kk < Npar - 1; kk++)
                                    {
                                        Configuration[jj, kk] = Convert.ToSingle(RR.NextDouble());
                                    }
                                    for (int kk = Npar - 1; kk < Npar; kk++)
                                    {
                                        Configuration[jj, kk] = Convert.ToSingle(RR.NextDouble());
                                    }
                                }
                                ///////////////////////////////////////////////////////
                                bool[] dis = new bool[Nconf]; // The ones have been discarded...
                                int dis_conf = 0;
                                int best_cand = -1;
                                int ins_count = 0;
                                ss = Directory.GetCurrentDirectory() + "\\FRDE.txt";
                                if (!File.Exists(ss))
                                {
                                    for (int IT = 0; IT < Niter; IT++)
                                    {
                                        Rha = new R[instance, Nconf];
                                        dis = new bool[Nconf];
                                        double[] orders = new double[Nconf];
                                        for (int II = 0; II < instance && dis_conf <= Nconf - 1; II++)
                                        {
                                            N = Ns[II];
                                            P = Ps[II];
                                            int[] Indexes = new int[P];
                                            for (int jjj = 0; jjj < Nconf; jjj++)
                                            {
                                                if (!dis[jjj])
                                                {
                                                    Mean = 0;
                                                    double Cr = Configuration[jjj, 0]; double F = Configuration[jjj, 1];

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
                                                            Fmin = 1000;
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
                                                        }

                                                        costs[tt] = Best_indi.F;
                                                        Mean += costs[tt];
                                                    }
                                                    Rha[II, jjj].Cost = Mean / Ntest;
                                                    Rha[II, jjj].conf = jjj;
                                                }
                                            }
                                            for (int hh = II; hh < II + 1; hh++)
                                            {
                                                for (int hh2 = 0; hh2 < Nconf - 1; hh2++)
                                                {
                                                    if (!dis[hh2])
                                                        for (int hh3 = hh2 + 1; hh3 < Nconf; hh3++)
                                                        {
                                                            if (!dis[hh3])
                                                                if (Rha[hh, hh2].Cost < Rha[hh, hh3].Cost)
                                                                {
                                                                    R temp = Rha[hh, hh2];
                                                                    Rha[hh, hh2] = Rha[hh, hh3];
                                                                    Rha[hh, hh3] = temp;
                                                                }
                                                        }
                                                }
                                            }
                                            for (int hh = II; hh < II + 1; hh++)
                                            {
                                                for (int ii = Nconf - 1; ii > 0; ii--)
                                                {
                                                    if (!dis[ii])
                                                    {
                                                        Rha[hh, ii].value++;
                                                        for (int jj = ii - 1; jj >= 0; jj--)
                                                        {
                                                            if (Rha[hh, ii].Cost == Rha[hh, jj].Cost)
                                                            {
                                                                Rha[hh, ii].value++;
                                                            }
                                                            else
                                                            {
                                                                ii = jj + 1;
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            if (Rha[II, 1].value <= 1 && !dis[0])
                                            {
                                                Rha[II, 0].value = 1;
                                            }
                                            int Nc = 0;
                                            for (int ii = 0; ii < Nconf; ii++)
                                            {
                                                if (!dis[ii])
                                                {

                                                    if (Rha[II, ii].value > 2)
                                                    {
                                                        int temp = Convert.ToInt32(Rha[II, ii].value);
                                                        int ind = 0;
                                                        for (int jj = ii - temp + 1; jj <= ii; jj++)
                                                        {
                                                            ind += jj + 1;
                                                        }
                                                        for (int jj = ii - temp + 1; jj <= ii; jj++)
                                                        {
                                                            Rha[II, jj].value = ind / temp;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Rha[II, ii].value = ii + 1 - Nc;
                                                    }
                                                }
                                                else
                                                    Nc++;

                                            }
                                            for (int jj = II; jj < II + 1; jj++)
                                                for (int ii = 0; ii < orders.Length; ii++)
                                                {
                                                    if (!dis[ii])
                                                    {
                                                        orders[Rha[jj, ii].conf] += Rha[II, ii].value;
                                                    }
                                                }
                                            ////////////////////T computation
                                            double T = 0;
                                            double sorat = 0;
                                            for (int hh2 = 0; hh2 < Nconf; hh2++)
                                            {
                                                if (!dis[hh2])
                                                {
                                                    sorat += Math.Pow(orders[hh2] - (((II + 1) * Nconf + 1) / 2), 2);
                                                }
                                            }
                                            sorat = sorat * (Nconf - 1);
                                            double makhraj = 0;
                                            for (int hh = 0; hh < II + 1; hh++)
                                            {
                                                for (int hh2 = 0; hh2 < Nconf; hh2++)
                                                {
                                                    if (!dis[hh2])
                                                    {
                                                        makhraj += Math.Pow(Rha[hh, hh2].conf, 2);
                                                    }
                                                }
                                            }

                                            makhraj = makhraj - ((II * Nconf * Math.Pow((Nconf + 1), 2)) / 4);
                                            T = sorat / makhraj;
                                            ////////////////
                                            double alpha2 = 0.05;
                                            double quantile1 = LH_Class.get_t_quantile(alpha2, II + 1, t_table); //getStudentT(alpha, rows);
                                            if (T <= quantile1)
                                            {

                                            }
                                            else
                                            {
                                                //calculating T2 (pair-wise test), when needed
                                                double T2, quantile2 = LH_Class.get_t_quantile(alpha2, II + 1, t_table, true);
                                                double best_score = -1;
                                                for (int j = 0; j < Nconf; j++)
                                                {

                                                    if (orders[j] > best_score || best_score == -1)
                                                    {
                                                        best_score = orders[j];
                                                        best_cand = j;
                                                    }
                                                }
                                                makhraj *= Math.Abs((2 * (II + 1)) * (1 - (T / ((II + 1) * (Nconf - 1)))));
                                                makhraj /= ((II + 1) * (Nconf - 1));
                                                for (int j = 0; j < Nconf; j++)
                                                    if (!dis[j])
                                                    {
                                                        if (j != best_cand)
                                                        {
                                                            double diff = orders[best_cand] - orders[j];
                                                            if (diff < 0) diff *= (-1);
                                                            T2 = diff / Math.Sqrt(makhraj);
                                                            if (diff / Math.Sqrt(makhraj) > quantile2)
                                                            {
                                                                dis[j] = true;
                                                                dis_conf++;
                                                                orders[j] = 0;
                                                            }
                                                        }
                                                    }
                                            }
                                            ////////////////////
                                            ins_count = II;
                                        }
                                        //////////////////////////////////////////Select The best///////////////////////////////////
                                        int remainder = Nconf - dis_conf;
                                        int[] rz = new int[Nconf];
                                        int kk2 = 0;
                                        for (int ii = 0; ii < rz.Length; ii++)
                                        {
                                            if (!dis[ii])
                                            {
                                                rz[Rha[ins_count, ii].conf] = kk2 + 1;
                                                kk2++;
                                            }
                                        }
                                        double[] Pz = new double[remainder];
                                        double rands = RR.NextDouble();
                                        kk2 = 0;
                                        for (int ii = 0; ii < Nconf; ii++)
                                        {
                                            if (!dis[ii])
                                            {
                                                if (kk2 == 0)
                                                    Pz[kk2] = Convert.ToDouble(remainder - orders[ii] + 1) / (remainder * (remainder + 1) / 2);
                                                else
                                                    Pz[kk2] = Convert.ToDouble(remainder - orders[ii] + 1) / (remainder * (remainder + 1) / 2) + Pz[kk2 - 1];
                                                if (Pz[kk2] > rands)
                                                {
                                                    best_cand = Rha[ins_count, ii].conf;
                                                    break;
                                                }
                                                kk2++;
                                            }
                                        }
                                        ///////////////////////////////////////////////////////////////////////////////////////////


                                        Bused += Bj[IT];
                                        double lboundCW = 0;
                                        double uboundCW = 10;
                                        double l_lg = 0;
                                        double u_lg = 1;
                                        int Mue = 5 + IT + 1;
                                        double deltad_menfi_yekCW = (uboundCW - lboundCW) / 2;
                                        double deltad_menfi_yek_lg = (u_lg - l_lg) / 2;
                                        int symbol = 0;
                                        Bj[IT + 1] = (Bwhole - Bused) / (Niter - IT + 1);
                                        int Nconf_perv = Nconf;
                                        Nconf = Convert.ToInt32(Bj[IT + 1] / (Mue + Math.Min(5, IT + 1))) - remainder;// (Nconf-dis_conf) is equal the remainder of perv_conf
                                        if (Nconf < 1)
                                        {
                                            break;
                                        }
                                        double deltad_CW = deltad_menfi_yekCW * Math.Pow((1.0 / Nconf), ((double)IT) / Npar);
                                        double delta_lg = deltad_menfi_yek_lg * Math.Pow((1.0 / Nconf), ((double)IT) / Npar);
                                        float[,] PervConf = (float[,])Configuration.Clone();
                                        Configuration = new float[Nconf + remainder, Npar];
                                        ///////C1 , C2 , W, r_lg
                                        for (int jj = 0; jj < Nconf; jj++)
                                        {
                                            for (kk2 = 0; kk2 < Npar - 1; kk2++)
                                            {
                                                symbol = RR.Next(0, 2);
                                                if (symbol == 0)
                                                    Configuration[jj, kk2] = Convert.ToSingle(PervConf[best_cand, kk2] + deltad_CW * RR.NextDouble());
                                                else
                                                    Configuration[jj, kk2] = Convert.ToSingle(PervConf[best_cand, kk2] - deltad_CW * RR.NextDouble());
                                            }
                                            symbol = RR.Next(0, 2);
                                            if (symbol == 0)
                                                Configuration[jj, Npar - 1] = Convert.ToSingle(PervConf[best_cand, Npar - 1] + delta_lg * RR.NextDouble());
                                            else
                                                Configuration[jj, Npar - 1] = Convert.ToSingle(PervConf[best_cand, Npar - 1] - delta_lg * RR.NextDouble());
                                        }
                                        int iii = Nconf;
                                        for (int jj = 0; jj < Nconf_perv; jj++)
                                        {
                                            if (!dis[jj])
                                            {
                                                for (kk2 = 0; kk2 < Npar; kk2++)
                                                {
                                                    Configuration[iii, kk2] = PervConf[jj, kk2];
                                                }
                                                iii++;
                                            }
                                        }
                                        Nconf = Nconf + remainder;// the set of perv_conf+ curr_conf
                                        dis_conf = 0;
                                    }
                                    sw = new StreamWriter(ss);
                                    for (int ii = 0; ii < Npar; ii++)
                                    {
                                        sw.WriteLine(Configuration[best_cand, ii]);
                                    }
                                    sw.Close();
                                }

                            }

                            #endregion
                            #region FRES
                            else if (method == "FRES")
                            {

                                int func_eval = 0;
                                int max_func_eval = NPop * Iteration;
                                int G = 5;
                                //double[] c_s = { 0.5, 1, 2, 3, 5 };
                                //double[] w_s = { 0.1, 0.5, 0.8, 1, 1.5 };
                                double Mean = 0;
                                /////////////Initialization Process//////////////////////
                                int instance = dimen.Length;
                                int Nconf = 0;
                                int Npar = 2;
                                int Bwhole = Convert.ToInt32(Bud.Text);
                                int Bused = 0;
                                int Niter = Convert.ToInt32(Math.Floor(2 + Math.Log(Npar)));
                                int[] Bj = new int[Niter + 2];
                                Bj[0] = Bwhole / Niter;
                                Nconf = Bj[0] / 5;
                                Random RR = new Random();
                                float[,] Configuration = new float[Nconf, Npar];
                                double[] Cost = new double[Nconf];
                                R[,] Rha = new R[instance, Nconf];

                                for (int jj = 0; jj < Nconf; jj++)
                                {
                                    for (int kk = 0; kk < Npar - 1; kk++)
                                    {
                                        Configuration[jj, kk] = Convert.ToSingle(RR.NextDouble());
                                    }
                                    for (int kk = Npar - 1; kk < Npar; kk++)
                                    {
                                        Configuration[jj, kk] = Convert.ToSingle(RR.NextDouble());
                                    }
                                }
                                ///////////////////////////////////////////////////////
                                bool[] dis = new bool[Nconf]; // The ones have been discarded...
                                int dis_conf = 0;
                                int best_cand = -1;
                                int ins_count = 0;
                                ss = Directory.GetCurrentDirectory() + "\\FRES.txt";
                                if (!File.Exists(ss))
                                {
                                    for (int IT = 0; IT < Niter; IT++)
                                    {
                                        Rha = new R[instance, Nconf];
                                        dis = new bool[Nconf];
                                        double[] orders = new double[Nconf];
                                        for (int II = 0; II < instance && dis_conf <= Nconf - 1; II++)
                                        {
                                            N = Ns[II];
                                            P = Ps[II];
                                            int[] Indexes = new int[P];
                                            for (int jjj = 0; jjj < Nconf; jjj++)
                                            {
                                                if (!dis[jjj])
                                                {
                                                    Mean = 0;

                                                    int breeds_number = Convert.ToInt32(Configuration[jjj, 0] * NPop); double SC = Configuration[jjj, 1];
                                                    if (breeds_number < 1)
                                                        breeds_number = 1;
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
                                                        }

                                                        costs[tt] = Best_nodes.f;
                                                        Mean += costs[tt];
                                                    }
                                                    Rha[II, jjj].Cost = Mean / Ntest;
                                                    Rha[II, jjj].conf = jjj;
                                                }
                                            }
                                            for (int hh = II; hh < II + 1; hh++)
                                            {
                                                for (int hh2 = 0; hh2 < Nconf - 1; hh2++)
                                                {
                                                    if (!dis[hh2])
                                                        for (int hh3 = hh2 + 1; hh3 < Nconf; hh3++)
                                                        {
                                                            if (!dis[hh3])
                                                                if (Rha[hh, hh2].Cost < Rha[hh, hh3].Cost)
                                                                {
                                                                    R temp = Rha[hh, hh2];
                                                                    Rha[hh, hh2] = Rha[hh, hh3];
                                                                    Rha[hh, hh3] = temp;
                                                                }
                                                        }
                                                }
                                            }
                                            for (int hh = II; hh < II + 1; hh++)
                                            {
                                                for (int ii = Nconf - 1; ii > 0; ii--)
                                                {
                                                    if (!dis[ii])
                                                    {
                                                        Rha[hh, ii].value++;
                                                        for (int jj = ii - 1; jj >= 0; jj--)
                                                        {
                                                            if (Rha[hh, ii].Cost == Rha[hh, jj].Cost)
                                                            {
                                                                Rha[hh, ii].value++;
                                                            }
                                                            else
                                                            {
                                                                ii = jj + 1;
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            if (Rha[II, 1].value <= 1 && !dis[0])
                                            {
                                                Rha[II, 0].value = 1;
                                            }
                                            int Nc = 0;
                                            for (int ii = 0; ii < Nconf; ii++)
                                            {
                                                if (!dis[ii])
                                                {

                                                    if (Rha[II, ii].value > 2)
                                                    {
                                                        int temp = Convert.ToInt32(Rha[II, ii].value);
                                                        int ind = 0;
                                                        for (int jj = ii - temp + 1; jj <= ii; jj++)
                                                        {
                                                            ind += jj + 1;
                                                        }
                                                        for (int jj = ii - temp + 1; jj <= ii; jj++)
                                                        {
                                                            Rha[II, jj].value = ind / temp;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Rha[II, ii].value = ii + 1 - Nc;
                                                    }
                                                }
                                                else
                                                    Nc++;

                                            }
                                            for (int jj = II; jj < II + 1; jj++)
                                                for (int ii = 0; ii < orders.Length; ii++)
                                                {
                                                    if (!dis[ii])
                                                    {
                                                        orders[Rha[jj, ii].conf] += Rha[II, ii].value;
                                                    }
                                                }
                                            ////////////////////T computation
                                            double T = 0;
                                            double sorat = 0;
                                            for (int hh2 = 0; hh2 < Nconf; hh2++)
                                            {
                                                if (!dis[hh2])
                                                {
                                                    sorat += Math.Pow(orders[hh2] - (((II + 1) * Nconf + 1) / 2), 2);
                                                }
                                            }
                                            sorat = sorat * (Nconf - 1);
                                            double makhraj = 0;
                                            for (int hh = 0; hh < II + 1; hh++)
                                            {
                                                for (int hh2 = 0; hh2 < Nconf; hh2++)
                                                {
                                                    if (!dis[hh2])
                                                    {
                                                        makhraj += Math.Pow(Rha[hh, hh2].conf, 2);
                                                    }
                                                }
                                            }

                                            makhraj = makhraj - ((II * Nconf * Math.Pow((Nconf + 1), 2)) / 4);
                                            T = sorat / makhraj;
                                            ////////////////
                                            double alpha2 = 0.05;
                                            double quantile1 = LH_Class.get_t_quantile(alpha2, II + 1, t_table); //getStudentT(alpha, rows);
                                            if (T <= quantile1)
                                            {

                                            }
                                            else
                                            {
                                                //calculating T2 (pair-wise test), when needed
                                                double T2, quantile2 = LH_Class.get_t_quantile(alpha2, II + 1, t_table, true);
                                                double best_score = -1;
                                                for (int j = 0; j < Nconf; j++)
                                                {

                                                    if (orders[j] > best_score || best_score == -1)
                                                    {
                                                        best_score = orders[j];
                                                        best_cand = j;
                                                    }
                                                }
                                                makhraj *= Math.Abs((2 * (II + 1)) * (1 - (T / ((II + 1) * (Nconf - 1)))));
                                                makhraj /= ((II + 1) * (Nconf - 1));
                                                for (int j = 0; j < Nconf; j++)
                                                    if (!dis[j])
                                                    {
                                                        if (j != best_cand)
                                                        {
                                                            double diff = orders[best_cand] - orders[j];
                                                            if (diff < 0) diff *= (-1);
                                                            T2 = diff / Math.Sqrt(makhraj);
                                                            if (diff / Math.Sqrt(makhraj) > quantile2)
                                                            {
                                                                dis[j] = true;
                                                                dis_conf++;
                                                                orders[j] = 0;
                                                            }
                                                        }
                                                    }
                                            }
                                            ////////////////////
                                            ins_count = II;
                                        }
                                        //////////////////////////////////////////Select The best///////////////////////////////////
                                        int remainder = Nconf - dis_conf;
                                        int[] rz = new int[Nconf];
                                        int kk2 = 0;
                                        for (int ii = 0; ii < rz.Length; ii++)
                                        {
                                            if (!dis[ii])
                                            {
                                                rz[Rha[ins_count, ii].conf] = kk2 + 1;
                                                kk2++;
                                            }
                                        }
                                        double[] Pz = new double[remainder];
                                        double rands = RR.NextDouble();
                                        kk2 = 0;
                                        for (int ii = 0; ii < Nconf; ii++)
                                        {
                                            if (!dis[ii])
                                            {
                                                if (kk2 == 0)
                                                    Pz[kk2] = Convert.ToDouble(remainder - orders[ii] + 1) / (remainder * (remainder + 1) / 2);
                                                else
                                                    Pz[kk2] = Convert.ToDouble(remainder - orders[ii] + 1) / (remainder * (remainder + 1) / 2) + Pz[kk2 - 1];
                                                if (Pz[kk2] > rands)
                                                {
                                                    best_cand = Rha[ins_count, ii].conf;
                                                    break;
                                                }
                                                kk2++;
                                            }
                                        }
                                        ///////////////////////////////////////////////////////////////////////////////////////////


                                        Bused += Bj[IT];
                                        double lboundCW = 0;
                                        double uboundCW = 10;
                                        double l_lg = 0;
                                        double u_lg = 1;
                                        int Mue = 5 + IT + 1;
                                        double deltad_menfi_yekCW = (uboundCW - lboundCW) / 2;
                                        double deltad_menfi_yek_lg = (u_lg - l_lg) / 2;
                                        int symbol = 0;
                                        Bj[IT + 1] = (Bwhole - Bused) / (Niter - IT + 1);
                                        int Nconf_perv = Nconf;
                                        Nconf = Convert.ToInt32(Bj[IT + 1] / (Mue + Math.Min(5, IT + 1))) - remainder;// (Nconf-dis_conf) is equal the remainder of perv_conf
                                        if (Nconf < 1)
                                        {
                                            break;
                                        }
                                        double deltad_CW = deltad_menfi_yekCW * Math.Pow((1.0 / Nconf), ((double)IT) / Npar);
                                        double delta_lg = deltad_menfi_yek_lg * Math.Pow((1.0 / Nconf), ((double)IT) / Npar);
                                        float[,] PervConf = (float[,])Configuration.Clone();
                                        Configuration = new float[Nconf + remainder, Npar];
                                        ///////C1 , C2 , W, r_lg
                                        for (int jj = 0; jj < Nconf; jj++)
                                        {
                                            for (kk2 = 0; kk2 < Npar - 1; kk2++)
                                            {
                                                symbol = RR.Next(0, 2);
                                                if (symbol == 0)
                                                    Configuration[jj, kk2] = Convert.ToSingle(PervConf[best_cand, kk2] + deltad_CW * RR.NextDouble());
                                                else
                                                    Configuration[jj, kk2] = Convert.ToSingle(PervConf[best_cand, kk2] - deltad_CW * RR.NextDouble());
                                            }
                                            symbol = RR.Next(0, 2);
                                            if (symbol == 0)
                                                Configuration[jj, Npar - 1] = Convert.ToSingle(PervConf[best_cand, Npar - 1] + delta_lg * RR.NextDouble());
                                            else
                                                Configuration[jj, Npar - 1] = Convert.ToSingle(PervConf[best_cand, Npar - 1] - delta_lg * RR.NextDouble());
                                        }
                                        int iii = Nconf;
                                        for (int jj = 0; jj < Nconf_perv; jj++)
                                        {
                                            if (!dis[jj])
                                            {
                                                for (kk2 = 0; kk2 < Npar; kk2++)
                                                {
                                                    Configuration[iii, kk2] = PervConf[jj, kk2];
                                                }
                                                iii++;
                                            }
                                        }
                                        Nconf = Nconf + remainder;// the set of perv_conf+ curr_conf
                                        dis_conf = 0;
                                    }
                                    sw = new StreamWriter(ss);
                                    for (int ii = 0; ii < Npar; ii++)
                                    {
                                        sw.WriteLine(Configuration[best_cand, ii]);
                                    }
                                    sw.Close();

                                }
                            }
                        }

                        #endregion
                        else
                        {
                            #region Maximin

                            #region GA
                            if (method == "Genetic")
                            {
                                int min_index = 0;
                                //double mu1 = Convert.ToDouble(Mu1.Text);
                                //double mu2 = Convert.ToDouble(Mu2.Text);
                                //double mu_step = Convert.ToDouble(Mu_step.Text);
                                //double cro1 = Convert.ToDouble(cr1.Text);
                                //double cro2 = Convert.ToDouble(cr2.Text);
                                //double cro_step = Convert.ToDouble(cr_step.Text);
                                double[] MU_s = { 0.0001, 0.001, 0.005, 0.01, 0.1 };
                                double[] CR_s = { 0.2, 0.4, 0.6, 0.8, 1 };
                                for (int iii = 0; iii < 5; iii++)
                                    for (int jjj = 0; jjj < 5; jjj++)
                                    {
                                        double mu_rate = MU_s[iii];
                                        double cr_rate = CR_s[jjj];
                                        ss = "Result_N_" + N.ToString() + "P_" + P.ToString() + "pop_" + NPop.ToString() + method + "_cr_" + cr_rate.ToString() + "_mu_rate_" + mu_rate.ToString() + "_test_" + Ntest.ToString() + ".txt";
                                        ss2 = "fit_N_" + N.ToString() + "P_" + P.ToString() + "pop_" + NPop.ToString() + method + "_cr_" + cr_rate.ToString() + "_mu_rate_" + mu_rate.ToString() + "_test_" + Ntest.ToString() + ".txt";
                                        #region file_existency
                                        if (!File.Exists(ss))
                                        {
                                            for (int tt = 0; tt < Ntest; tt++)
                                            {
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
                                                }
                                                costs[tt] = Best_indi.F;
                                                Nodes_test[tt].LH = (int[,])Best_indi.LH.Clone();
                                            }


                                            sw = new StreamWriter(ss);
                                            for (int tt = 0; tt < Ntest; tt++)
                                            {
                                                for (int ii = 0; ii < N; ii++)
                                                {
                                                    for (int jj = 0; jj < P; jj++)
                                                    {
                                                        sw.Write(Nodes_test[tt].LH[ii, jj].ToString() + " ");
                                                    }
                                                    sw.WriteLine();
                                                }
                                            }
                                            sw.Close();
                                            sw = new StreamWriter(ss2);
                                            for (int tt = 0; tt < Ntest; tt++)
                                            {
                                                sw.Write(costs[tt].ToString() + " ");
                                            }
                                            sw.Close();

                                        }
                                        #endregion
                                    }

                            }
                            #endregion
                            #region SA
                            else if (method == "SA")
                            {

                                int it = 0;
                                double[] T_s = { 1 };
                                double[] cr_s = { 0.8, 0.85, 0.9, 0.95, 0.99 };
                                for (int T_index = 0; T_index < T_s.Length; T_index++)
                                    for (int C_index = 0; C_index < cr_s.Length; C_index++)
                                    {
                                        double T = T_s[T_index];
                                        double cr = cr_s[C_index];
                                        double M = P * (P - 1) * N;
                                        ss = "Result_N_" + N.ToString() + "P_" + P.ToString() + "_col_rate" + cr.ToString() + "_N_" + M.ToString() + "T_" + T.ToString() + method + "_test" + Ntest.ToString() + ".txt";
                                        ss2 = "fit_N_" + N.ToString() + "P_" + P.ToString() + "_col_rate" + cr.ToString() + "_N_" + M.ToString() + "T_" + T.ToString() + method + "_test" + Ntest.ToString() + ".txt";
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
                                                double Z_best = -10000;
                                                //if (Criterion == "Maximin")
                                                //    z1 = LH_Class.F_Maximin(LH, N, P);
                                                //else
                                                z1 = LH_Class.F_Maximin(LH, N, P);
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
                                                        double z2 = -10000;
                                                        z2 = LH_Class.F_Maximin(LH_temp, N, P);
                                                        #region Maxmin
                                                        if (Criterion == "Maximin")
                                                        {
                                                            dz = z1 - z2;
                                                            if (z2 < z1 || Math.Exp(-dz / T) > rr.NextDouble())
                                                            {
                                                                LH = (int[,])LH_temp.Clone();
                                                                z2 = z1;
                                                            }
                                                            if (dz > 0)
                                                                I++;
                                                            if (Z_best < z2)
                                                            {
                                                                Z_best = z2;
                                                            }
                                                        }
                                                        #endregion
                                                        it++;
                                                    }
                                                    T = T * cr;
                                                }
                                                costs[tt] = Z_best;
                                                Nodes_test[tt].LH = (int[,])LH.Clone();
                                            }


                                            sw = new StreamWriter(ss);
                                            for (int tt = 0; tt < Ntest; tt++)
                                            {
                                                for (int ii = 0; ii < N; ii++)
                                                {
                                                    for (int jj = 0; jj < P; jj++)
                                                    {
                                                        sw.Write(Nodes_test[tt].LH[ii, jj].ToString() + " ");
                                                    }
                                                    sw.WriteLine();
                                                }
                                            }
                                            sw.Close();
                                            sw = new StreamWriter(ss2);
                                            for (int tt = 0; tt < Ntest; tt++)
                                            {
                                                sw.Write(costs[tt].ToString() + " ");
                                            }
                                            sw.Close();
                                        }
                                    }

                            }
                            #endregion
                            #region CP
                            else if (method == "CP")
                            {
                                int it = 0;
                                ss = "Result_N_" + N.ToString() + "P_" + P.ToString() + method + "_test" + Ntest.ToString() + ".txt";
                                ss2 = "fit_N_" + N.ToString() + "P_" + P.ToString() + method + "_test" + Ntest.ToString() + ".txt";
                                if (!File.Exists(ss))
                                {
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        it = 0;
                                        int[,] LH = LH_Class.constructing_Latin_hypercube(N, P, rr);
                                        double Z = 0;
                                        int MaxIter = Iteration * NPop;
                                        while (it < MaxIter)
                                        {

                                            int[,] LH_temp = (int[,])LH.Clone();
                                            double z1 = LH_Class.F_Maximin(LH_temp, N, P);
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
                                                            double z2 = LH_Class.F_Maximin(LH_temp, N, P);
                                                            double dz = z2 - z1;
                                                            if (dz > 0)
                                                            {
                                                                LH = (int[,])LH_temp.Clone();
                                                                z1 = z2;
                                                            }
                                                        }
                                                        it++;
                                                    }
                                            }
                                            Z = z1;
                                        }
                                        costs[tt] = Z;
                                        Nodes_test[tt].LH = (int[,])LH.Clone();
                                    }


                                    sw = new StreamWriter(ss);
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        for (int ii = 0; ii < N; ii++)
                                        {
                                            for (int jj = 0; jj < P; jj++)
                                            {
                                                sw.Write(Nodes_test[tt].LH[ii, jj].ToString() + " ");
                                            }
                                            sw.WriteLine();
                                        }
                                    }
                                    sw.Close();
                                    sw = new StreamWriter(ss2);
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        sw.Write(costs[tt].ToString() + " ");
                                    }
                                    sw.Close();
                                }


                            }
                            #endregion
                            #region MOA
                            else if (method == "MOAOriginal")
                            {
                                double short_range = 0.01;
                                int acceleration = Convert.ToInt32(Ac.Text);
                                int Distance = Convert.ToInt32(D.Text);
                                double[] Magnet = new double[NPop];
                                double[] Mass = new double[NPop];
                                double al1 = Convert.ToDouble(Al.Text);
                                double al2 = Convert.ToDouble(Al2.Text);
                                double al_step = Convert.ToDouble(Al_step.Text);
                                double in1 = Convert.ToDouble(Inten.Text);
                                double in2 = Convert.ToDouble(Inten2.Text);
                                double in_step = Convert.ToDouble(Inten_step.Text);
                                for (double alpha = al1; alpha < al2; alpha += al_step)
                                    for (double intensity = in1; intensity < al2; intensity += in_step)
                                    {
                                        ss = "Result_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_intensity" + intensity.ToString() + "_alpha_" + alpha.ToString() + "_Dis_" + method + Distance.ToString() + "_Acc_" + Ac.Text + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + "_struct_" + structure + ".txt";
                                        ss2 = "fit_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_intensity" + intensity.ToString() + "alpha_" + alpha.ToString() + "_Dis_" + method + Distance.ToString() + "_Acc_" + Ac.Text + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + "_struct_" + structure + ".txt";
                                        if (!File.Exists(ss))
                                        {
                                            for (int tt = 0; tt < Ntest; tt++)
                                            {
                                                MOA_Node[] Nodes = new MOA_Node[NPop];
                                                MOA_Node[] Forces = new MOA_Node[NPop];
                                                MOA_Node[] a = new MOA_Node[NPop];
                                                MOA_Node[] v = new MOA_Node[NPop];
                                                Latin_Hypercube[] LHC = new Latin_Hypercube[NPop];
                                                Latin_Hypercube Best_indi = new Latin_Hypercube();
                                                double[] distances = new double[NPop];
                                                Best_indi.F = 1000;

                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    Forces[ii].x = new double[N, P];
                                                    a[ii].x = new double[N, P];
                                                    v[ii].x = new double[N, P];
                                                }
                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    Nodes[ii].x = LH_Class.node_constructing(N, P, rr);
                                                }
                                                for (int it = 0; it < Iteration; it++)
                                                {
                                                    Fmax = 0; Fmin = 1000;
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
                                                    }
                                                    double range = Fmax - Fmin;
                                                    for (int ii = 0; ii < NPop; ii++)
                                                    {
                                                        Magnet[ii] = (Fmax - LHC[ii].F) / (range);
                                                        Mass[ii] = Magnet[ii] * intensity + alpha;
                                                    }

                                                    for (int ii = 0; ii < NPop; ii++)
                                                    {
                                                        Forces[ii].x = new double[N, P];
                                                    }
                                                    for (int ii = 0; ii < NPop; ii++)
                                                    {
                                                        int[] Neigbour = LH_Class.Structures(ii, NPop, structure, rr);
                                                        for (int jj = 0; jj < Neigbour.Length; jj++)
                                                        {
                                                            if (ii != Neigbour[jj])
                                                            {
                                                                if (D.Text == "1")
                                                                    distances[ii] = distance1(Nodes[ii].x, Nodes[Neigbour[jj]].x, N, P);
                                                                else
                                                                    distances[ii] = distance4(LHC[ii].LH, LHC[Neigbour[jj]].LH, N, P);
                                                                if (distances[ii] > short_range)
                                                                {
                                                                    for (int n = 0; n < N; n++)
                                                                        for (int p = 0; p < P; p++)
                                                                            Forces[ii].x[n, p] = Forces[ii].x[n, p] + (Nodes[Neigbour[jj]].x[n, p] - Nodes[ii].x[n, p]) * Magnet[Neigbour[jj]] / distances[ii];

                                                                }

                                                                else
                                                                {
                                                                    for (int n = 0; n < N; n++)
                                                                        for (int p = 0; p < P; p++)
                                                                        {
                                                                            Forces[ii].x[n, p] = rr.NextDouble();
                                                                        }
                                                                    Nodes[ii].x = LH_Class.node_constructing(N, P, rr);
                                                                }
                                                            }
                                                        }
                                                        //for (int n = 0; n < N; n++)
                                                        //    for (int p = 0; p < P; p++)
                                                        //    {
                                                        //        Forces[ii].x[n, p] = Forces[ii].x[n, p] / (NPop - 1);
                                                        //        //Forces[ii].x[n, p] = Forces[ii].x[n, p] * rr.NextDouble();
                                                        //    }

                                                    }
                                                    if (acceleration == 0)
                                                    {
                                                        for (int ii = 0; ii < NPop; ii++)
                                                        {
                                                            for (int n = 0; n < N; n++)
                                                                for (int p = 0; p < P; p++)
                                                                {
                                                                    v[ii].x[n, p] = (Forces[ii].x[n, p] / Mass[ii]);
                                                                    Nodes[ii].x[n, p] = Nodes[ii].x[n, p] + v[ii].x[n, p];
                                                                }

                                                            Nodes[ii].x = Node_treatment(Nodes[ii].x, N, P, rr);
                                                        }
                                                    }
                                                    else if (acceleration == 1)
                                                    {
                                                        for (int ii = 0; ii < NPop; ii++)
                                                        {
                                                            for (int n = 0; n < N; n++)
                                                                for (int p = 0; p < P; p++)
                                                                {
                                                                    a[ii].x[n, p] = (Forces[ii].x[n, p] / Mass[ii]);
                                                                    v[ii].x[n, p] = v[ii].x[n, p] * rr.NextDouble() + a[ii].x[n, p];
                                                                    Nodes[ii].x[n, p] = Nodes[ii].x[n, p] + v[ii].x[n, p];
                                                                }

                                                            Nodes[ii].x = Node_treatment(Nodes[ii].x, N, P, rr);
                                                        }
                                                    }


                                                }
                                                costs[tt] = Best_indi.F;
                                                Nodes_test[tt].LH = (int[,])Best_indi.LH.Clone();
                                            }
                                            sw = new StreamWriter(ss);
                                            for (int tt = 0; tt < Ntest; tt++)
                                            {
                                                for (int ii = 0; ii < N; ii++)
                                                {
                                                    for (int jj = 0; jj < P; jj++)
                                                    {
                                                        sw.Write(Nodes_test[tt].LH[ii, jj].ToString() + " ");
                                                    }
                                                    sw.WriteLine();
                                                }
                                            }
                                            sw.Close();
                                            sw = new StreamWriter(ss2);
                                            for (int tt = 0; tt < Ntest; tt++)
                                            {
                                                sw.Write(costs[tt].ToString() + " ");
                                            }
                                            sw.Close();
                                        }
                                    }
                            }
                            #endregion
                            #region MOA2
                            else if (method == "MOA2")
                            {
                                double[,] divers = new double[Ntest, Iteration];
                                double[,] fitnesses = new double[Ntest, Iteration];
                                double short_range = Convert.ToDouble(SHR.Text);
                                int acceleration = Convert.ToInt32(Ac.Text);
                                int Distance = Convert.ToInt32(D.Text);
                                double[] Magnet = new double[NPop];
                                double[] Mass = new double[NPop];
                                double al1 = Convert.ToDouble(Al.Text);
                                double al2 = Convert.ToDouble(Al2.Text);
                                double al_step = Convert.ToDouble(Al_step.Text);
                                double in1 = Convert.ToDouble(Inten.Text);
                                double in2 = Convert.ToDouble(Inten2.Text);
                                double in_step = Convert.ToDouble(Inten_step.Text);
                                for (double alpha = al1; alpha <= al2; alpha += al_step)
                                    for (double intensity = in1; intensity <= in2; intensity += in_step)
                                    {
                                        ss = "Result_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_intensity" + intensity.ToString() + "_alpha_" + alpha.ToString() + "_Dis_" + method + Distance.ToString() + "_Acc_" + Ac.Text + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + ".txt";
                                        ss2 = "fit_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_intensity" + intensity.ToString() + "alpha_" + alpha.ToString() + "_Dis_" + method + Distance.ToString() + "_Acc_" + Ac.Text + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + ".txt";
                                        string ss3 = "Fiter_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_intensity" + intensity.ToString() + "alpha_" + alpha.ToString() + "_Dis_" + method + Distance.ToString() + "_Acc_" + Ac.Text + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + ".txt";
                                        string ss4 = "Diver_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_intensity" + intensity.ToString() + "alpha_" + alpha.ToString() + "_Dis_" + method + Distance.ToString() + "_Acc_" + Ac.Text + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + ".txt";
                                        if (!File.Exists(ss))
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
                                                Latin_Hypercube Best_indi = new Latin_Hypercube();
                                                double[] distances = new double[NPop];
                                                Best_indi.F = 1000;

                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    Forces[ii].x = new double[N, P];
                                                    a[ii].x = new double[N, P];
                                                    v[ii].x = new double[N, P];
                                                }
                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    Nodes[ii].x = LH_Class.node_constructing(N, P, rr);
                                                    BNodes[ii].x = (double[,])Nodes[ii].x.Clone();
                                                }
                                                for (int it = 0; it < Iteration; it++)
                                                {
                                                    Fmax = 0; Fmin = 1000;
                                                    int min_index = 0; int max_index = 0;
                                                    for (int ii = 0; ii < NPop; ii++)
                                                    {
                                                        LHC[ii].LH = LH_Class.convert_search_s_to_solution_s(Nodes[ii].x, N, P);
                                                        LHC[ii].F = LH_Class.F(LHC[ii].LH, N, P);
                                                        B[ii].F = LHC[ii].F;
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
                                                    }
                                                    double range = Fmax - Fmin;
                                                    for (int ii = 0; ii < NPop; ii++)
                                                    {
                                                        Magnet[ii] = (Fmax - LHC[ii].F) / (range);
                                                        Mass[ii] = Magnet[ii] * intensity + alpha;
                                                    }
                                                    BNodes = LH_Class.cellular(LHC, B, Nodes, BNodes, NPop);
                                                    for (int ii = 0; ii < NPop; ii++)
                                                    {
                                                        Forces[ii].x = new double[N, P];
                                                    }
                                                    for (int ii = 0; ii < NPop; ii++)
                                                    {
                                                        distances[ii] = distance1(Nodes[ii].x, BNodes[ii].x, N, P);
                                                        //if (distances[ii] > short_range)
                                                        //{
                                                        for (int n = 0; n < N; n++)
                                                            for (int p = 0; p < P; p++)
                                                                Forces[ii].x[n, p] = Forces[ii].x[n, p] + (BNodes[ii].x[n, p] - Nodes[ii].x[n, p]) * Magnet[BNodes[ii].index] / distances[ii];

                                                        //}
                                                        //else
                                                        //{
                                                        //for (int n = 0; n < N; n++)
                                                        //    for (int p = 0; p < P; p++)
                                                        //    {
                                                        //        Forces[ii].x[n, p] = rr.NextDouble();
                                                        //    }
                                                        //Nodes[ii].x = LH_Class.node_constructing(N, P, rr);
                                                        //}

                                                        //for (int n = 0; n < N; n++)
                                                        //    for (int p = 0; p < P; p++)
                                                        //    {
                                                        //        //Forces[ii].x[n, p] =  Forces[ii].x[n, p] /(NPop-1);
                                                        //        Forces[ii].x[n, p] = Forces[ii].x[n, p] * rr.NextDouble();
                                                        //    }
                                                    }
                                                    if (acceleration == 0)
                                                    {
                                                        for (int ii = 0; ii < NPop; ii++)
                                                        {
                                                            for (int n = 0; n < N; n++)
                                                                for (int p = 0; p < P; p++)
                                                                {
                                                                    v[ii].x[n, p] = (Forces[ii].x[n, p] / Mass[ii]) * rr.NextDouble();
                                                                    Nodes[ii].x[n, p] = Nodes[ii].x[n, p] + v[ii].x[n, p];
                                                                }

                                                            Nodes[ii].x = Node_treatment(Nodes[ii].x, N, P, rr);
                                                        }
                                                    }
                                                    else if (acceleration == 1)
                                                    {
                                                        for (int ii = 0; ii < NPop; ii++)
                                                        {
                                                            for (int n = 0; n < N; n++)
                                                                for (int p = 0; p < P; p++)
                                                                {
                                                                    a[ii].x[n, p] = (Forces[ii].x[n, p] / Mass[ii]);
                                                                    v[ii].x[n, p] = v[ii].x[n, p] * rr.NextDouble() + a[ii].x[n, p];
                                                                    Nodes[ii].x[n, p] = Nodes[ii].x[n, p] + v[ii].x[n, p];
                                                                }

                                                            Nodes[ii].x = Node_treatment(Nodes[ii].x, N, P, rr);
                                                        }
                                                    }

                                                    divers[tt, it] = LH_Class.diversity(LHC, NPop, N, P);
                                                    fitnesses[tt, it] = LH_Class.best_for_iter(LHC, NPop);

                                                }
                                                costs[tt] = Best_indi.F;
                                                Nodes_test[tt].LH = (int[,])Best_indi.LH.Clone();
                                            }
                                            sw = new StreamWriter(ss);
                                            for (int tt = 0; tt < Ntest; tt++)
                                            {
                                                for (int ii = 0; ii < N; ii++)
                                                {
                                                    for (int jj = 0; jj < P; jj++)
                                                    {
                                                        sw.Write(Nodes_test[tt].LH[ii, jj].ToString() + " ");
                                                    }
                                                    sw.WriteLine();
                                                }
                                            }
                                            sw.Close();
                                            sw = new StreamWriter(ss2);
                                            for (int tt = 0; tt < Ntest; tt++)
                                            {
                                                sw.Write(costs[tt].ToString() + " ");
                                            }
                                            sw.Close();
                                            sw = new StreamWriter(ss3);
                                            for (int ii = 0; ii < Ntest; ii++)
                                            {
                                                for (int jj = 0; jj < Iteration; jj++)
                                                    sw.Write(fitnesses[ii, jj].ToString() + "  ");
                                                sw.WriteLine();
                                            }
                                            sw.Close();
                                            sw = new StreamWriter(ss4);
                                            for (int ii = 0; ii < Ntest; ii++)
                                            {
                                                for (int jj = 0; jj < Iteration; jj++)
                                                    sw.Write(divers[ii, jj].ToString() + "  ");
                                                sw.WriteLine();
                                            }
                                            sw.Close();
                                        }
                                    }
                            }
                            #endregion
                            #region MOA3
                            else if (method == "MOA")
                            {
                                // Frankenstein MOA parameters
                                //int estep = 0;
                                int k = NPop * 2;
                                double T = 0.1;
                                ////////////////////////////////////
                                ArrayList[] Neighbors = new ArrayList[NPop];
                                for (int ii = 0; ii < NPop; ii++)
                                {
                                    Neighbors[ii] = new ArrayList();
                                    for (int jj = 0; jj < NPop; jj++)
                                        if (ii != jj)
                                            Neighbors[ii].Add(jj);
                                }
                                double[,] divers = new double[Ntest, Iteration];
                                double[,] fitnesses = new double[Ntest, Iteration];
                                double CExp = Convert.ToDouble(Cexp_text.Text);
                                double TExp = Convert.ToDouble(TExp_text.Text);
                                int ISSR = Convert.ToInt32(ISSR_combo.Text);
                                double CSRR = Convert.ToDouble(CSRR_text.Text);
                                double core_effect = Convert.ToDouble(CE.Text);
                                double opposed_core_effect = 1 - core_effect;
                                //int zetta = 2;
                                //int portion = (Iteration / NPop)*zetta;
                                //if (orgMOA.Checked)
                                //    opposed_core_effect = 1;
                                //else
                                //    method = "MOA_opt";
                                double short_range = Convert.ToDouble(SHR.Text);
                                int acceleration = Convert.ToInt32(Ac.Text);
                                int Distance = Convert.ToInt32(D.Text);
                                double[] Magnet = new double[NPop];
                                double[] Mass = new double[NPop];
                                double intensity = 1;
                                double alpha = 0.1;
                                ss = "Res_N_" + N.ToString() + "P_" + P.ToString() + "T_" + T.ToString() + "_Tcc" + TC.Text.ToString() + "_ce_" + core_effect.ToString() + "_Pop_" + NPop.ToString() + "_int" + intensity.ToString() + "_al_" + alpha.ToString() + "_Dis_" + method + Distance.ToString() + "_Acc_" + Ac.Text + "_It_" + Iteration.ToString() + "_t_" + Ntest.ToString() + "_str_" + structure + ".txt";
                                ss2 = "fit_N_" + N.ToString() + "P_" + P.ToString() + "T_" + T.ToString() + "_Tcc" + TC.Text.ToString() + "_ce_" + core_effect.ToString() + "_Pop_" + NPop.ToString() + "_int" + intensity.ToString() + "al_" + alpha.ToString() + "_Dis_" + method + Distance.ToString() + "_Acc_" + Ac.Text + "_It_" + Iteration.ToString() + "_t_" + Ntest.ToString() + "_str_" + structure + ".txt";
                                string ss3 = "Fiter_N_" + N.ToString() + "P_" + P.ToString() + "T_" + T.ToString() + "_Tcc" + TC.Text.ToString() + "_ce_" + core_effect.ToString() + "_Pop_" + NPop.ToString() + "_int" + intensity.ToString() + "_al_" + alpha.ToString() + "_Dis_" + method + Distance.ToString() + "_Acc_" + Ac.Text + "_It_" + Iteration.ToString() + "_t_" + Ntest.ToString() + "_str_" + structure + ".txt";
                                string ss4 = "Diver_N_" + N.ToString() + "P_" + P.ToString() + "_Tcc" + TC.Text.ToString() + "_ce_" + core_effect.ToString() + "_Pop_" + NPop.ToString() + "_int" + intensity.ToString() + "al_" + alpha.ToString() + "_Dis_" + method + Distance.ToString() + "_Acc_" + Ac.Text + "_It_" + Iteration.ToString() + "_t_" + Ntest.ToString() + "_str_" + structure + ".txt";
                                if (!File.Exists(ss))
                                {
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        core_effect = Convert.ToDouble(CE.Text);
                                        T = 0.1;

                                        MOA_Node[] Nodes = new MOA_Node[NPop];
                                        MOA_Node[] BNodes = new MOA_Node[NPop];
                                        MOA_Node Best_node = new MOA_Node();
                                        MOA_Node[] Forces = new MOA_Node[NPop];
                                        MOA_Node[] a = new MOA_Node[NPop];
                                        MOA_Node[] v = new MOA_Node[NPop];
                                        Latin_Hypercube[] LHC = new Latin_Hypercube[NPop];
                                        Latin_Hypercube[] B = new Latin_Hypercube[NPop];
                                        Latin_Hypercube Best_indi = new Latin_Hypercube();
                                        double[] distances = new double[NPop];
                                        Best_indi.F = 1000;
                                        int running_update_time = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(Iteration / (NPop - 3))));
                                        int declination_range = (2 * Iteration) / NPop;
                                        int L = NPop / 2;
                                        for (int ii = 0; ii < NPop; ii++)
                                        {
                                            Forces[ii].x = new double[N, P];
                                            a[ii].x = new double[N, P];
                                            v[ii].x = new double[N, P];
                                        }
                                        for (int ii = 0; ii < NPop; ii++)
                                        {
                                            Nodes[ii].x = LH_Class.node_constructing(N, P, rr);
                                            BNodes[ii].x = (double[,])Nodes[ii].x.Clone();
                                            BNodes[ii].f = 10000;
                                        }
                                        for (int it = 0; it < Iteration; it++)
                                        {
                                            Fmax = 0; Fmin = 1000;
                                            int min_index = 0; int max_index = 0;
                                            for (int ii = 0; ii < NPop; ii++)
                                            {
                                                LHC[ii].LH = LH_Class.convert_search_s_to_solution_s(Nodes[ii].x, N, P);
                                                LHC[ii].F = LH_Class.F(LHC[ii].LH, N, P);
                                                B[ii].F = LHC[ii].F;
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
                                                Best_node.x = (double[,])Nodes[min_index].x.Clone();
                                            }
                                            if (Exp.Text == "YES")
                                            {
                                                double div = LH_Class.diversity(LHC, NPop, N, P);
                                                if (div < TExp)
                                                {
                                                    for (int ii = 0; ii < NPop; ii++)
                                                        for (int jj = 0; jj < N; jj++)
                                                            for (int kk = 0; kk < P; kk++)
                                                            {
                                                                Nodes[ii].x[jj, kk] += 2 * CExp * rr.NextDouble() - CExp;
                                                            }
                                                }
                                            }
                                            double range = Fmax - Fmin;
                                            for (int ii = 0; ii < NPop; ii++)
                                            {
                                                Magnet[ii] = (Fmax - LHC[ii].F) / (range);
                                                Mass[ii] = Magnet[ii] * intensity + alpha;
                                            }
                                            //if (structure == "Frankenstein")
                                            //{
                                            //    LH_Class.Topology_Update2(ref Neighbors,NPop,rr,it,running_update_time);
                                            //    BNodes=LH_Class.Define_Local_Best(Neighbors,LHC,Nodes,BNodes,NPop);
                                            //}
                                            if (structure != "Dynamic" && structure != "RDynamic" && structure != "RRDynamic")
                                                BNodes = LH_Class.StructureCore(LHC, Nodes, BNodes, NPop, structure, rr);
                                            //else if(structure !="Frankenstein")
                                            //    BNodes = LH_Class.DynamicStructureCore3(LHC, B, Nodes, BNodes,portion, it, NPop,rr);
                                            for (int ii = 0; ii < NPop; ii++)
                                            {
                                                Forces[ii].x = new double[N, P];
                                            }
                                            for (int ii = 0; ii < NPop; ii++)
                                            {
                                                #region reaching to core
                                                if (D.Text == "1")
                                                    distances[ii] = distance1(Nodes[ii].x, BNodes[ii].x, N, P);
                                                else if (D.Text == "2")
                                                    distances[ii] = distance2(Nodes[ii].x, BNodes[ii].x, N, P);
                                                else if (D.Text == "3")
                                                    distances[ii] = distance3(Nodes[ii].x, BNodes[ii].x, N, P);
                                                else if (D.Text == "4")
                                                    distances[ii] = distance4(LHC[ii].LH, LHC[BNodes[ii].index].LH, N, P);

                                                // reducing core effect
                                                opposed_core_effect = 1 - core_effect;
                                                //
                                                //if (distances[ii] > short_range)
                                                //{
                                                for (int n = 0; n < N; n++)
                                                    for (int p = 0; p < P; p++)
                                                        Forces[ii].x[n, p] = Forces[ii].x[n, p] + (BNodes[ii].x[n, p] - Nodes[ii].x[n, p]) * Magnet[BNodes[ii].index] * core_effect / distances[ii];

                                                //}
                                                //else
                                                //{

                                                //    if (ISSR == 1)
                                                //    {
                                                //        int dim = Convert.ToInt32(Math.Ceiling(CSRR * N));
                                                //        int Points = Convert.ToInt32(Math.Ceiling(CSRR * P));
                                                //        LH_Class.Short_Range_Operation1(ref Nodes[ii].x, dim, Points, P, rr);
                                                //    }
                                                //    else if (ISSR == 2)
                                                //    {
                                                //        LH_Class.Short_Range_Operation2(ref Nodes[ii].x, N, P, CSRR, rr);
                                                //    }
                                                //    else if (ISSR == 3)
                                                //    {
                                                //        LH_Class.Short_Range_Operation3(ref Forces[ii].x, N, P, CSRR, rr);
                                                //    }
                                                //    else
                                                //    {
                                                //        //Do nothing when the selected option is the basic MOA
                                                //    }
                                                //}
                                                #endregion
                                                #region particles effect
                                                if (opposed_core_effect > 0)
                                                {
                                                    int[] Neigbour = LH_Class.Structures(ii, NPop, structure, rr);
                                                    for (int jj = 0; jj < Neigbour.Length; jj++)
                                                    {
                                                        if (ii != Neigbour[jj] && Nodes[ii].index != jj)
                                                        {
                                                            if (D.Text == "1")
                                                                distances[ii] = distance1(Nodes[ii].x, Nodes[Neigbour[jj]].x, N, P);
                                                            else if (D.Text == "2")
                                                                distances[ii] = distance2(Nodes[ii].x, Nodes[Neigbour[jj]].x, N, P);
                                                            else if (D.Text == "3")
                                                                distances[ii] = distance3(Nodes[ii].x, Nodes[Neigbour[jj]].x, N, P);
                                                            else
                                                                distances[ii] = distance4(LHC[ii].LH, LHC[Neigbour[jj]].LH, N, P);
                                                            if (distances[ii] > short_range)
                                                            {
                                                                for (int n = 0; n < N; n++)
                                                                    for (int p = 0; p < P; p++)
                                                                        Forces[ii].x[n, p] += (Nodes[Neigbour[jj]].x[n, p] - Nodes[ii].x[n, p]) * Magnet[Neigbour[jj]] * opposed_core_effect / distances[ii];

                                                            }


                                                            else
                                                            {
                                                                if (ISSR == 1)
                                                                {
                                                                    int dim = Convert.ToInt32(Math.Ceiling(CSRR * N));
                                                                    int Points = Convert.ToInt32(Math.Ceiling(CSRR * P));
                                                                    LH_Class.Short_Range_Operation1(ref Nodes[ii].x, dim, Points, P, rr);
                                                                }
                                                                else if (ISSR == 2)
                                                                {
                                                                    LH_Class.Short_Range_Operation2(ref Nodes[ii].x, N, P, CSRR, rr);
                                                                }
                                                                else if (ISSR == 3)
                                                                {
                                                                    LH_Class.Short_Range_Operation3(ref Forces[ii].x, N, P, CSRR, rr);
                                                                }
                                                                else
                                                                {
                                                                    //Do nothing when the selected option is the basic MOA
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                #endregion

                                            }
                                            if (acceleration == 0)
                                            {
                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    for (int n = 0; n < N; n++)
                                                        for (int p = 0; p < P; p++)
                                                        {
                                                            v[ii].x[n, p] = (Forces[ii].x[n, p] / Mass[ii]) * rr.NextDouble();
                                                            Nodes[ii].x[n, p] = Nodes[ii].x[n, p] + v[ii].x[n, p];
                                                            //Nodes[ii].x[n, p] = Nodes[ii].x[n, p] + v[ii].x[n, p] + (Best_node.x[n, p]-Nodes[ii].x[n, p])*T*rr.NextDouble() ;
                                                        }

                                                    Nodes[ii].x = Node_treatment(Nodes[ii].x, N, P, rr);
                                                }
                                            }
                                            else if (acceleration == 1)
                                            {
                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    for (int n = 0; n < N; n++)
                                                        for (int p = 0; p < P; p++)
                                                        {
                                                            a[ii].x[n, p] = (Forces[ii].x[n, p] / Mass[ii]);
                                                            v[ii].x[n, p] = v[ii].x[n, p] * rr.NextDouble() + a[ii].x[n, p];
                                                            Nodes[ii].x[n, p] = Nodes[ii].x[n, p] + v[ii].x[n, p];
                                                        }

                                                    Nodes[ii].x = Node_treatment(Nodes[ii].x, N, P, rr);
                                                }
                                            }
                                            divers[tt, it] = LH_Class.diversity(LHC, NPop, N, P);
                                            fitnesses[tt, it] = LH_Class.best_for_iter(LHC, NPop);
                                        }
                                        costs[tt] = Best_indi.F;
                                        Nodes_test[tt].LH = (int[,])Best_indi.LH.Clone();
                                    }
                                    sw = new StreamWriter(ss);
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        for (int ii = 0; ii < N; ii++)
                                        {
                                            for (int jj = 0; jj < P; jj++)
                                            {
                                                sw.Write(Nodes_test[tt].LH[ii, jj].ToString() + " ");
                                            }
                                            sw.WriteLine();
                                        }
                                    }
                                    sw.Close();
                                    sw = new StreamWriter(ss2);
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        sw.Write(costs[tt].ToString() + " ");
                                    }
                                    sw.Close();
                                    sw = new StreamWriter(ss3);
                                    for (int ii = 0; ii < Ntest; ii++)
                                    {
                                        for (int jj = 0; jj < Iteration; jj++)
                                            sw.Write(fitnesses[ii, jj].ToString() + "  ");
                                        sw.WriteLine();
                                    }
                                    sw.Close();
                                    sw = new StreamWriter(ss4);
                                    for (int ii = 0; ii < Ntest; ii++)
                                    {
                                        for (int jj = 0; jj < Iteration; jj++)
                                            sw.Write(divers[ii, jj].ToString() + "  ");
                                        sw.WriteLine();
                                    }
                                    sw.Close();
                                }

                            }
                            #endregion
                            #region MOAC
                            else if (method == "MOAC")
                            {
                                int acceleration = 0;
                                int Distance = 1;
                                double[] betta = { 0, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1 };
                                double gamma = 0.95;
                                int O = N * P * 1000000;
                                double intensity = 0.1;
                                double alpha = 1;
                                for (int jjj = 0; jjj < betta.Length; jjj++)
                                {
                                    Iteration = (Convert.ToInt32(2 * (O * (1 - betta[jjj])) / (NPop * N * P * (P - 1)))) + 1;
                                    int Individual_Learning = Convert.ToInt32((betta[jjj] * O) / (2 * N * P * Iteration));
                                    double[] Magnet = new double[NPop];
                                    double[] Mass = new double[NPop];
                                    double[,] divers = new double[Ntest, Iteration];
                                    double[,] fitnesses = new double[Ntest, Iteration];
                                    double core_effect = Convert.ToDouble(CE.Text);
                                    double opposed_core_effect = Convert.ToDouble(CE.Text);
                                    ss = "Res_N_" + N.ToString() + "P_" + P.ToString() + "gamma_" + gamma.ToString() + "_Pop_" + NPop.ToString() + "IL" + Individual_Learning.ToString() + "_int" + intensity.ToString() + "_al_" + alpha.ToString() + "_Dis_" + method + Distance.ToString() + "_Acc_" + Ac.Text + "_It_" + Iteration.ToString() + "_t_" + Ntest.ToString() + "_str_" + structure + ".txt";
                                    ss2 = "fit_N_" + N.ToString() + "P_" + P.ToString() + "gamma_" + gamma.ToString() + "_Pop_" + NPop.ToString() + "IL" + Individual_Learning.ToString() + "_int" + intensity.ToString() + "al_" + alpha.ToString() + "_Dis_" + method + Distance.ToString() + "_Acc_" + Ac.Text + "_It_" + Iteration.ToString() + "_t_" + Ntest.ToString() + "_str_" + structure + ".txt";
                                    //string ss3 = "Fiter_N_" + N.ToString() + "P_" + P.ToString() + "T_" + T_text.Text.ToString() +"_Pop_" + NPop.ToString() + "_int" + intensity.ToString() + "_al_" + alpha.ToString() + "_Dis_" + method + Distance.ToString() + "_Acc_" + Ac.Text + "_It_" + Iteration.ToString() + "_t_" + Ntest.ToString() + "_str_" + structure + ".txt";
                                    //string ss4 = "Diver_N_" + N.ToString() + "P_" + P.ToString() + "T_" + T_text.Text.ToString() + "_Pop_" + NPop.ToString() + "_int" + intensity.ToString() + "al_" + alpha.ToString() + "_Dis_" + method + Distance.ToString() + "_Acc_" + Ac.Text + "_It_" + Iteration.ToString() + "_t_" + Ntest.ToString() + "_str_" + structure + ".txt";
                                    if (!File.Exists(ss))
                                    {
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {

                                            MOA_Node[] Nodes = new MOA_Node[NPop];
                                            MOA_Node[] BNodes = new MOA_Node[NPop];
                                            MOA_Node Best_node = new MOA_Node();
                                            MOA_Node[] Forces = new MOA_Node[NPop];
                                            MOA_Node[] a = new MOA_Node[NPop];
                                            MOA_Node[] v = new MOA_Node[NPop];
                                            Latin_Hypercube[] LHC = new Latin_Hypercube[NPop];
                                            Latin_Hypercube[] B = new Latin_Hypercube[NPop];
                                            Latin_Hypercube Best_indi = new Latin_Hypercube();
                                            double[] distances = new double[NPop];
                                            Best_indi.F = 1000;
                                            for (int ii = 0; ii < NPop; ii++)
                                            {
                                                Forces[ii].x = new double[N, P];
                                                a[ii].x = new double[N, P];
                                                v[ii].x = new double[N, P];
                                            }
                                            for (int ii = 0; ii < NPop; ii++)
                                            {
                                                Nodes[ii].x = LH_Class.node_constructing(N, P, rr);
                                                BNodes[ii].x = (double[,])Nodes[ii].x.Clone();
                                                BNodes[ii].f = 10000;
                                            }
                                            for (int it = 0; it < Iteration; it++)
                                            {
                                                Fmax = 0; Fmin = 1000;
                                                int min_index = 0; int max_index = 0;
                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    LHC[ii].LH = LH_Class.convert_search_s_to_solution_s(Nodes[ii].x, N, P);
                                                    LHC[ii].F = LH_Class.F(LHC[ii].LH, N, P);
                                                    B[ii].F = LHC[ii].F;
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
                                                    Best_node.x = (double[,])Nodes[min_index].x.Clone();
                                                }
                                                double range = Fmax - Fmin;
                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    Magnet[ii] = (Fmax - LHC[ii].F) / (range);
                                                    Mass[ii] = Magnet[ii] * intensity + alpha;
                                                }
                                                //if (structure != "Dynamic" && structure != "RDynamic" && structure != "RRDynamic")
                                                BNodes = LH_Class.StructureCore(LHC, Nodes, BNodes, NPop, structure, rr);
                                                //else if (structure != "Frankenstein")
                                                //    BNodes = LH_Class.DynamicStructureCore3(LHC, B, Nodes, BNodes, portion, it, NPop, rr);
                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    Forces[ii].x = new double[N, P];
                                                }
                                                for (int ii = 0; ii < NPop; ii++)
                                                {
                                                    #region reaching to core
                                                    if (D.Text == "1")
                                                        distances[ii] = distance1(Nodes[ii].x, BNodes[ii].x, N, P);
                                                    else if (D.Text == "2")
                                                        distances[ii] = distance2(Nodes[ii].x, BNodes[ii].x, N, P);
                                                    else if (D.Text == "3")
                                                        distances[ii] = distance3(Nodes[ii].x, BNodes[ii].x, N, P);
                                                    else if (D.Text == "4")
                                                        distances[ii] = distance4(LHC[ii].LH, LHC[BNodes[ii].index].LH, N, P);

                                                    // reducing core effect
                                                    core_effect = 1 - opposed_core_effect;
                                                    //
                                                    //if (distances[ii] > short_range)
                                                    //{
                                                    for (int n = 0; n < N; n++)
                                                        for (int p = 0; p < P; p++)
                                                            Forces[ii].x[n, p] = Forces[ii].x[n, p] + (BNodes[ii].x[n, p] - Nodes[ii].x[n, p]) * Magnet[BNodes[ii].index] * core_effect / distances[ii] + (Best_node.x[n, p] - Nodes[ii].x[n, p]) * rr.NextDouble();


                                                    #endregion
                                                    #region particles effect
                                                    if (opposed_core_effect > 0)
                                                    {
                                                        int[] Neigbour = LH_Class.Structures(ii, NPop, structure, rr);
                                                        for (int jj = 0; jj < Neigbour.Length; jj++)
                                                        {
                                                            if (ii != Neigbour[jj] && Nodes[ii].index != jj)
                                                            {
                                                                if (D.Text == "1")
                                                                    distances[ii] = distance1(Nodes[ii].x, Nodes[Neigbour[jj]].x, N, P);
                                                                else if (D.Text == "2")
                                                                    distances[ii] = distance2(Nodes[ii].x, Nodes[Neigbour[jj]].x, N, P);
                                                                else if (D.Text == "3")
                                                                    distances[ii] = distance3(Nodes[ii].x, Nodes[Neigbour[jj]].x, N, P);
                                                                else
                                                                    distances[ii] = distance4(LHC[ii].LH, LHC[Neigbour[jj]].LH, N, P);
                                                                //if (distances[ii] > short_range)
                                                                //{
                                                                for (int n = 0; n < N; n++)
                                                                    for (int p = 0; p < P; p++)
                                                                        Forces[ii].x[n, p] += (Nodes[Neigbour[jj]].x[n, p] - Nodes[ii].x[n, p]) * Magnet[Neigbour[jj]] * opposed_core_effect / distances[ii];

                                                                //}

                                                            }
                                                        }
                                                    }
                                                    #endregion

                                                }
                                                // Individual Learning
                                                int IL = 0;
                                                while (IL < Individual_Learning)
                                                {

                                                    int[,] LH_temp = (int[,])Best_indi.LH.Clone();
                                                    double[,] x = (double[,])Best_node.x.Clone();
                                                    int nrand = rr.Next(N);
                                                    int P1 = rr.Next(P);
                                                    int P2 = rr.Next(P);
                                                    int temp = LH_temp[nrand, P1];
                                                    LH_temp[nrand, P1] = LH_temp[nrand, P2];
                                                    LH_temp[nrand, P2] = temp;
                                                    double x_temp = x[nrand, P1];
                                                    x[nrand, P1] = x[nrand, P2];
                                                    x[nrand, P2] = x_temp;
                                                    double z2 = LH_Class.F(LH_temp, N, P);
                                                    if ((z2 - Best_indi.F) < 0)
                                                    {
                                                        Best_indi.LH = (int[,])LH_temp.Clone();
                                                        Best_node.x = (double[,])x.Clone();
                                                        Best_indi.F = z2;
                                                    }
                                                    IL++;

                                                }
                                                Best_indi.F = LH_Class.F(Best_indi.LH, N, P);
                                                //////////////////////////////////////////

                                                #region noacceleration
                                                if (acceleration == 0)
                                                {
                                                    for (int ii = 0; ii < NPop; ii++)
                                                    {
                                                        for (int n = 0; n < N; n++)
                                                            for (int p = 0; p < P; p++)
                                                            {
                                                                v[ii].x[n, p] = (Forces[ii].x[n, p] / Mass[ii]) * rr.NextDouble();
                                                                Nodes[ii].x[n, p] = Nodes[ii].x[n, p] + v[ii].x[n, p];
                                                            }

                                                        Nodes[ii].x = Node_treatment(Nodes[ii].x, N, P, rr);
                                                    }
                                                }
                                                #endregion
                                                #region acceleration
                                                else if (acceleration == 1)
                                                {
                                                    for (int ii = 0; ii < NPop; ii++)
                                                    {
                                                        for (int n = 0; n < N; n++)
                                                            for (int p = 0; p < P; p++)
                                                            {
                                                                a[ii].x[n, p] = (Forces[ii].x[n, p] / Mass[ii]);
                                                                v[ii].x[n, p] = v[ii].x[n, p] * rr.NextDouble() + a[ii].x[n, p];
                                                                Nodes[ii].x[n, p] = Nodes[ii].x[n, p] + v[ii].x[n, p];
                                                            }

                                                        Nodes[ii].x = Node_treatment(Nodes[ii].x, N, P, rr);
                                                    }
                                                }
                                                #endregion
                                                opposed_core_effect = opposed_core_effect * gamma;
                                                divers[tt, it] = LH_Class.diversity(LHC, NPop, N, P);
                                                fitnesses[tt, it] = LH_Class.best_for_iter(LHC, NPop);
                                            }
                                            costs[tt] = Best_indi.F;
                                            Nodes_test[tt].LH = (int[,])Best_indi.LH.Clone();
                                        }
                                        sw = new StreamWriter(ss);
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            for (int ii = 0; ii < N; ii++)
                                            {
                                                for (int jj = 0; jj < P; jj++)
                                                {
                                                    sw.Write(Nodes_test[tt].LH[ii, jj].ToString() + " ");
                                                }
                                                sw.WriteLine();
                                            }
                                        }
                                        sw.Close();
                                        sw = new StreamWriter(ss2);
                                        for (int tt = 0; tt < Ntest; tt++)
                                        {
                                            sw.Write(costs[tt]);
                                            sw.Write(" ");
                                        }
                                        sw.Close();
                                        //sw = new StreamWriter(ss3);
                                        //for (int ii = 0; ii < Ntest; ii++)
                                        //{
                                        //    for (int jj = 0; jj < Iteration; jj++)
                                        //        sw.Write(fitnesses[ii, jj].ToString() + "  ");
                                        //    sw.WriteLine();
                                        //}
                                        //sw.Close();
                                        //sw = new StreamWriter(ss4);
                                        //for (int ii = 0; ii < Ntest; ii++)
                                        //{
                                        //    for (int jj = 0; jj < Iteration; jj++)
                                        //        sw.Write(divers[ii, jj].ToString() + "  ");
                                        //    sw.WriteLine();
                                        //}
                                        //sw.Close();
                                    }

                                }
                            }
                            #endregion
                            #region PSO
                            else if (method == "PSO")
                            {
                                //double W1 = Convert.ToDouble(Wmin.Text);
                                //double W2 = Convert.ToDouble(Wmax.Text);
                                //double w_step = Convert.ToDouble(W_step.Text);
                                //double C11 = Convert.ToDouble(cmin.Text);
                                //double C12 = Convert.ToDouble(cmax.Text);
                                //double C11_step = Convert.ToDouble(c_step.Text);
                                //double C21 = Convert.ToDouble(cmin21.Text);
                                //double C22 = Convert.ToDouble(cmin22.Text);
                                //double C22_step = Convert.ToDouble(c2_step.Text);
                                //for (double W = W1; W <= W2; W += w_step)
                                //    for (double C1 = C11; C1 <= C12; C1 += C11_step)
                                //        for (double C2 = C21; C2 <= C12; C2 += C22_step)
                                //        {

                                //double[] W_s = { 0.1, 0.5, 0.75, 1, 1.5 };
                                //double[] C_s = { 0.1, 0.5, 1, 1.5, 2, 2.5 };
                                //for (int cc = 0; cc < 5; cc++)
                                //    for (int ww = 0; ww < 5; ww++)
                                //    {
                                double C1 = 1.0;
                                double C2 = 1.0;
                                double W = 1.5;
                                ss = "Result_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_W_" + W.ToString() + "_C1_" + C1.ToString() + "_C2_" + C2.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + ".txt";
                                ss2 = "fit_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_W_" + W.ToString() + "_C1_" + C1.ToString() + "_C2_" + C2.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + ".txt";
                                if (!File.Exists(ss))
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
                                        for (int it = 0; it < Iteration; it++)
                                        {
                                            Fmax = 0; Fmin = 1000;
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
                                        }

                                        costs[tt] = Best_indi.F;
                                        Nodes_test[tt].LH = (int[,])Best_indi.LH.Clone();

                                    }

                                    sw = new StreamWriter(ss);
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        for (int ii = 0; ii < N; ii++)
                                        {
                                            for (int jj = 0; jj < P; jj++)
                                            {
                                                sw.Write(Nodes_test[tt].LH[ii, jj].ToString() + " ");
                                            }
                                            sw.WriteLine();
                                        }
                                    }
                                    sw.Close();
                                    sw = new StreamWriter(ss2);
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        sw.Write(costs[tt].ToString() + " ");
                                    }
                                    sw.Close();
                                }
                                //}
                            }

                            #endregion
                            #region DE
                            else if (method == "DE")
                            {

                                double[] Cr_s = { 0.001, 0.01, .1, 0.5, 1 };
                                double[] F_s = { 0.001, 0.01, 0.2, 0.4, 0.6 };
                                for (int cc = 0; cc < 5; cc++)
                                    for (int ww = 0; ww < 5; ww++)
                                    {
                                        double Cr = Cr_s[cc];
                                        double F = F_s[ww];
                                        ss = "Result_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_F_" + F.ToString() + "_Cr_" + Cr.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + ".txt";
                                        ss2 = "fit_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_F_" + F.ToString() + "_Cr_" + Cr.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + ".txt";
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
                                                    Fmin = 1000;
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
                                                }

                                                costs[tt] = Best_indi.F;
                                                Nodes_test[tt].LH = (int[,])Best_indi.LH.Clone();

                                            }

                                            sw = new StreamWriter(ss);
                                            for (int tt = 0; tt < Ntest; tt++)
                                            {
                                                for (int ii = 0; ii < N; ii++)
                                                {
                                                    for (int jj = 0; jj < P; jj++)
                                                    {
                                                        sw.Write(Nodes_test[tt].LH[ii, jj].ToString() + " ");
                                                    }
                                                    sw.WriteLine();
                                                }
                                            }
                                            sw.Close();
                                            sw = new StreamWriter(ss2);
                                            for (int tt = 0; tt < Ntest; tt++)
                                            {
                                                sw.Write(costs[tt].ToString() + " ");
                                            }
                                            sw.Close();
                                        }
                                    }

                            }

                            #endregion
                            #region ES
                            else if (method == "ES")
                            {

                                double[] Lambda_s = { 0.2, 0.4, 0.6, 0.8, 1 };
                                // sigma constant which is the constant factor to be multiplied to sigma
                                //double[] SC_s = { 0.2, 0.4, 0.6, 0.8, 1,1.2,1.5 };
                                //for (int cc = 0; cc < 5; cc++)
                                //    for (int ww = 0; ww < 7; ww++)
                                //    {
                                //int breeds_number = Convert.ToInt32(Lambda_s[cc] * NPop);
                                int breeds_number = 1 * NPop;
                                double SC = 0.8;
                                ss = "Result_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_Lambda_" + Lambda_s[4].ToString() + "_Sigma_Fac_" + SC.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + ".txt";
                                ss2 = "fit_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_Lambda_" + Lambda_s[4].ToString() + "_Sigma_Fac_" + SC.ToString() + method + "_Iteration_" + Iteration.ToString() + "_test_" + Ntest.ToString() + ".txt";
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
                                        }

                                        costs[tt] = Best_nodes.f;
                                        Nodes_test[tt].LH = (int[,])Best_nodes.LH.Clone();

                                    }

                                    sw = new StreamWriter(ss);
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        for (int ii = 0; ii < N; ii++)
                                        {
                                            for (int jj = 0; jj < P; jj++)
                                            {
                                                sw.Write(Nodes_test[tt].LH[ii, jj].ToString() + " ");
                                            }
                                            sw.WriteLine();
                                        }
                                    }
                                    sw.Close();
                                    sw = new StreamWriter(ss2);
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        sw.Write(costs[tt].ToString() + " ");
                                    }
                                    sw.Close();
                                }
                                //}
                            }

                            #endregion
                            #region MAPSO
                            else if (method == "MAPSO")
                            {
                                string learning = "Gbest";
                                double I_str = 1000;
                                double[] r_lg_s = { 0.5, 0.3, 0.5, 0.7, 0.9 };
                                double C1 = 1.0; double C2 = 1.0; double W = 1.5;
                                //for (int LL = 0; LL < r_lg_s.Length; LL++)
                                //{
                                double r_lg = r_lg_s[0];
                                double n_frec = I_str * ((1 - r_lg) / r_lg);
                                Iteration = (Convert.ToInt32((n_frec / NPop) * 1.9));
                                int Learning = Convert.ToInt32(r_lg * I_str);
                                ss = "Result_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_W_" + W.ToString() + "_C1_" + C1.ToString() + "_C2_" + C2.ToString() + method + "r_LcLG" + r_lg.ToString() + "_test_" + Ntest.ToString() + ".txt";
                                ss2 = "fit_N_" + N.ToString() + "P_" + P.ToString() + "_Pop_" + NPop.ToString() + "_W_" + W.ToString() + "_C1_" + C1.ToString() + "_C2_" + C2.ToString() + method + "r_LcLG" + r_lg.ToString() + "_test_" + Ntest.ToString() + ".txt";
                                if (!File.Exists(ss))
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
                                        Best_nodes.f = -1000;
                                        for (int ii = 0; ii < NPop; ii++)
                                        {
                                            v[ii].x = new double[N, P];
                                        }
                                        Fmax = 0; Fmin = 1000;
                                        for (int ii = 0; ii < NPop; ii++)
                                        {
                                            Nodes[ii].x = LH_Class.node_constructing(N, P, rr);
                                            BNodes[ii].x = (double[,])Nodes[ii].x.Clone();
                                            LHC[ii].LH = LH_Class.convert_search_s_to_solution_s(Nodes[ii].x, N, P);
                                            LHC[ii].F = LH_Class.F_Maximin(LHC[ii].LH, N, P);
                                            BNodes[ii].f = -10000;

                                        }

                                        loca_searches ls_methods = new loca_searches();
                                        ls_methods.result_insert = 1.0 / 3; ls_methods.result_inverse = 1.0 / 3; ls_methods.result_swap = 1.0 / 3;//are being replaced
                                                                                                                                                  //Best_nodes.LH = (int[,])ls_methods.LH.Clone();
                                                                                                                                                  //Best_nodes.x = (double[,])ls_methods.x.Clone();
                                                                                                                                                  //Best_nodes.f = LH_Class.F(Best_nodes.LH, N, P);
                                        for (int it = 0; it < Iteration; it++)
                                        {
                                            for (int ii = 0; ii < NPop; ii++)
                                            {
                                                LHC[ii].LH = LH_Class.convert_search_s_to_solution_s(Nodes[ii].x, N, P);
                                                LHC[ii].F = LH_Class.F_Maximin(LHC[ii].LH, N, P);
                                            }
                                            BNodes = LH_Class.define_pbest2(LHC, Nodes, BNodes, NPop);
                                            for (int ii = 0; ii < NPop; ii++)
                                            {
                                                if (BNodes[ii].f > Best_nodes.f)
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
                                                    double delta_tetha = LH_Class.SA_local_search2(ref BNodes[ii], ls_chosen, P, N, rr, Learning);
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
                                                #region notused
                                                //if (ls_methods.result_insert > ls_methods.result_inverse)
                                                //    if (ls_methods.result_insert > ls_methods.result_swap)
                                                //    {
                                                //        ls_chosen = 0;
                                                //    }
                                                //    else
                                                //        ls_chosen = 2;
                                                //else if (ls_methods.result_inverse > ls_methods.result_swap)
                                                //    ls_chosen = 1;
                                                //else ls_chosen = 2;
                                                #endregion
                                                double delta_tetha = LH_Class.SA_local_search2(ref Best_nodes, ls_chosen, P, N, rr, Learning);
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
                                        }

                                        costs[tt] = Best_nodes.f;
                                        Nodes_test[tt].LH = (int[,])Best_nodes.LH.Clone();

                                    }

                                    sw = new StreamWriter(ss);
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        for (int ii = 0; ii < N; ii++)
                                        {
                                            for (int jj = 0; jj < P; jj++)
                                            {
                                                sw.Write(Nodes_test[tt].LH[ii, jj].ToString() + " ");
                                            }
                                            sw.WriteLine();
                                        }
                                    }
                                    sw.Close();
                                    sw = new StreamWriter(ss2);
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        sw.Write(costs[tt].ToString() + " ");
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
                                int[] Ms = { 1, 10, 50, 100, 500 };
                                int[] Js = { 1, 10, 30, 50, 100 };
                                double[] Ths = { 0.0001, 0.001, 0.01, 0.1 };
                                for (int Thi = 0; Thi < 4; Thi++)
                                    for (int Ji = 0; Ji < 5; Ji++)
                                        for (int Mi = 0; Mi < 5; Mi++)
                                        {
                                            double Th = Ths[Thi];
                                            int M = Ms[Mi];
                                            int J = Js[Ji];
                                            ss = "Result_N_" + N.ToString() + "P_" + P.ToString() + "th_" + Th.ToString() + "M_" + M.ToString() + "J_" + J.ToString() + method + "_test" + Ntest.ToString() + ".txt";
                                            ss2 = "fit_N_" + N.ToString() + "P_" + P.ToString() + "th_" + Th.ToString() + "M_" + M.ToString() + "J_" + J.ToString() + method + "_test" + Ntest.ToString() + ".txt";
                                            if (!File.Exists(ss))
                                            {
                                                for (int tt = 0; tt < Ntest; tt++)
                                                {
                                                    Th = 0.005;
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
                                                    }
                                                    costs[tt] = Z;
                                                    Nodes_test[tt].LH = (int[,])LH.Clone();
                                                }


                                                sw = new StreamWriter(ss);
                                                for (int tt = 0; tt < Ntest; tt++)
                                                {
                                                    for (int ii = 0; ii < N; ii++)
                                                    {
                                                        for (int jj = 0; jj < P; jj++)
                                                        {
                                                            sw.Write(Nodes_test[tt].LH[ii, jj].ToString() + " ");
                                                        }
                                                        sw.WriteLine();
                                                    }
                                                }
                                                sw.Close();
                                                sw = new StreamWriter(ss2);
                                                for (int tt = 0; tt < Ntest; tt++)
                                                {
                                                    sw.Write(costs[tt].ToString() + " ");
                                                }
                                                sw.Close();
                                            }
                                        }

                            }
                            #endregion
                            #region ILS
                            else if (method == "ILS")
                            {
                                int it = 0;
                                ss = "Result_N_" + N.ToString() + "P_" + P.ToString() + method + "_test" + Ntest.ToString() + ".txt";
                                ss2 = "fit_N_" + N.ToString() + "P_" + P.ToString() + method + "_test" + Ntest.ToString() + ".txt";
                                if (!File.Exists(ss2))
                                {
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        it = 0;
                                        int[,] LH = LH_Class.constructing_Latin_hypercube(N, P, rr);
                                        double z1 = 0;
                                        int MaxIter = Iteration * NPop;
                                        bool change = false;
                                        while (it < MaxIter)
                                        {

                                            int[,] LH_temp = (int[,])LH.Clone();
                                            z1 = LH_Class.F_Maximin(LH_temp, N, P);
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
                                                                double z2 = LH_Class.F_Maximin(LH_temp, N, P);
                                                                double dz = z2 - z1;
                                                                if (dz > 0)
                                                                {
                                                                    LH = (int[,])LH_temp.Clone();
                                                                    z1 = z2;
                                                                    change = true;
                                                                }
                                                            }
                                                            it++;
                                                        }
                                            }
                                            while (change && it < MaxIter);
                                            LH_Class.Perturbation(ref LH, rr, N, P);
                                        }
                                        costs[tt] = z1;
                                        Nodes_test[tt].LH = (int[,])LH.Clone();
                                    }


                                    sw = new StreamWriter(ss);
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        for (int ii = 0; ii < N; ii++)
                                        {
                                            for (int jj = 0; jj < P; jj++)
                                            {
                                                sw.Write(Nodes_test[tt].LH[ii, jj].ToString() + " ");
                                            }
                                            sw.WriteLine();
                                        }
                                    }
                                    sw.Close();
                                    sw = new StreamWriter(ss2);
                                    for (int tt = 0; tt < Ntest; tt++)
                                    {
                                        sw.Write(costs[tt].ToString() + " ");
                                    }
                                    sw.Close();
                                    //}
                                }

                            }
                            #endregion
                            #endregion
                        }

                    }
                //}
                #endregion
                Application.Exit();
                //}
            }
            #endregion
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
            for (int ii = 0; ii < N; ii++)
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
                    result += Math.Pow(Math.Abs(x1[ii, jj] - x2[ii, jj]), 2);
                }
            return Math.Sqrt(result);
        }
        public double distance3(double[,] x1, double[,] x2, int N, int P)
        {
            double result = 0;
            for (int ii = 0; ii < N; ii++)
                for (int jj = 0; jj < P; jj++)
                {
                    result = Math.Max(x1[ii, jj] - x2[ii, jj], result);
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
                        int[,] vertex = string_to_array(str_best_x, N, P);
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
        public double[,] Node_treatment(double[,] Node, int N, int P, Random rr)
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
            int dist = 0;
            for (int ii = 0; ii < N; ii++)
                for (int jj = 0; jj < P; jj++)
                    if (LH1[ii, jj] != LH2[ii, jj])
                        dist++;
            return dist / (P * N);
        }
        public int[,] string_to_array(string ss, int N, int P)
        {
            string[] all = ss.Split(' ');
            int[,] LH = new int[N, P];
            int kk = 0;
            for (int ii = 0; ii < N; ii++)
                for (int jj = 0; jj < P; jj++)
                    LH[ii, jj] = Convert.ToInt32(all[kk++]);
            return LH;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "DE" || comboBox1.Text == "ES" || comboBox1.Text == "ILS" || comboBox1.Text == "MASW")
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
