using System;
using System.IO;
namespace HigherClass;
public class Documento : ClassBase                       //todo lo que tieneque ver con los documentos
{
    private string name;
    private string route;
    private string snippet;                              //cachito de texto

    public Documento(string route) : base()              //Contructor de esta clase
    {

        StreamReader leer = new StreamReader(route);
        string text;
        try
        {

            text = leer.ReadToEnd().ToLower();           //lee todo el documento y lo devuelve como un string
            leer.Close();                                //cierro el stream despues de leer el archivo

        }
        catch (EndOfStreamException error)
        {

            throw new Exception("Error al cargar");

        }

        LLenar_Arrays(text);                                //llenar los campos

        this.name = route.Split("/")[2];                   //le da a las rutas la forma ../Content/arch1.txt
        this.snippet = text.Length >= 100 ? text.Substring(0, 100) : text;            //si el texto tiene mas de 100 terminos devuelve solo esta cantidad sino me devuelve los que tengan
        this.route = route;

    }

    public bool ContienePalabras(string[] palabra)         //-----------------------------------   recibe un array de palablas y devuelve
    {                                                                                           // true si las tiene todas, sino, false                                                                    
        if (palabra == null || palabra.Length == 0) return true;
        foreach (var a in palabra)
        {
            if (this.DevuelTF(a) == 0)
            {
                return false;
            }
        }
        return true;
    }                                                      //--------------------------------------             

    public int DistanciaMinima(string[] palabras)          //lee las palabras par a par entre los documentos
    {
        if (palabras == null || palabras.Length == 0) return 1;

        StreamReader sr = new StreamReader(route);
        string[] lectura = RemplasaSignos(sr.ReadToEnd());
        sr.Close();

        int distancia = 0;
        for (int i = 0; i < lectura.Length; i++)
        {
            if (Array.IndexOf(palabras, lectura[i]) != -1)
            {
                distancia += i;
            }
        }
        return (distancia / lectura.Length) + 1;
    }

    public string Name             //devuelve el nombre
    {
        get
        {
            return name;
        }
    }

    public string Snippet
    {
        get
        {
            return snippet;
        }
    }
}
