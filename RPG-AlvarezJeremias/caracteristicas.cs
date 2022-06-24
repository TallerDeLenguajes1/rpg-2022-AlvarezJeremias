using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class valores
{
    private double velocidad;
    private double fuerza;
    private double destreza;
    private double armadura;
    private double nivel;

    public double Velocidad { get => velocidad; set => velocidad = value; }
    public double Fuerza { get => fuerza; set => fuerza = value; }
    public double Destreza { get => destreza; set => destreza = value; }
    public double Armadura { get => armadura; set => armadura = value; }
    public double Nivel { get => nivel; set => nivel = value; }

    public valores() { 
        Random random = new Random();
        this.Velocidad = random.Next(1, 10);
        this.Fuerza = random.Next(1, 10);
        this.Nivel = random.Next(1, 10);
        this.Armadura = random.Next(1, 10);
        this.Destreza = random.Next(1, 5);

    }
}

