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
            if (student == null)
                return;
            context.students.Remove(student);
            context.SaveChanges();
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
            context.SaveChanges();
        }
        public IEnumerable<Student> GetStudents()
        {
            var students = context.students.Select(s=>new Student
            {
                Id = s.StudentId,
                FirstName = s.StudentFirstName,
                LastName = s.StudentLastName,
            }).ToList();
            return students ?? new List<Student>();
        }

        public void AddStudent(Student student)
        {
            context.students.AddOrUpdate(new students()
            {
                StudentFirstName = student.FirstName,
                StudentLastName = student.LastName,
            });
            context.SaveChanges();
        }
    }
}