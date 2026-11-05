using Uniaraxa.Domain.Entities;

namespace Uniaraxa.Service.Services
{
    public interface ITeacherService
    {
        void AddTeacher(Teacher teacher);
        bool UpdateTeacher(Teacher teacher);
        bool DeleteTeacher(int id);
        Teacher? GetTeacherById(int id);
        List<Teacher> GetAllTeachers();
    }
}
