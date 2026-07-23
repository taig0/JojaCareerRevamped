using JojaCareer.Data;
using JojaCareer.Quests;
using JojaCareer.Player;
using StardewValley;

namespace JojaCareer.Dialogues;

internal static class MorrisInterview
{
    public static void Start(
        NPC morris
    )
    {
        string? question =
            ModEntry.DialogueManager.GetText(
                "InterviewQuestion"
            );

        string? yes =
            ModEntry.DialogueManager.GetText(
                "InterviewYes"
            );

        string? no =
            ModEntry.DialogueManager.GetText(
                "InterviewNo"
            );

        if (
            question is null ||
            yes is null ||
            no is null
        )
        {
            return;
        }

        Game1.currentLocation.createQuestionDialogue(
            question,
            new Response[]
            {
                new Response(
                    "InterviewYes",
                    yes
                ),

                new Response(
                    "InterviewNo",
                    no
                )
            },
            (
                Farmer who,
                string answer
            ) =>
            {
                AnswerQuestion(
                    morris,
                    answer
                );
            }
        );
    }

    private static void AnswerQuestion(
        NPC morris,
        string answer
    )
    {
        switch (answer)
        {
            case "InterviewYes":
                AcceptJob(
                    morris
                );

                break;

            case "InterviewNo":
                DeclineJob(
                    morris
                );

                break;
        }
    }

    private static void AcceptJob(
        NPC morris
    )
    {
        PlayerData.State =
            PlayerState.Employee;

        ShowDialogue(
            morris,
            "InterviewAccepted"
        );

        MorrisIntroductionQuest.Complete();
    }

    private static void DeclineJob(
        NPC morris
    )
    {
        ShowDialogue(
            morris,
            "InterviewDeclined"
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