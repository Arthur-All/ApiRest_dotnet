using Microsoft.EntityFrameworkCore.Internal;
using ApiRest.Model;
using ApiRest.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiRest.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {

        private MySQLContext _context;

        public PersonServiceImplementation(MySQLContext context)
        {
            _context = context;
        }
        
        public List<Person> FindAll() //Encontra Geral que esta registrado no Db
        {
            return _context.Persons.ToList();
        }

        public Person FindByID(long id) //retorna o ID que vc escolher (se existir)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Create(Person person) //Cria obj novo
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return person;
        }

        public Person Update(Person person) //Atualiza obj
        {
            if (!Exists(person.Id)) return new Person(); //checador de objs

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));  //basicamente um checador de status
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person); //altera e salva 
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return person;
        }

        public void Delete(long id) //esse aqui deleta o cara pelo ID
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        private bool Exists(long id) //ligação com o update. olha lá
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}
