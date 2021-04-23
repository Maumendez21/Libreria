using Microsoft.AspNetCore.Mvc;
using segundoBlazor.Server.Models;
using segundoBlazor.Shared.Autor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace segundoBlazor.Server.Controllers
{
    [ApiController]
    public class AutorController : Controller
    {
        [HttpGet]
        [Route("api/Autor/Delete/{data?}")]
        public int eliminarAutor(string data)
        {
            int resp = 0;

            try
            {
                using (BDBibliotecaContext db = new BDBibliotecaContext())
                {
                    int id = int.Parse(data);
                    Autor oautor = db.Autors.Where(a => a.Iidautor == id).First();
                    oautor.Bhabilitado = 0;
                    db.SaveChanges();
                    resp = 1;
                }

            }
            catch (Exception ex)
            {

                resp = 0;
            }

            return resp;
        }
        
        [HttpGet]
        [Route("api/Autor/recuperar/{idAutor?}")]
        public AutorEditCLS recuperarInfo(int idAutor)
        {
            AutorEditCLS oAutorCLS = new AutorEditCLS();
            using (BDBibliotecaContext db = new BDBibliotecaContext())
            {
                oAutorCLS = (from autor in db.Autors
                             where autor.Iidautor == idAutor
                             select new AutorEditCLS
                             {
                                 idAutor = autor.Iidautor,
                                 nombreAutor = autor.Nombre,
                                 aPaterno = autor.Appaterno,
                                 aMaterno = autor.Apmaterno,
                                 idPais = autor.Iidpais.ToString(),
                                 idSexo = autor.Iidsexo.ToString(),
                                 description = autor.Descripcion
                             }).FirstOrDefault();
                return oAutorCLS;
            }
        }

        [HttpGet]
        [Route("api/Autor/List")]
        public List<AutorCLS> listarAutor()
        {
            List<AutorCLS> listaAutor = new List<AutorCLS>();

            using(var db = new BDBibliotecaContext())
            {
                listaAutor = (from autor in db.Autors
                              join pais in db.Pais
                              on autor.Iidpais equals pais.Iidpais
                              join sexo in db.Sexos
                              on autor.Iidsexo equals sexo.Iidsexo
                              where autor.Bhabilitado==1
                              select new AutorCLS
                              {
                                  idAutor = autor.Iidautor,
                                  nombre = autor.Nombre + " " + autor.Appaterno + " " + autor.Apmaterno,
                                  pais = pais.Nombre,
                                  sexo = sexo.Nombre,
                                  description = autor.Descripcion
                              }).ToList();
            }


            return listaAutor;
        }

        [HttpGet]
        [Route("api/Autor/PaisList")]
        public List<PaisCLS> Paises()
        {
            List<PaisCLS> listPais = new List<PaisCLS>();
            using (var db = new BDBibliotecaContext())
            {
                listPais = (from pais in db.Pais
                            where pais.Bhabilitado == 1
                            select new PaisCLS
                            {
                                idPais = pais.Iidpais,
                                nombre = pais.Nombre
                            }).ToList();
            }
            return listPais;
        }

        [HttpGet]
        [Route("api/Autor/SexoList")]
        public List<SexoCLS> Sexo()
        {
            List<SexoCLS> listSexo = new List<SexoCLS>();
            using (var db = new BDBibliotecaContext())
            {
                listSexo = (from sexo in db.Sexos
                            where sexo.Bhabilitado == 1
                            select new SexoCLS
                            {
                                idSexo = sexo.Iidsexo,
                                sexo = sexo.Nombre
                            }).ToList();
            }
            return listSexo;
        }

        [HttpPost]
        [Route("api/Autor/Guardar")]
        public int GuardarDatos(AutorEditCLS oAutorCLS)
        {
            int resp = 0;

            try
            {
                using (BDBibliotecaContext db = new BDBibliotecaContext())
                {

                    if (oAutorCLS.idAutor==0)
                    {

                        Autor oAutor = new Autor();
                        oAutor.Nombre = oAutorCLS.nombreAutor;
                        oAutor.Appaterno = oAutorCLS.aPaterno;
                        oAutor.Apmaterno = oAutorCLS.aMaterno;
                        oAutor.Descripcion = oAutorCLS.description;
                        oAutor.Iidsexo = int.Parse(oAutorCLS.idSexo);
                        oAutor.Iidpais = int.Parse(oAutorCLS.idPais);
                        oAutor.Bhabilitado = 1;
                        db.Autors.Add(oAutor);
                        db.SaveChanges();
                        resp = 1;
                    }
                    else
                    {
                        Autor oAutor = db.Autors.Where(p => p.Iidautor == oAutorCLS.idAutor).First();
                        oAutor.Nombre = oAutorCLS.nombreAutor;
                        oAutor.Appaterno = oAutorCLS.aPaterno;
                        oAutor.Apmaterno = oAutorCLS.aMaterno;
                        oAutor.Descripcion = oAutorCLS.description;
                        oAutor.Iidsexo = int.Parse(oAutorCLS.idSexo);
                        oAutor.Iidpais = int.Parse(oAutorCLS.idPais);
                        db.SaveChanges();
                        resp = 1;
                    }
                }
            }
            catch (Exception ex)
            {

                resp = 0;
            }


            return resp;
        }

        [HttpGet]
        [Route("api/Autor/{data?}")]
        public List<AutorCLS> filtrarAutor(string data)
        {
            List<AutorCLS> listaAutor = new List<AutorCLS>();

            using (var db = new BDBibliotecaContext())
            {

                if (data == null || data == "--Seleccione--")
                {
                    listaAutor = (from autor in db.Autors
                                  join pais in db.Pais
                                  on autor.Iidpais equals pais.Iidpais
                                  join sexo in db.Sexos
                                  on autor.Iidsexo equals sexo.Iidsexo
                                  where autor.Bhabilitado == 1
                                  select new AutorCLS
                                  {
                                      idAutor = autor.Iidautor,
                                      nombre = autor.Nombre + " " + autor.Appaterno + " " + autor.Apmaterno,
                                      pais = pais.Nombre,
                                      sexo = sexo.Nombre,
                                      description = autor.Descripcion
                                  }).ToList();
                }
                else
                {
                    listaAutor = (from autor in db.Autors
                                  join pais in db.Pais
                                  on autor.Iidpais equals pais.Iidpais
                                  join sexo in db.Sexos
                                  on autor.Iidsexo equals sexo.Iidsexo
                                  where autor.Bhabilitado == 1 && autor.Iidpais == int.Parse(data)
                                  select new AutorCLS
                                  {
                                      idAutor = autor.Iidautor,
                                      nombre = autor.Nombre + " " + autor.Appaterno + " " + autor.Apmaterno,
                                      pais = pais.Nombre,
                                      sexo = sexo.Nombre,
                                      description = autor.Descripcion
                                  }).ToList();
                }
                
            }


            return listaAutor;
        }
    }
}
