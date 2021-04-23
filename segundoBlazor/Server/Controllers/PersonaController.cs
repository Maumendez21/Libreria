using Microsoft.AspNetCore.Mvc;
using segundoBlazor.Server.Models;
using segundoBlazor.Shared;
using segundoBlazor.Shared.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace segundoBlazor.Server.Controllers
{


    

    [ApiController]
    public class PersonaController : Controller
    {

        [HttpPost]
        [Route("api/Persona/Guardar")]
        public int Guardar([FromBody] PersonaEditarCLS oPersonaAdd)
        {
            int resp = 0;

            try
            {
                using (BDBibliotecaContext db = new BDBibliotecaContext())
                {
                    if (oPersonaAdd.idPersona == 0)
                    {
                        Persona oPersona = new Persona();
                        oPersona.Nombre = oPersonaAdd.nombre;
                        oPersona.Appaterno = oPersonaAdd.aPaterno;
                        oPersona.Apmaterno = oPersonaAdd.aMaterno;
                        oPersona.Telefono = oPersonaAdd.telefono;
                        oPersona.Correo = oPersonaAdd.correo;
                        oPersona.Fechanacimiento = oPersonaAdd.fechaNac;
                        oPersona.Bhabilitado = 1;
                        oPersona.Btieneusuario = 0;
                        db.Personas.Add(oPersona);
                        db.SaveChanges();
                        resp = 1;
                    }
                    else
                    {
                        Persona oPersona = db.Personas.Where(p => p.Iidpersona == oPersonaAdd.idPersona).First();
                        oPersona.Nombre = oPersonaAdd.nombre;
                        oPersona.Appaterno = oPersonaAdd.aPaterno;
                        oPersona.Apmaterno = oPersonaAdd.aMaterno;
                        oPersona.Telefono = oPersonaAdd.telefono;
                        oPersona.Correo = oPersonaAdd.correo;
                        oPersona.Fechanacimiento = oPersonaAdd.fechaNac;
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
        [Route("api/Persona/obtener/{Id?}")]
        public PersonaEditarCLS obtenerPersona(int Id)
        {
            PersonaEditarCLS oPersonaEdit = new PersonaEditarCLS();
            using (BDBibliotecaContext db = new BDBibliotecaContext())
            {
                oPersonaEdit = (from persona in db.Personas
                              where persona.Iidpersona == Id
                              select new PersonaEditarCLS
                              {
                                  idPersona = persona.Iidpersona,
                                  nombre = persona.Nombre,
                                  aPaterno = persona.Appaterno,
                                  aMaterno = persona.Apmaterno,
                                  telefono = persona.Telefono,
                                  correo = persona.Correo,
                                  fechaNac = (DateTime) persona.Fechanacimiento

                              }).FirstOrDefault();
                return oPersonaEdit;
            }

        }
        [HttpGet]
        [Route("api/Personas/List")]
       public List<PersonasCLS> listarPersonas()
        {
            List<PersonasCLS> listaPersona = new List<PersonasCLS>();

            using (BDBibliotecaContext db = new BDBibliotecaContext()) 
            {
                listaPersona = (from persona in db.Personas
                                where persona.Bhabilitado == 1
                                select new PersonasCLS
                                {
                                    idPersona = persona.Iidpersona,
                                    nombreCompleto = persona.Nombre + " " + persona.Appaterno + " " + persona.Apmaterno,
                                    correo = persona.Correo,
                                    fechaMostrarCadena = persona.Fechanacimiento == null ? "" :
                                    persona.Fechanacimiento.Value.ToShortDateString()
                                }).ToList();
            }


            return listaPersona;
        }

        [HttpGet]
        [Route("api/Personas/buscar/{data?}")]
        public List<PersonasCLS> Buscar(string data)
        {
            

            List<PersonasCLS> listaPersona = new List<PersonasCLS>();

            using (BDBibliotecaContext db = new BDBibliotecaContext())
            {
                if (data==null)
                {

                    listaPersona = (from persona in db.Personas
                                    where persona.Bhabilitado == 1
                                    select new PersonasCLS
                                    {
                                        idPersona = persona.Iidpersona,
                                        nombreCompleto = persona.Nombre + " " + persona.Appaterno + " " + persona.Apmaterno,
                                        correo = persona.Correo,
                                        fechaMostrarCadena = persona.Fechanacimiento == null ? "" :
                                        persona.Fechanacimiento.Value.ToShortDateString()
                                    }).ToList();
                }
                else
                {
                    listaPersona = (from persona in db.Personas
                                    where persona.Bhabilitado == 1 &&
                                    (persona.Nombre + " " + persona.Appaterno + " " + persona.Apmaterno).Contains(data)
                                    select new PersonasCLS
                                    {
                                        idPersona = persona.Iidpersona,
                                        nombreCompleto = persona.Nombre + " " + persona.Appaterno + " " + persona.Apmaterno,
                                        correo = persona.Correo,
                                        fechaMostrarCadena = persona.Fechanacimiento == null ? "" :
                                        persona.Fechanacimiento.Value.ToShortDateString()
                                    }).ToList();

                }
            }


            return listaPersona;
        }

        [HttpGet]
        [Route("api/Persona/Delete/{idPersona?}")]
        public int Elminar(int idPersona)
        {
            int resp = 0;

            try
            {
                using (BDBibliotecaContext db = new BDBibliotecaContext())
                {
                    Persona oPersona = db.Personas.Where(p => p.Iidpersona == idPersona).FirstOrDefault();
                    oPersona.Bhabilitado = 0;
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
    }
}
