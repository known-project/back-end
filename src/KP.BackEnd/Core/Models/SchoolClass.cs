using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace KP.BackEnd.Core.Models
{
    public class SchoolClass
    {
        private Guid _id;
        private Guid _supervisorId;
        private string _name;
        private string _schoolName;
        private ICollection<ChannelPost> _channelPosts;
        private string _token;
        private SuggestedPlan _suggestedPlan;

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
        
        public virtual ICollection<ChannelPost> ChannelPosts
        {
            get => _channelPosts;
            set => _channelPosts = value;
        }

        public string Token
        {
            get => _token;
            set => _token = value;
        }

        public virtual SuggestedPlan SuggestedPlan
        {
            get => _suggestedPlan;
            set => _suggestedPlan = value;
        }
    }
}
