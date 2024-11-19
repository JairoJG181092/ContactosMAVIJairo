using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using ContactosMavi.Models;
using ContactosMavi.Clases;
using System.Diagnostics.Contracts;

namespace ContactosMavi.Controllers
{
    

    public class TransaccionesController : Controller
    {

        private Conexion conexion = new Conexion();

        // GET: Transacciones
        public ActionResult Index()
        {
            var contactos = ObtenerContactos();
            return View(contactos);
        }

        // GET: Transacciones/Buscar/5
        public ActionResult Buscar(string nombre)
        {
            var contactos = ConsultarContactos(nombre);
            return View("Index",contactos);
        }

        // GET: Transacciones/Ver
        public ActionResult Ver(int id)
        {
            var contacto = ConsultarContactoPorId(id);
            return View(contacto);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Transacciones/Create
        [HttpPost]
        public ActionResult Create(Contacto contacto)
        {
            
                if (ModelState.IsValid)
                {
                    if (contacto.Id == 0)
                    
                        InsertarContacto(contacto);
                    
                    else
                    
                        ActualizarContacto(contacto);
                    

                    return RedirectToAction("Index");
                }
            return View(contacto);
        }
        
        //// POST: Transacciones/Create
        //[HttpPost]
        //public ActionResult Create(Contacto contacto)
        //{
        //    try
        //    {
                
        //    catch
        //    {
        //        return View();
        //    }
        //    return View(contacto);
        //}

        // GET: Transacciones/Edit/5
        public ActionResult Edits(int id)
        {
            var contacto = ConsultarContactoPorId(id);
            return View(contacto);
        }

        // POST: Transacciones/Edit/5
        [HttpPost]
        public ActionResult Edits(Contacto contacto)
        {
            
                if (ModelState.IsValid)
                {
                 
                        ActualizarContacto(contacto);


                    return RedirectToAction("Index");
                }
                return View(contacto);
            
            
               
            
        }

        // GET: Transacciones/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                EliminarContacto(id);
                return RedirectToAction("Index");
            }
            catch { return View(); }
        }
        private List<Contacto> ObtenerContactos()
        {
            var lista = new List<Contacto>();
            conexion.Abrir();
            using (SqlCommand cmd = new SqlCommand("sp_ObtenerTodosContactos", conexion.GetConnection()))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Contacto
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            TipoContacto = reader.GetString(2),
                            TelefonoFijo = reader.GetString(3),
                            TelefonoMovil = reader.GetString(4),
                            FechaNacimiento = reader.GetDateTime(5),
                            Sexo = reader.GetString(6),
                            EstadoCivil = reader.GetString(7)
                        });
                    }
                }
                
            }
            return lista;
        }
        private List<Contacto> ConsultarContactos(string nombre)
        {
            List<Contacto> contactos = new List<Contacto>();
            conexion.Abrir();

            using (SqlCommand cmd = new SqlCommand("sp_ConsultarContactos", conexion.GetConnection()))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        contactos.Add(new Contacto
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            TipoContacto = reader.GetString(2),
                            TelefonoFijo = reader.IsDBNull(3) ? null : reader.GetString(3),
                            TelefonoMovil = reader.GetString(4),
                            FechaNacimiento = reader.GetDateTime(5),
                            Sexo = reader.GetString(6),
                            EstadoCivil = reader.GetString(7)
                        });
                    }
                }
            }

            conexion.Cerrar();
            return contactos;
        }

        private Contacto ConsultarContactoPorId(int id)
        {
            Contacto contacto = null;
            conexion.Abrir();

            using (SqlCommand cmd = new SqlCommand("sp_ConsultarContactoPorId", conexion.GetConnection()))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        contacto = new Contacto
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            TipoContacto = reader.GetString(2),
                            TelefonoFijo = reader.IsDBNull(3) ? null : reader.GetString(3),
                            TelefonoMovil = reader.GetString(4),
                            FechaNacimiento = reader.GetDateTime(5),
                            Sexo = reader.GetString(6),
                            EstadoCivil = reader.GetString(7)
                        };
                    }
                }
            }

            conexion.Cerrar();
            return contacto;
        }

        private void InsertarContacto(Contacto contacto)
        {
            conexion.Abrir();

            using (SqlCommand cmd = new SqlCommand("sp_InsertarContacto", conexion.GetConnection()))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", contacto.Nombre);
                cmd.Parameters.AddWithValue("@TipoContacto", contacto.TipoContacto);
                cmd.Parameters.AddWithValue("@TelefonoFijo", contacto.TelefonoFijo ?? "");
                cmd.Parameters.AddWithValue("@TelefonoMovil", contacto.TelefonoMovil);
                cmd.Parameters.AddWithValue("@FechaNacimiento", contacto.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Sexo", contacto.Sexo);
                cmd.Parameters.AddWithValue("@EstadoCivil", contacto.EstadoCivil);
                cmd.ExecuteNonQuery();
            }

            conexion.Cerrar();
        }

        private void ActualizarContacto(Contacto contacto)
        {
            conexion.Abrir();

            using (SqlCommand cmd = new SqlCommand("sp_ActualizarContacto", conexion.GetConnection()))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", contacto.Id);
                cmd.Parameters.AddWithValue("@Nombre", contacto.Nombre);
                cmd.Parameters.AddWithValue("@TipoContacto", contacto.TipoContacto);
                cmd.Parameters.AddWithValue("@TelefonoFijo", contacto.TelefonoFijo ?? "");
                cmd.Parameters.AddWithValue("@TelefonoMovil", contacto.TelefonoMovil);
                cmd.Parameters.AddWithValue("@FechaNacimiento", contacto.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Sexo", contacto.Sexo);
                cmd.Parameters.AddWithValue("@EstadoCivil", contacto.EstadoCivil);
                cmd.ExecuteNonQuery();
            }

            conexion.Cerrar();
        }

        private void EliminarContacto(int id)
        {
            conexion.Abrir();

            using (SqlCommand cmd = new SqlCommand("sp_EliminarContacto", conexion.GetConnection()))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }

            conexion.Cerrar();
        }
    }

}
