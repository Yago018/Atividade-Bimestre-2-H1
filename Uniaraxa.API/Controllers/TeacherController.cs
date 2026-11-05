using Microsoft.AspNetCore.Mvc;
using Uniaraxa.Domain.Entities;
using Uniaraxa.Service.Services;

namespace Uniaraxa.API.Controllers
{
    [ApiController]
    [Route("api/teacher")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public IActionResult GetAllTeachers() => Ok(_teacherService.GetAllTeachers());

        [HttpGet("{id:int}")]
        public IActionResult GetTeacherById(int id)
        {
            var teacher = _teacherService.GetTeacherById(id);
            return teacher is null ? NotFound() : Ok(teacher);
        }

        [HttpPost]
        public IActionResult AddTeacher([FromBody] Teacher teacher)
        {
            _teacherService.AddTeacher(teacher);
            return CreatedAtAction(nameof(GetTeacherById), new { id = teacher.Id }, teacher);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateTeacher(int id, [FromBody] Teacher teacher)
        {
            if (id != teacher.Id)
                return BadRequest("O ID da rota deve ser igual ao ID do professor.");

            return _teacherService.UpdateTeacher(teacher) ? NoContent() : NotFound();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteTeacher(int id)
        {
            return _teacherService.DeleteTeacher(id) ? NoContent() : NotFound();
        }
    }
}
