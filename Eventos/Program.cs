using System;


internal class Program
{
        
    public static void Main(string[] args)
    {
        Ejemplo<int> miEjemplo = new Ejemplo<int>();
        miEjemplo.setPropiedad(6);
        Ejemplo<string> miEjemplo2 = new Ejemplo<string>();
        miEjemplo2.setPropiedad("hola");
        Ejemplo2<int, string> miEjemplo3 = new Ejemplo2<int, string>();
        miEjemplo3.setPropiedad(5,"manzanas");
        Console.WriteLine($"El tipo de la clase Ejemplo2 es: {miEjemplo3}");
        
        Action<int> miEventoParametrizado = null;
        Action miEvento = null;
        miEventoParametrizado += (int x) => Console.WriteLine(x);
        
        miEvento = () => { };
        miEvento += () => { Console.WriteLine("Evento Lanzado"); };
        miEvento += () => { Console.WriteLine("Evento 2 Lanzado"); };
        miEvento.Invoke();
        miEvento += () => { Console.WriteLine("Evento 3 lanzado"); };
        miEvento += () => { Console.WriteLine("Evento 4 lanzado"); };
        miEvento += miMetodo;
        Action<int> nuevoEvento = (int numero) => { };
        nuevoEvento += miParametrizado; /*-> es el metodo parametrizado*/ 
        nuevoEvento.Invoke(6);
        Console.WriteLine("---2 LLAMADA----");
        miEvento.Invoke();
            
            
        void miMetodo()
        {
            Console.WriteLine("Metodo 5 lanzado");
        }

        void miParametrizado(int numero)
        {
            Console.WriteLine("Metodo " + numero + " lanzado");
        }
        
    }
    
    /*La T es un genérico, que son variables las cuales se pone el tipo una vez se crea el objeto*/
    class Ejemplo<T>
    {
        private T propiedad;

        public void setPropiedad(T p)
        {
            propiedad = p;
        }

        public override string ToString()
        {
            return typeof(T).ToString();
        } 
    }

    class Ejemplo2<T,T2>
    {
        private T propiedad1;
        private T2 propiedad2;

        public void setPropiedad(T p, T2 p2)
        {
            propiedad1 = p;
            propiedad2 = p2;
        }

        public override string ToString()
        {
            return typeof(T).ToString() + typeof(T2).ToString();
        }
    }
}