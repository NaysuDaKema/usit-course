using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Man man = new();
            Boat boat = new();
            man.Travel(boat);
            Jet jet = new();

            // используем адаптер
            ITransport jetTransport = new HelToTransportAdapter(jet);
            man.Travel(jetTransport);
            Console.Read();
        }
    }
    interface ITransport
    {
        void Man();
    }

    class Boat : ITransport
    {
        public void Man()
        {
            Console.WriteLine("Лодка плывет по реке");
        }
    }
    class Man
    {
        public void Travel(ITransport transport)
        {
            transport.Man();
        }
    }
    // интерфейс вертолета
    interface IJet
    {
        void Move();
    }
    class Jet : IJet
    {
        public void Move()
        {
            Console.WriteLine("Рективный самолёт летит далеко, далёко");
        }
    }
    // Адаптер от Jet к ITransport
    class HelToTransportAdapter : ITransport
    {
        Jet jet;
        public HelToTransportAdapter(Jet c)
        {
            jet = c;
        }

        public void Man()
        {
            jet.Move();
        }
    }
}
