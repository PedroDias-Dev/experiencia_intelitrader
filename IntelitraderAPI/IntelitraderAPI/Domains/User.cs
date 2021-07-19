using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IntelitraderAPI.Domains
{
    public class User
    {
        public User()
        {
            id = Guid.NewGuid();
            creationDate = DateTime.Now;
        }

        [Key]
        public Guid id { get; set; }
        public string firstName { get; set; }
        public string surName { get; set; }
        public int age { get; set; }
        public DateTime creationDate { get; set; }
        
    }
}
