using System;
using System.IO;
using System.Text;

namespace Charcito
{
	class HighScore
	{
		private int _high;
		private string _name;
		public HighScore()
		{
			_high = 0;
			_name = "Margarita";
		}
		public HighScore(int high, string name)
		{
			_high = high;
			_name = name;
		}
		public void EscribiElPuntaje(int puntos)
		{
			if (!File.Exists("HIGHSCOREY.bin"))
			{
				FileStream puntajeAlto = new FileStream("HIGHSCOREY.bin", FileMode.Create);
			}
			BinaryWriter writing = new BinaryWriter(File.Open("HIGHSCOREY.bin", FileMode.Open));
			if (!(puntos > _high))
			{
				writing.Write(_name);
				writing.Write(" ");
				writing.Write(_high);
			}
			if (puntos > _high)
			{
				Console.WriteLine("NUEVO PUNTAJE MAS ALTO!!!");
				Console.WriteLine("Por favor, escriba su nombre...");
				_name = Console.ReadLine();
				_high = puntos;
				writing.Write(_name);
				writing.Write(" ");
				writing.Write(_high);
			}
		}
		public void LeeElPuntaje()
		{
			if(File.Exists("HIGHSCOREY.bin"))
			{
				BinaryReader reading = new BinaryReader(File.Open("HIGHSCOREY.bin", FileMode.Open));
				Console.Write(reading.ReadString() + " " + reading.ReadInt32());
			}
		}
	}
}