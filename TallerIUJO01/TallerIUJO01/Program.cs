/*
 * Creado por SharpDevelop.
 * Usuario: usuario
 * Fecha: 17/4/2026
 * Hora: 10:52 a. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.IO;

namespace TallerIUJO01
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("-----Taller 01-----");
			
			//1. El dato del usuario
			string registroUsuario = "    ID_67;  ErnestoCables;  EVALUACION;    67";
			
			Console.WriteLine("\n");
			Console.WriteLine(registroUsuario);
			
			string registroLimpio = registroUsuario.Trim();
			
			
			Console.WriteLine(registroLimpio);
			
			string[] partesRegistro = registroLimpio.Split(';');
			string id = partesRegistro[0].Trim();
			string nombre = partesRegistro[1].Trim();
			string tarea = partesRegistro[2].Trim().ToLower();
			string nota = partesRegistro[3].Trim();
			
			Console.WriteLine("\n");
			Console.WriteLine(string.Format("el usuario {0} de ID: {1} tiene  la tarea {2} y {3} es su calificación", nombre, id, tarea, nota));
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}