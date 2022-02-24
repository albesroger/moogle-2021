using System.Reflection.Metadata;
using System.Collections.Generic;
namespace MotorBusque;
public class Class2
{
    Dictionary<string, int> Dicc1;

    public Class2(Documento[] docu)
    {

        Dicc1 = new Dictionary<string, int>();

        for (int i = 0; i < docu.Length; i++)
        {
            foreach (var item in docu[i].DevuelIter())
            {
                if (this.Dicc1.ContainsKey(auxiliar[i]))        //si la tiene le sumo 1 a su TF(frecuencia absoluta)
                {

                    this.Dicc1[item]++;

                }
                else
                {

                    this.Dicc1.Add(item, 1);                   // agrego una intancia de la palabra con TF == 1

                }
            }
        }

    }

}
