using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelitraderAPI.Common
{
    public class Entidade : Notifiable
    {
        public Entidade()
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;
        }

        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
