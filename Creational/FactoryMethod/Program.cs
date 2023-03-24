using System;

// Фабричный метод (Factory Method) - это паттерн, который определяет интерфейс для создания
// объектов некоторого класса,но непосредственное решение о том, объект какого класса создавать
// происходит в подклассах.То есть паттерн предполагает, что базовый класс делегирует создание
// объектов классам-наследникам.
namespace Patterns.Creational.FactoryMethod
{
	public class Program
	{
        public static void Main(string[] args)
        {
            Developer dev = new PanelDeveloper("ООО ПанельСтрой");
            House house = dev.Create();

            dev = new WoodDeveloper("ООО ДеревоСтрой");
            House house2 = dev.Create();
        }
    }

    // Абстрактный класс строительной компании
    abstract class Developer
	{
		public string Name { get; set; }

		public Developer(string Name)
		{
			this.Name = Name;
		}

		// Фабричный метод
		abstract public House Create();
	}

    // строит панельные дома
    class PanelDeveloper : Developer
	{
		public PanelDeveloper(string Name) : base(Name)
		{}

        public override House Create()
        {
			return new PanelHouse();
        }
    }

    // строит деревянные дома
    class WoodDeveloper : Developer
	{
		public WoodDeveloper(string Name) : base(Name)
		{ }

        public override House Create()
        {
			return new WoodHouse();
        }
    }

	abstract class House
	{ }

	class PanelHouse : House
	{
		public PanelHouse()
		{
			Console.WriteLine("Panel house has been created");
		}
	}

	class WoodHouse : House
	{
		public WoodHouse()
		{
			Console.WriteLine("Wood house has been created");
		}
	}
}

