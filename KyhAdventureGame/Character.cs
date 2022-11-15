namespace KyhAdventureGame;

public class Character
{
    public int X { get; set; }
    public int Y { get; set; }

    public string Action = "";
    public string LastFacingDirection = "Left";
    public int LastSpriteIndex = -1;

    public Character()
    {
        X = 20;
        Y = 20;
    }

    public string GetSprite()
    {
        if (string.IsNullOrEmpty(Action))
        {
            if (LastFacingDirection == "Left") return Next(Sprites.IdleLeft);
            else return Next(Sprites.IdleRight);
        }
        if (Action == "Go")
        {
            if (LastFacingDirection == "Left") return Next(Sprites.RunLeft);
            else return Next(Sprites.RunRight);
        }

        return "";
    }

    private string Next(string[] idleLeft)
    {
        if (LastSpriteIndex == -1) LastSpriteIndex = 0;
        if (LastSpriteIndex == idleLeft.Length) LastSpriteIndex = 0;
        LastSpriteIndex++;
        return idleLeft[LastSpriteIndex-1];
    }

    public void MoveLeft()
    {

        if (X > 0)
        {
            X--;
            if(LastFacingDirection != "Left" || Action != "Go")
                LastSpriteIndex = -1;
        }
        Action = "Go";
        LastFacingDirection = "Left";
    }

    public void MoveRight()
    {
        if (X < 40)
        {
            X++;
            if (LastFacingDirection != "Right" || Action != "Go")
                LastSpriteIndex = -1;
        }
        Action = "Go";
        LastFacingDirection = "Right";
    }

    public void Idle()
    {
        if(Action != "")
            LastSpriteIndex = -1;
        Action = "";
    }
}