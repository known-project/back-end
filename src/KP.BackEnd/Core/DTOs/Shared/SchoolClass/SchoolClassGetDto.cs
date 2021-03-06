using System;

namespace KP.BackEnd.Core.DTOs.Shared.SchoolClass
{
    public class SchoolClassGetDto
    {
        private Guid _id;
        private Guid _supervisorId;
        private string _name;
        private string _schoolName;

        public Guid Id
        {
            get => _id;
            set => _id = value;
        }

        public Guid SupervisorId
        {
            get => _supervisorId;
            set => _supervisorId = value;
        }

        public string SchoolName
        {
            get => _schoolName;
            set => _schoolName = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }
    }
}