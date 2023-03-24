using System;
using System.Text;

//Строитель (Builder) - шаблон проектирования,
//который инкапсулирует создание объекта и позволяет разделить его на различные этапы.
namespace Patterns.Creational.Builder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Baker baker = new Baker();

            BreadBuilder builder = new RyeBreadBuilder();
            Bread ryeBread = baker.Bake(builder);
            Console.WriteLine(ryeBread.ToString());

            builder = new WheatBreadBuilder();
            Bread wheatBread = baker.Bake(builder);
            Console.WriteLine(wheatBread.ToString());
        }
    }

    public class Flour
    {
        public string Sort { get; set; }
    }

    public class Salt
    { }

    public class Additives
    {
        public string Name { get; set; }
    }

    public class Bread
    {
        public Flour Flour { get; set; }

        public Salt Salt { get; set; }

        public Additives Additives { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (Flour != null)
                sb.Append(Flour.Sort + "\n");
            if (Salt != null)
                sb.Append("Соль \n");
            if (Additives != null)
                sb.Append(Additives.Name + "\n");

            return sb.ToString();
        }
    }

    public abstract class BreadBuilder
    {
        public Bread Bread { get; private set; }

        public void CreateBread()
        {
            Bread = new Bread();
        }

        public abstract void SetFlour();
        public abstract void SetSalt();
        public abstract void SetAdditives();
    }

    public class Baker
    {
        public Bread Bake(BreadBuilder breadBuilder)
        {
            breadBuilder.CreateBread();
            breadBuilder.SetFlour();
            breadBuilder.SetSalt();
            breadBuilder.SetAdditives();

            return breadBuilder.Bread;
        }
    }

    // строитель для ржаного хлеба
    public class RyeBreadBuilder : BreadBuilder
    {
        public override void SetFlour()
        {
            this.Bread.Flour = new Flour { Sort = "Ржаная мука 1 сорта" };
        }

        public override void SetSalt()
        {
            this.Bread.Salt = new Salt();
        }

        public override void SetAdditives()
        {
            // Не используется
        }
    }

    // строитель для пшеничного хлеба
    class WheatBreadBuilder : BreadBuilder
    {
        public override void SetFlour()
        {
            this.Bread.Flour = new Flour { Sort = "Пшеничная мука высший сорт" };
        }

        public override void SetSalt()
        {
            this.Bread.Salt = new Salt();
        }

        public override void SetAdditives()
        {
            this.Bread.Additives = new Additives { Name = "Улучшитель хлебопекарный" };
        }
    }
}

