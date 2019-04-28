using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projetoApi.models;
using projetoApi.Repositorio;

namespace projetoApi.Controllers
{
    [Route("api/[controller]")]
    //[Authorize()]
    public class UsuarioController: Controller
    {
        private readonly IUsuarioRepository _usuarioRepor;
        
        public UsuarioController(IUsuarioRepository usuarioRepor)
        {
            _usuarioRepor = usuarioRepor;
        }

        [HttpGet]
        public IEnumerable<Usuarios> GetAll(){
            return _usuarioRepor.GetAll();
        }

        [HttpGet("{id}", Name="GetUsuario")]
        public IActionResult GetById(long id){

            var usuario = _usuarioRepor.Find(id);
            if(usuario==null){
                return NotFound();
            }else{
                return new ObjectResult(usuario);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Usuarios usuario){

            if(usuario==null){
                return BadRequest();
            }else{
                _usuarioRepor.add(usuario);
                return CreatedAtRoute("GetUsuario", new {id=usuario.Id}, usuario);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Usuarios usuario){

            if(usuario==null || usuario.Id != id){
                return BadRequest();
            }else{
                var _usuario = _usuarioRepor.Find(id);
                if(_usuario==null){
                    return NotFound();
                }else{
                    _usuario.Nome = usuario.Nome;
                    _usuario.Email = usuario.Email;  

                    _usuarioRepor.Update(_usuario);
                    return new NoContentResult();
                }
            }
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(long id){

            var usuario = _usuarioRepor.Find(id);

            if(usuario==null){
                return NotFound();
            }else{
                _usuarioRepor.Remover(id);
                return new NoContentResult();
            }
        }
    }
}