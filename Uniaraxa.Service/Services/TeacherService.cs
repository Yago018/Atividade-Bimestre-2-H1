using Uniaraxa.Domain.Entities;
using Uniaraxa.Domain.Interfaces;

namespace Uniaraxa.Service.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public void AddTeacher(Teacher teacher) => _teacherRepository.AddTeacher(teacher);

        public bool UpdateTeacher(Teacher teacher) => _teacherRepository.UpdateTeacher(teacher);

        public bool DeleteTeacher(int id) => _teacherRepository.DeleteTeacher(id);

        public Teacher? GetTeacherById(int id) => _teacherRepository.GetTeacherById(id);

        public List<Teacher> GetAllTeachers() => _teacherRepository.GetAllTeachers();
    }
}
