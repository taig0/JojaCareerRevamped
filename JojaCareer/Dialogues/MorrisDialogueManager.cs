using StardewModdingAPI;
using StardewValley;

namespace JojaCareer.Dialogues;

internal sealed class MorrisDialogueManager
{
    private readonly IMonitor Monitor;

    private readonly Dictionary<string, string> Dialogues;

    public MorrisDialogueManager(
        IModHelper helper,
        IMonitor monitor
    )
    {
        Monitor = monitor;

        Dialogues =
            helper.Data.ReadJsonFile<
                Dictionary<string, string>
            >(
                "assets/MorrisDialogue.json"
            )
            ?? new Dictionary<string, string>();
    }

    public Dialogue? CreateDialogue(
        NPC speaker,
        string dialogueKey
    )
    {
        if (!Dialogues.TryGetValue(
                dialogueKey,
                out string? text
            ))
        {
            Monitor.Log(
                $"Dialogue key '{dialogueKey}' was not found.",
                LogLevel.Error
            );

            return null;
        }

        return new Dialogue(
            speaker,
            dialogueKey,
            text
        );
    }
}