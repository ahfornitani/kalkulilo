#!/usr/bin/python
# -*- coding: utf-8 -*-
import math

listo_anstatauigo = {"konstantopi": "3.1415926536",
                     "konstpi": "3.1415926536",
                     "konstantoe": "2.7182818285",
                     "konste": "2.7182818285",
                     "konstc": "299792458",
                     "lumrapido": "299792458"}
# print(listo_anstatauigo['lumrapido'])
for key, value in listo_anstatauigo.items():
    print(key, value)

while(True):
    # print("Enigu la valoron: \n")
    enigita = input()

    if "kpd" in enigita:
        # print("OMG, vi trovis min!")
        disigita = enigita.split("kpd")
        x = disigita[0]
        y = disigita[len(disigita) - 1]
        print(f'Rezulto estas: {math.floor(float(x)/float(y)*100)}%')
    else:
        print("Foriru!")


#  // se entajpita cheno enhavas "kpd" (kiel procentajho de), kalkuli adekvate
#                 if (enigita.Contains(("kpd")))
#                 {
#                     string[] disigita = enigita.Split("kpd");
#                     string x = disigita[0];
#                     string y = disigita[disigita.Length - 1];
#                     enigita = $"{x}/{y}*100";
#                 }
