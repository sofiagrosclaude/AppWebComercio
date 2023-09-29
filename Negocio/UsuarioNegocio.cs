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
        public bool Loguear(Usuario users)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Select Id, email, pass, admin from USERS where email = @email AND pass = @pass");
                datos.agregarParametro("@email", users.Email);
                datos.agregarParametro("@pass", users.Pass);




                datos.ejecutarLector();
                while (datos.Lector.Read())
                {
                    users.Id = (int)datos.Lector["Id"];
                    //users.TipoUsuario = (bool)(datos.Lector["admin"]) == 1 ? TipoAdmin.ADMIN : TipoAdmin.USER;
                    users.TipoUsuario = (bool)(datos.Lector["admin"]);
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

        public int insertarNuevo(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("insertarNuevo");
                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@pass", nuevo.Pass);
                return datos.ejecutarAccionScalar();


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
