
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
        SearchItem[] si = new SearchItem[docs.Length];
        for (int i = 0; i < docs.Length; i++)
        {
            if (!docs[i].ContienePalabras(cb.PalabrasOperador('^'))) continue;
            si[i] = new SearchItem(docs[i].Name, docs[i].Snippet, vocabulario.ObtenerScore(cb, i));
        }

        Cronom.Stop();             //se detiene el cronometro
        Console.WriteLine("Tiempo empleado " + Cronom.ElapsedMilliseconds + "ms");

        return new SearchResult(si, vocabulario.GetSuggestion(query));

    }




}
