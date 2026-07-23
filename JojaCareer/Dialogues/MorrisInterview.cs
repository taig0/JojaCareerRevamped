using JojaCareer.Data;
using JojaCareer.Quests;
using StardewValley;

namespace JojaCareer.Dialogues;

internal static class MorrisInterview
{
    public static void Start(
        NPC morris,
        Farmer player
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
            AnswerQuestion
        );
    }

    private static void AnswerQuestion(
        Farmer who,
        string answer
    )
    {
        switch (answer)
        {
            case "InterviewYes":
                AcceptJob();
                break;

            case "InterviewNo":
                DeclineJob();
                break;
        }
    }

    private static void AcceptJob()
    {
        PlayerData.State =
            PlayerState.Employee;

        MorrisIntroductionQuest.Complete();
    }

    private static void DeclineJob()
    {
        // O jogador continua em InterviewAvailable.
    }
}