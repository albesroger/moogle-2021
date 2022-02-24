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
    public float[] VectoriQuiery(ClassBase PalabraRecivi)
    {

        float[] watusi = new float[Dicc1.Count];
        int index = 0;

        foreach (var aux in Dicc1.Keys)              // calcula TF-IDF
        {
            watusi[index++] = PalabraRecivi.DevuelTF(aux) * (float)Math.Log10((float)tamanno / (float)Dicc1[aux]);
        }
        return watusi;

    }
    public float ObtenerScore(ClassBase palabr_score, int puntacion)
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
