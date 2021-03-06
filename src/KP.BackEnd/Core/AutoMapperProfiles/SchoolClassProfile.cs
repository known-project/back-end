using AutoMapper;
using KP.BackEnd.Core.DTOs.Shared;
using KP.BackEnd.Core.DTOs.Shared.SchoolClass;
using KP.BackEnd.Core.DTOs.Supervisor.SchoolClass;
using KP.BackEnd.Core.Models;

namespace KP.BackEnd.Core.AutoMapperProfiles
{
    public class SchoolClassProfile: Profile
    {
        public SchoolClassProfile()
        {
            #region Supervisor

            CreateMap<DTOs.Supervisor.SchoolClass.SchoolClassPostDto, SchoolClass>();
            CreateMap<SchoolClass, SchoolClassGetDto>();

            #endregion
        }
    }
}