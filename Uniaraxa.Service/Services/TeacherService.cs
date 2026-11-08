using Domain.Entities;
using Domain.Interfaces;

namespace Uniaraxa.Service.Services;

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _repository;

    public TeacherService(ITeacherRepository repository)
    {
        _repository = repository;
    }

    public Teacher Inserir(Teacher teacher)
        => _repository.Inserir(teacher);

    public bool Atualizar(int id, Teacher teacher)
        => _repository.Atualizar(id, teacher);

    public IEnumerable<Teacher> ListarTodos()
        => _repository.ListarTodos();

    public Teacher? BuscarPorId(int id)
        => _repository.BuscarPorId(id);

    public bool Remover(int id)
        => _repository.Remover(id);
}