using Web_24BM.Models;

namespace Web_24BM.Services
{
	public class ContactoService
	{

		private readonly MayateContext base_de_datos;
		
		public ContactoService(MayateContext db)
		{
			this.base_de_datos = db;
		}

		public void CrearContacto(Curriculum curriculum)
		{
			
			Contacto nuevoContacto = new Contacto()
			{
				Nombre = "Martin",
				Apellidos = "Aguilar"
			};

			this.base_de_datos.Contactos.Add(nuevoContacto);

			this.base_de_datos.SaveChanges();

		}
	}
}
