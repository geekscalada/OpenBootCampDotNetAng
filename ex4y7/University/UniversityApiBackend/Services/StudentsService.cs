using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public class StudentsService : IStudentsService
    {

        private readonly UniversityDBContext _context;

        public StudentsService(UniversityDBContext context)
        {
            _context = context;
        }

        // TODO: resolve Mtehods
        public IEnumerable<Student> GetStudentsWithCourses()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetStudentsWithNoCourses()
        {
            var students = _context.Students;

            var listStudentsWithNoCourses = from student in students where !student.Courses.Any() select student;

            return listStudentsWithNoCourses;

        }

        public IEnumerable<Course> GetCoursesByStudent(string nameStudent)
        {
            var courses = _context.Courses;

            var listStudentsInsideCourse = courses!.Where(x => x.Students.Any(x => x.FirstName == nameStudent));

            return listStudentsInsideCourse;
        }

        public IEnumerable<Student> GetDataOfStudentByName(string nameStudent)
        {
            var students = _context.Students;

            var listDataStudent = from student in students where student.FirstName == nameStudent select student;

            return listDataStudent;
        }
    }
}
