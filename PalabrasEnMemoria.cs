using System;
using System.Collections.Generic;

namespace Ahorcado
{
    public class PalabrasEnMemoria : IRepositorioPalabras
    {
        
        private readonly List<string> _palabras;

        public PalabrasEnMemoria(int categoria)
        {
            
            _palabras = categoria switch
            {
                1 => new List<string> { "arquitectura", "componente", "descomposicion", "dependencia", "acoplamiento" },
                2 => new List<string> { "polimorfismo", "encapsulamiento", "herencia", "abstraccion", "clase" },
                3 => new List<string> { "ensamblado", "namespace", "interfaz", "delegado", "middleware" },
                _ => new List<string> { "arquitectura", "polimorfismo", "ensamblado" }
            };
        }

        public string ObtenerPalabraAleatoria()
        {
            var random = new Random();
            return _palabras[random.Next(_palabras.Count)];
        }
    }
}