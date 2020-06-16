using System;

namespace ValutaOmregner
{
    public class Omregn
    {
        public static double valutakurs = 0.7041;

        public static double TilSvenskeKroner(double danskeKroner)
        {
           double result = danskeKroner / valutakurs;
            return result;
        }

        public static double TilDanskeKroner(double svenskeKroner)
        {
            double result = svenskeKroner * valutakurs;
            return result;
        }

    }
}
