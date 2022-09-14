using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ODataDemo.Models;

namespace OData6Demo.Api.Services
{
    public class StudentService : IStudentService
    {
        public IQueryable<Student> RetrieveAllStudents()
        {
            return new List<Student>
            {
                new Student
                {
                    Id = Guid.NewGuid(),
                    Name = "Sujith",
                    Score = 200
                },
                new Student
                {
                    Id = Guid.NewGuid(),
                    Name = "Kushal",
                    Score = 160
                },
                new Student
                {
                    Id = Guid.NewGuid(),
                    Name = "kiran",
                    Score = 170
                }
            }.AsQueryable(); ;
        }
    }
}
