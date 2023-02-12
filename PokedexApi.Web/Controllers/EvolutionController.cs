// using AutoMapper;
// using Microsoft.AspNetCore.Mvc;
// using PokedexApi.Domain.Dtos;
// using PokedexApi.Domain.Interfaces;
// using PokedexApi.Web.FormRequest;

// namespace PokedexApi.Web.Controllers
// {
//     [ApiController]
//     [Route("evolution")]
//     public class EvolutionController : ControllerBase
//     {
//         private readonly IEvolutionRepository _repository;
//         private readonly IMapper _mapper;

//         public EvolutionController(IEvolutionRepository repository, IMapper mapper)
//         {
//             _repository = repository;
//             _mapper = mapper;
//         }

//         [HttpPost("add")]
//         public async Task<IActionResult> AddAsync([FromBody] EvolutionAddFormRequest payload)
//         {
//             try
//             {
//                 var result = await _repository.AddAsync(new EvolutionAddDTO
//                 {
//                     PokemonId = payload.PokemonId,
//                     PreEvolution = payload.PreEvolution,
//                     EvolutionForm = payload.EvolutionForm
//                 });

//                 return Created("Evolution has been registered", result);
//             }
//             catch (Exception ex)
//             {
//                 return BadRequest(ex.Message);
//             }
//         }

//         [HttpGet("{pokemonId}")]
//         public async Task<IActionResult> GetByPokemonId([FromRoute] int pokemonId)
//         {
//             try
//             {
//                 var result = await _repository.GetByIdAsync(new EvolutionGetByIdDTO
//                 {
//                     PokemonId = pokemonId
//                 });

//                 return Ok(_mapper.Map<EvolutionResource>(result));
//             }
//             catch (Exception ex)
//             {
//                 return BadRequest(ex.Message);
//             }
//         }

//         [HttpDelete("{pokemonId}/remove")]
//         public async Task<IActionResult> RemoveByPokemonId([FromRoute] Guid pokemonId)
//         {
//             try
//             {
//                 await _repository.DeleteAsync(pokemonId);

//                 return NoContent();
//             }
//             catch (Exception ex)
//             {
//                 return BadRequest(ex.Message);
//             }
//         }
//     }
// }
