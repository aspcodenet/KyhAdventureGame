using Figgle;
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

        while (true)
        {
            //Game running

        }
    }
}