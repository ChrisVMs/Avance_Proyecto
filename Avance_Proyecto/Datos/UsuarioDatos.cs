using System;
using Avance_Proyecto.Models;
using System.Data.SqlClient;
using System.Data;

namespace Avance_Proyecto.Datos
{
    public class UsuarioDatos
    {
        public bool Guardar(UsuarioModel ousuario)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar_Usuarios", conexion);
                    cmd.Parameters.AddWithValue("usuario", ousuario.usuario);
                    cmd.Parameters.AddWithValue("pass", ousuario.pass);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }
    }
}
