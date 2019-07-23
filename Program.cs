﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using Newtonsoft.Json;

namespace CalcConsoleAug
{
    static class Program
    {
        static void Main(string[] args)
        {
            CultureInfo miaKulturo = new CultureInfo("pt-BR", true);
            Console.OutputEncoding = Encoding.UTF8;


            // Ĉi tiu stako konservas antaŭajn rezultojn
            Stack<decimal> rezultStako = new Stack<decimal>();
            while (true)
            {
                string[] originala = Console.ReadLine().Split("#");
                string enigita = originala[0].ToLower();

                #region Listo de Anstataŭigo
                Dictionary<string, string> listoDeAnstataŭigo = new Dictionary<string, string> {
                    //konstantoj
                    { "konstantopi", "3.1415926536"},
                    { "konstpi", "3.1415926536"},
                    { "konstantoe", "2.7182818285"},
                    { "konste", "2.7182818285"},
                    { "konstc", "299792458"},
                    { "lumrapido", "299792458"},
                    { "kvr", "sqrt("},

                    // temperaturaj konvertoj
                    // Farenhejto al C kaj al K estas aparte
                    {"c al f", "*1.8 + 32"},
                    {"c en f", "*1.8 + 32"},
                    {"c al k", "+273.15"},
                    {"c en k", "+273.15"},
                    {"k al c", "-273.15"},
                    {"k en c", "-273.15"},
                    {"k al f", "*(9/5) - 459.67"},
                    {"k en f", "*(9/5) - 459.67"},
                    {"r al f", " - 459.67"},
                    {"r en f", " - 459.67"},

                    //kilometro
                    
                    {"km al pm", "*1000000000000000"},
                    {"km en pm", "*1000000000000000"},
                    {"km al nm", "*1000000000000"},
                    {"km en nm", "*1000000000000"},
                    {"km al µm", "*1000000000"},
                    {"km en µm", "*1000000000"},
                    {"km al mm", "*1000000"},
                    {"km en mm", "*1000000"},
                    {"km al cm", "*100000"},
                    {"km en cm", "*100000"},
                    {"km al dm", "*10000"},
                    {"km en dm", "*10000"},
                    {"km al marmejloj", "*0.539957"},
                    {"km en marmejloj", "*0.539957"},
                    {"km al marmejlo", "*0.539957"},
                    {"km en marmejlo", "*0.539957"},
                    {"km al mejloj", "*0.6213712"},
                    {"km en mejloj", "*0.6213712"},
                    {"km al mejlo", "*0.6213712"},
                    {"km en mejlo", "*0,6213712"},
                    {"km al m", "*1000"},
                    {"km en m", "*1000"},
                    {"km al dam", "*100"},
                    {"km en dam", "*100"},
                    {"km al hm", "*10"},
                    {"km en hm", "*10"},
                    {"marmejloj al km", "*1.852"},
                    {"marmejloj en km", "*1.852"},
                    {"marmejlo al km", "*1.852"},
                    {"marmejlo en km", "*1.852"},
                    {"mejloj al km", "*1.609344"},
                    {"mejloj en km", "*1.609344"},
                    {"mejlo al km", "*1.609344"},
                    {"mejlo en km", "*1.609344"},
                    
                    //hektometro
                    {"hm al km", "/10"},
                    {"hm en km", "/10"},

                    // Dekoblaj unuoj 
                    {"m al dm", "*10" },
                    {"m en dm", "*10" },
                    {"m al cm", "*100"},
                    {"m en cm", "*100"},
                    {"m al mm", "*1000"},
                    {"m en mm", "*1000"},
                    {"m al dam", "/10"},
                    {"m en dam", "/10"},
                    {"m al km", "/1000"},
                    {"m en km", "/1000"},

                    { "\\", ""},
                    {",", "." },
                    {";", "+" },
                    {"[", "(" },
                    {"]", ")" },
                    { "kpd", ""},
                    { "oble", "*" },
                    {"proc de", "/100*" },
                    {"proc", "/100*" },
                    {"elc de", "/100*" },
                    {"elc", "/100*" },
                    { "dudek", "20" },
                    { "tridek", "30" },
                    { "kvardek", "40" },
                    { "kvindek", "50" },
                    { "sesdek", "60" },
                    { "sepdek", "70" },
                    { "okdek", "80" },
                    { "naŭdek", "90" },
                    { "nauxdek", "90" },
                    { "naudek", "90" },
                    { "dekunu", "11" },
                    { "dekdu", "12" },
                    { "dektri", "13" },
                    { "dekkvar", "14" },
                    { "dekkvin", "15" },
                    { "dekses", "16" },
                    { "deksep", "17" },
                    { "dekok", "18" },
                    { "deknaŭ", "19" },
                    { "deknaux", "19" },
                    { "deknau", "19" },

                    { "ducentmil", "200000" },
                    { "tricentmil", "300000" },
                    { "kvarcentmil", "400000" },
                    { "kvincentmil", "500000" },
                    { "sescentmil", "600000" },
                    { "sepcentmil", "700000" },
                    { "okcentmil", "800000" },
                    { "naŭcentmil", "900000" },
                    { "nauxcentmil", "900000" },
                    { "naucentmil", "900000" },
                    { "centmil", "100000" },

                    { "ducent", "200" },
                    { "tricent", "300" },
                    { "kvarcent", "400" },
                    { "kvincent", "500" },
                    { "sescent", "600" },
                    { "sepcent", "700" },
                    { "okcent", "800" },
                    { "naŭcent", "900" },
                    { "foje", "*" },
                    { "foj", "*" },
                    { "centfoje", "*100" },
                    { "cent", "100" },
                    { "plus", "+" },
                    { "minus", "-" },
                    { "sub", "-" },
                    { "multobligitade", "*" },
                    { "mult", "*" },
                    { "dividitade", "/" },
                    { "onigi", "/" },
                    { "div", "/" },

                    { "pli", "+" },
                    { "kaj", "+" },
                    { "unu", "1" },
                    { "du", "2" },
                    { "tri", "3" },
                    { "kvar", "4" },
                    { "kvin", "5" },
                    { "ses", "6" },
                    { "sep", "7" },
                    { "ok", "8" },
                    { "naŭ", "9" },
                    { "nau", "9" },
                    { "naux", "9" },
                    { "dek", "10" },


                    { "dumil", "2000" },
                    { "trimil", "3000" },
                    { "kvarmil", "4000" },
                    { "kvinmil", "5000" },
                    { "sesmil", "6000" },
                    { "sepmil", "7000" },
                    { "okmil", "8000" },
                    { "ok mil", "8000" },
                    { "naŭmil", "9000" },
                    { "naŭ mil", "9000" },
                    { "dekmil", "10000" },

                    { "miliardo", "*1000000000" },
                    { "mardo", "*1000000000" },
                    { "miliono", "*1000000" },
                    { " mil", "*1000" },
                    { "mil", "000" },
                    { "mi", "*1000000" },
                    { "biliono", "*1000000000000" },
                    { "bi", "*1000000000000" },

                    {"mod", "%" },
                    {"pot", "Math.Pow(2, 2)" },
                    };
                #endregion
                string enigitaPostKonverto = enigita;
                foreach (string ŝlosilo in listoDeAnstataŭigo.Keys)
                {
                    if (enigita.Contains(ŝlosilo))
                    {
                        enigita = enigita.Replace(ŝlosilo, listoDeAnstataŭigo[ŝlosilo]);
                        enigitaPostKonverto = enigita;
                    }
                    else if (enigita.Contains("forig") || enigita.Contains("vakig"))
                    {
                        Console.Clear();
                    }
                }

                List<string> listoFarenhejtoAl = new List<string> {
                    "f al c", "f en c", "°f en °c", "°f al °c",
                    "f al k", "f en k", "°f en °k", "°f al °k",
                    "f al r", "f en r", "°f en °r", "°f al °r",
                };

                foreach (string ero in listoFarenhejtoAl)
                {
                    if (enigita.Contains(ero))
                    {
                        string enigitaKopio = enigitaPostKonverto;
                        string[] disigita = enigitaKopio.Split(ero);
                        double farenhejto = Convert.ToDouble(disigita[0].Replace("°", String.Empty));
                        double formulo = 0.0;
                        if (ero.EndsWith("c"))
                        {
                            formulo = (farenhejto - 32) / 1.8;
                        }
                        else if (ero.EndsWith("k"))
                        {
                            formulo = (farenhejto + 459.67) * 5 / 9;
                        }
                        else if (ero.EndsWith("r"))
                        {
                            formulo = (farenhejto + 459.67);
                        }
                        //Console.WriteLine($">> {formulo.ToString().Replace(".", ",")} °C");
                        enigita = formulo.ToString();
                        rezultStako.Push(Convert.ToDecimal(formulo));
                    }
                }

                // Provo konverti monon
                string oxrAppId = "62182152dd4540d1885982f4c7685897";
                List<string> listoDeValutoj = new List<string> { "BRL", "CAD", "USD", "NZD", "GBP", };
                string rezultoMonKonverto = $"https://openexchangerates.org/api/latest.json?app_id={oxrAppId}&base=GBP&callback=someCallbackFunction";

                foreach (string valuto in listoDeValutoj)
                {

                }


                List<string> resultStrings = new List<string> { "res", "ant", "antaŭa", "rez", };
                List<string> elirKomandListo = new List<string> { "eliri()", "fermu()" };

                /// <summary>
                /// Jen kiel preni la antaŭajn valorojn funkcias
                /// </summary>
                foreach (string str in resultStrings)
                {
                    if (enigita.Contains(str))
                    {
                        if (rezultStako.Count == 0)
                        {
                            //Se stako malplenas, ankaŭ malplenigi ant/res/rez por ke eroro ne okazu
                            Console.WriteLine("Ankoraŭ ne ekzistas antaŭa kalkulo registrita");
                            enigita = enigita.Replace(str, string.Empty);
                        }
                        else
                        {
                            //se stako havas valorojn, preni lastan por kalkuli
                            enigita = enigita.Replace(str, rezultStako.Peek().ToString());
                        }
                    }
                }

                // Quit
                foreach (string elirKomando in elirKomandListo)
                {
                    if (enigita.Contains(elirKomando))
                    {
                        Console.WriteLine("Ĉu vi vere volas fermi ĉi tiu aplikaĵon? [J]/[N]");
                        string jesAŭNe = Console.ReadLine().ToLower();
                        if (jesAŭNe == "j")
                        {
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("Bone, plue kalkulumu!");
                        }
                    }
                }


                //Preni enjtapitajn valoron, post kiam trans-ŝanĝoj okazis (ekz. "dek" -> 10)
                // kaj fari la kalkulon

                try
                {
                    decimal rezulto = Convert.ToDecimal(new DataTable().Compute(enigita, null));
                    rezultStako.Push(rezulto);
                    if (rezulto % 2 == 0)
                    {
                        string montruĈiTiun = Convert.ToDouble(rezulto).ToString("#,##0");
                        Console.WriteLine($">> {montruĈiTiun.Replace(".", ",")}");
                    }
                    else
                    {
                        Console.WriteLine($">> {rezulto.ToString().Replace(".", ",")} ");
                    }

                }
                catch (Exception escepto)
                {
                    Console.WriteLine("Nevalida kalkulo");
                    //Console.WriteLine(escepto);
                }


            }
        }
    }
}