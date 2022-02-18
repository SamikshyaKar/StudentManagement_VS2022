using StudentManagement_VS2022.Models;
using MongoDB.Driver;

namespace StudentManagement_VS2022.Services
{
    public class StudentService : IstudentService
    {
        private readonly IMongoCollection<Students> _students;

        public StudentService(IStudentStoreDatabaseSettings studentStoreDatabaseSettings, IMongoClient mongoClient)
        {
           var database=  mongoClient.GetDatabase(studentStoreDatabaseSettings.DatabaseName);
           _students = database.GetCollection<Students>(studentStoreDatabaseSettings.StudentCoursesCollectionName);
        }
        public Students Create(Students studentobj)
        {
            _students.InsertOne(studentobj);
            return studentobj;
        }

        public List<Students> Get()
        {
            return _students.Find(student=>true).ToList();
        }

        public Students GetById(string id)
        {
            return _students.Find(student => student.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _students.DeleteOne(student=>student.Id == id);
        }

        public void Update(string ID, Students studentobj)
        {
            _students.ReplaceOne(student=>student.Id==ID, studentobj);
        }
    }
}
