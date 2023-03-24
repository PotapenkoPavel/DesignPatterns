using System;
// Паттерн "Абстрактная фабрика" (Abstract Factory) предоставляет интерфейс
// для создания семейств взаимосвязанных объектов с определенными интерфейсами
// без указания конкретных типов данных объектов.
namespace Patterns.Creational.AbstractFactory
{
	public class Program
	{
        public static void Main(string[] args)
        {
            Hero elf = new Hero(new ElfFactory());
            elf.Attack();
            elf.Run();

            Hero warrior = new Hero(new WarriorFactory());
            warrior.Attack();
            warrior.Run();

            Console.ReadLine();
        }
    }

    //абстрактный класс - оружие
    abstract class Weapon
	{
		public abstract void Hit();
	}

    // абстрактный класс движение
    abstract class Movement
	{
		public abstract void Move();
	}

    // класс арбалет
    class Arbalet : Weapon
	{
        public override void Hit()
        {
			Console.WriteLine("Hit from arbalet");
        }
    }

    // класс меч
    class Sword : Weapon
	{
        public override void Hit()
        {
			Console.WriteLine("Hit from sword");
        }
    }

    // движение - полет
    class FlyMovement : Movement
	{
        public override void Move()
        {
			Console.WriteLine("Flying");
        }
    }

    // движение - бег
    class RunMovement : Movement
	{
        public override void Move()
        {
            Console.WriteLine("Running");
        }
    }

    // класс абстрактной фабрики
    abstract class HeroFactory
    {
        public abstract Movement CreateMovement();
        public abstract Weapon CreateWeapon();
    }

    // Фабрика создания летящего героя с арбалетом
    class ElfFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new FlyMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Arbalet();
        }
    }

    // Фабрика создания бегущего героя с мечом
    class WarriorFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new RunMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Sword();
        }
    }

    // клиент - сам супергерой
    class Hero
    {
        private Weapon weapon;
        private Movement movement;

        public Hero(HeroFactory factory)
        {
            weapon = factory.CreateWeapon();
            movement = factory.CreateMovement();
        }

        public void Run()
        {
            movement.Move();
        }

        public void Attack()
        {
            weapon.Hit();
        }
    }
}

