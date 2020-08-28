using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Zoo
{
	class Program
	{
		Utility utility = new Utility();
		static void Main()
		{
			Program p = new Program();
			p.Run();
		}

		public void Run()
		{
			utility.TestTiger();
			string input = Console.ReadLine().ToLower();
			string[] command = input.Split(" ");
			while (true)
			{
				switch (command[0])
				{
					case "exit":
						Environment.Exit(0);
						break;
					default:
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.WriteLine("Unknown command");
						Console.ResetColor();
						break;
				}
			}
		}
	}

	class Utility
	{
		List<Animal> animals = new List<Animal>();
		public void TestTiger()
		{
			Tiger t = new Tiger("", 5, 5);
			animals.Add(t);
		}
	}

	class RndIDGen
	{
		static void RND(int min, int max)
		{
			Random rnd = new Random();
			rnd.Next(min, max);
		}
	}
	abstract class Animal
	{
		public string name;
		public int age;

		public Animal(string name, int age)
		{
			this.name = name;
			this.age = age;
		}
	}

	class Owl : Animal
	{
		public int wingspan;

		public Owl(string name, int age, int wingspan) : base(name, age)
		{
			this.wingspan = wingspan;
		}
	}

	class Tiger : Animal
	{
		public int weight;

		public Tiger(string name, int age, int weight) : base(name, age)
		{
			this.weight = weight;
		}
	}

	class Elephant : Animal
	{
		public int trunkLength;
		public Elephant(string name, int age, int trunkLenght) : base(name, age)
		{
			this.trunkLength = trunkLenght;
		}
	}

	class OtherAnim : Animal
	{
		public int species;
		public OtherAnim(string name, int age, int species) : base(name, age)
		{
			this.species = species;
		}
	}
}
