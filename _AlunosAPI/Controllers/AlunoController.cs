using _AlunosAPI.Context;
using _AlunosAPI.Dtos;
using _AlunosAPI.Models;
using _AlunosAPI.Pagination;
using _AlunosAPI.Repository.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace _AlunosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AlunoController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public AlunoController(IUnitOfWork context,IMapper mapper)
        {
            _uof = context;
            _mapper = mapper;
        }
        // api/alunos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlunoDTO>>> GetAlunos([FromQuery] AlunosParamers alunosParamers)
        {
            var aluno = await _uof.AlunoRepository.GetAlunos(alunosParamers);

            var metadata = new
            {
                aluno.TotalCount,
                aluno.PageSize,
                aluno.CurrentPage,
                aluno.TotalPages,
                aluno.HasNext,
                aluno.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            var alunoDto = _mapper.Map<List<AlunoDTO>>(aluno);  
            
            return alunoDto;
        }
        // api/alunos/1
        [HttpGet("{id:int}", Name = "ObterAluno")]
        public async Task<ActionResult<AlunoDTO>> GetId(int id)
        {
            var aluno = await _uof.AlunoRepository.GetById(x => x.Id == id);

            if(aluno is null)
            {
                return NotFound($"Aluno do Id{id} não encontrado");
            }

            var alunoDto = _mapper.Map<AlunoDTO>(aluno);

            return alunoDto;
        }
        //
        [HttpGet("AlunoPorNome")] 
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunoPorNome([FromQuery] string nome)
        {
            var alunos = await _uof.AlunoRepository.GetAlunoByName(nome);

            if (alunos == null)
            {
                return NotFound($"Não existem alunos com nome = {nome}");
            }                

            return Ok(alunos);
        }

        // api/alunos
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Aluno aluno)
        {
                        
            _uof.AlunoRepository.Add(aluno);
            await _uof.Commit();

            var alunoDTO = _mapper.Map<AlunoDTO>(aluno);    

            return new CreatedAtRouteResult("ObterAluno",
                new { id = aluno.Id }, alunoDTO);
           
        }
        // api/alunos/1
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AlunoDTO alunoDto)
        {
            if (id != alunoDto.Id)
            {
                return BadRequest();
            }

            var aluno = _mapper.Map<Aluno>(alunoDto);

            _uof.AlunoRepository.Update(aluno);
            await _uof.Commit();
            return Ok();
        }
        // api/alunos/1
        [HttpDelete]
        public async Task<ActionResult<AlunoDTO>> Delete(int id)
        {
            var aluno = await _uof.AlunoRepository.GetById(p => p.Id == id);

            if (aluno == null)
            {
                return NotFound();
            }

            _uof.AlunoRepository.Delete(aluno);
            await _uof.Commit();

            var alunoDto = _mapper.Map<AlunoDTO>(aluno);

            return alunoDto;
        }
    }
}
