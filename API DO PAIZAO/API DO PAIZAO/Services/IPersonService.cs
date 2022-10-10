using API_DO_PAIZAO.Models;
using System.Collections.Generic;

namespace API_DO_PAIZAO.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person Update(Person person);

        Person FindById(int Id);

        List<Person> FindAll();
        void Delete(int Id);



    }
}
