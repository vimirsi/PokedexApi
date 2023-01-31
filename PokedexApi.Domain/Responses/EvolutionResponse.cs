using PokedexApi.Core.Enums;
using PokedexApi.Domain.Entities;

namespace PokedexApi.Domain.Responses
{
    public class EvolutionResponse
    {
        public Pokemon PreEvolution { get; set; }
        public Pokemon ActualStage { get; set; }
        public Pokemon EvolutionForm { get; set; }
    }
}