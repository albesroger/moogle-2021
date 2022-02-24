namespace HigherClass;
public class ClassBase
{
    Dictionary<string, int> diccionario;
    public ClassBase()
    {

        diccionario = new Dictionary<string, int>();            //inicio un diccionario nuevo

    }

    public ClassBase(string texto)
    {
        diccionario = new Dictionary<string, int>();
        LLenarArrays(texto);

    }
    protected void LLenarArrays(string texto)                   //rellena los terminos con la palabra y su frecuencia absoluta
    {

        var auxiliar = RemplasaSignos(texto);                   // var >> toma el tipo de valor que se le pase

        for (int i = 0; i < auxiliar.Length; i++)               //comprobar que el diccionario contenga la palabra
        {

            if (this.diccionario.ContainsKey(auxiliar[i]))      //si la tiene le sumo 1 a su TF(frecuencia absoluta)
            {

                this.diccionario[auxiliar[i]]++;

            }
            else
            {

                this.diccionario.Add(auxiliar[i], 1);          // agrego una intancia de la palabra con TF == 1

            }

        }

    }
    private string[] RemplasaSignos(string TextoOrigen)        //remplasar los signos que no me interesan
    {

        return TextoOrigen.ToLower()
                .Replace('\n', ' ')
                .Replace('_', ' ')
                .Replace(',', ' ')
                .Replace('.', ' ')
                .Replace(';', ' ')
                .Replace('-', ' ')
                .Replace('/', ' ')
                .Replace('\\', ' ')
                .Split(" ");

    }
    public int CantTerminos()                           //retorna la candidad de elementos del documento
    {

        return this.diccionario.Count;

    }

    public int DevuelTF(string palabra)                 //devuelve la frecuencia de un termino en especifo
    {
        if (this.diccionario.ContainsKey(palabra))      //si lo tiene
        {

            return this.diccionario[palabra];           //develvo su TF

        }
        return 0;                                       //en otro caso devuelvo 0

    }
    public IEnumerable<string> DevuelIter()             //devuelve un iterador que apunta a los terminos del texto  (cambiar)
    {

        return this.diccionario.Keys;                   // devuelve las llaves que hay en el diccionario  (cambiar)

    }

}
