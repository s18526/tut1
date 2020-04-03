using System;
using System.Collections.Generic;
using System.Linq;
using Tutorial3.Models;

namespace Tutorial3.DAL
{
    public class MockDbService : IDbService
    {
        private readonly List<Student> _students = new List<Student>()
        {
            new Student { IndexNumber = "s1", FirstName = "Max", LastName = "Kite"},
            new Student { IndexNumber = "s2", FirstName = "Tom", LastName = "Mise"},
            new Student { IndexNumber = "s3", FirstName = "Bob", LastName = "Brown"},
            new Student { IndexNumber = "s4", FirstName = "Kyle", LastName = "Vivik"},
        };

        public IEnumerable<Student> GetStudents() => _students;

        public Student GetById(string id) => _students.FirstOrDefault(student => student.IndexNumber == id);

        public IEnumerable<int> GetSemesters(string studentId)
        {
            return new int[] { };
        }

        public Student Add(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 1000)}";
            _students.Add(student);
            return student;
        }

        public Student Update(string id, Student student)
        {
            var getById = GetById(id);
            if (getById == null)
            {
                return null;
            }

            if (student.FirstName != null)
            {
                getById.FirstName = student.FirstName;
            }
            if (student.LastName != null)
            {
                getById.LastName = student.LastName;
            }
            if (student.IndexNumber != null)
            {
                getById.IndexNumber = student.IndexNumber;
            }

            return getById;
        }

        public bool Delete(string id) => _students.Remove(GetById(id));
    }
}