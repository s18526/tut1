using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial3.Models;

namespace Tutorial3.DAL
{
    public interface IDbService
    {
        public IEnumerable<Student> GetStudents();
    }
}
