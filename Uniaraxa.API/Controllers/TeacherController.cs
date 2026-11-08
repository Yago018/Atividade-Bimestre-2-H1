using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Uniaraxa.Service.Services;

namespace API.Controllers;

[ApiController]
[Route("api/teachers")]
public class TeacherController : ControllerBase
{
    private readonly ITeacherService _service;

    public TeacherController(ITeacherService service)
    {
        _service = service;
    }

    [HttpPost]
    public ActionResult<Teacher> Inserir([FromBody] Teacher teacher)
    {
        var criado = _service.Inserir(teacher);

        return CreatedAtAction(
            nameof(BuscarPorId),
            new { id = criado.Id },
            criado);
    }

    [HttpPut("{id:int}")]
    public IActionResult Atualizar(int id, [FromBody] Teacher teacher)
    {
        // O ID da rota identifica o registro a atualizar.
        if (!_service.Atualizar(id, teacher))
            return NotFound();

        return NoContent();
    }

    [HttpGet]
    public ActionResult<IEnumerable<Teacher>> ListarTodos()
    {
        return Ok(_service.ListarTodos());
    }

    [HttpGet("{id:int}")]
    public ActionResult<Teacher> BuscarPorId(int id)
    {
        var teacher = _service.BuscarPorId(id);

        if (teacher is null)
            return NotFound();

        return Ok(teacher);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Remover(int id)
    {
        if (!_service.Remover(id))
            return NotFound();

        return NoContent();
    }
}