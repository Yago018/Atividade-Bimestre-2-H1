using Domain.Entities;

namespace Domain.Interfaces;

public interface ITeacherRepository
{
    Teacher Inserir(Teacher teacher);
    bool Atualizar(int id, Teacher teacher);
    IEnumerable<Teacher> ListarTodos();
    Teacher? BuscarPorId(int id);
    bool Remover(int id);
}