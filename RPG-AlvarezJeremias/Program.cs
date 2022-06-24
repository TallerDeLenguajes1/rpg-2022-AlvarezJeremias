using RPG_AlvarezJeremias;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List <personaje> peleadores=new List<personaje> ();
        List<personaje> perdedores = new List<personaje>();

        Console.WriteLine("Los dos primeros peleadores seran: ");
        personaje luchador1=new personaje ();
        personaje luchador2=new personaje ();
        peleadores.Add (luchador1);
        peleadores.Add (luchador2);
        foreach (personaje PJ in peleadores)
        {

        }

    }

    void MostrarLuchador(personaje PJ)
    {

        Console.WriteLine("Es de tipo : "+ PJ.Datos.Tipo);
        Console.WriteLine("Nacio el "+PJ.Datos.FechaNacimiento);
        Console.WriteLine($"y tiene {PJ.Datos.Edad} años!");
        Console.WriteLine("Su nombre es: "+ PJ.Datos.Nombre);
        Console.WriteLine($"El es {PJ.Datos.Apodo}!!!");

        Console.WriteLine($"Datos: \n|Fuerza: {PJ.Caracteristicas.Fuerza}|" +
            $"|Destreza: {PJ.Caracteristicas.Destreza}|" +
            $"|Armadura: {PJ.Caracteristicas.Armadura}|" +
            $"|Nivel: {PJ.Caracteristicas.Nivel}|" +
            $"|Velocidad: {PJ.Caracteristicas.Velocidad}|");


    }
}