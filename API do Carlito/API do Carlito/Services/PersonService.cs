﻿using API_do_Carlito.Data.Repository;
using API_do_Carlito.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_do_Carlito.Services
{
    public class PersonService : IPersonService
    {
        private readonly Repository _repo;
        public async Task<List<Person>> FindAllPerson()
        {
            var personList = await _repo.FindAllPerson();
            return personList;
        }
       /* public async Task<Person> FindById(int Id)
        {
            var person = await _repo.FindById(Id);
            return person;
        }*/

       public async Task<int> CreatePerson(Person personModel)
        {
            var create = await _repo.CreatePerson(personModel);
            return create;
        }
       public async Task<int> UpdatePerson(Person personModel)
       {
            var edit = await _repo.UpdatePerson(personModel); //resultado do meu repositorio
            return edit;
       }
       public async Task<int> DeletePerson(int Id)
        {
            var delete = await _repo.DeletePerson(Id);
            return delete;
        }



    }


}
