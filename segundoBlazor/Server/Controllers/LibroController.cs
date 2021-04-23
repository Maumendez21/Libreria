using Microsoft.AspNetCore.Mvc;
using segundoBlazor.Server.Models;
using segundoBlazor.Shared.Libro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace segundoBlazor.Server.Controllers
{

    [ApiController]
    public class LibroController : Controller
    {
        [HttpGet]
        [Route("api/Libro/list")]
        public List<LibroCLS> listarLibro()
        {
            List<LibroCLS> listLibro = new List<LibroCLS>();

            using (BDBibliotecaContext db = new BDBibliotecaContext())
            {
                listLibro = (from libro in db.Libros
                               join autor in db.Autors
                               on libro.Iidautor equals autor.Iidautor
                               where libro.Bhabilitado == 1
                               select new LibroCLS
                               {
                                   idLibro = libro.Iidlibro,
                                   nombreAutor = autor.Nombre + " " + autor.Appaterno,
                                   Titulo = libro.Titulo,
                                   numPaginas = (int)libro.Numpaginas,
                                   Stock = (int)libro.Stock

                               }).ToList();
            }
            return listLibro;
        }
        [HttpPost]
        [Route("api/libro/guardar")]
        public int GuardarDatos([FromBody]LibroDTO libro)
        {
            int resp = 0;
            try
            {
                using (BDBibliotecaContext DB = new BDBibliotecaContext())
                {
                    if (libro.idLibro == 0)
                    {
                        Libro oLibro = new Libro();
                        oLibro.Iidautor =Convert.ToInt32(libro.Iidautor);
                        oLibro.Libropdf = libro.libroPDF;
                        oLibro.Fotocaratula = libro.caratula;
                        oLibro.Numpaginas = libro.numPaginas;
                        oLibro.Resumen = libro.Resumen;
                        oLibro.Stock = libro.Stock;
                        oLibro.Titulo = libro.Titulo;
                        oLibro.Bhabilitado = 1;
                        DB.Libros.Add(oLibro);
                        DB.SaveChanges();
                        resp = 1;

                    }
                    else
                    {
                        Libro oLibro = DB.Libros.Where(p => p.Iidlibro == libro.idLibro).First();
                        oLibro.Iidautor = Convert.ToInt32(libro.Iidautor);
                        oLibro.Libropdf = libro.libroPDF;
                        oLibro.Fotocaratula = libro.caratula;
                        oLibro.Numpaginas = libro.numPaginas;
                        oLibro.Resumen = libro.Resumen;
                        oLibro.Stock = libro.Stock;
                        oLibro.Titulo = libro.Titulo;
                        DB.SaveChanges();
                        resp = 1;
                    }
                }
            }
            catch (Exception)
            {
                resp = 0;
            }
            return resp;
        }

        [HttpGet]
        [Route("api/eliminarLibro/{id}")]
        public int eliminarLibro(int id)
        {
            int resp = 0;
            try
            {
                using (BDBibliotecaContext db = new BDBibliotecaContext())
                {
                    Libro libro = db.Libros.Where(p => p.Iidlibro == id).First();
                    libro.Bhabilitado = 0;
                    db.SaveChanges();
                    resp = 1;
                }
            }
            catch (Exception)
            {

                resp = 0;
            }
            return resp;
        }

        [HttpGet]
        [Route("api/libro/{idLibro}")]
        public LibroDTO RecuperarLibro(int idLibro)
        {
            LibroDTO olibro = new LibroDTO();
            using (BDBibliotecaContext DB = new BDBibliotecaContext())
            {
                 Libro oLibro = DB.Libros.Where(p => p.Iidlibro == idLibro).First();
                 olibro.idLibro = oLibro.Iidlibro;
                 olibro.Titulo = oLibro.Titulo;
                 olibro.Iidautor = oLibro.Iidautor.ToString();
                 olibro.Resumen = oLibro.Resumen;
                 olibro.libroPDF = oLibro.Libropdf;
                 olibro.caratula = oLibro.Fotocaratula;
                 olibro.numPaginas = oLibro.Numpaginas;
                 olibro.Stock = oLibro.Stock;

            }
            return olibro;
        }
    }
}
