using Web_24BM.Models;

namespace Web_24BM.Services
{
	public class ContactoService
	{

		private readonly BaseDeDatosContext base_de_datos;
		
		public ContactoService(BaseDeDatosContext base_de_datos)
		{
			this.base_de_datos = base_de_datos;
		}
        public string? GuardarArchivo(IFormFile archivo, string carpetaDestino)
        {
            if (archivo == null || archivo.Length == 0)
            {
                return null; // No se proporcionó un archivo válido.
            }

            // Generar un nombre de archivo único con un uuid
            Guid uuid = Guid.NewGuid();
            
            string extension = Path.GetExtension(archivo.FileName);

            string nombreArchivo = $"{uuid}{extension}";

            // Combinar la ruta de destino con el nombre del archivo.
            string rutaCompleta = Path.Combine(carpetaDestino, nombreArchivo);

            // Crear el directorio de destino si no existe.
            if (!Directory.Exists(carpetaDestino))
            {
                Directory.CreateDirectory(carpetaDestino);
            }

            using (var stream = new FileStream(rutaCompleta, FileMode.Create))
            {
                archivo.CopyTo(stream);
            }

            return nombreArchivo;

        }
        public void CrearContacto(Curriculum curriculum)
		{

            string carpetaDestino = Path.Combine("wwwroot", "uploads");

            string archivo = this.GuardarArchivo( curriculum.Foto , carpetaDestino)!;

            Contacto nuevoContacto = new Contacto()
			{
				Nombre = curriculum.Nombre,
				Apellidos = curriculum.Apellidos,
				Email = curriculum.Email,
				Direccion = curriculum.Direccion,
				FechaNacimiento = curriculum.FechaNacimiento,
				Objetivo = curriculum.Objetivo,
                Foto = archivo
            };

			this.base_de_datos.Contactos.Add(nuevoContacto);

			this.base_de_datos.SaveChanges();

		}
	}
}
