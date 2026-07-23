using JojaCareer.Data;
using JojaCareer.Player;
using StardewValley;

namespace JojaCareer.Shifts;

internal static class ShiftManager
{
    public static void StartShift()
    {
        if (
            PlayerData.State !=
            PlayerState.Employee
        )
        {
            return;
        }

        if (
            PlayerData.IsOnShift
        )
        {
            return;
        }

        JojaUniform.SaveCurrentOutfit(
            Game1.player
        );

        JojaUniform.Equip(
            Game1.player
        );

        PlayerData.IsOnShift =
            true;
    }

    public static void EndShift()
    {
        if (
            !PlayerData.IsOnShift
        )
        {
            return;
        }

        JojaUniform.RestorePreviousOutfit(
            Game1.player
        );

        PlayerData.IsOnShift =
            false;
    }
}