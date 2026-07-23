internal sealed class PlayerOutfit
{
    public string? HatId { get; set; }

    public string ShirtId { get; set; } =
        string.Empty;

    public string PantsId { get; set; } =
        string.Empty;

    public int PantsRed { get; set; }

    public int PantsGreen { get; set; }

    public int PantsBlue { get; set; }

    public int PantsAlpha { get; set; }
}