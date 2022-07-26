using RPG_AlvarezJeremias;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\nCuando este listo para jugar, presione la tecla P, luego la tecla ENTER\n");
        int eleccion=Convert.ToChar(Console.ReadLine());
        string archivo = @"C:\Users\jerem\source\repos\rpg-2022-AlvarezJeremias\RPG-AlvarezJeremias\ganadores.csv";
        StreamWriter escritor = new StreamWriter(archivo); //abrimos un archivo con la clase StreamWriter para leer o escribir
        escritor.WriteLine("Nombre, Apodo, Tipo, Victorias"); //Escribimos en el archivo
        while (eleccion=='y'|| eleccion=='Y' || eleccion=='P' || eleccion=='p')
        {

        List <personaje> peleadores=new List<personaje> ();  //se crean las dos listas 
        List<personaje> perdedores = new List<personaje>();

        Console.WriteLine("Los dos primeros peleadores seran: ");
        personaje luchador1=new personaje ();// se crean los 4 personajes que participaran
        personaje luchador2=new personaje ();
        personaje luchador3=new personaje();// en ocasiones, los apodos y nombres de los personajes son iguales, lo que presta mucho a la confusion al momento de ejecutar el programa y leer los registros.
        personaje luchador4=new personaje ();// Eso queda para solucionarse en un futuro.
        peleadores.Add (luchador1);
        peleadores.Add (luchador2);// se añaden los 2 primeros luchadores a la lista de peleadores

        foreach (personaje PJ in peleadores)
        {
            MostrarLuchador(PJ);  // se muestran los luchadores en la lista actualmente
        }
        
        Console.WriteLine("\t----------PELEA:----------");
        int i;
            Console.WriteLine($"PELEADOR 1: {peleadores[0].Datos.Apodo}");
            Console.WriteLine($"PELEADOR 2: {peleadores[1].Datos.Apodo}");
        for ( i = 0; i < 3; i++)
        {


            Pelea(peleadores, 0, 1);   // se realiza el calculo de combate aleatorio
            i=KO(peleadores,perdedores,luchador1,luchador2,i);  // esta funcion chequea si alguno de los combatientes se quedo sin salud, y devuelve i=5 si asi es, caso contrario devuelve el valor actual de i
            if (peleadores.Count>1)
            {
                Console.WriteLine($"{peleadores[1].Datos.Apodo} logro sobrevivir al ataque!");
                Console.WriteLine($"Ahora, ATACA!");
                Pelea(peleadores,1,0);
                i = KO(peleadores, perdedores,luchador2,luchador1, i);

            }

        }

        if (i<5) // si ambos jugadores aun tienen vida restante..
        {
            if (peleadores[0].Datos.Salud < peleadores[1].Datos.Salud)   // Pierde el que menos salud tenga
            {
                perdedores.Add(peleadores[0]);
                peleadores.RemoveAt(0);
            }  else
            {
                perdedores.Add(peleadores[1]);
                peleadores.RemoveAt(1);
            }
        }
        
        while (peleadores.Count>1)  // Si ocurrio un empate, se pelea hasta que se desempate...
            {
                Console.WriteLine("\nHay que desempatar!");

                int k;
                for (k = 0;  k<3; k++)
                {
                Pelea(peleadores, 0, 1);
                k = KO(peleadores, perdedores,luchador1, luchador2,k);
                if(peleadores.Count>1)
                {
                    Console.WriteLine($"{peleadores[1].Datos.Apodo} logro sobrevivir al ataque!");
                    Console.WriteLine($"Ahora, ATACA!");
                    Pelea(peleadores, 1, 0);
                    k= KO(peleadores, perdedores, luchador2, luchador1, k);
                }
                }
                if (k < 5) // si ambos jugadores aun tienen vida restante..
                {
                    if (peleadores[0].Datos.Salud < peleadores[1].Datos.Salud)   // Pierde el que menos salud tenga
                    {
                        perdedores.Add(peleadores[0]);
                        peleadores.RemoveAt(0);
                    }
                    else
                    {
                        perdedores.Add(peleadores[1]);
                        peleadores.RemoveAt(1);
                    }
                }


            }
        int j;
        if (peleadores.Count == 1)
        {
            Console.WriteLine("\nA continuacion, pelearan otros dos competidores!");
            peleadores.Add(luchador3);
            peleadores.Add(luchador4);
            MostrarLuchador(luchador3);
            MostrarLuchador(luchador4);

            Console.WriteLine("\nAhora: A pelear!");

                Console.WriteLine($"PELEADOR 3: {peleadores[1].Datos.Apodo}");
                Console.WriteLine($"PELEADOR 4: {peleadores[2].Datos.Apodo}");
            for (j = 0; j < 3; j++)
            {

                Pelea(peleadores, 1, 2);
                i = KO(peleadores, perdedores, luchador3, luchador4, j);
                if (peleadores.Count > 1)
                {

                    Pelea(peleadores, 2, 1);
                    j = KO(peleadores, perdedores, luchador4, luchador3, j);


                }
            }
            if (j < 5)
            {
                if (luchador3.Datos.Salud < luchador4.Datos.Salud)
                {
                    perdedores.Add(luchador3);
                    peleadores.Remove(luchador3);
                }
                else
                {
                    perdedores.Add(luchador4);
                    peleadores.Remove(luchador4);
                }
            }
                while (peleadores.Count > 2)  // Si quedan mas de 2 jugadores en la tabla, se siguen peleando los luchadores 3 y 4 hasta que desempaten.
                {
                    Console.WriteLine("\nHay que desempatar!");

                    int x;
                    for (x = 0; x < 3; x++)
                    {
                        Pelea(peleadores, 1, 2);
                        x = KO(peleadores, perdedores, luchador3, luchador4, x);
                        if (peleadores.Count > 2)
                        {

                            Pelea(peleadores, 2, 1);
                            x = KO(peleadores, perdedores, luchador4, luchador3, x);
                        }
                    }
                    if (x < 5) // si ambos jugadores aun tienen vida restante..
                    {
                        if (luchador3.Datos.Salud < luchador4.Datos.Salud)   // Pierde el que menos salud tenga
                        {
                            perdedores.Add(luchador3);
                            peleadores.Remove(luchador3);
                        }
                        else
                        {
                            perdedores.Add(luchador4);
                            peleadores.Remove(luchador4);
                        }
                    }


                }
            }
            Console.WriteLine("\nsolamente quedan los finalistas!  ellos son: ");
            Console.WriteLine($"\n\n {peleadores[0].Datos.Nombre} y {peleadores[1].Datos.Nombre}!");

            Console.WriteLine("Ahora, se pelearan por el trono de hierro! :");
            Console.WriteLine("\nAhora: A pelear!");

            Console.WriteLine($"FINALISTA 1: {peleadores[0].Datos.Apodo}");
            Console.WriteLine($"FINALISTA 2: {peleadores[1].Datos.Apodo}");
            int f;
            for (f = 0;  f< 3; f++)
            {

                Pelea(peleadores, 0, 1);
                f = KO(peleadores, perdedores, peleadores[0], peleadores[1], f);
                if (peleadores.Count > 1)
                {

                    Pelea(peleadores, 1, 0);
                    f = KO(peleadores, perdedores, peleadores[1], peleadores[0], f);


                }
            }
            if (f< 5)
            {
                if (peleadores[0].Datos.Salud < peleadores[1].Datos.Salud)
                {
                    perdedores.Add(peleadores[0]);
                    peleadores.RemoveAt(0);
                }
                else
                {
                    perdedores.Add(peleadores[1]);
                    peleadores.RemoveAt(1);
                }
            }
            while (peleadores.Count > 1)  // Si quedan mas de 2 jugadores en la tabla, se siguen peleando los luchadores hasta que desempaten.
            {
                Console.WriteLine("\nHay que desempatar!");

                int x;
                for (x = 0; x < 3; x++)
                {
                    Pelea(peleadores, 0, 1);
                    x = KO(peleadores, perdedores, peleadores[0], peleadores[1], x);
                    if (peleadores.Count > 1)
                    {

                        Pelea(peleadores, 1, 0);
                        x = KO(peleadores, perdedores, peleadores[1], peleadores[0], x);
                    }
                }
                if (x < 5) // si ambos jugadores aun tienen vida restante..
                {
                    if (peleadores[0].Datos.Salud < peleadores[1].Datos.Salud)   // Pierde el que menos salud tenga
                    {
                        perdedores.Add(peleadores[0]);
                        peleadores.RemoveAt(0);
                    }
                    else
                    {
                        perdedores.Add(peleadores[1]);
                        peleadores.RemoveAt(1);
                    }
                }


            }
            foreach (personaje PJ in peleadores)
            {
                Console.WriteLine($"\nQuedo el finalista: {PJ.Datos.Nombre}");
            }
            peleadores[0].Datos.Victorias++;
            EscribirGanadorenCSV(peleadores, escritor);
            Console.Write("Desea volver a jugar? [Y/N] : ");
            eleccion = Convert.ToChar(Console.ReadLine());
            
        }
        escritor.Close();
    }
/*COMENTARIOS PARA EL MEJORAMIENTO PROXIMO DEL JUEGO
 -el proceso de If's,While's y for's necesarios para llevar a cabo las peleas se utiliza mucho, se tendra muy en cuenta convertirlo en una funcion para mejorar el aspecto del codigo.
-Actualmente decidí hacer el RPG solo con 4 luchadores, pero solo seria necesario repetir el mismo codigo indefinidamente para que sea posible hacerlo con mas jugadores

 */
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

    public static int KO (List<personaje> listaPeleadores, List<personaje>listaPerdedores, personaje PJ1, personaje PJ2, int opcion)
    {
        if (PJ1.Datos.Salud<=0){
            listaPerdedores.Add(PJ1);
            listaPeleadores.Remove(PJ1);
            return 5;
        }else
        {
            if (PJ2.Datos.Salud<=0)
            {
                listaPerdedores.Add(PJ2);
                listaPeleadores.Remove(PJ2);
                return 5;
            }
        }
        return opcion;
    }
    public static void  AumentoCaracteristicas (personaje PJ)
    {
        int opcion=0;
        while (opcion != 1 || opcion!=2 || opcion !=3) 
        {
            Console.WriteLine("El ganador sera premiado con un bonus de una caracteristica a eleccion!");
            Console.WriteLine("Elija cual sera la bonificacion que se llevara a cabo: \nOpcion 1: +10 Salud\nOpcion 2: +2 Fuerza.\nOpcion 3: +2 Armadura. ");
            opcion = Convert.ToInt32(Console.ReadLine());
 ;           switch (opcion)
            {
                case 1:
                    PJ.Datos.Salud += 10;
                    Console.WriteLine("Se a aumentado la salud del personaje en 10 puntos.");
                    Console.WriteLine($"Salud Actual: {PJ.Datos.Salud} puntos.");
                    break;

                case 2:
                    PJ.Caracteristicas.Fuerza += 2;
                    Console.WriteLine("Se a aumentado la fuerza del personaje en 2 puntos.");
                    Console.WriteLine($"Fuerza Actual: {PJ.Caracteristicas.Fuerza} puntos.");
                    break;
                case 3:
                    PJ.Caracteristicas.Armadura += 2;
                    Console.WriteLine("Se a aumentado la armadura del personaje en 2 puntos.");
                    Console.WriteLine($"Armadura Actual: {PJ.Caracteristicas.Armadura} puntos.");
                    break;
            }
        }


    }
    public static void EscribirGanadorenCSV(List <personaje> listaPeleadores, StreamWriter writer)
    {
        if (listaPeleadores[0].Datos.Victorias >=1)
        {
            writer.WriteLine($"{listaPeleadores[0].Datos.Nombre},{listaPeleadores[0].Datos.Apodo},{listaPeleadores[0].Datos.Tipo},{listaPeleadores[0].Datos.Victorias}");
        }
    }
    public static void RegistrarJson (List <personaje> ListaPeleadores)
    {
        string route = @"C:\Users\jerem\source\repos\rpg-2022-AlvarezJeremias\RPG-AlvarezJeremias\registroJugadores.json";
        var opcion = new JsonSerializerOptions { WriteIndented=true};
        string registro = JsonSerializer.Serialize(ListaPeleadores, opcion);
        File.WriteAllText(route, registro);

    }
    public static personaje CrearPjJson ()
    {

    }
}