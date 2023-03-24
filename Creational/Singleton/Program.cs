using System;

// Одиночка (Singleton, Синглтон) - порождающий паттерн, который гарантирует, что для определенного
// класса будет создан только один объект, а также предоставит к этому объекту точку доступа.
namespace Patterns.Creational.Singleton
{
    class Singleton
    {
        private static Singleton? instance;

        private Singleton()
        { }

        public static Singleton GetInstance()
        {
            if (instance == null)
            {
                instance = new Singleton();
            }

            return instance;
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Singleton instance1 = Singleton.GetInstance();
            Singleton instance2 = Singleton.GetInstance();
            Console.WriteLine(instance1 == instance2);
        }
    }
}

