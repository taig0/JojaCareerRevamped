using Microsoft.Xna.Framework;
using StardewValley;
using StardewValley.Objects;

namespace JojaCareer.Player;

internal static class JojaUniform
{
    private static string? SavedHatId;

    private static string? SavedShirtId;

    private static string? SavedPantsId;

    private static Color SavedPantsColor;

    public static void SaveCurrentOutfit(
        Farmer player
    )
    {
        SavedHatId =
            player.hat.Value?.QualifiedItemId;

        SavedShirtId =
            player.shirt.Value;

        SavedPantsId =
            player.pants.Value;

        SavedPantsColor =
            player.pantsColor.Value;
    }

    public static void Equip(
        Farmer player
    )
    {
        player.hat.Value =
            ItemRegistry.Create<Hat>(
                "(H)JojaCap"
            );

        player.shirt.Value =
            "1105";

        player.pantsColor.Value = new Color(46, 85, 183);
    }

    public static void RestorePreviousOutfit(
        Farmer player
    )
    {
        if (
            SavedHatId is not null
        )
        {
            player.hat.Value =
                ItemRegistry.Create<Hat>(
                    SavedHatId
                );
        }
        else
        {
            player.hat.Value =
                null;
        }

        player.shirt.Value =
            SavedShirtId;

        player.pants.Value =
            SavedPantsId;

        player.pantsColor.Value =
            SavedPantsColor;
    }
}