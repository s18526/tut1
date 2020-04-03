using System.Collections.Generic;
using Tutorial3.Models;

namespace Tutorial3.DAL
{
    public interface IDbService
    {
        IEnumerable<Student> GetStudents();

        Student Add(Student student);

        Student GetById(string id);
        
        Student Update(string id, Student student);
        
        bool Delete(string id);
       
        IEnumerable<int> GetSemesters(string studentId);
    }
}