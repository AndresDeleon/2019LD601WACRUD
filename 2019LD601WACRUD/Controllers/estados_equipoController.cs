using _2019LD601WACRUD.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2019LD601WACRUD.Controllers
{
    [ApiController]
    public class estados_equipoController : ControllerBase
    {
        private readonly prestamosContext _contexto;

        public estados_equipoController(prestamosContext miContexto)
        {
            this._contexto = miContexto;
        }

        [HttpGet]
        [Route("api/estados_equipo")]
        public IActionResult Get()
        {
            IEnumerable<estados_equipo> estadosList = from ee in _contexto.estados_equipo
                                               select ee;

            if (estadosList.Count() > 0)
            {
                return Ok(estadosList);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("api/estados_equipo/{idEstadoEquipo}")]
        public IActionResult Get(int idEstadoEquipo)
        {
            IEnumerable<estados_equipo> estado = from ee in _contexto.estados_equipo
                                                      where ee.id_estados_equipo == idEstadoEquipo
                                                      select ee;

            if (estado.Count() > 0)
            {
                return Ok(estado);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("api/estados_equipo")]
        public IActionResult guardaEstado([FromBody] estados_equipo estadoNuevo)
        {
            try
            {
                _contexto.estados_equipo.Add(estadoNuevo);
                _contexto.SaveChanges();
                return Ok(estadoNuevo);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("api/estados_equipo")]
        public IActionResult updateEquipo([FromBody] estados_equipo estadoModificar)
        {
            try
            {
                estados_equipo estadoExiste = (from ee in _contexto.estados_equipo
                                        where ee.id_estados_equipo == estadoModificar.id_estados_equipo
                                        select ee).FirstOrDefault();

                if (estadoExiste is null)
                {
                    return NotFound();
                }

                estadoExiste.descripcion = estadoModificar.descripcion;
                estadoExiste.estado = estadoModificar.estado;

                _contexto.Entry(estadoExiste).State = EntityState.Modified;
                _contexto.SaveChanges();

                return Ok(estadoExiste);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}
