using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentApi.Models;

namespace StudentApi.Controllers
{
    public class ValuesController : ApiController
    {
        StudentContext db = new StudentContext();


        public IEnumerable<Student> GetStudents()
        {
            return db.Students;
        }

        public Student GetStudent(int id)
        {
            Student student = db.Students.Find(id);

            return student;

        }


        [HttpPost]
        public void CreateStudent([FromBody]Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }


        [HttpPut]
        public void EditStudent(int id, [FromBody]Student student)
        {
            if (id == student.Id)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();

            }
        }

        [HttpDelete]
        public void DeleteStudent(int id)
        {
            Student student = db.Students.Find(id);
            if (student != null)
            {
                db.Students.Remove(student);
                db.SaveChanges();
            }

        }
    }
}
