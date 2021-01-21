using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstHelloWorld
{
	struct Airport
	{
		public int count;
		public Aircraft[] aircrafts;

		public AircraftType AircraftType { get; private set; }

		public bool IsFreeRunway()
		{
			return aircrafts[aircrafts.Length - 1].flight != null;
		}

		public string[] GetAvailableAircraftTypes()
		{
			string[] array = new string[2] {
				AircraftType.Boing.ToString(),
				AircraftType.An.ToString()
			};
			return array;
		}

		public bool isHaveAircraft()
		{
			return aircrafts.Length > 0 && aircrafts[0].flight != "";
		}

		public void InitAircraft()
		{
			for (int i = 0; i < count; i++)
			{
				Console.WriteLine("Enter please number");
				Aircraft aircraft = new Aircraft()
				{
					flight = (Console.ReadLine()),
                    type = AircraftType.Boing,
					start = DateTime.Now,

					end = DateTime.Now
				};
				aircrafts[i] = aircraft;
			}
		}


	}


	struct Aircraft
	{
		public string flight;
		public AircraftType type;
		public DateTime start;
		public DateTime end;

	}

	enum AircraftType
	{

		Boing = 1,
		An,
	}

	class Program
	{
		private static Aircraft aircraft;

		static void Main(string[] args)
		{
			var airport = new Airport();
			var rand = new Random();
			Console.WriteLine("Enter runway place count");
			airport.count = Convert.ToInt32(Console.ReadLine());
			airport.aircrafts = new Aircraft[airport.count];
			bool isExit = false;
			int freeRunWay = 0;
			airport.InitAircraft();
			while (isExit == false)
			{
				Console.Clear();
				if (airport.isHaveAircraft())
				{
					Console.WriteLine("Aircraft");
					Console.WriteLine("Flight\t Type\t Landing\t\t\t TakeOff\t");
					for (int i = 0; i < airport.aircrafts.Length; i++)
					{
						var car = airport.aircrafts[i];
						var rnd = rand.Next(12);
						Console.WriteLine("{0}\t {1}\t {2}\t {3}\t", aircraft.flight, aircraft.type, aircraft.start, aircraft.end.AddHours(rnd));

					}
				}
				Console.WriteLine("Do you want to land the plain");
				bool isPlaneAircraft = Console.ReadLine() == "Yes" || Console.ReadLine() == "Y";
				if (isPlaneAircraft)
				{
					if (airport.IsFreeRunway())
					{
						Console.WriteLine("Haven`t free runway. Wait for car exit from parking.");
						Console.WriteLine("Continue? (Yes/No)");
						isExit = Console.ReadLine() == "No";
					}
					else
					{
						var Aircraft = new Aircraft();
						Console.WriteLine("Creating aircraft ");
						Console.WriteLine("Enter flight");
                        aircraft.flight = Console.ReadLine();
						
						var aircraftTypes = airport.GetAvailableAircraftTypes();
						for (int i = 0; i < aircraftTypes.Length; i++)
						{
							Console.WriteLine("{0}. {1}", i + 1, aircraftTypes[1]);
						}
						var selectedAircraftType = Convert.ToInt32(Console.ReadLine());
						switch (selectedAircraftType)
						{
							case (int)AircraftType.Boing:
                                aircraft.type = AircraftType.Boing;
								break;
							case (int)AircraftType.An:
								aircraft.type = AircraftType.An;
								break;
							default:
								aircraft.type = AircraftType.An - 24;
								break;
							
						}
						aircraft.start = DateTime.Now;
						airport.aircrafts[freeRunWay] = aircraft;
						freeRunWay++;
						Console.WriteLine("The plane is landed");
					}
				}
				Console.WriteLine("Continue? (Yes/No)");
				isExit = Console.ReadLine() == "No";
			}
		}
	}
}