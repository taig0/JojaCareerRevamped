/*using HarmonyLib;
using JojaCareer.Data;
using JojaCareer.Dialogues;
using StardewModdingAPI;
using StardewValley;

namespace JojaCareer.Patches;

[HarmonyPatch(
    typeof(NPC),
    nameof(NPC.checkAction)
)]
internal static class NPCInteractionPatch
{
    public static bool Prefix(
        NPC __instance,
        Farmer who,
        GameLocation l
    )
    {
        ModEntry.ModMonitor.Log(
            $"checkAction called for: {__instance.Name}",
            LogLevel.Info
        );

        if (
            __instance.Name !=
            "Morris"
        )
        {
            return true;
        }

        ModEntry.ModMonitor.Log(
            "Morris interaction detected!",
            LogLevel.Info
        );

        if (
            PlayerData.State ==
            PlayerState.InterviewAvailable
        )
        {
            MorrisInterview.Start(
                __instance
            );

            return false;
        }

        if (
            PlayerData.State ==
            PlayerState.Employee
            &&
            !PlayerData.IsOnShift
        )
        {
            MorrisShiftDialogue.Start(
                __instance
            );

            return false;
        }

        Dialogue? dialogue =
            ModEntry.DialogueManager.CreateDialogue(
                __instance,
                "Greeting"
            );

        if (
            dialogue is null
        )
        {
            ModEntry.ModMonitor.Log(
                "Could not create Morris dialogue.",
                LogLevel.Error
            );

            return true;
        }

        __instance.CurrentDialogue.Clear();

        __instance.CurrentDialogue.Push(
            dialogue
        );

        Game1.drawDialogue(
            __instance
        );

        return false;
    }
}*/