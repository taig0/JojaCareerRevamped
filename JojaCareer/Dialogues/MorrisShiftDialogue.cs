using JojaCareer.Shifts;
using StardewValley;

namespace JojaCareer.Dialogues;

internal static class MorrisShiftDialogue
{
    public static void Start(
        NPC morris
    )
    {
        string? question =
            ModEntry.DialogueManager.GetText(
                "ShiftStartQuestion"
            );

        string? yes =
            ModEntry.DialogueManager.GetText(
                "ShiftStartYes"
            );

        string? no =
            ModEntry.DialogueManager.GetText(
                "ShiftStartNo"
            );

        if (
            question is null
            ||
            yes is null
            ||
            no is null
        )
        {
            return;
        }

        Game1.currentLocation
            .createQuestionDialogue(
                question,
                new Response[]
                {
                    new Response(
                        "ShiftStartYes",
                        yes
                    ),

                    new Response(
                        "ShiftStartNo",
                        no
                    )
                },
                (
                    Farmer who,
                    string answer
                ) =>
                {
                    if (
                        answer ==
                        "ShiftStartYes"
                    )
                    {
                        ShiftManager.StartShift();

                        ShowDialogue(
                            morris,
                            "ShiftStarted"
                        );
                    }
                }
            );
    }

    private static void ShowDialogue(
        NPC morris,
        string dialogueKey
    )
    {
        Dialogue? dialogue =
            ModEntry.DialogueManager.CreateDialogue(
                morris,
                dialogueKey
            );

        if (dialogue is null)
        {
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