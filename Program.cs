using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using System.Linq;

namespace CalcConsoleAug
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            // havi UTF8 por belaj ĉapeloj en konzolo
            CultureInfo miaKulturo = new CultureInfo("eo", false);
            Console.OutputEncoding = Encoding.UTF8;

            // Ĉi tiu stako konservas antaŭajn rezultojn
            Stack<double> rezultStako = new Stack<double>();
            Stack<string> alKonvertoUnuo = new Stack<string>();
            Stack<string> finaSimbolo = new Stack<string>();


            #region Listo de Anstataŭigo

            // Ĉi tiu listo estas uzata por ŝanĝi entajpitan tekston egalan al Dict.Key al tekso egala al Dict.Value 
            Dictionary<string, string> listoDeAnstataŭigo = new Dictionary<string, string>
            {
                //konstantoj
                {"konstantopi", "3.1415926536"},
                {"konstpi", "3.1415926536"},
                {"konstantoe", "2.7182818285"},
                {"konste", "2.7182818285"},
                {"konstc", "299792458"},
                {"lumrapido", "299792458"},

                //tempo
                {"jaroj al monatoj", "*12"},
                {"jaroj al tagoj", "*365"},
                {"monatoj al jaroj", "/12"},
                {"monatoj al tagoj", "*30"},
                {"tagoj al horoj", "*24"},
                {"tagoj al minutoj", "*24*60"},
                {"horoj al minutoj", "*60"},
                {"horo al minuto", "*60"},
                {"h al min", "*60"},
                {"horoj al sekundoj", "*60*60"},
                {"horo al sekundo", "*60*60"},
                {"h al sek", "*60*60"},
                {"h al s", "*60*60"},
                {"minutoj al horo", "/60"},
                {"minutoj al horoj", "/60"},
                {"minuto al horo", "/60"},
                {"min al h", "/60"},
                {"minutoj al sekundoj", "*60"},
                {"minuto al sekundo", "*60"},
                {"min al sek", "*60"},
                {"min al s", "*60"},

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
                {"g al kg", "/1000"},
                {"kg al g", "*1000"},
                {"cm al mm", "*10"},
                {"cm al m", "/100"},
                {"mm al cm", "/10"},
                {"mm al m", "/100"},
                {"m al dm", "*10"},
                {"m en dm", "*10"},
                {"m al cm", "*100"},
                {"m en cm", "*100"},
                {"m al mm", "*1000"},
                {"m en mm", "*1000"},
                {"m al dam", "/10"},
                {"m en dam", "/10"},
                {"m al km", "/1000"},
                {"m en km", "/1000"},
                

                //imperiaj unuoj
                {"colo en pm", "*25400000000"},
                {"colo en nm", "*25400000"},
                {"colo en μm", "*25400"},
                {"colo en mm", "*25.4"},
                {"colo en cm", "*2.54"},
                {"colo en dm", "*0.254"},
                {"colo en m", "*0.0254"},
                {"colo en dam", "*0.00254"},
                {"colo en hm", "*0.000254"},
                {"colo en km", "*0.0000254"},
                {"cm al colo", "/2.54"},
                {"cm en colo", "/2.54"},

                {"\\", ""},
                {",", "."},
                {";", "+"},
                {"[", "("},
                {"]", ")"},
                {"kpd", ""},
                {"oble", "*"},
                {"proc de", "/100*"},
                {"procde", "/100*"},
                {"proc", "/100*"},
                {"pd", "/100*"},
                {"elc de", "/100*"},
                {"elc", "/100*"},
                {"dudek", "20"},
                {"tridek", "30"},
                {"kvardek", "40"},
                {"kvindek", "50"},
                {"sesdek", "60"},
                {"sepdek", "70"},
                {"okdek", "80"},
                {"naŭdek", "90"},
                {"nauxdek", "90"},
                {"naudek", "90"},
                {"dekunu", "11"},
                {"dekdu", "12"},
                {"dektri", "13"},
                {"dekkvar", "14"},
                {"dekkvin", "15"},
                {"dekses", "16"},
                {"deksep", "17"},
                {"dekok", "18"},
                {"deknaŭ", "19"},
                {"deknaux", "19"},
                {"deknau", "19"},

                {"ducentmil", "200000"},
                {"tricentmil", "300000"},
                {"kvarcentmil", "400000"},
                {"kvincentmil", "500000"},
                {"sescentmil", "600000"},
                {"sepcentmil", "700000"},
                {"okcentmil", "800000"},
                {"naŭcentmil", "900000"},
                {"nauxcentmil", "900000"},
                {"naucentmil", "900000"},
                {"centmil", "100000"},

                {"ducent", "200"},
                {"tricent", "300"},
                {"kvarcent", "400"},
                {"kvincent", "500"},
                {"sescent", "600"},
                {"sepcent", "700"},
                {"okcent", "800"},
                {"naucent", "900"},
                {"naŭcent", "900"},
                {"foje", "*"},
                {"foj", "*"},
                {"centfoje", "*100"},
                {"cent", "100"},
                {"plus", "+"},
                {"minus", "-"},
                {"sub", "-"},
                {"multobligitade", "*"},
                {"mult", "*"},
                {"dividitade", "/"},
                {"onigi", "/"},
                {"div", "/"},

                {"pli", "+"},
                {"kaj", "+"},
                {"unu", "1"},
                {"du", "2"},
                {"tri", "3"},
                {"kvar", "4"},
                {"kvin", "5"},
                {"ses", "6"},
                {"sep", "7"},
                {"ok", "8"},
                {"naŭ", "9"},
                {"nau", "9"},
                {"naux", "9"},
                {"dek", "10"},

                {"dumil", "2000"},
                {"trimil", "3000"},
                {"kvarmil", "4000"},
                {"kvinmil", "5000"},
                {"sesmil", "6000"},
                {"sepmil", "7000"},
                {"okmil", "8000"},
                {"ok mil", "8000"},
                {"naŭmil", "9000"},
                {"naŭ mil", "9000"},
                {"dekmil", "10000"},

                {"miliardo", "*1000000000"},
                {"mardo", "*1000000000"},
                {"miliono", "*1000000"},
                {" mil", "*1000"},
                {"mil", "000"},
                {"mi", "*1000000"},
                {"biliono", "*1000000000000"},
                {"bi", "*1000000000000"},

                {"mod", "%"},
            };

            #endregion Listo de Anstataŭigo

            #region Listo Trigonometria
            List<string> listoSinuso = new List<string> { "sinuso", "sin", };
            List<string> listoKosinuso = new List<string> { "kosinuso", "kosin", "kos", "cos" };
            List<string> listoTangento = new List<string> { "tangento", "tan", "tg" };
            List<string> listoKotangento = new List<string> { "kotangento", "kotan", "cotan", "cotg", "kot" };

            #endregion

            // porĉiama ripetanta while por ke kalkulilo ne ĉesu
            while (true)
            {
                // # produktas komenton
                string[] originala = Console.ReadLine().Split("#");
                // minuskle, por faciligi
                string enigita = originala[0].ToLower();

                // se entajpita ĉeno enhavas "kpd" (kiel procentaĵo de), kalkuli adekvate
                if (enigita.Contains(("kpd")))
                {
                    string[] disigita = enigita.Split("kpd");
                    string x = disigita[0];
                    string y = disigita[disigita.Length - 1];
                    enigita = $"{x}/{y}*100";
                    finaSimbolo.Push("%");
                }

                if (enigita.Contains("aver"))
                {
                    // string[] disigita = enigita.Split("aver");
                    // string[] numeroj = disigita[1].Split(" ");

                    var disigita = enigita.Split("aver");
                    Console.WriteLine(disigita[0]);

                    // double sumo = 0, aver = 0;

                    // for (int i = 0; i < numeroj.Length; i++)
                    // {
                    //     sumo += Convert.ToDouble(numeroj[i]);
                    // }

                    // aver = sumo / numeroj.Length;
                    // enigita = aver.ToString(CultureInfo.CurrentUICulture);
                }

                # region Trigonometriaj funkcioj
                foreach (var sinuso in listoSinuso)
                {
                    if (enigita.Contains(sinuso))
                    {
                        string[] disigita = enigita.Split(sinuso);
                        string sinValoro = disigita[disigita.Length - 1];
                        enigita = TrigFunkcioj.Sinuskalkulo(Convert.ToDouble(sinValoro)).ToString(CultureInfo.CurrentUICulture);
                    }
                }

                foreach (var kosin in listoKosinuso)
                {
                    if (enigita.Contains(kosin))
                    {
                        string[] disigita = enigita.Split(kosin);
                        string kosinusValoro = disigita[disigita.Length - 1];
                        enigita = TrigFunkcioj.Kosinuskalkulo(Convert.ToDouble(kosinusValoro)).ToString(CultureInfo.CurrentUICulture);
                    }
                }

                foreach (var tangento in listoTangento)
                {
                    if (enigita.Contains(tangento))
                    {
                        string[] disigita = enigita.Split(tangento);
                        string tangentValoro = disigita[disigita.Length - 1];
                        enigita = TrigFunkcioj.Tangentkalkulo(Convert.ToDouble(tangentValoro)).ToString(CultureInfo.CurrentUICulture);
                    }
                }

                foreach (var kotangento in listoKotangento)
                {
                    if (enigita.Contains(kotangento))
                    {
                        string[] disigita = enigita.Split(kotangento);
                        string kotangentValoro = disigita[disigita.Length - 1];
                        enigita = TrigFunkcioj.Kotangentkalkulo(Convert.ToDouble(kotangentValoro)).ToString(CultureInfo.CurrentUICulture);
                    }
                }

                #endregion

                //se entajpita ĉeno enhavas "exp" (ekz. 78 exp 15 = 78 estas 15 procentoj de kio?)
                if (enigita.Contains(("exp")))
                {
                    string[] disigita = enigita.Split("exp");
                    string x = disigita[0];
                    string y = disigita[disigita.Length - 1];
                    enigita = $"{x}/({y}/100)";
                    // finaSimbolo.Push("%");
                }

                // = simbolo indikas variablon
                if (enigita.Contains("="))
                {
                    // apartigi per = simbolo. Unua parto estas nomo de variablo
                    // dua parto estas la enhavo (valoro)
                    var varDisigita = enigita.Split("=");
                    var varNomo = varDisigita[0].Trim();
                    var varEnhavo = $"({varDisigita[1].Trim()})*1";

                    // se ŝlosilo el la listo enestas enhavo-ĉenon
                    // do prenu la valoron de la ŝlosilo kaj anstataŭigi je enhavo-ĉeno
                    // ekz, se varEnhavo enhavas "10 * lumrapido", ĝi iĝos "10 * 299792458"
                    // do la variablo estos varNomo = 10 * 299792458
                    foreach (var ŝlosilo in listoDeAnstataŭigo.Keys)
                    {
                        if (varEnhavo.Contains(ŝlosilo))
                        {
                            varEnhavo = varEnhavo.Replace(ŝlosilo, listoDeAnstataŭigo[ŝlosilo]);
                        }
                    }
                    listoDeAnstataŭigo.Add(varNomo, varEnhavo);
                }

                // "en" kaj "al" indikas konverton
                if (enigita.Contains("al") || enigita.Contains("en"))
                {
                    var disigitaEnhavo = enigita.Split();
                    var lastaUnuo = disigitaEnhavo[disigitaEnhavo.Length - 1];
                    alKonvertoUnuo.Push(lastaUnuo);
                }

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

                #region Temperaturaj konvertoj

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

                // konsulti ĉiujn valorojn en la listo.
                // se valoro ekzistas, konsulti la lastan signon, por decidi al kio konverti
                foreach (string ero in temperaturoDeAl)
                {
                    if (enigita.Contains(ero))
                    {
                        string enigitaKopio = enigitaPostKonverto;
                        string[] disigita = enigitaKopio.Split(ero);
                        //"deTemperaturo" estas unua valoro. Ekz-e "50 f al c" > deTemperaturo == 50
                        //nuligi grad-signon, ĉar ĝi nur malhelpas kalkuli
                        double deTemperaturo = Convert.ToDouble(disigita[0].Replace("°", String.Empty));
                        //alTemperaturo estas la fina rezulto. Ekz-e "50 f al c" > alTemperaturo == 10
                        double alTemperaturo = 0;

                        //Farenhejtaj konvertoj
                        if (ero.Contains("f al") || ero.Contains("f en"))
                        {
                            if (ero.EndsWith("c", StringComparison.CurrentCulture))
                            {
                                alTemperaturo = (deTemperaturo - 32) / 1.8;
                                finaSimbolo.Push("°C");
                            }
                            else if (ero.EndsWith("k", StringComparison.CurrentCulture))
                            {
                                alTemperaturo = (deTemperaturo + 459.67) * 5 / 9;
                                finaSimbolo.Push("K");
                            }
                            else if (ero.EndsWith("r", StringComparison.CurrentCulture))
                            {
                                alTemperaturo = (deTemperaturo + 459.67);
                                finaSimbolo.Push("°R");
                            }
                        }

                        //Celsiaj konvertoj
                        if (ero.Contains("c al") || ero.Contains("c en"))
                        {
                            if (ero.EndsWith("f", StringComparison.CurrentCulture))
                            {
                                alTemperaturo = (deTemperaturo * 1.8) + 32;
                                finaSimbolo.Push("°F");
                            }
                            else if (ero.EndsWith("k", StringComparison.CurrentCulture))
                            {
                                alTemperaturo = deTemperaturo + 273.15;
                                finaSimbolo.Push("K");
                            }
                            else if (ero.EndsWith("r", StringComparison.CurrentCulture))
                            {
                                alTemperaturo = (deTemperaturo + 273.15) * 9 / 5;
                                finaSimbolo.Push("°R");
                            }
                        }

                        //Kelvinaj konvertoj
                        if (ero.Contains("k al") || ero.Contains("k en"))
                        {
                            if (ero.EndsWith("f", StringComparison.CurrentCulture))
                            {
                                alTemperaturo = (deTemperaturo * 9 / 5) - 459.67;
                                finaSimbolo.Push("°F");
                            }
                            else if (ero.EndsWith("c"))
                            {
                                alTemperaturo = deTemperaturo - 273.15;
                                finaSimbolo.Push("°C");
                            }
                            else if (ero.EndsWith("r", StringComparison.CurrentCulture))
                            {
                                alTemperaturo = deTemperaturo * 9 / 5;
                                finaSimbolo.Push("°R");
                            }
                        }

                        //Reaŭmuraj konvertoj
                        if (ero.Contains("r al") || ero.Contains("r en"))
                        {
                            if (ero.EndsWith("f", StringComparison.CurrentCulture))
                            {
                                alTemperaturo = deTemperaturo - 459.67;
                                finaSimbolo.Push("°F");
                            }
                            else if (ero.EndsWith("c", StringComparison.CurrentCulture))
                            {
                                alTemperaturo = (deTemperaturo - 491.67) * 5 / 9;
                                finaSimbolo.Push("°C");
                            }
                            else if (ero.EndsWith("k", StringComparison.CurrentCulture))
                            {
                                alTemperaturo = deTemperaturo * 5 / 9;
                                finaSimbolo.Push("K");
                            }
                        }

                        enigita = alTemperaturo.ToString(CultureInfo.CurrentCulture);
                        rezultStako.Push(Convert.ToDouble(alTemperaturo));
                    }
                }

                #endregion Temperaturaj konvertoj

                #region Radikoj

                //kontroli, ĉu "kvr" enestas la ĉenon entajpitan. Se jes, kalkuli kvadratan radikon
                if (enigita.Contains("kvr"))
                {
                    string enigitaKopio = enigitaPostKonverto;
                    string[] disigita = enigitaKopio.Split("kvr");
                    string bazo = disigita[1];

                    // ĉu estas "res" por antaŭa rezulto?
                    double rezulto = rezultStako.Peek();
                    if (rezultStako.Count == 0)
                    {
                        if (enigita.Contains("res"))
                        {
                            //Se stako malplenas, ankaŭ malplenigi ant/res/rez por ke eroro ne okazu
                            Console.WriteLine("Ankoraŭ ne ekzistas antaŭa kalkulo registrita");
                        }
                    }
                    else
                    {
                        if (rezulto != 0)
                        {
                            if (bazo.Contains("res"))
                            {
                                bazo = rezultStako.Peek().ToString();
                                enigita = Rondigi(Convert.ToDouble(bazo)).ToString(CultureInfo.CurrentCulture);
                            }

                        }
                    }

                    enigita = Kvadrata(Convert.ToDouble(bazo)).ToString(CultureInfo.CurrentCulture);

                }

                if (enigita.Contains("nrad"))
                {
                    string enigitaKopio = enigitaPostKonverto;
                    string[] disigita = enigitaKopio.Split("nrad");
                    string bazo = disigita[0];
                    string n_radiko = disigita[1];


                    if (rezultStako.Count == 0)
                    {
                        if (enigita.Contains("res"))
                        {
                            //Se stako malplenas, ankaŭ malplenigi ant/res/rez por ke eroro ne okazu
                            Console.WriteLine("Ankoraŭ ne ekzistas antaŭa kalkulo registrita");
                        }
                    }
                    else
                    {
                        //se stako havas valorojn, preni lastan por kalkuli
                        // ĉu estas "res" por antaŭa rezulto?
                        double rezulto = rezultStako.Peek();
                        if (rezulto != 0)
                        {

                            if (bazo.Contains("res") && n_radiko.Contains("res"))
                            {
                                n_radiko = bazo = rezulto.ToString();
                            }

                            if (bazo.Contains("res"))
                            {
                                bazo = rezulto.ToString();
                            }
                            else if (n_radiko.Contains("res"))
                            {
                                n_radiko = rezulto.ToString();
                            }


                        }
                    }

                    enigita = TrigFunkcioj.N_aRadiko(Convert.ToDouble(bazo), Convert.ToInt16(n_radiko)).ToString(CultureInfo.CurrentCulture);
                }

                #endregion

                #region Rondigo

                //rondigi nombron
                if (enigita.Contains("rond"))
                {
                    string enigitaKopio = enigitaPostKonverto;
                    string[] disigita = enigitaKopio.Split("rond");
                    string rondigota = disigita[1];

                    // ĉu estas "res" por antaŭa rezulto?
                    double rezulto = rezultStako.Peek();
                    if (rezulto != 0)
                    {
                        if (rondigota.Contains("res"))
                        {
                            rondigota = rezultStako.Peek().ToString();
                            enigita = Rondigi(Convert.ToDouble(rondigota)).ToString(CultureInfo.CurrentCulture);
                        }
                    }
                    enigita = Rondigi(Convert.ToDouble(rondigota)).ToString(CultureInfo.CurrentCulture);

                }

                #endregion



                #region Potencoj
                List<string> potencoSimboloj = new List<string> { "pot", "^" };

                foreach (var potencoSimbolo in potencoSimboloj)
                {
                    // Potenci laŭ bazo kaj potenco entajpitiaj
                    if (enigita.Contains(potencoSimbolo))
                    {
                        string enigitaKopio = enigitaPostKonverto;
                        string[] disigita = enigitaKopio.Split(potencoSimbolo);
                        string bazo = disigita[0];
                        string potenco = disigita[1];


                        if (rezultStako.Count == 0)
                        {
                            if (enigita.Contains("res"))
                            {
                                //Se stako malplenas, ankaŭ malplenigi ant/res/rez por ke eroro ne okazu
                                Console.WriteLine("Ankoraŭ ne ekzistas antaŭa kalkulo registrita");
                            }
                        }
                        else
                        {
                            //se stako havas valorojn, preni lastan por kalkuli
                            // ĉu estas "res" por antaŭa rezulto?
                            double rezulto = rezultStako.Peek();
                            if (rezulto != 0)
                            {

                                if (bazo.Contains("res") && potenco.Contains("res"))
                                {
                                    potenco = bazo = rezulto.ToString();
                                }

                                if (bazo.Contains("res"))
                                {
                                    bazo = rezulto.ToString();
                                }
                                else if (potenco.Contains("res"))
                                {
                                    potenco = rezulto.ToString();
                                }


                            }
                        }

                        enigita = Potenci(Convert.ToDouble(bazo), Convert.ToDouble(potenco)).ToString(CultureInfo.CurrentCulture);
                    }
                }




                #endregion

                #region Monaj konvertoj
                /* 

                                // Provo konverti monon
                                string oxrAppId = "62182152dd4540d1885982f4c7685897";
                                List<string> listoDeValutoj = new List<string> {
                                    "AED", "AFN", "ALL", "AMD", "ANG", "AOA", "ARS", "AUD", "AWG", "AZN", "BAM", "BBD", "BDT", "BGN",
                                    "BHD", "BIF", "BMD", "BND", "BOB", "BRL", "BSD", "BTC", "BTN", "BWP", "BYN", "BZD", "CAD", "CDF",
                                    "CHF", "CLF", "CLP", "CNH", "CNY", "COP", "CRC", "CUC", "CUP", "CVE", "CZK", "DJF", "DKK", "DOP",
                                    "DZD", "EGP", "ERN", "ETB", "EUR", "FJD", "FKP", "GBP", "GEL", "GGP", "GHS", "GIP", "GMD", "GNF",
                                    "GTQ", "GYD", "HKD", "HNL", "HRK", "HTG", "HUF", "IDR", "ILS", "IMP", "INR", "IQD", "IRR", "ISK",
                                    "JEP", "JMD", "JOD", "JPY", "KES", "KGS", "KHR", "KMF", "KPW", "KRW", "KWD", "KYD", "KZT", "LAK",
                                    "LBP", "LKR", "LRD", "LSL", "LYD", "MAD", "MDL", "MGA", "MKD", "MMK", "MNT", "MOP", "MRO", "MRU",
                                    "MUR", "MVR", "MWK", "MXN", "MYR", "MZN", "NAD", "NGN", "NIO", "NOK", "NPR", "NZD", "OMR", "PAB",
                                    "PEN", "PGK", "PHP", "PKR", "PLN", "PYG", "QAR", "RON", "RSD", "RUB", "RWF", "SAR", "SBD", "SCR",
                                    "SDG", "SEK", "SGD", "SHP", "SLL", "SOS", "SRD", "SSP", "STD", "STN", "SVC", "SYP", "SZL", "THB",
                                    "TJS", "TMT", "TND", "TOP", "TRY", "TTD", "TWD", "TZS", "UAH", "UGX", "USD", "UYU", "UZS", "VEF",
                                    "VES", "VND", "VUV", "WST", "XAF", "XAG", "XAU", "XCD", "XDR", "XOF", "XPD", "XPF", "XPT", "YER",
                                    "ZAR", "ZMW", "ZWL", };

                                foreach (var valuto in listoDeValutoj)
                                {
                                    if (enigita.Contains(valuto))
                                    {
                                        string enigitaKopio = enigitaPostKonverto;
                                        string[] disigita = enigitaKopio.Split(valuto);
                                        //"deTemperaturo" estas unua valoro. Ekz-e "2 BRL al CAD" > deValuto == 2
                                        decimal deValuto = Convert.ToDecimal(disigita[0]);
                                        //alValuto estas la fina rezulto. Ekz-e "2 BRL al CAD" > alValuto == 5.2
                                        decimal alValuto = 0;
                                        string rezultoMonKonverto = $"https://openexchangerates.org/api/latest.json?app_id={oxrAppId}";

                                        WebClient client = new WebClient();
                                        string elŝutĈeno = client.DownloadString(rezultoMonKonverto);
                                        // Console.WriteLine(elŝutĈeno);


                                        int found = 0;
                                        found = elŝutĈeno.IndexOf("\"rates\": {");
                                        var modĈeno = elŝutĈeno
                                        .Substring(found)
                                        .Replace("\"rates\": {", String.Empty)
                                        .Replace("}", String.Empty)
                                        .Replace("\"", "'")
                                        .Replace(":", ": '")
                                        .Replace(",", "',")
                                        .Replace(" ", String.Empty)
                                        .ToLower()
                                        .Trim();
                                        modĈeno += "'";
                                        Console.WriteLine(modĈeno);


                                        string json = $"{{{modĈeno}}}";

                                        var jsonAlVortaro = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

                                        foreach (var item in jsonAlVortaro)
                                        {
                                            Console.WriteLine($"{item.Key} valoras {item.Value}");
                                        }
                                    }
                                }


                                */
                #endregion Monaj konvertoj

                #region Antaŭaj rezultoj

                List<string> rezultĈenoj = new List<string> { "res", "ant", "antaŭa", "rez", };

                foreach (string ĉeno in rezultĈenoj)
                {
                    if (enigita.Contains(ĉeno))
                    {
                        if (rezultStako.Count == 0)
                        {
                            //Se stako malplenas, ankaŭ malplenigi ant/res/rez por ke eroro ne okazu
                            Console.WriteLine("Ankoraŭ ne ekzistas antaŭa kalkulo registrita");
                            enigita = enigita.Replace(ĉeno, string.Empty);
                        }
                        else
                        {
                            //se stako havas valorojn, preni lastan por kalkuli
                            enigita = enigita.Replace(ĉeno, rezultStako.Peek().ToString(CultureInfo.CurrentCulture));
                        }
                    }
                }

                #endregion Antaŭaj rezultoj

                #region Ferm-komandoj

                List<string> elirKomandListo = new List<string> { "eliri()", "eliri", "fermu()" };
                foreach (string elirKomando in elirKomandListo)
                {
                    if (enigita.Contains(elirKomando))
                    {
                        Console.WriteLine("Ĉu vi vere volas fermi ĉi tiu aplikaĵon? [J]/[N]");
                        string jesAŭNe = Console.ReadLine()?.ToLower();
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

                #endregion Ferm-komandoj

                #region Montri rezulton

                List<string> unuoj = new List<string> { "m", "km", "k", "f", "c" };

                //Preni enjtapitajn valoron, post kiam trans-ŝanĝoj okazis (ekz. "dek" -> 10)
                // kaj fari la kalkulon

                try
                {
                    double rezulto = Convert.ToDouble(new DataTable().Compute(enigita, null));
                    rezultStako.Push(rezulto);
                    string finaSimboloStr = "";

                    if (finaSimbolo.Count() != 0)
                    {
                        // Console.WriteLine($"Jen la fina simbolo: {finaSimbolo.Peek()}");
                        finaSimboloStr = finaSimbolo.Peek();
                    }

                    //string testo = alKonvertoUnuo.Pop();
                    if (Math.Abs(rezulto % 2) < 0)
                    {
                        //string montruĈiTiun = Convert.ToDouble(rezulto).ToString("#,##0");
                        string montruĈiTiun = Convert.ToDouble(rezulto).ToString(CultureInfo.CurrentCulture);
                        Console.WriteLine($">> {montruĈiTiun.Replace(".", ",")} {finaSimboloStr}");
                        finaSimbolo.Clear();
                    }
                    else
                    {
                        Console.WriteLine($">> {rezulto.ToString(CultureInfo.CurrentCulture).Replace(".", ",")} {finaSimboloStr}");
                        finaSimbolo.Clear();
                    }
                }
                catch (Exception escepto)
                {
                    Console.WriteLine("Nevalida kalkulo");
                    Console.WriteLine(escepto);
                }

                #endregion Montri rezulton
            }
        }

        private static double Kvadrata(double numero) => Math.Sqrt(numero);

        private static double Potenci(double bazo, double potenco) => Math.Pow(bazo, potenco);

        private static double Rondigi(double rondigata) => Math.Round(rondigata);
    }
}