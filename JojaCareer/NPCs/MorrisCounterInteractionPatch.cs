using HarmonyLib;
using Microsoft.Xna.Framework;
using StardewValley;
using StardewValley.Locations;
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
        // Só queremos alterar a JojaMart
        if (__instance.Name != JojaMartName)
        {
            return true;
        }

        // Procurar o Morris na JojaMart
        NPC? morris =
            Game1.getCharacterFromName(
                MorrisId
            );

        if (morris is null)
        {
            return true;
        }

        /*
         * O tile de interação é o tile imediatamente
         * abaixo do Morris.
         *
         * Exemplo:
         *
         * Morris:  (14, 8)
         * Balcão:  (14, 9)
         */
        Vector2 interactionTile =
            morris.Tile +
            new Vector2(0, 1);

        // Verificar se o jogador clicou no tile do balcão
        if (tileLocation.X != interactionTile.X ||
            tileLocation.Y != interactionTile.Y)
        {
            return true;
        }

        ModEntry.ModMonitor.Log(
            "Morris counter interaction detected.",
            StardewModdingAPI.LogLevel.Info
        );

        // Criar o diálogo
        Dialogue dialogue =
            ModEntry.DialogueManager.CreateDialogue(
                morris,
                "Greeting"
            );

        // Limpar diálogos anteriores
        morris.CurrentDialogue.Clear();

        // Adicionar o novo diálogo
        morris.CurrentDialogue.Push(
            dialogue
        );

        // Abrir a caixa de diálogo
        Game1.drawDialogue(
            morris
        );

        /*
         * Impedir que o jogo continue a processar
         * a interação normal do tile.
         */
        return false;
    }
}