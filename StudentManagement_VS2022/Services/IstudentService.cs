using StudentManagement_VS2022.Models;

namespace StudentManagement_VS2022.Services
{
    public interface IstudentService
    {
        List<Students> Get();
        Students GetById(string id);
        Students Create(Students studentobj);
        void Update(string ID, Students studentobj);
        void Remove(string id);

    }
}
