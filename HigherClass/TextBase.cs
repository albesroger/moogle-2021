namespace HigherClass;

public class ClassBase
{
    Dictionary<string, int> diccionario;
    List<string>[] operadores;
    public ClassBase()
    {

        diccionario = new Dictionary<string, int>();            //inicio un diccionario nuevo

    }


    public string[] PalabrasOperador(char c)
    {
        switch (c)
        {
            case '^':
                return operadores[0].ToArray();
                break;
            case '!':
                return operadores[1].ToArray();
                break;
            case '~':
                return operadores[3].ToArray();
                break;
            case '*':
                return operadores[2].ToArray();
                break;
            default:
                return null;
                break;

        }

    }

    public ClassBase(string texto)
    {
        diccionario = new Dictionary<string, int>();
        LLenar_Arrays(CargarOperadores(texto));
        foreach (var a in PalabrasOperador('*'))
        {

            diccionario[a] *= 2;
        }

    }

    private string CargarOperadores(string query)
    {
        string nuevaquery = "";
        operadores = new List<string>[4];
        for (int i = 0; i < 4; i++)
        {

            operadores[i] = new List<string>();

        }
        int posicionPalabra = 0;
        for (int i = 0; i < query.Length; i++)
        {
            if (query[i] == ' ') posicionPalabra = i;
            if (query[i] == '^')
            {
                operadores[0].Add(BuscaPalabra(i + 1, query));
            }
            if (query[i] == '!')
            {
                operadores[1].Add(BuscaPalabra(i + 1, query));
            }
            if (query[i] == '*')
            {
                while (i < query.Length && query[i] == '*') i++;
                operadores[2].Add(BuscaPalabra(i, query));
            }
            if (query[i] == '~')
            {
                operadores[3].Add(BuscaPalabra(i + 1, query));
                operadores[3].Add(query.Substring(posicionPalabra, i));
            }
            else
            {
                nuevaquery += query[i];
            }
        }
        return nuevaquery;

    }


    private string BuscaPalabra(int pos, string text)
    {
        string palabra = "";

        for (int i = pos; i < text.Length; i++)
        {
            if (text[i] == ' ') break;

            palabra += text[i];
        }
        return palabra;
    }

    protected void LLenar_Arrays(string texto)                  //rellena los terminos con la palabra y su frecuencia absoluta
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
    protected string[] RemplasaSignos(string TextoOrigen)         //remplasar los signos que no me interesan
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

    public int CantTerminos()                                   //retorna la candidad de elementos del documento
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
    public IEnumerable<string> DevuelIter()             //devuelve un iterador que apunta a los terminos del texto  
    {

        return this.diccionario.Keys;                   // devuelve las llaves que hay en el diccionario  

    }

}
