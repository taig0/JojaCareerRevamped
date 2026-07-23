using StardewValley;

namespace JojaCareer.Data;

internal static class PlayerData
{
    private const string PlayerStateKey =
        "JojaCareer.PlayerState";

    public static PlayerState State
    {
        get
        {
            if (
                !Game1.player.modData.TryGetValue(
                    PlayerStateKey,
                    out string? value
                )
            )
            {
                return PlayerState.None;
            }

            return Enum.TryParse(
                value,
                out PlayerState state
            )
                ? state
                : PlayerState.None;
        }

        set
        {
            Game1.player.modData[
                PlayerStateKey
            ] = value.ToString();
        }
    }
}