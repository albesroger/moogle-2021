
using System.Collections.Generic;
using System.Diagnostics;
using System;
using System.IO;
using HigherClass;
using MotorBusque;
namespace MoogleEngine;


public static class Moogle
{
    public static SearchResult Query(string query)
    {
        Stopwatch Cronom = new Stopwatch();                //inicio cronometro para medir el tiempo de busqueda
        Cronom.Start();

        ClassBase cb = new ClassBase(query);
        string[] archivos = Directory.GetFiles("../Content");
        Documento[] docs = new Documento[archivos.Length];
        int tamFinal = 0;
        for (int i = 0; i < archivos.Length; i++)
        {
            docs[i] = new Documento(archivos[i]);
        }

        Class2 vocabulario = new Class2(docs);
        List<SearchItem> si = new List<SearchItem>();
        for (int i = 0; i < docs.Length; i++)
        {
            if (cb.PalabrasOperador('^').Length > 0 && !docs[i].ContienePalabras(cb.PalabrasOperador('^'))) continue;
            if (cb.PalabrasOperador('!').Length > 0 && docs[i].ContienePalabras(cb.PalabrasOperador('!'))) continue;
            if (Class2.ObtenerScore(cb, i) > 0)
            {

                si.Add(new SearchItem(docs[i].Name, docs[i].Snippet, Class2.ObtenerScore(cb, i) / docs[i].DistanciaMinima(cb.PalabrasOperador('~'))));

            }

        }
        System.Console.WriteLine();

        var sortList = si.OrderByDescending(x => x.Score);

        Cronom.Stop();             //se detiene el cronometro
        Console.WriteLine("Tiempo empleado " + Cronom.ElapsedMilliseconds + "ms");

        return new SearchResult(sortList.ToArray(), vocabulario.GetSuggestion(query));

    }




}
