using API_DO_PAIZAO.Models;
using System.Collections.Generic;
using System.Threading;

namespace API_DO_PAIZAO.Services.Implemantations
{
    public class PersonServeceImplementation : IPersonService
    {
        private volatile int  count;

        public Person Create(Person person)
        {
           return person;
        }

        public void Delete(int Id)
        {
            
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for(int i = 0; i< 7; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

       

        public Person FindById(int Id)
        {
            return new Person
            {
                Id = CriaIDPORRAA(),
                Name = "Nelson",
                Email = "Nelson@Monster.com.br",
                Password = "xvideos2022",
                Active = true
            };
        }

        public Person Update(Person person)
        {
            return person;
        }




        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = CriaIDPORRAA(),
                Name = "NOME"+i,
                Email = "EMAIL"+i,
                Password = "SENHA"+i,
                Active = true
            };
        }

        private int CriaIDPORRAA()
        {
            return Interlocked.Increment(ref count);
        }

      
    }
}
