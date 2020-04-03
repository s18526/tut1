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
            new Student { IndexNumber = "s12345", FirstName = "Tom", LastName = "Vice"},
            new Student { IndexNumber = "s23456", FirstName = "Kyle", LastName = "Johnson"},
            new Student { IndexNumber = "s34567", FirstName = "Bob", LastName = "Mise"},
        };

        public IEnumerable<Student> GetStudents() => _students;

        public Student GetById(string id) => _students.FirstOrDefault(student => student.IndexNumber == id);

        public IEnumerable<int> GetSemesters(string studentId)
        {
            return new int[] { };
        }

        public Student Add(Student student)
        {
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