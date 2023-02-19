namespace PokedexApi.Core.utils;

public static class RarityEnumMapper
{
    static private IDictionary<string, int> Genders = new Dictionary<string, int>()
    {
        ["Common"] = 1,
        ["Rare"] = 2,
        ["Sub_Legendary"] = 3,
        ["Legendary"] = 4,
        ["Mythical"] = 5,
    };

    public static int EncodeToIntRarityEnum (this string key)
    {
        if(!Genders.ContainsKey(key))
        {
            throw new KeyNotFoundException("Rarity key does not exits.");
        }
        return Genders[key];
    }

    public static string DecodeToStringRarityEnum(this int value)
    {
        return Genders.FirstOrDefault(g => g.Value == value).Key;
    }
}
