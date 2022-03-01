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
    public class marcasController : ControllerBase
    {
        private readonly prestamosContext _contexto;

        public marcasController(prestamosContext miContexto)
        {
            this._contexto = miContexto;
        }

        [HttpGet]
        [Route("api/marcas")]
        public IActionResult Get()
        {
            IEnumerable<marcas> marcasList = from m in _contexto.marcas
                                               select m;

            if (marcasList.Count() > 0)
            {
                return Ok(marcasList);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("api/marcas/{idMarca}")]
        public IActionResult Get(int idMarca)
        {
            IEnumerable<marcas> marcas = from m in _contexto.marcas
                                           where m.id_marcas == idMarca
                                           select m;


            if (marcas.Count() > 0)
            {
                return Ok(marcas);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("api/marcas")]
        public IActionResult guardarEquipo([FromBody] marcas marcaNueva)
        {
            try
            {
                _contexto.marcas.Add(marcaNueva);
                _contexto.SaveChanges();
                return Ok(marcaNueva);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("api/marcas")]
        public IActionResult updateEquipo([FromBody] marcas marcaModificar)
        {
            try
            {
                marcas marcaExiste = (from m in _contexto.marcas
                                        where m.id_marcas == marcaModificar.id_marcas
                                        select m).FirstOrDefault();

                if (marcaExiste is null)
                {
                    return NotFound();
                }

                marcaExiste.nombre_marca = marcaModificar.nombre_marca;
                marcaExiste.estados = marcaModificar.estados;

                _contexto.Entry(marcaExiste).State = EntityState.Modified;
                _contexto.SaveChanges();

                return Ok(marcaExiste);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}
