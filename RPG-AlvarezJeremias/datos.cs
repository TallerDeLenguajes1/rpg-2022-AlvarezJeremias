﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net;

public class data
{
    private string tipo = "";
    private string nombre = "";
    private string apodo = "";
    private DateTime fechaNacimiento;
    private int edad;
    private double salud;
    private int victorias;
    private string bardo;

    public string Tipo { get => tipo; set => tipo = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Apodo { get => apodo; set => apodo = value; }
    public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
    public int Edad { get => edad; set => edad = value; }
    public double Salud { get => salud; set => salud = value; }
    public int Victorias { get => victorias; set => victorias = value; }
    public string Bardo { get => bardo; set => bardo = value; }

    string[] ArregloNombres = new string[] { "V1", "DuskDude", "DoomGuy", "Duke Nukem", "Jacket", "Gordon Freeman" };
    string[] ArregloTipo = new string[] { "Cientifico", "Maquina", "Asesino", "Infernal" };
    string[] ArregloApodos = new string[] { "Blood Machine", "The Freeman", "Intruder", "Nightmare", "El Elegido", "Rockstar" };

    public data()
    {
        Random rand = new Random();
        int aux = rand.Next(0, 6);
        this.Nombre = ArregloNombres[aux];

        switch (aux)
        {
            case 0:
                this.Apodo = ArregloApodos[0];
                this.Tipo = ArregloTipo[1];
                break;
            case 1:
                this.Apodo = ArregloApodos[2];
                this.Tipo = ArregloTipo[3];
                break;
            case 2:
                this.Apodo = ArregloApodos[3];
                this.Tipo = ArregloTipo[3];
                break;
            case 3:
                this.Apodo = ArregloApodos[5];
                this.Tipo = ArregloTipo[2];
                break;
            case 4:
                this.Apodo = ArregloApodos[4];
                this.Tipo = ArregloTipo[2];
                break;
            case 5:
                this.Apodo = ArregloApodos[1];
                this.Tipo = ArregloTipo[0];
                break;

        }

        this.FechaNacimiento = new DateTime(rand.Next(1900, 2021), rand.Next(1, 13), rand.Next(1, 29));
        this.Salud = 100;
        this.Edad = ObtenerEdad(fechaNacimiento);
        this.Bardo=generadorInsultos();

    }
    public int ObtenerEdad(DateTime fechaNacimiento)
    {
        int edad = DateTime.Now.Year - fechaNacimiento.Year;

        if (fechaNacimiento.Month>DateTime.Now.Month)
        {
            edad -= 1;
        }
        if (fechaNacimiento.Month == DateTime.Now.Month)
        {
            if (fechaNacimiento.Day>DateTime.Now.Day)
            {
                edad -= 1;
            }

        }
        return edad;
    }
    public string generadorInsultos()
    {
        string url= $"https://evilinsult.com/generate_insult.php?lang=en&type=json";
        var pedido = (HttpWebRequest)WebRequest.Create(url);
        pedido.Method = "GET";
        pedido.ContentType = "application/json";
        pedido.Accept = "application/json";
        Random rand = new Random();

        using (WebResponse respuesta = pedido.GetResponse())
        {
            using (Stream reader = respuesta.GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(reader))
                {
                    string respuestaBody = sr.ReadToEnd();
                    Insulto myDeserializedClass = JsonSerializer.Deserialize<Insulto>(respuestaBody);
                    string insultoPersonal = myDeserializedClass.Insult;
                    return insultoPersonal;
                }
                
            }
        }
    }
    public class Insulto
    {
        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("insult")]
        public string Insult { get; set; }

        [JsonPropertyName("created")]
        public string Created { get; set; }

        [JsonPropertyName("shown")]
        public string Shown { get; set; }

        [JsonPropertyName("createdby")]
        public string Createdby { get; set; }

        [JsonPropertyName("active")]
        public string Active { get; set; }

        [JsonPropertyName("comment")]
        public string Comment { get; set; }
    }

}