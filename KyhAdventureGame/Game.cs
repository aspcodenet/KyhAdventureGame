using System.Text;
using Figgle;
using KyhAdventureGame;
using Spectre.Console;

public class Game
{
    public void Run()
    {
        var text = FiggleFonts.Standard.Render("PIZZA QUEST");
        AnsiConsole.Write(text);
        var image = new CanvasImage("pizza.png");
        image.MaxWidth(40);
        AnsiConsole.Write(image);

        if (!AnsiConsole.Confirm("Ready to start ??"))
        {
            return ;
        }

        Console.CursorVisible = false;
        Console.Clear();
        var character = new Character();
        character.Action = "";
        while (true)
        {
            Console.CursorVisible = false;
            if (Console.KeyAvailable)
            {
                Console.CursorVisible = false;
                var action = Console.ReadKey(true).KeyChar;
                if (action == 'a')
                    character.MoveLeft();
                else if (action == 'd')
                    character.MoveRight();
            }
            else
                character.Idle();
            DrawScene();

            WriteAt(character.GetSprite(), character.X, character.Y);
            System.Threading.Thread.Sleep(100);
        }
    }

    private void DrawScene()
    {
        WriteAt(Sprites.Mountain, 0, 0);
        WriteAt(Sprites.Mountain2, 7, 1);
        WriteAt(Sprites.Mountain3, 14, 0);
        WriteAt(Sprites.Mountains, 21, 1);
        WriteAt(Sprites.Mountain, 28, 0);
        WriteAt(Sprites.Mountain2, 35, 1);
        WriteAt(Sprites.Mountain3, 42, 0);
        WriteAt(Sprites.Mountains, 49, 1);
        WriteAt(Sprites.Mountain, 56, 0);
        WriteAt(Sprites.Mountain2, 63, 1);
        WriteAt(Sprites.Mountain3, 70, 0);
        WriteAt(Sprites.Mountains, 77, 1);


        WriteAt(Sprites.Tree2,10,10);
        WriteAt(Sprites.Tree2, 17, 10);
        WriteAt(Sprites.Store, 40, 7);
        WriteAt(Sprites.Store, 40, 7);



    }

    void WriteAt(string s, int x, int y)
    {
        foreach (var part in s.Split("\n"))
        {
            Console.SetCursorPosition(x, y);
            Console.Write(part);
            y++;
        }
    }
}