using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;




namespace Negocio
{
    public class UsuarioNegocio
    {
		public bool Loguear(Usuario usuario)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setearQuery("Select Id, email, pass, admin from USERS where email = @email AND pass = @pass");
				datos.agregarParametro("@email", usuario.Email);
				datos.agregarParametro("@pass", usuario.Pass);
				

				

				datos.ejecutarLector();
				while (datos.Lector.Read())
				{
					usuario.Id = (int)datos.Lector["Id"];
                    usuario.TipoUsuario = (int)(datos.Lector["admin"]) == 1 ? TipoAdmin.ADMIN : TipoAdmin.USER;
                    return true;
				}
				return false;

			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				datos.cerrarConexion();
			}
		}

	}
}
