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
            MostrarLuchador(PJ);
        }
         
            Console.WriteLine("\t----------PELEA:----------");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"\t---RONDA NUMERO {i + 1}---");
                Console.WriteLine($"ATACANTE: {peleadores[0].Datos.Apodo}");
                Console.WriteLine($"OPONENTE: {peleadores[1].Datos.Apodo}");

                Pelea(peleadores, 0, 1);
                i=KO(peleadores,perdedores,i);
                if (peleadores.Count>1)
            {
                Console.WriteLine($"{peleadores[1].Datos.Apodo} logro sobrevivir al ataque!");
                Console.WriteLine($"Ahora, ATACA!");

            }

            }
        
         

    }

   public static void MostrarLuchador(personaje PJ)
    {
        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine("Es de tipo : "+ PJ.Datos.Tipo);
        Console.WriteLine($"Nacio el { PJ.Datos.FechaNacimiento.Day}, mes {PJ.Datos.FechaNacimiento.Month} del año {PJ.Datos.FechaNacimiento.Year}");
        Console.WriteLine($"y tiene {PJ.Datos.Edad} años!");
        Console.WriteLine("Su nombre es: "+ PJ.Datos.Nombre);
        Console.WriteLine($"El es {PJ.Datos.Apodo}!!!");

        Console.WriteLine($"\n --Datos-- \n|Fuerza: {PJ.Caracteristicas.Fuerza}|" +
            $"|Destreza: {PJ.Caracteristicas.Destreza}|" +
            $"|Armadura: {PJ.Caracteristicas.Armadura}|" +
            $"|Nivel: {PJ.Caracteristicas.Nivel}|" +
            $"|Velocidad: {PJ.Caracteristicas.Velocidad}|");
        Console.WriteLine();


    }

    public static void Pelea (List <personaje> listaPeleadores,int ataque, int defensa)
    {
        double PD = ((listaPeleadores[ataque].Caracteristicas.Destreza) / 1.5) * listaPeleadores[ataque].Caracteristicas.Fuerza * listaPeleadores[ataque].Caracteristicas.Nivel;
        Random r = new Random();
        double ED = r.Next(1,101);
        double VA = (PD * ED) / 100;

        double PDEF = listaPeleadores[defensa].Caracteristicas.Destreza * listaPeleadores[defensa].Caracteristicas.Armadura * listaPeleadores[defensa].Caracteristicas.Nivel;
        double EDEF = r.Next(1, 101);
        double VD = (PDEF* EDEF) /100;

        double DP = 0;
        if (VD>VA)
        {
            DP = 0;
        }
        else
        {
            DP = Math.Round(VA - VD);
        }
        if (DP > 0)
        {
        Console.WriteLine($"{listaPeleadores[ataque].Datos.Apodo} le hiso {DP} de daño a  {listaPeleadores[defensa].Datos.Apodo}");

        }else
        {
            Console.WriteLine($"{listaPeleadores[ataque].Datos.Apodo} no logro hacer daño a {listaPeleadores[defensa].Datos.Apodo}");
        }
        listaPeleadores[defensa].Datos.Salud -= DP;

        Console.WriteLine($"Salud actual de {listaPeleadores[defensa].Datos.Apodo}: {listaPeleadores[defensa].Datos.Salud}");

    }

    public static int KO (List<personaje> listaPeleadores, List<personaje>listaPerdedores, int opcion)
    {
        if (listaPeleadores[0].Datos.Salud<=0){
            listaPerdedores.Add(listaPeleadores[0]);
            listaPeleadores.RemoveAt(0);
            return 5;
        }else
        {
            if (listaPeleadores[1].Datos.Salud<=0)
            {
                listaPerdedores.Add(listaPeleadores[1]);
                listaPeleadores.RemoveAt(1);
                return 5;
            }
        }
        return opcion;
    }
}