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

    public static ShiftState ShiftState
    {
        get
        {
            if (
                !Game1.player.modData.TryGetValue(
                    "JojaCareer_ShiftState",
                    out string? value
                )
            )
            {
                return ShiftState.OffShift;
            }

            return Enum.Parse<ShiftState>(
                value
            );
        }

        set
        {
            Game1.player.modData[
                "JojaCareer_ShiftState"
            ] = value.ToString();
        }
    }

    public static bool IsOnShift
    {
        get
        {
            return Game1.player.modData.TryGetValue(
                "JojaCareer_IsOnShift",
                out string? value
            )
            &&
            value == "true";
        }

        set
        {
            Game1.player.modData[
                "JojaCareer_IsOnShift"
            ] =
                value.ToString()
                    .ToLower();
        }
    }
}