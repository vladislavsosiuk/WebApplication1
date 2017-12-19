using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Managers
{
    public class StudentManager : IStudentManager
    {
        StudentsContext context;

        public StudentManager()
        {
            context = new StudentsContext();
        }
        public void DeleteStudent(int id)
        {
            var student = context.students.FirstOrDefault(s => s.StudentId == id);
            if (student != null)
                context.students.Remove(student);
        }

        public Student GetStudent(int id)
        {
            var student = context.students.FirstOrDefault(s => s.StudentId == id);
            return new Student
            {
                Id = student.StudentId,
                FirstName = student.StudentFirstName,
                LastName = student.StudentLastName,
            };
        }

        public void UpdateStudent(Student student)
        {
            var dbStudent = context.students.FirstOrDefault(s => s.StudentId == student.Id);
            if (dbStudent == null)
                return;
            dbStudent.StudentFirstName = student.FirstName;
            dbStudent.StudentLastName = student.LastName;

            context.students.AddOrUpdate(dbStudent);
        }
    }
}