using System;

namespace CalcConsoleAug
{
    public static class TrigFunkcioj
    {
        internal static double N_aRadiko(double A, int N) => Math.Pow(A, 1.0 / N);

        internal static double AlAngulo(double alAngulo)
        {
            double radAlAngulo = Math.PI * alAngulo / 180.0;
            return radAlAngulo;
        }
        internal static double Sinuskalkulo(double sinValoro) => Math.Sin(AlAngulo(sinValoro));

        internal static double Kosinuskalkulo(double kosinusValoro) => Math.Cos(AlAngulo(kosinusValoro));

        internal static double Tangentkalkulo(double tangentvaloro) => Math.Tan(AlAngulo(tangentvaloro));

        internal static double Kotangentkalkulo(double kotangentvaloro)
        {
            double sinValoro = Math.Sin(AlAngulo(kotangentvaloro));
            double kosValoro = Math.Cos(AlAngulo(kotangentvaloro));
            return kosValoro / sinValoro;
        }
    }
}