using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Managers
{
    interface IStudentManager
    {
        Student GetStudent(int id);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
    }
}
