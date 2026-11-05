using Uniaraxa.Domain.Entities;
using Uniaraxa.Domain.Interfaces;

namespace Uniaraxa.Infra.Repositories
{
    // Os dados permanecem em memoria somente enquanto a API estiver em execucao.
    public class TeacherRepository : ITeacherRepository
    {
        private readonly Dictionary<int, Teacher> _teachers = new();
        private readonly object _lock = new();
        private int _nextId;

        public void AddTeacher(Teacher teacher)
        {
            lock (_lock)
            {
                teacher.Id = ++_nextId;
                _teachers.Add(teacher.Id, Copy(teacher));
            }
        }

        public bool UpdateTeacher(Teacher teacher)
        {
            lock (_lock)
            {
                if (!_teachers.ContainsKey(teacher.Id))
                    return false;

                _teachers[teacher.Id] = Copy(teacher);
                return true;
            }
        }

        public bool DeleteTeacher(int id)
        {
            lock (_lock)
            {
                return _teachers.Remove(id);
            }
        }

        public Teacher? GetTeacherById(int id)
        {
            lock (_lock)
            {
                return _teachers.TryGetValue(id, out var teacher) ? Copy(teacher) : null;
            }
        }

        public List<Teacher> GetAllTeachers()
        {
            lock (_lock)
            {
                return _teachers.Values.Select(Copy).ToList();
            }
        }

        private static Teacher Copy(Teacher teacher) => new()
        {
            Id = teacher.Id,
            Name = teacher.Name,
            Email = teacher.Email,
            UrlLattes = teacher.UrlLattes,
            DataAdmissao = teacher.DataAdmissao
        };
    }
}
