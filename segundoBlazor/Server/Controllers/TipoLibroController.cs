using Microsoft.AspNetCore.Mvc;
using segundoBlazor.Server.Models;
using segundoBlazor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace segundoBlazor.Server.Controllers
{

    [ApiController]
    public class TipoLibroController : Controller
    {

        [HttpGet]
        [Route("api/TipoLibro/obtener/{Id?}")]
        public TipoLibroCLS obtenerTipoLibro(int Id)
        {
            TipoLibroCLS otipoLibro = new TipoLibroCLS();
            using (BDBibliotecaContext db = new BDBibliotecaContext())
            {
                otipoLibro = (from tipoLibro in db.TipoLibros
                              where tipoLibro.Iidtipolibro == Id
                              select new TipoLibroCLS
                              {
                                  Iidtipolibro = tipoLibro.Iidtipolibro,
                                  Nombretipolibro = tipoLibro.Nombretipolibro,
                                  Descripcion = tipoLibro.Descripcion

                              }).FirstOrDefault();
                return otipoLibro;
            }
                
        }

        [HttpPost]
        [Route("api/TipoLibro/Guardar")]
        public int Guardar([FromBody] TipoLibroCLS oTipoLibroCLS)
        {
            int resp = 0;

            try
            {
                using(BDBibliotecaContext db = new BDBibliotecaContext())
                {
                    if (oTipoLibroCLS.Iidtipolibro == 0)
                    {
                        TipoLibro oTipoLibro = new TipoLibro();
                        oTipoLibro.Nombretipolibro = oTipoLibroCLS.Nombretipolibro;
                        oTipoLibro.Descripcion = oTipoLibroCLS.Descripcion;
                        oTipoLibro.Bhabilitado = 1;
                        db.TipoLibros.Add(oTipoLibro);
                        db.SaveChanges();
                        resp = 1;
                    }else
                    {
                        TipoLibro oTipoLibro = db.TipoLibros.Where(p => p.Iidtipolibro == oTipoLibroCLS.Iidtipolibro).First();

                        oTipoLibro.Nombretipolibro = oTipoLibroCLS.Nombretipolibro;
                        oTipoLibro.Descripcion = oTipoLibroCLS.Descripcion;
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
        [Route("api/tipoLibro/Delete/{data?}")]
        public int eliminarTipoLibro(string data)
        {
            int resp = 0;

            try
            {
                using (BDBibliotecaContext db = new BDBibliotecaContext())
                {
                    int id = int.Parse(data);
                    TipoLibro otipoLibro = db.TipoLibros.Where(a => a.Iidtipolibro == id).First();
                    otipoLibro.Bhabilitado = 0;
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
        [Route("api/TipoLibro/Get")]
        public List<TipoLibroCLS> Get()
        {
            List<TipoLibroCLS> listado = new List<TipoLibroCLS>();
            using (BDBibliotecaContext db = new BDBibliotecaContext())
            {
                listado = (from tipoLibro in db.TipoLibros
                           where tipoLibro.Bhabilitado == 1
                           select new TipoLibroCLS
                           {
                               Iidtipolibro = tipoLibro.Iidtipolibro,
                               Nombretipolibro = tipoLibro.Nombretipolibro,
                               Descripcion = tipoLibro.Descripcion

                           }).ToList();

            }
            return listado;
        }
        
        [HttpGet]
        [Route("api/TipoLibro/Filtrar/{data?}")]
        public List<TipoLibroCLS> Filtrar(string data)
        {
            List<TipoLibroCLS> listado = new List<TipoLibroCLS>();
            using (BDBibliotecaContext db = new BDBibliotecaContext())
            {

                if (data == null)
                {

                    listado = (from tipoLibro in db.TipoLibros
                               where tipoLibro.Bhabilitado == 1
                               select new TipoLibroCLS
                               {
                                   Iidtipolibro = tipoLibro.Iidtipolibro,
                                   Nombretipolibro = tipoLibro.Nombretipolibro,
                                   Descripcion = tipoLibro.Descripcion

                               }).ToList();
                }
                else
                {
                    listado = (from tipoLibro in db.TipoLibros
                               where tipoLibro.Bhabilitado == 1
                               && tipoLibro.Nombretipolibro.Contains(data)
                               select new TipoLibroCLS
                               {
                                   Iidtipolibro = tipoLibro.Iidtipolibro,
                                   Nombretipolibro = tipoLibro.Nombretipolibro,
                                   Descripcion = tipoLibro.Descripcion

                               }).ToList();

                }

            }
            return listado;
        }

    }

}
