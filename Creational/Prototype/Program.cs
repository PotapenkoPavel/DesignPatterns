using System;

// Паттерн Прототип (Prototype) позволяет создавать объекты на основе уже ранее созданных
// объектов-прототипов. То есть по сути данный паттерн предлагает технику клонирования объектов.
namespace Patterns.Creational.Prototype
{
	public interface IFigure
	{
		IFigure Clone();
		void GetInfo();
	}

	class Rectangle : IFigure
	{
		private int width { get; set; }
		private int height { get; set; }


		public Rectangle(int width, int height)
		{
			this.width = width;
			this.height = height;
		}

		public IFigure Clone()
		{
			return new Rectangle(width, height);
		}

		public void GetInfo()
		{
			Console.WriteLine($"Rectangle with width - {width} and height - {height}");
		}
	}

	class Circle : IFigure
	{
		public float radius { get; set; }

		public Circle(float radius)
		{
			this.radius = radius;
		}

		public IFigure Clone()
		{
			return new Circle(radius);
		}

		public void GetInfo()
		{
			Console.WriteLine($"Circle with radius - {radius}");
		}
	}

    class Program
    {
        public static void Main(string[] args)
        {
            Circle circle = new Circle(2.5f);

            circle.radius = 2.2F;
        }
    }
}

