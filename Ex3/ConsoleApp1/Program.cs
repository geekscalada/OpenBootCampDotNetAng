// See https://aka.ms/new-console-template for more information
using UniversityApiBackend;
using UniversityApiBackend.Models.DataModels;

Console.WriteLine("Hello, World!");


Services.findUsersByEmail("example5@example.com");

Services.findUsersOver18();

Services.findUsersWithAtLeastOneCourse();

Services.findCourseByLevelAndStudents(Level.Basic);


Services.findCoursesWOStudents();

Services.findCoursesByLevelAndCategory("frontend", Level.Medium);