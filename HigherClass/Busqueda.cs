using System;
using Microsoft.VisualBasic.CompilerServices;
namespace HigherClass;
public class Busq : ClassBase              //clase relacionada con la busqueda
{
    public Busq(string busq) : base()      //constructor de la clase busqueda 
    {

        this.LLenarArrays(busq);

    }
}
