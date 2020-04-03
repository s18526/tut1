using System;
using System.Collections.Generic;
using Npgsql;
using Tutorial3.Models;

namespace Tutorial3.DAL
{
    public class SqlService : IDbService
    {
        private readonly NpgsqlConnection _sqlConnection = new NpgsqlConnection("Server=localhost;Database=apbd;Port=5432");

        public SqlService()
        {
            _sqlConnection.Open();
        }

        public IEnumerable<Student> GetStudents()
        {
            using var command = new NpgsqlCommand("SELECT * FROM Student;", _sqlConnection);
            using var sqlDataReader = command.ExecuteReader();

            var students = new List<Student>();
            while (sqlDataReader.Read())
            {
                students.Add(new Student
                {
                    IndexNumber = sqlDataReader["indexnumber"].ToString(),
                    FirstName = sqlDataReader["firstname"].ToString(),
                    LastName = sqlDataReader["lastname"].ToString(),
                });

            }

            return students;
        }

        public Student GetById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> GetSemesters(string studentId)
        {
            using var command = new NpgsqlCommand("SELECT E.Semester FROM Student JOIN Enrollment E on Student.IdEnrollment = E.IdEnrollment WHERE IndexNumber = @studentId;", _sqlConnection);
            command.Parameters.AddWithValue("studentId", studentId);

            using var sqlDataReader = command.ExecuteReader();
            var result = new List<int>();
            while (sqlDataReader.Read())
            {
                result.Add((int)sqlDataReader["Semester"]);
            }

            return result;
        }

        public Student Update(string id, Student student)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Student Add(Student student)
        {
            throw new NotImplementedException();
        }
    }
}