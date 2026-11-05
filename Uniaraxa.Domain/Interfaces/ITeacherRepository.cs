using Uniaraxa.Domain.Entities;

namespace Uniaraxa.Domain.Interfaces
{
    public interface ITeacherRepository
    {
        void AddTeacher(Teacher teacher);
        bool UpdateTeacher(Teacher teacher);
        bool DeleteTeacher(int id);
        Teacher? GetTeacherById(int id);
        List<Teacher> GetAllTeachers();
    }
}
