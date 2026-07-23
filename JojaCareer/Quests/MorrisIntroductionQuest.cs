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
            Game1.player.questLog.Any(
                quest =>
                    quest.id.Value ==
                    QuestId
            )
        )
        {
            return;
        }

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
}