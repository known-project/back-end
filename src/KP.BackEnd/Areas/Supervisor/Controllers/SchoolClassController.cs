using System;
using System.Threading.Tasks;
using AutoMapper;
using KP.BackEnd.Core;
using KP.BackEnd.Core.DTOs.Supervisor.SchoolClass;
using KP.BackEnd.Core.DTOs.Supervisor.SchoolClass;
using KP.BackEnd.Core.Models;
using KP.BackEnd.Persistence.EntityConfigurations;
using Microsoft.AspNetCore.Mvc;

namespace KP.BackEnd.Areas.Supervisor.Controllers
{
    [Route("api/supervisor/[controller]")]
    [ApiController]
    public class SchoolClassController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public SchoolClassController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolClassPostDto>> Get(Guid id)
        {
//            var userId = ApplicationUserConfiguration.SupervisorIdTmp; 
            var schoolClass = await _unitOfWork.SchoolClasses.Find(id);
            
            return Ok(_mapper.Map<SchoolClassGetDto>(schoolClass)); // TODO
        }
        
        [HttpPost]
        public async Task<ActionResult<SchoolClassPostDto>> Create([FromBody] SchoolClassPostDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = ApplicationUserConfiguration.SupervisorIdTmp;
            var schoolClass= _mapper.Map<SchoolClass>(dto); // TODO

            await _unitOfWork.SchoolClasses.Add(schoolClass);
            await _unitOfWork.Complete();

            return CreatedAtAction(nameof(Get), _mapper.Map<SchoolClassGetDto>(schoolClass), null);
        }
    }
}