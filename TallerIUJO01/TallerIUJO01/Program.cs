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
using System.Text;

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
			string id = partesRegistro[0].Trim().Replace("ID_", " ");
			string nombre = partesRegistro[1].Trim();
			string tarea = partesRegistro[2].Trim().ToLower();
			string nota = partesRegistro[3].Trim();
			
			Console.WriteLine(string.Format("el usuario {0} de ID: {1} tiene  la tarea {2} y {3} es su calificación", nombre, id, tarea, nota));
			
			//Flujo en Archivos
			
			string rutaRaiz = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DatosIUJO");
			string archivoTexto = Path.Combine(rutaRaiz, "notas.txt");
			
			Console.WriteLine(archivoTexto);
			
			if(!Directory.Exists(rutaRaiz))
			{
				Console.WriteLine("Creando Directorio....");
				Directory.CreateDirectory(rutaRaiz);
				Console.WriteLine("Directorio Creado con éxito.");
			}
			
			using (StreamWriter sw = new StreamWriter(archivoTexto, true))
			{
				sw.WriteLine(string.Format("ID: {0} | Nota: {1} | {2:yyyy-MM-dd HH:mm}", id, nota, DateTime.Now));
			}
			
			//Persistencia de Datos
			string archivoBin = Path.Combine(rutaRaiz, "auditoria.dat");
			using (FileStream fs = new FileStream(archivoBin, FileMode.Append, FileAccess.Write))
			{
				byte[] bytesID = Encoding.UTF8.GetBytes(id + "|");
				fs.Write(bytesID, 0, bytesID.Length);
			}
			Console.WriteLine("Persistencia de Datos generada con éxito.");
			
			//Inspección de Metadatos
			FileInfo info = new FileInfo(archivoTexto);
			Console.WriteLine(string.Format("El archivo notas pesa un total de: {0} bytes", info.Length));
			
			//Lectura Secuencial
			Console.WriteLine("\n---> Contenido Actual del Reporte:");
			using (StreamReader sr = new StreamReader(archivoTexto))
			{
				string linea;
				while ((linea = sr.ReadLine()) != null)
				{
					Console.WriteLine(" LINEA: " + linea);
				}
			}
			
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}