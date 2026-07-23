using HarmonyLib;
using JojaCareer.Dialogues;
using JojaCareer.NPCs;
using JojaCareer.Quests;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Menus;

namespace JojaCareer;

internal sealed class ModEntry : Mod
{
    public static IMonitor ModMonitor { get; private set; } = null!;

    public static MorrisDialogueManager DialogueManager
    {
        get;
        private set;
    } = null!;

    public static MorrisNpcManager MorrisManager
    {
        get;
        private set;
    } = null!;

    private Harmony Harmony { get; set; } = null!;

    public override void Entry(IModHelper helper)
    {
        ModMonitor = Monitor;

        DialogueManager =
            new MorrisDialogueManager(
                helper,
                Monitor
            );

        MorrisManager =
            new MorrisNpcManager(
                Monitor
            );

        Harmony =
            new Harmony(
                ModManifest.UniqueID
            );

        Harmony.PatchAll();

        helper.Events.GameLoop.SaveLoaded +=
            OnSaveLoaded;

        helper.Events.GameLoop.DayStarted += OnDayStarted;
        helper.Events.Display.MenuChanged += OnMenuChanged;
    }

    private void OnSaveLoaded(
        object? sender,
        SaveLoadedEventArgs e
    )
    {
        MorrisManager.SpawnMorris();
    }
    private void OnDayStarted(
        object? sender,
        DayStartedEventArgs e
    )
    {
        const string mailId =
            "JojaCareer_Invitation";

        if (
            !Game1.player.hasOrWillReceiveMail(
                mailId
            )
        )
        {
            Game1.addMailForTomorrow(
                mailId
            );

            Monitor.Log(
                "Joja Career invitation scheduled.",
                LogLevel.Info
            );
        }
    }

    private void OnMenuChanged(
    object? sender,
    MenuChangedEventArgs e
)
    {
        if (
            e.OldMenu is LetterViewerMenu &&
            e.NewMenu is null
        )
        {
            Monitor.Log(
                "Letter closed.",
                LogLevel.Debug
            );

            QuestManager.CheckMail();
        }
    }
}