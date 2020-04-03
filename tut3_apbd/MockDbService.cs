using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial3.Models;

namespace Tutorial3.DAL
{
    public class MockDbService : IDbService
    {
        private static IEnumerable<Student> _students;

        static MockDbService()
        {
            _students = new List<Student>
            {
                new Student{ idStudent=1, FirstName="Jan", LastName="Kowalski" },
                new Student{ idStudent=2, FirstName="Anna", LastName="Malewski" },
                new Student{ idStudent=3, FirstName="Anrzej", LastName="Anrzejewicz" }
            };
        }

        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }
    }
}
