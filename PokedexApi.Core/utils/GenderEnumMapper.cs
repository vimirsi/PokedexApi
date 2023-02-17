namespace PokedexApi.Core.utils;

public static class GenderEnumMapper
{
    static private IDictionary<string, int> Genders = new Dictionary<string, int>()
    {
        ["Male"] = 1,
        ["Female"] = 2,
        ["Fluid"] = 3,
    };

    public static int EncodeToIntGenderEnum (this string key)
    {
        if(!Genders.ContainsKey(key))
        {
            throw new KeyNotFoundException("Gender key does not exits.");
        }
        return Genders[key];
    }

    public static string DecodeToStringGenderEnum(this int value)
    {
        return Genders.FirstOrDefault(g => g.Value == value).Key;
    }
}