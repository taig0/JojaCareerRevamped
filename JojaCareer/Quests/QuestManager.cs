using StardewValley;

namespace JojaCareer.Quests;

internal static class QuestManager
{
    private const string InvitationMail =
        "JojaCareer_Invitation";

    public static void CheckMail()
    {
        if (
            !Game1.player.mailReceived.Contains(
                InvitationMail
            )
        )
        {
            return;
        }

        MorrisIntroductionQuest.Start();
    }
}