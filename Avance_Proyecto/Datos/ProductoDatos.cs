using Avance_Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Avance_Proyecto.Datos;
using System.Data;

namespace Avance_Proyecto.Datos
{
    public class ProductoDatos
    {
        public List<ProductoModel> Listar()
        {
            var oListaProducto = new List<ProductoModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar_Productos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oListaProducto.Add(new ProductoModel()
                        {
                            IdProducto = Convert.ToInt32(dr["IdProducto"]),
                            Nombre = dr["Nombre"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                            Stock = Convert.ToInt32(dr["Stock"])
                        });
                    }
                }
            }
            return oListaProducto;
        }

        public ProductoModel Obtener(int IdProducto)
        {
            var oProducto = new ProductoModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener_Productos", conexion);
                cmd.Parameters.AddWithValue("IdProducto", IdProducto);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oProducto.IdProducto = Convert.ToInt32(dr["IdProducto"]);
                        oProducto.Nombre = dr["Nombre"].ToString();
                        oProducto.Descripcion = dr["Descripcion"].ToString();
                        oProducto.Stock = Convert.ToInt32(dr["Stock"]);
                    }
                }
            }
            return oProducto;
        }

        public bool Guardar(ProductoModel ocontacto)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar_Productos", conexion);
                    cmd.Parameters.AddWithValue("Nombre", ocontacto.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", ocontacto.Descripcion);
                    cmd.Parameters.AddWithValue("Stock", ocontacto.Stock);
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

        public bool Editar(ProductoModel oproducto)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar_Productos", conexion);
                    cmd.Parameters.AddWithValue("IdProducto", oproducto.IdProducto);
                    cmd.Parameters.AddWithValue("Nombre", oproducto.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", oproducto.Descripcion);
                    cmd.Parameters.AddWithValue("Stock", oproducto.Stock);
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

        public bool Eliminar(int IdProducto)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar_Productos", conexion);
                    cmd.Parameters.AddWithValue("IdProducto", IdProducto);
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
