using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25sept
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Team team = new Team();
            team.BuildHouse();
            Console.WriteLine("Строительство дома завершено!");
        }
    }
    public interface IPart
    {
        string Name { get; }
    }

    public interface IWorker
    {
        void Build(IPart partToBuild);
    }

    public class Basement : IPart
    {
        public string Name => " Фундамент ";
    }

    public class Walls : IPart
    {
        public string Name => " Стены ";
    }

    public class Window : IPart
    {
        public string Name => " Окно ";
    }

    public class Door : IPart
    {
        public string Name => "Дверь ";
    }

    public class Roof : IPart
    {
        public string Name => "Крыша ";
    }

    public class House
    {
        public Basement Basement { get; set; }
        public Walls Walls { get; set; }
        public List<Window> Windows { get; set; } = new List<Window>();
        public Door Door { get; set; }
        public Roof Roof { get; set; }

        public void ShowHouse()
        {
            Console.WriteLine("Ваш дом построен!  ");
            Console.WriteLine("     /\\      ");
            Console.WriteLine("    /  \\     ");
            Console.WriteLine("   /____\\    ");
            Console.WriteLine("  |      |   ");
            Console.WriteLine("  |  {}  |   ");
            Console.WriteLine("  |______|   ");
        }
    }

    public class Worker : IWorker
    {
        public void Build(IPart partToBuild)
        {
            Console.WriteLine($"Рабочий строит {partToBuild.Name}.");
        }
    }


    public class TeamLeader : IWorker
    {
        public void Build(IPart partToBuild)
        {

            Console.WriteLine($"Бригадир ведет отчет по постройке {partToBuild.Name}.");
        }
    }

    public class Team
    {
        private List<IWorker> workers = new List<IWorker>();
        private House house = new House();

        public Team()
        {
            for (int i = 0; i < 5; i++)
            {
                workers.Add(new Worker());
            }
            workers.Add(new TeamLeader());
        }

        public void BuildHouse()
        {

            var parts = new List<IPart>
        {
            new Basement(),
            new Walls(),
            new Walls(),
            new Walls(),
            new Door(),
            new Window(),
            new Window(),
            new Window(),
            new Window(),
            new Roof()
        };

            foreach (var part in parts)
            {
                foreach (var worker in workers)
                {
                    worker.Build(part);
                }
            }


            house.Basement = new Basement();
            house.Walls = new Walls();
            house.Door = new Door();
            house.Windows.Add(new Window());
            house.Windows.Add(new Window());
            house.Windows.Add(new Window());
            house.Windows.Add(new Window());
            house.Roof = new Roof();


            house.ShowHouse();
        }
    }
}

