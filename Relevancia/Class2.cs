using System.Numerics;
using System;
using System.Reflection.Metadata;
using System.Collections.Generic;
using HigherClass;
namespace MotorBusque;
public class Class2
{
    Dictionary<string, int> Dicc1;
    float[,] MatrisSistem;
    int tamanno;
    public Class2(Documento[] docu)
    {

        Dicc1 = new Dictionary<string, int>();
        tamanno = docu.Length;
        for (int i = 0; i < docu.Length; i++)
        {
            foreach (var item in docu[i].DevuelIter())
            {
                if (this.Dicc1.ContainsKey(item))        //si la tiene le sumo 1 a su TF(frecuencia absoluta)
                {

                    this.Dicc1[item]++;

                }
                else
                {

                    this.Dicc1.Add(item, 1);                   // agrego una intancia de la palabra con TF == 1

                }
            }
        }

        IniciMatrSistem(docu);
    }
    private void IniciMatrSistem(Documento[] document)
    {

        MatrisSistem = new float[document.Length, Dicc1.Count];
        for (int i = 0; i < document.Length; i++)
        {
            int index = 0;
            foreach (var aux in Dicc1.Keys)              // calcula TF-IDF
            {
                MatrisSistem[i, index++] = document[i].DevuelTF(aux) * (float)Math.Log10((float)document.Length / (float)Dicc1[aux]);
            }
        }
    }


    public string GetSuggestion(string term)
    {
        double distance = Double.MaxValue;
        string suggestion = string.Empty;
        string suggestions = string.Empty;
        foreach (var doc in term.Split(" "))
        {
            foreach (var word in Dicc1.Keys)
            {
                var dist = LevenshteinDistance(word, doc);
                if (distance > dist)
                {
                    distance = dist;
                    suggestion = word;
                }
            }
            distance = double.MaxValue;
            suggestions += suggestion;
            suggestions += " ";

        }
        return suggestions;
    }


    private int LevenshteinDistance(string s, string t)
    {

        // d es una tabla con m+1 renglones y n+1 columnas
        int costo = 0;
        int m = s.Length;
        int n = t.Length;
        int[,] d = new int[m + 1, n + 1];

        // Verifica que exista algo que comparar
        if (n == 0) return m;
        if (m == 0) return n;

        // Llena la primera columna y la primera fila.
        for (int i = 0; i <= m; d[i, 0] = i++) ;
        for (int j = 0; j <= n; d[0, j] = j++) ;


        /// recorre la matriz llenando cada unos de los pesos.
        /// i columnas, j renglones
        for (int i = 1; i <= m; i++)
        {
            // recorre para j
            for (int j = 1; j <= n; j++)
            {
                /// si son iguales en posiciones equidistantes el peso es 0
                /// de lo contrario el peso suma a uno.
                costo = (s[i - 1] == t[j - 1]) ? 0 : 1;
                d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1,              //Eliminacion
                            d[i, j - 1] + 1),                             //Insercion 
                            d[i - 1, j - 1] + costo);                     //Sustitucion
            }
        }

        return d[m, n];

    }

    public float[] VectoriQuiery(ClassBase PalabraRecivi)
    {

        float[] watusi = new float[Dicc1.Count];
        int index = 0;

        foreach (var aux in Dicc1.Keys)                                  // calcula TF-IDF
        {
            watusi[index++] = PalabraRecivi.DevuelTF(aux) * (float)Math.Log10((float)tamanno / (float)Dicc1[aux]);
        }
        return watusi;

    }

    public float ObtenerScore(ClassBase palabr_score, int puntacion)         //da el peso de cada palabra en los documentos(score)
    {

        float peso = 0f;
        float[] vector = VectoriQuiery(palabr_score);

        for (int i = 0; i < Dicc1.Count; i++)
        {
            peso += MatrisSistem[puntacion, i] * vector[i];
        }
        return peso;
    }

}
