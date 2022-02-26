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

            text = leer.ReadToEnd().ToLower();                      //lee todo el documento y lo devuelve como un string

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
