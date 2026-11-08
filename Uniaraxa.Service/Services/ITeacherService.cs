using Domain.Entities;

namespace Uniaraxa.Service.Services;

public interface ITeacherService
{
    Teacher Inserir(Teacher teacher);
    bool Atualizar(int id, Teacher teacher);
    IEnumerable<Teacher> ListarTodos();
    Teacher? BuscarPorId(int id);
    bool Remover(int id);
}