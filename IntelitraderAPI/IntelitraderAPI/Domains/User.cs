using Flunt.Validations;
using System;
using System.ComponentModel.DataAnnotations;
using Flunt.Notifications;

namespace IntelitraderAPI.Domains
{
    public class User : Notifiable
    {

        public User()
        {
            id = Guid.NewGuid();
            creationDate = DateTime.Now;
        }

        public void Validar(User user)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(user.firstName, "First Name", "Informe o nome do usuário! (Entity Error)")
                // surname não é obrigatorio
                //.IsNotNullOrEmpty(user.surName, "Sur Name", "Informe o segundo nome do usuário! (Entity Error)")
                .IsNotNullOrEmpty(user.age.ToString(), "Age", "Informe a idade do usuário! (Entity Error)")
            );
        }

        [Key]
        public Guid id { get; private set; }
        public string firstName { get; set; }
        public string surName { get; set; }
        public int age { get; set; }
        public DateTime creationDate { get; private set; }
        
    }
}
