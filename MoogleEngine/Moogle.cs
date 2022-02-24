
using System.IO;
using HigherClass;
using MotorBusque;
namespace MoogleEngine;


public static class Moogle
{
    public static SearchResult Query(string query)
    {
        ClassBase cb = new ClassBase(query);
        string[] archivos = Directory.GetFiles("../Content");
        Documento[] docs = new Documento[archivos.Length];

        for (int i = 0; i < archivos.Length; i++)
        {
            docs[i] = new Documento(archivos[i]);
        }

        Class2 vocabulario = new Class2(docs);
        SearchItem[] si = new SearchItem[docs.Length];
        for (int i = 0; i < docs.Length; i++)
        {
            si[i] = new SearchItem(docs[i].Name, docs[i].Snippet, vocabulario.ObtenerScore(cb, i));
        }
        return new SearchResult(si);
    }

}
