using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ODataDemo.Models;

namespace OData6Demo.Api.Services
{
    public interface IStudentService
    {
        IQueryable<Student> RetrieveAllStudents();
    }
}