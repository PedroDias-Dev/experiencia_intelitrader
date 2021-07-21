using IntelitraderAPI.Domains;
using System;
using System.Collections.Generic;

namespace IntelitraderAPI.Interfaces
{
    public interface IUserRepository
    {
        List<User> Listar();
        User BuscarPorId(Guid id);
        void Adicionar(User user);
        void Editar(Guid id, User user);
        void Remover(Guid id);
    }
}
