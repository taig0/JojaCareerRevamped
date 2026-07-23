using StardewModdingAPI;
using StardewValley;
using Microsoft.Xna.Framework;

namespace JojaCareer.NPCs;

internal sealed class MorrisNpcManager
{
    private readonly IMonitor Monitor;

    private const string MorrisId =
        "Morris";

    public MorrisNpcManager(
        IMonitor monitor
    )
    {
        Monitor = monitor;
    }

    public void SpawnMorris()
    {
        NPC? morris =
            Game1.getCharacterFromName(
                MorrisId
            );

        if (morris is null)
        {
            Monitor.Log(
                $"Could not find NPC '{MorrisId}'.",
                LogLevel.Error
            );

            return;
        }

        GameLocation? jojaMart =
            Game1.getLocationFromName(
                "JojaMart"
            );

        if (jojaMart is null)
        {
            Monitor.Log(
                "Could not find JojaMart.",
                LogLevel.Error
            );

            return;
        }

        Vector2 position =
            new Vector2(
                21,
                24
            ) * Game1.tileSize;

        morris.Position = position;

        if (!jojaMart.characters.Contains(morris))
        {
            jojaMart.addCharacter(morris);
        }

        Monitor.Log(
            "Morris spawned in JojaMart.",
            LogLevel.Info
        );
    }
}