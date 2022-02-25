using System;
using Microsoft.VisualBasic.CompilerServices;
namespace HigherClass;
public class Busqueda : ClassBase              //clase relacionada con la busqueda
{
    public Busqueda(string busq) : base()      //constructor de la clase busqueda 
    {

        this.LLenar_Arrays(busq);

    }
}
