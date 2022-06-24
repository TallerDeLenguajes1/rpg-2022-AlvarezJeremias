using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_AlvarezJeremias
{
    public class personaje
    {
        private valores caracteristicas;
        private data datos;

        public valores Caracteristicas { get => caracteristicas; set => caracteristicas = value; }
        public data Datos { get => datos; set => datos = value; }

        public personaje()
        {
            caracteristicas = new valores();
            datos= new data();
        }
    }
}
