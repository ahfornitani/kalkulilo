using System;
using System.Collections.Generic;
using System.Linq;

namespace CalcConsoleAug
{

    public class TemperaturKonvertoj
    {

        // Listo de eblaj temperaturaj konvertoj
        List<string> temperaturoDeAl = new List<string>
                {
                    "f al c", "f en c", "°f en °c", "°f al °c",
                    "f al k", "f en k", "°f en k", "°f al k",
                    "f al r", "f en r", "°f en °r", "°f al °r",

                    "c al f", "c en f", "°c en °f", "°c al °f",
                    "c al k", "c en k", "°c en k", "°c al k",
                    "c al r", "c en r", "°c en °r", "°c al °r",

                    "k al f", "k en f", "k en °f", "k al °f",
                    "k al c", "k en c", "k en °c", "k al °c",
                    "k al r", "k en r", "k en °r", "k al °r",

                    "r al f", "r en f", "°r en °f", "°r al °f",
                    "r al c", "r en c", "°r en °c", "°r al °c",
                    "r al k", "r en k", "r en k", "r al k",
                };

        internal static double AlCelsiuso(double de, double al)
        {
            return al;
        }

    }

}