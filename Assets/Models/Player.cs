using System.Collections.Generic;

public class Player
{
    public IList<PlayerItem> Items { get; } = new List<PlayerItem>();
}