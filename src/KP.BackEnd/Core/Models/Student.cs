using System;

namespace KP.BackEnd.Core.Models
{
    public class Student
    {
        private Guid _id;
        private ApplicationUser _identity;
        private string _major;
        private string _schoolName;
        private Guid _schoolClassId;

        public Guid Id {
            get => _id;
            set => _id = value;
        }

        public ApplicationUser Identity 
        {
            get => _identity;
            set => _identity = value;
        }

        public string Major 
        {
            get => _major;
            set => _major = value;
        }

        public string SchoolName 
        {
            get => _schoolName;
            set => _schoolName = value;
        }

        public Guid SchoolClassId
        {
            get => _schoolClassId;
            set => _schoolClassId = value;
        }

//        public Guid IdentityId { get; set; }
    }
}