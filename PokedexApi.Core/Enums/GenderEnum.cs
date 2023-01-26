using System.ComponentModel.DataAnnotations;

namespace PokedexApi.Core.Enums
{
    public enum GenderEnum
    {
        [Display(Name = "Male")]
        Male = 1,

        [Display(Name = "Female")]
        Female = 2,

        [Display(Name = "Fluid")]
        Fluid = 3
    }
}