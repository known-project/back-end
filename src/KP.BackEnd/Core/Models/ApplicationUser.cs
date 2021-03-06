using System;
using Microsoft.AspNetCore.Identity;

namespace KP.BackEnd.Core.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        private string _firstName;
        private string _lastName;
        private byte[] _image;

        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }

        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }

        public byte[] Image
        {
            get => _image;
            set => _image = value;
        }

        public ApplicationUser() {}
        public ApplicationUser(string userName) : base(userName) {}
    }
}