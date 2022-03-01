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
    public class tipo_equipoController : ControllerBase
    {
        private readonly prestamosContext _contexto;

        public tipo_equipoController(prestamosContext miContexto)
        {
            this._contexto = miContexto;
        }

        [HttpGet]
        [Route("api/tipo_equipo")]
        public IActionResult Get()
        {
            IEnumerable<tipo_equipo> tipoEquiposList = from te in _contexto.tipo_equipo
                                               select te;

            if (tipoEquiposList.Count() > 0)
            {
                return Ok(tipoEquiposList);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("api/tipo_equipo/{idTipoEquipo}")]
        public IActionResult Get(int idTipoEquipo)
        {
            IEnumerable<tipo_equipo> tipo_equipo = from te in _contexto.tipo_equipo 
                                                   where te.id_tipo_equipo == idTipoEquipo 
                                                   select te;


            if (tipo_equipo.Count() > 0)
            {
                return Ok(tipo_equipo);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("api/tipo_equipo")]
        public IActionResult guardarEquipo([FromBody] tipo_equipo tipoEquipoNuevo)
        {
            try
            {
                _contexto.tipo_equipo.Add(tipoEquipoNuevo);
                _contexto.SaveChanges();
                return Ok(tipoEquipoNuevo);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("api/tipo_equipo")]
        public IActionResult updateEquipo([FromBody] tipo_equipo tipoEquipoModificar)
        {
            try
            {
                tipo_equipo tipoEquipoExiste = (from te in _contexto.tipo_equipo
                                        where te.id_tipo_equipo == tipoEquipoModificar.id_tipo_equipo
                                        select te).FirstOrDefault();

                if (tipoEquipoExiste is null)
                {
                    return NotFound();
                }

                tipoEquipoExiste.descripcion = tipoEquipoModificar.descripcion;
                tipoEquipoExiste.estado = tipoEquipoModificar.estado;

                _contexto.Entry(tipoEquipoExiste).State = EntityState.Modified;
                _contexto.SaveChanges();

                return Ok(tipoEquipoExiste);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}
