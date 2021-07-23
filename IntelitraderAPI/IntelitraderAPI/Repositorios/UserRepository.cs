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
            try
            {
                return _ctx.Users.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public User BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Users.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Guid id, User user)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Adicionar(User user)
        {
            try
            {
                user.Validar(user);
                if (user.Invalid)
                    throw new Exception("Dados Inválidos!");

                _ctx.Users.Add(user);            

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remover(Guid id)
        {
            try
            {
                User userTemp = BuscarPorId(id);

                _ctx.Users.Remove(userTemp);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
