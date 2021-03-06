using System;
using Microsoft.AspNetCore.Identity;

namespace KP.BackEnd.Core.Models
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        private string _description;

        public string Description 
        {
            get => _description;
            set => _description = value;
        }
    }
}