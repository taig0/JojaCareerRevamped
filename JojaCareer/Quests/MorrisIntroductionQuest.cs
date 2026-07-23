using JojaCareer.Data;
using StardewValley;
using StardewValley.Quests;

namespace JojaCareer.Quests;

internal static class MorrisIntroductionQuest
{
    public const string QuestId =
        "JojaCareer_MorrisIntroduction";

    public static void Start()
    {
        if (
            PlayerData.State !=
            PlayerState.None
        )
        {
            return;
        }

        PlayerData.State =
            PlayerState.InterviewAvailable;

        Quest quest =
            new Quest();

        quest.id.Value =
            QuestId;

        quest.questTitle =
            "Uma oportunidade de carreira";

        quest.currentObjective =
            "Falar com Morris";

        Game1.player.questLog.Add(
            quest
        );

        Game1.addHUDMessage(
            new HUDMessage(
                "Nova missão: " +
                quest.questTitle,
                HUDMessage.newQuest_type
            )
        );
    }

    public static void Complete()
    {
        Quest? quest =
            Game1.player.questLog.FirstOrDefault(
                quest =>
                    quest.id.Value ==
                    QuestId
            );

        if (quest is not null)
        {
            Game1.player.questLog.Remove(
                quest
            );
        }

        Game1.addHUDMessage(
            new HUDMessage(
                "Missão concluída!",
                HUDMessage.newQuest_type
            )
        );
    }
}