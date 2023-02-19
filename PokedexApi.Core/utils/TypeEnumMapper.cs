namespace PokedexApi.Core.utils;

public static class TypeEnumMapper
{
    static private IDictionary<string, int> Genders = new Dictionary<string, int>()
    {
        ["Normal"] = 1,
        ["Fire"] = 2,
        ["Water"] = 3,
        ["Grass"] = 4,
        ["Flying"] = 5,
        ["Poison"] = 6,
        ["Electric"] = 7,
        ["Ground"] = 8,
        ["Rock"] = 9,
        ["Psychic"] = 10,
        ["Ice"] = 11,
        ["Bug"] = 12,
        ["Ghost"] = 13,
        ["Steel"] = 14,
        ["Dragon"] = 15,
        ["Dark"] = 16,
        ["Fairy"] = 17,
    };

    public static int EncodeToIntTypeEnum (this string key)
    {
        if(!Genders.ContainsKey(key))
        {
            throw new KeyNotFoundException("Rarity key does not exits.");
        }
        return Genders[key];
    }

    public static string DecodeToStringTypeEnum(this int value)
    {
        return Genders.FirstOrDefault(g => g.Value == value).Key;
    }
}
