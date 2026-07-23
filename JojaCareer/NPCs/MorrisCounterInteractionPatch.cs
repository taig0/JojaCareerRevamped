using HarmonyLib;
using JojaCareer.Data;
using JojaCareer.Dialogues;
using Microsoft.Xna.Framework;
using StardewValley;
using xTile.Dimensions;

namespace JojaCareer.Patches;

[HarmonyPatch(
    typeof(GameLocation),
    nameof(GameLocation.checkAction)
)]
internal static class MorrisCounterInteractionPatch
{
    private const string MorrisId =
        "Morris";

    private const string JojaMartName =
        "JojaMart";

    public static bool Prefix(
        GameLocation __instance,
        Location tileLocation,
        Microsoft.Xna.Framework.Rectangle viewport,
        Farmer who
    )
    {
        if (
            __instance.Name !=
            JojaMartName
        )
        {
            return true;
        }

        NPC? morris =
            Game1.getCharacterFromName(
                MorrisId
            );

        if (
            morris is null
        )
        {
            return true;
        }

        Vector2 interactionTile =
            morris.Tile +
            new Vector2(
                0,
                1
            );

        if (
            tileLocation.X !=
            interactionTile.X
            ||
            tileLocation.Y !=
            interactionTile.Y
        )
        {
            return true;
        }

        ModEntry.ModMonitor.Log(
            "Morris counter interaction detected.",
            StardewModdingAPI.LogLevel.Info
        );

        switch (
            PlayerData.State
        )
        {
            case PlayerState.InterviewAvailable:

                MorrisInterview.Start(
                    morris
                );

                return false;

            case PlayerState.Employee:

                if (
                    !PlayerData.IsOnShift
                )
                {
                    MorrisShiftDialogue.Start(
                        morris
                    );

                    return false;
                }

                ShowGreeting(
                    morris
                );

                return false;

            default:

                return true;
        }
    }

    private static void ShowGreeting(
        NPC morris
    )
    {
        Dialogue? dialogue =
            ModEntry.DialogueManager.CreateDialogue(
                morris,
                "Greeting"
            );

        if (
            dialogue is null
        )
        {
            ModEntry.ModMonitor.Log(
                "Could not create Morris dialogue.",
                StardewModdingAPI.LogLevel.Error
            );

            return;
        }

        morris.CurrentDialogue.Clear();

        morris.CurrentDialogue.Push(
            dialogue
        );

        Game1.drawDialogue(
            morris
        );
    }
}