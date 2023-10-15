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
                datos.setearConsulta("Select Id, email, pass, admin, nombre, apellido, urlImagenPerfil from USERS where email = @email AND pass = @pass");
                datos.setearParametro("@email", users.Email);
                datos.setearParametro("@pass", users.Pass);
               
                datos.ejecutarLectura();

            

                if (datos.Lector.Read())
                {
                    users.Id = (int)datos.Lector["Id"];
                    //users.TipoUsuario = (bool)(datos.Lector["admin"]) == 1 ? TipoAdmin.ADMIN : TipoAdmin.USER;
                    users.Admin = (bool)(datos.Lector["admin"]);
                    if (!(datos.Lector["urlImagenPerfil"] is DBNull))
                        users.urlImagenPerfil = (string)datos.Lector["urlImagenPerfil"];
                    if (!(datos.Lector["nombre"] is DBNull))
                        users.Nombre = (string)datos.Lector["nombre"];
                    if (!(datos.Lector["apellido"] is DBNull))
                        users.Apellido = (string)datos.Lector["apellido"];
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

        public void actualizar(Usuario usuario)
        {
                AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update USERS set urlImagenPerfil = @imagen, Nombre = @nombre, Apellido = @apellido where Id = @id");
                //datos.setearParametro("@imagen", usuario.urlImagenPerfil != null ? usuario.urlImagenPerfil : "");
                datos.setearParametro("@imagen", (object)usuario.urlImagenPerfil ?? DBNull.Value);
                datos.setearParametro("@nombre", usuario.Nombre);
                datos.setearParametro("@apellido", usuario.Apellido);
                datos.setearParametro("@id", usuario.Id);
                datos.ejecutarAccion();
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
