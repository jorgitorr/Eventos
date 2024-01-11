using System;


internal class Program
{
        
    public static void Main(string[] args)
    {
        Action miEvento = () => { };
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
}