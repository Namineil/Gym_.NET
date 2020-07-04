using System;
using System.Collections.Generic;

namespace Gym.API.Domain.Models
{

    public class User
    {
        public int IdUser { get; set; }

        public string FullName { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime Birthday { get; set; }

        public byte[] Image { get; set; }
        public string Login { get; set; }

        public string Password { get; set; }
        public string Token { get; set; }


        public IList<AdministratorHall> AdministratorHall { get; set; } = new List<AdministratorHall>();

        public IList<Client> Client { get; set; } = new List<Client>();

        public IList<UserRole> UserRoles { get; set; } = new List<UserRole>();

        public IList<Trainer> Trainer { get; set; } = new List<Trainer>();
    }

}