using System.Collections.Generic;
using Tutorial3.Models;

namespace Tutorial3.DAL
{
    public interface IDbService
    {
       
        Student Update(string id, Student student);
       
        bool Delete(string id);
       
        Student Add(Student student);
       
        IEnumerable<Student> GetStudents();
        
        Student GetById(string id);
       
        IEnumerable<int> GetSemesters(string studentId);
    }
}