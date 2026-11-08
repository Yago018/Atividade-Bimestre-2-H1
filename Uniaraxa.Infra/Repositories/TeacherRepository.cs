using Domain.Entities;
using Domain.Interfaces;

namespace Infra.Repositories;

public class TeacherRepository : ITeacherRepository
{
    private readonly List<Teacher> _teachers = new();
    private readonly object _lock = new();
    private int _proximoId = 1;

    public Teacher Inserir(Teacher teacher)
    {
        lock (_lock)
        {
            var novo = Copiar(teacher);
            novo.Id = _proximoId++;
            _teachers.Add(novo);
            return Copiar(novo);
        }
    }

    public bool Atualizar(int id, Teacher teacher)
    {
        lock (_lock)
        {
            var existente = _teachers.FirstOrDefault(t => t.Id == id);

            if (existente is null)
                return false;

            existente.Name = teacher.Name;
            existente.Email = teacher.Email;
            existente.UrlLattes = teacher.UrlLattes;
            existente.DataAdmissao = teacher.DataAdmissao;

            return true;
        }
    }

    public IEnumerable<Teacher> ListarTodos()
    {
        lock (_lock)
        {
            return _teachers.Select(Copiar).ToList();
        }
    }

    public Teacher? BuscarPorId(int id)
    {
        lock (_lock)
        {
            var teacher = _teachers.FirstOrDefault(t => t.Id == id);
            return teacher is null ? null : Copiar(teacher);
        }
    }

    public bool Remover(int id)
    {
        lock (_lock)
        {
            return _teachers.RemoveAll(t => t.Id == id) > 0;
        }
    }

    private static Teacher Copiar(Teacher teacher) => new()
    {
        Id = teacher.Id,
        Name = teacher.Name,
        Email = teacher.Email,
        UrlLattes = teacher.UrlLattes,
        DataAdmissao = teacher.DataAdmissao
    };
}