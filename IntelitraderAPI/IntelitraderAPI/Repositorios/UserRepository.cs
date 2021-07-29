using IntelitraderAPI.Context;
using IntelitraderAPI.Domains;
using IntelitraderAPI.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelitraderAPI.Repositorios
{
    public class UserRepository : IUserRepository
    {
        private readonly UsersContext _ctx;
        public UserRepository()
        {
            _ctx = new UsersContext();
        }

        public List<User> Listar()
        {
            return _ctx.Users.ToList();
        }

        public User BuscarPorId(Guid id)
        {
            return _ctx.Users.Find(id);
        }

        public void Editar(Guid id, User user)
        {
            User userTemp = BuscarPorId(id);

            if (userTemp == null)
                throw new Exception("Usuario não encontrado!");

            user.Validar(user);
            if (user.Invalid)
                throw new Exception("Dados Inválidos!");

            userTemp.firstName = user.firstName;
            userTemp.surName = user.surName;
            userTemp.age = user.age;

            _ctx.Users.Update(userTemp);
            _ctx.SaveChanges();
        }

        public void Adicionar(User user)
        {
            user.Validar(user);
            if (user.Invalid)
                throw new Exception("Dados Inválidos!");

            _ctx.Users.Add(user);            

            _ctx.SaveChanges();
        }

        public void Remover(Guid id)
        {
            User userTemp = BuscarPorId(id);

            _ctx.Users.Remove(userTemp);
            _ctx.SaveChanges();
        }
    }
}
