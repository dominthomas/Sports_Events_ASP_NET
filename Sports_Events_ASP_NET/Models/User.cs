using System;
namespace Sports_Events_ASP_NET.Models
{
    public class User
    {
        public int UserID { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public int Phone { get; set; }

        public string Email { get; set; }

        public int AddressID { get; set; }

        public int DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string WorkLocation { get; set; }

        public string Bio { get; set; }

        public string Skills { get; set; }
    }
}
