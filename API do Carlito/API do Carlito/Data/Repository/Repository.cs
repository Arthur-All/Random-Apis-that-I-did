using API_do_Carlito.Data.Context;
using API_do_Carlito.Interface;
using API_do_Carlito.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_do_Carlito.Data.Repository
{
    public class Repository : IPersonServices
    {
        private readonly IConfiguration _config;
        private readonly SQLContext _context;

        public Repository(IConfiguration config, SQLContext context)
        {
            _context = context;
            _config = config;
        }

       public async Task<List<Person>> FindAllPerson()
       {
            using (var connection = new SqlConnection(_config.GetConnectionString("SQLConnectionString")))
            {
                var select = "select*from Person";
                var persons = (await connection.QueryAsync<Person>(select)).ToList();
                return persons;
            }
       }
       
        public async Task<int>CreatePerson(Person personModel)
        {
            using(var connection = new SqlConnection(_config.GetConnectionString("SQLConnectionString")))
            {
                var parameters = new { Id = personModel.Id };
                var select = "select*from Person where Id = @Id";
                var findPerson = await connection.QueryFirstAsync<Person>(select, parameters);
                if (findPerson.GetType() != typeof(Person)) //Meu validador, não posso receber qualquer coisa
                {
                    Person person = new Person();
                    await _context.Persons.AddAsync(person);
                    return await _context.SaveChangesAsync();
                }
                return 0;
            }
        }
        public async Task<int> UpdatePerson( Person personModel)
        {
            using(var connection = new SqlConnection(_config.GetConnectionString("SQLConnectionString")))
            {
                connection.Open();
                var parameters = new { Id = personModel.Id };
                var select = "select*from Person where Id = @Id";
                var findPerson = await connection.QueryFirstAsync<Person>(select, parameters);
                if(findPerson.GetType()!= typeof(Person))//Meu validador, não posso editar algo que n existe
                {
                    return 0;
                }
                findPerson.Name = personModel.Name;
                findPerson.Id = personModel.Id;
                findPerson.Email = personModel.Email;
                _context.Persons.Update(findPerson);
                return await _context.SaveChangesAsync();
            }
        }
        public async Task<int> DeletePerson(int Id)
        {
            using(var connection = new SqlConnection(_config.GetConnectionString("SQLConnectionString")))
            {
                connection.Open();
                var parameters = new { Id };
                var select = "select*from Person where Id = @Id";
                var findPerson = await connection.QueryFirstAsync<Person>(select, parameters);
                if(findPerson.GetType() != typeof(Person))
                {
                    return 0;
                }
                _context.Remove(findPerson);
                return await _context.SaveChangesAsync();
            }
        } 




    }
}
